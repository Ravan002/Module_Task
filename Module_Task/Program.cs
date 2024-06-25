using ModuleTask.Concrete;

User admin = new User();
admin.FullName = "Ravan Mammadov";
admin.Password = "12345";
admin.Role = "Admin";

UserManager userManager = new(admin);


User satici = new User();
satici.FullName = "Mahmud Mahmudov";
satici.Password = "123satici";
satici.Role = "Satici";

User kassir = new User();
kassir.FullName = "Kerim Kerimov";
kassir.Password = "123skassir";
kassir.Role = "Head Cassier";


User satici2 = new User();
satici2.FullName = "Satici 2";
satici2.Password = "12345";
satici2.Role = "Satici";

Console.WriteLine("checking user manager methods\n");

// Yeni user add olunmaga calisilir ve bu zaman access yoxlanilir
// Sadece Admin rolu olan userlar user manager icindeki butun methodlari islede bilir
// Amma diger Role-lar userdaki hec bir method-u istifade eleye bilmir
userManager.Add(admin, satici);
userManager.Add(satici ,kassir);
userManager.Add(admin ,kassir);
userManager.Add(kassir ,satici2);
userManager.Add(admin, satici2);



Console.WriteLine("\n");
// Userlarin oldugu listi almaga calisiriq.
// Burada satici ve kassir fail olacaq cunki dediyim kimi usermanagerdaki hec bir methoda accessleri yoxdur 
userManager.GetAll(admin);
userManager.GetAll(satici);
userManager.GetAll(kassir);

// get user by id
User? u = userManager.GetById(admin, 4);

Console.WriteLine("\n");
// update user
userManager.Update(satici, u);
userManager.Update(kassir, u);
userManager.Update(admin, u);

userManager.GetAll(admin);


Console.WriteLine("\n");
// delete user where id==4
userManager.Delete(satici, 4);
userManager.Delete(kassir, 4);
userManager.Delete(admin, 4);





ProductManager productManager = new ProductManager();

// CategoryManager yaranan zaman auto olaraq icine bezi categoryler elave olunur
CategoryManager categoryManager = new CategoryManager();



Product product1 = new Product();
product1.ProductName = "Esya 1";
product1.CategoryId = 1;
product1.Price = 123.45;

Product product2 = new Product();
product2.ProductName = "Esya 2";
product2.CategoryId = 1;
product2.Price = 303.45;

Product product3 = new Product();
product3.ProductName = "Esya 3";
product3.CategoryId = 2;
product3.Price = 563.65;


// Product manager icinde her bir method ucun ozune mexsus HaveAccess list-i var.
// Eger Saticinin-da product add etmesine icaze vermek istesek gerek hemin listin icine "Satici" rolunu elave edek
Console.WriteLine("\n");
productManager.Add(admin, product1);
productManager.Add(kassir, product2);
productManager.Add(satici, product3);
productManager.Add(admin, product3);

// Diger methodlari-da usermanagerde gosterdiyim kimi cagira bilersiz.
// IBaseService temel crud operatorlarini daisiyir.
// IProductService, IUserService, ve ICategoryService ise hemin entity-ler ucun lazim olan spesifik methodlari saxlayir
// Meselen IProductService - de GetByCategoryId methodu hansiki yanlizca Product ile bagli bir methoddur
// Daha sonra Her bir entity class-da id object yaranan zaman auto olaraq artir
// CheckAccessHelper bir static class-dir ve icinde CheckPermission adli static bir method var.
// Access olub olmadigini yoxlamaga komek edir. Helper class oldugundan ayrica bir static class yaradib orada istifade etmeyi uygun gordum.

// Satmaq ve qaytarmaq ucun methodlari sadece list yaradib remove ve add eleyerek duzelde bilerik (Vaxt qalmadigindan yaza bilmedim).