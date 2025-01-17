﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ModelsLibrary.ModelsDto;

namespace OnlineShop.Db.Helper
{
    public static class ProductGenerator
    {
        public static List<Product> BaseProducts { get; set; } = new ();
        public static List<Image> BaseImages { get; set; } = new ();
        public static HashSet<ProductsImages> ProductsImages { get; set; } = new ();
        private static Random random = new Random();
        private static List<string> names = new List<string>
        {
            "Вилка",
            "Детское пюре",
            "Журнал",
            "Конструктор",
            "Крем",
            "Кукла",
            "Мишка",
            "Мячик",
            "Настольная игра",
            "Пирамидка",
            "Пистолетик",
            "Соска",
            "Чашка"
        };
        private static string rusLorem = @"Прежде всего, базовый вектор развития однозначно фиксирует необходимость своевременного 
выполнения сверхзадачи. Задача организации, в особенности же повышение уровня гражданского сознания не оставляет шанса для позиций, 
занимаемых участниками в отношении поставленных задач. Задача организации, в особенности же внедрение современных методик говорит о 
возможностях экспериментов, поражающих по своей масштабности и грандиозности. Внезапно, реплицированные с зарубежных источников,
современные исследования представлены в исключительно положительном свете. Ясность нашей позиции очевидна: постоянное 
информационно-пропагандистское обеспечение нашей деятельности прекрасно подходит для реализации соответствующих условий активизации. 
Принимая во внимание показатели успешности, реализация намеченных плановых заданий в значительной степени обусловливает важность системы 
обучения кадров, соответствующей насущным потребностям.
Прежде всего, внедрение современных методик создаёт необходимость включения в производственный план целого ряда внеочередных мероприятий 
с учётом комплекса модели развития. Принимая во внимание показатели успешности, укрепление и развитие внутренней структуры является 
качественно новой ступенью направлений прогрессивного развития. Однозначно, диаграммы связей набирают популярность среди определенных 
слоев населения, а значит, должны быть объявлены нарушающими общечеловеческие нормы этики и морали. С учётом сложившейся международной 
обстановки, разбавленное изрядной долей эмпатии, рациональное мышление позволяет оценить значение анализа существующих паттернов поведения.
Равным образом, современная методология разработки не даёт нам иного выбора, кроме определения позиций, занимаемых участниками в отношении
поставленных задач.
В рамках спецификации современных стандартов, представители современных социальных резервов неоднозначны и будут смешаны с не уникальными 
данными до степени совершенной неузнаваемости, из-за чего возрастает их статус бесполезности. Учитывая ключевые сценарии поведения, 
глубокий уровень погружения создаёт предпосылки для прогресса профессионального сообщества. Повседневная практика показывает, что 
повышение уровня гражданского сознания не оставляет шанса для экспериментов, поражающих по своей масштабности и грандиозности. 
Как принято считать, диаграммы связей и по сей день остаются уделом либералов, которые жаждут быть рассмотрены исключительно в разрезе 
маркетинговых и финансовых предпосылок. Равным образом, перспективное планирование выявляет срочную потребность дальнейших направлений 
развития. Являясь всего лишь частью общей картины, тщательные исследования конкурентов лишь добавляют фракционных разногласий и 
представлены в исключительно положительном свете.
Предварительные выводы неутешительны: новая модель организационной деятельности в значительной степени обусловливает важность 
благоприятных перспектив. Банальные, но неопровержимые выводы, а также интерактивные прототипы формируют глобальную экономическую 
сеть и при этом — заблокированы в рамках своих собственных рациональных ограничений. Сложно сказать, почему стремящиеся вытеснить 
традиционное производство, нанотехнологии и по сей день остаются уделом либералов, которые жаждут быть объявлены нарушающими 
общечеловеческие нормы этики и морали. Следует отметить, что высококачественный прототип будущего проекта обеспечивает актуальность 
направлений прогрессивного развития.
Современные технологии достигли такого уровня, что новая модель организационной деятельности влечет за собой процесс внедрения и 
модернизации модели развития. Современные технологии достигли такого уровня, что реализация намеченных плановых заданий обеспечивает 
актуальность анализа существующих паттернов поведения.".Replace("\r\n", "");

        /// <summary>
        /// заполнение тестовыми данными изображений по папкам
        /// </summary>
        /// <returns></returns>
        public static Image[] GeneradeRandomImages()
        {
            // проходимся по папкам и созраняем изображения
            foreach (var name in names)
            {
                var imagePath = $"wwwroot/Images/{name}/";
                var files = Directory.GetFiles(imagePath);
                var images = files.Select(x => new Image() { Id = Guid.NewGuid(), Url = x }).ToList();
                BaseImages.AddRange(images);
            }
            return BaseImages.ToArray();
        }
        public static List<Product> GeneradeRandomProducts()
        {
            foreach (var name in names)
            {
                for (int i = 0; i < random.Next(7, 20); i++)
                {
                    var product = new Product()
                    {
                        Id = Guid.NewGuid(),
                        Name = $"{name} №{i + 1}",
                        Cost = random.Next(1, Int32.MaxValue),
                        Description = rusLorem.Substring(0, random.Next(rusLorem.Length / 2, rusLorem.Length))
                    };
                    BaseProducts.Add(product);
                    var imagePath = $"wwwroot/Images/{name}/";
                    var files = Directory.GetFiles(imagePath).ToList();
                    files.ForEach(file =>
                    {
                        var productImage = new ProductsImages()
                        {
                            ProductId = product.Id,
                            ImageId = BaseImages.FirstOrDefault(x => x.Url == file).Id
                        };
                        ProductsImages.Add(productImage);
                    });
                }
            }
            return BaseProducts;
        }

        public static ProductsImages[] GeneradeRandomProductsImages()
        {
            return ProductsImages.ToArray();
        }
    }
}

