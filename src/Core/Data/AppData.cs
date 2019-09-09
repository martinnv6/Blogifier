using Core.Helpers;
using System;
using System.Linq;

namespace Core.Data
{
    public class AppData
    {
        public static void Seed(AppDbContext context)
        {
            if (context.BlogPosts.Any())
                return;

            context.Authors.Add(new Author
            {
                AppUserName = "admin",
                Email = "admin@us.com",
                DisplayName = "Administrator",
                Avatar = "data/admin/avatar.png",
                Bio = "<p>Algo sobre <b>administrador</b>, quiza algun HTML o algun texto con formato deberia ir aqui.</p><p>Deberia ser customizable y editable desde el perfil del usuario.</p>",
                IsAdmin = true,
                Created = DateTime.UtcNow.AddDays(-120)
            });

            context.Authors.Add(new Author
            {
                AppUserName = "demo",
                Email = "demo@us.com",
                DisplayName = "Demo user",
                Bio = "Descripcion corta sobre este usuario y el blog.",
                Created = DateTime.UtcNow.AddDays(-110)
            });

            context.SaveChanges();

            var adminId = context.Authors.Single(a => a.AppUserName == "admin").Id;
            var demoId = context.Authors.Single(a => a.AppUserName == "demo").Id;

            context.BlogPosts.Add(new BlogPost
            {
                Title = "Bienvenido al Blog!",
                Slug = "welcome-to-blog!",
                Description = SeedData.FeaturedDesc,
                Content = SeedData.PostWhatIs,
                Categories = "welcome,blog",
                AuthorId = adminId,
                Cover = "data/admin/cover-blog.png",
                PostViews = 5,
                Rating = 4.5,
                IsFeatured = true,
                Published = DateTime.UtcNow.AddDays(-100)
            });

            context.BlogPosts.Add(new BlogPost
            {
                Title = "Funcionalidades del blog",
                Slug = "blog-features",
                Description = "Lista de funcionalidades principales soportadas, incluidas administracio de usuarios, de contenido, busquedas simples etc. Esta no es la lista completa aun esta pendiente terminarla.",
                Content = SeedData.PostFeatures,
                Categories = "blog",
                AuthorId = adminId,
                Cover = "data/admin/cover-globe.png",
                PostViews = 15,
                Rating = 4.0,
                Published = DateTime.UtcNow.AddDays(-55)
            });

            context.BlogPosts.Add(new BlogPost
            {
                Title = "Demo post",
                Slug = "demo-post",
                Description = "Este es un sitio demo para probar el blog. Funciona en memoria y no guarda nada, entonces puedes probar lo que tu quieras.",
                Content = SeedData.PostDemo,
                AuthorId = demoId,
                Cover = "data/demo/demo-cover.jpg",
                PostViews = 25,
                Rating = 3.5,
                Published = DateTime.UtcNow.AddDays(-10)
            });

            context.Notifications.Add(new Notification
            {
                Notifier = "Blog Somos de Cadereyta",
                AlertType = AlertType.System,
                AuthorId = 0,
                Content = "Bienvenido al blog Somos de Cadereyta!",
                Active = true,
                DateNotified = SystemClock.Now()
            });

            context.SaveChanges();
        }
    }

    public class SeedData
    {
        public static readonly string FeaturedDesc = @"Este blog es hermoso y liviano escrito en .NET Core. Esta aplicación web multiplataforma, altamente extensible y personalizable ofrece las mejores funciones de blog en un paquete pequeño y portátil.

#### Para acceder:
* User: demo
* Pswd: demo";

        public static readonly string PostWhatIs = @"## Que es Blog Somos de Cadereyta

Este blog es hermoso y liviano escrito en .NET Core. Esta aplicación web multiplataforma, altamente extensible y personalizable ofrece las mejores funciones de blog en un paquete pequeño y portátil.

## Requerimientos del sistema

* Windows, Mac or Linux
* ASP.NET Core 2.1
* Visual Studio 2017, VS Code or other code editor (Atom, Sublime etc)
* SQLite by default, MS SQL Server tested, EF compatible databases should work

## Comenzar (desarrollador)

1. Clone or download source code
2. Run application in Visual Studio or using your code editor
3. Use admin/admin to log in as admininstrator
4. Use demo/demo to log in as user

## Demo site

El [sitio demo](http://blogsomosdecadereyta.azurewebsites.net) es un patio de recreo para ver las características del blog. Puede escribir y publicar posts, cargar archivos y probar la aplicación antes de la instalación. Y no te preocupes, es solo un arenero y se limpiará solo.

![Demo-1.png](/data/admin/admin-editor.png)";

        public static readonly string PostFeatures = @"### Gestión de usuarios
Este blog es una aplicación multiusuario con funciones simples de administrador / usuario, que permite que cada usuario escriba y publique publicaciones y el administrador cree nuevos usuarios.

### Gestión de contenido
El administrador de archivos incorporado permite cargar imágenes y archivos y usarlos como enlaces en el editor de publicaciones.

![file-mgr.png](/data/admin/admin-files.png)

### Plugin System
Este blog construido como una aplicación altamente extensible que permite que los módulos se carguen lateralmente y se agreguen al blog en tiempo de ejecución.

### Editor de markdown
El editor de publicaciones utiliza la sintaxis de markdown, que muchos escritores prefieren a HTML por su simplicidad.

### Búsqueda simple
Hay una búsqueda simple pero rápida y funcional en las listas de publicaciones, así como la búsqueda en la lista de imágenes / archivos en el administrador de archivos.

### Creador
Martin Navarrete :).
";

        public static readonly string PostDemo = @"Este sitio de demostración es un espacio aislado para probar las características de Blogifier. Se ejecuta en la memoria y no guarda ningún dato, por lo que puede probar todo sin ensuciar. ¡Que te diviertas!

#### To login:
* User: demo
* Pswd: demo";

    }
}
