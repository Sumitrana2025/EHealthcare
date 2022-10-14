using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(StoreContext context, UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new User
                {
                    UserName = "bob",
                    Email = "bob@test.com"
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, "Member");

                var admin = new User
                {
                    UserName = "admin",
                    Email = "admin@test.com"
                };

                await userManager.CreateAsync(admin, "Pa$$w0rd");
                await userManager.AddToRolesAsync(admin, new[] { "Member", "Admin" });
            }





            if (context.Products.Any()) return;

            var products = new List<Product>
            {
                new Product
                {
                    Name = "CROCIN ADVANCE 650 Tablet 15's",
                    Description =
                        "CROCIN ADVANCE 650 TABLET contains Paracetamol which belongs to the group of medicines called Analgesics and Antipyretics. It is also used to lower fever (high body temperature) and relieve cold or flu symptoms.",
                    Price = 25,
                    PictureUrl = "/images/products/crocin_advance.jpg",
                    Brand = "gsk",
                    Type = "Tablet",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "1 AL M Syrup 60ml",
                    Description = "1-Al M Syrup 60 ml is a combination of anti-allergic drugs, consisting of two medicines: Levocetirizine and Montelukast, primarily used to treat allergic symptoms. Levocetirizine blocks the effects of a chemical messenger known as 'histamine,' which is naturally involved in allergic reactions.",
                    Price = 60,
                    PictureUrl = "/images/products/1_al_m_syrup.jpg",
                    Brand = "FDC Limited",
                    Type = "Syrup",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "A 24 250mg Tablet 6's",
                    Description =
                        "A 24 250MG contain Azithromycin which belongs to a group of medicine called macrolide antibiotics. It is used to treat infections caused by micro-organisms such as bacteria including chest, throat or nasal infection, ear infections, skin and soft tissue infections.",
                    Price = 57,
                    PictureUrl = "/images/products/a_24.jpg",
                    Brand = "Comed Chemicals Limited",
                    Type = "Tablet",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "ACLIZAC 75mg Tablet 10's",
                    Description =
                        "ACLIZAC 75MG contains Clopidogrel which belongs to a group of medicines called antiplatelet which prevents the clumping and reduces the formation of blood clots (thrombosis). Platelets are very small structures in the blood which clump together during blood clotting.",
                    Price = 60,
                    PictureUrl = "/images/products/aclizac_75mg.jpg",
                    Brand = "Ajanta Pharma Ltd",
                    Type = "Tablet",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Anxipan Capsule 10",
                    Description =
                        "Anxipan Capsule is a combination of two medicines used to treat anxiety, acidity, and heartburn. It relaxes the nerves in the brain and also prevents excess acid formation in the stomach, indigestion, and heartburn that may be associated with anxiety.",
                    Price = 102,
                    PictureUrl = "/images/products/anxipan_capsule.jpg",
                    Brand = "Savi Health Science",
                    Type = "Tablet",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "COFFIX Syrup 100ml",
                    Description =
                        "Coffix Syrup is a combination of four medicines: Chlorpheniramine, dextromethorphan, menthol and phenylephrine which relieve dry cough. Chlorpheniramine is an antiallergic which relieves allergy symptoms like runny nose, watery eyes and sneezing.",
                    Price = 52,
                    PictureUrl = "/images/products/coffix_syrup.jpg",
                    Brand = "ASTRA LABS",
                    Type = "Syrup",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Duopil HS 1/850mg Tablet 10'S",
                    Description =
                        "DUOPIL HS is a combination of Glimepiride and Metformin which belongs to a group of medicines called Antidiabetic agents. DUOPIL HS is used to treat type 2 diabetes mellitus when diet, exercise and the single agent does not result in adequate glycemic control.",
                    Price = 51,
                    PictureUrl = "/images/products/duopil_hs.jpg",
                    Brand = "Aristo Pharmaceuticals Pvt Ltd",
                    Type = "Tablet",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "EBERCOS Cream 30gm",
                    Description =
                        "EBERCOS contains Eberconazole which belongs to a group of medicines called Anti-fungal agents. It is used to treat fungal skin infections such as infections of the fingernails and toenails. This medicine stops the growth of fungus in infections.",
                    Price = 332,
                    PictureUrl = "/images/products/ebercos_cream.jpg",
                    Brand = "Percos India Pvt Ltd",
                    Type = "Cream",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Xerina Cream 50gm",
                    Description =
                        "It is used for treating fine lines, acne, blackheads, dullness, oiliness",
                    Price = 368,
                    PictureUrl = "/images/products/xerina_cream.jpg",
                    Brand = "Cymbiotics Pvt Ltd",
                    Type = "Cream",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Onabet Cream 30gm",
                    Description =
                        "ONABET contain sertaconazole which belongs to a group of medicine called imidazole antifungal agent. It is used on the skin to treat athlete’s foot that is between the toes (interdigital tinea pedis) in people 12 years of age and older with normal immune systems. ",
                    Price = 278,
                    PictureUrl = "/images/products/onabet_cream.jpg",
                    Brand = "Glenmark Pharmaceuticals Ltd",
                    Type = "Cream",
                    QuantityInStock = 100
                },

            };

            foreach (var product in products)
            {
                context.Products.Add(product);
            }
            context.SaveChanges();
        }
    }
}