using FluentValidation;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        //FLUENT VALİDATİON KENDİ DÖKÜMANTASYONUNA BAKARAK KURALLARI GÖREBİLİRİZ. BURADA KURALLARI YAZARAK GİRİLEN DEĞERLERİ KONTROL EDEBİLİRİZ
        public ProductValidator()
        {
            RuleFor(p=> p.ProductName).NotEmpty().WithMessage("Ürün İsmi Boş Olamaz");
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.UnitsInStock).NotEmpty();

            RuleFor(p => p.UnitPrice).GreaterThan(0); // BU KURAL P İÇİN P'NİN UNİT PRİCE DA BOŞ OLAMAZDI AYNI ZAMANDA 0'DAN BÜYÜK OLMALI
            RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short)0); // P İÇİN İLK ETAPTA SIFIR OLMASI GEREKMEKTEDİR KODU 
            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryId == 2); // graterthan 10 yani category ıd=2 ise unit price 10dan büyük olmalı

            RuleFor(p => p.ProductName).Must(StartWidhA).WithMessage("Ürün Adı A Harfi İle Başlamalıdır");
        }

        private bool StartWidhA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
