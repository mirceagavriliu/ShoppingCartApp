﻿using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Entities
{
    public static class CarContextExtension
    {
        public static void EnsureSeedDataForContext(this CarContext context)
        {
            context.Cars.RemoveRange(context.Cars);
            context.SaveChanges();
            var cars = new List<Car>()
            {
                //new Item('Honda civic',30000,5,'https://cars.usnews.com/static/images/Auto/izmo/i103961693/2019_honda_civic_hatchback_angularfront.jpg'),
                //new Item('VW Golf',25000,4,'https://c4d709dd302a2586107d-f8305d22c3db1fdd6f8607b49e47a10c.ssl.cf1.rackcdn.com/thumbnails/stock-images/80fb9a32c996c38e50f4f9945a8dd874.png'),
                 //new Item('Mercedes A Class',40000,2,'https://cars.usnews.com/static/images/article/201803/127528/9_-_2019_Mercedes-Benz_A-Class_640x420.jpg'),
                 //new Item('Skoda Fabia',15000,6,'data:image/jpeg;base64,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G2gFMVq1ttheSSTjjvqd5XWm8gUu23s7Ij/esiPkCG22k9UdPmgOIFKLvDOQeMZ2p3uD6q4OQuL2l3uhAcEupdXfhyGw+0O90L38jofaHe6EBwC6vbq7/wDkfD7Q73QvfyPh9of7oQHz/dS6voD8j4faH+6F7+R8Hr3+6EB8/XUuL6C/JCD17+AT8kIPXv4BAfPt1Lq+gvyQg9e/gE/JCD17+AQHz7dS6voL8kIPXv8AdCpPIfD7Q/3QgPn+iUXfjyGw+0P90K27kKi9pd7o+qA4RHIQVs+gdbJYGljXeI6oc05Y509En5neukS8grTla3D9A+qxJeQF/m25vbET8HIDVHa1RYPNmhdI3yXvc913ouAhp34g4rX9J6XfM7E13bAOoLo/5Bz+3R/7Tv7lm2bkJI8q2A9UdPmgOTWQU+al7JKQuq2fkXY3O0E/pUnZuSeBucjj2IDTtVdNSMcACV2DQtvMjBVRtg1Gs8WQJU/ZrExgo0IDJREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREB//9k=')
                new Car()
                {
                    Id= Guid.NewGuid(),
                    Name= "Honda Civic",
                    Price=30000,
                    Stock= 5,
                    ImagePath="https://cars.usnews.com/static/images/Auto/izmo/i103961693/2019_honda_civic_hatchback_angularfront.jpg"

                },
                                new Car()
              {
                    Id= Guid.NewGuid(),
                    Name= "VW Golf",
                    Price=25000,
                    Stock= 4,
                    ImagePath="https://c4d709dd302a2586107d-f8305d22c3db1fdd6f8607b49e47a10c.ssl.cf1.rackcdn.com/thumbnails/stock-images/80fb9a32c996c38e50f4f9945a8dd874.png"

                },
                new Car()
                {
                    Id= Guid.NewGuid(),
                    Name= "Mercedes A Class",
                    Price=40000,
                    Stock= 2,
                    ImagePath="https://cars.usnews.com/static/images/article/201803/127528/9_-_2019_Mercedes-Benz_A-Class_640x420.jpg"

                },
                new Car()
                {
                    Id= Guid.NewGuid(),
                    Name= "Skoda Fabia",
                    Price=15000,
                    Stock= 6,
                    ImagePath="data:image/jpeg;base64,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G2gFMVq1ttheSSTjjvqd5XWm8gUu23s7Ij/esiPkCG22k9UdPmgOIFKLvDOQeMZ2p3uD6q4OQuL2l3uhAcEupdXfhyGw+0O90L38jofaHe6EBwC6vbq7/wDkfD7Q73QvfyPh9of7oQHz/dS6voD8j4faH+6F7+R8Hr3+6EB8/XUuL6C/JCD17+AT8kIPXv4BAfPt1Lq+gvyQg9e/gE/JCD17+AQHz7dS6voL8kIPXv8AdCpPIfD7Q/3QgPn+iUXfjyGw+0P90K27kKi9pd7o+qA4RHIQVs+gdbJYGljXeI6oc05Y509En5neukS8grTla3D9A+qxJeQF/m25vbET8HIDVHa1RYPNmhdI3yXvc913ouAhp34g4rX9J6XfM7E13bAOoLo/5Bz+3R/7Tv7lm2bkJI8q2A9UdPmgOTWQU+al7JKQuq2fkXY3O0E/pUnZuSeBucjj2IDTtVdNSMcACV2DQtvMjBVRtg1Gs8WQJU/ZrExgo0IDJREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREB//9k=",
                },
            };
            context.Cars.AddRange(cars);
            context.SaveChanges();
        }
    }
}