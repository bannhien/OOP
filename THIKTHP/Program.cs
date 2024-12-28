using System;
namespace ThiKTHP
{
    abstract class Customers
    {
        public string TenKH;
        public int SoLuongHang;
        public double DonGia;
        public double ThueVAT = 0.1;
        abstract public double Cost();
        abstract public void Xuat();
    }
    class NormalCutomers: Customers
    {
        public double MaGiam;
        public override double Cost()
        {
            if (MaGiam == 0.0)
            {
                return SoLuongHang*DonGia+ThueVAT;
            }
            else
            {
                return SoLuongHang*DonGia-MaGiam+ThueVAT;
            }
        }
        public override void Xuat()
        {
            Console.WriteLine("Ten KH: "+TenKH);
            Console.WriteLine("So luong hang: "+SoLuongHang);
            Console.WriteLine("Don gia: "+DonGia);
            Console.WriteLine("Ma giam: "+MaGiam);
            Console.WriteLine("Thue VAT: "+ThueVAT);
            Console.WriteLine("Gia tong: "+Cost());
        }
    }
    class LoyalCustomers: Customers
    {
        public int SoNamThanThiet;
        public double KhuyenMai;
        public override double Cost()
        {
            KhuyenMai= Math.Max(SoNamThanThiet*0.05,0.4);
            return (SoLuongHang*DonGia)*(1-KhuyenMai)+ThueVAT;
        }
        public override void Xuat()
        {
            Console.WriteLine("Ten KH: "+TenKH);
            Console.WriteLine("So luong hang: "+SoLuongHang);
            Console.WriteLine("Don gia: "+DonGia);
            Console.WriteLine("So nam than thiet: "+SoNamThanThiet);
            Console.WriteLine("Khuyen mai: "+KhuyenMai);
            Console.WriteLine("Thue VAT: "+ThueVAT);
            Console.WriteLine("Gia tong: "+Cost());
        }
    }
    class SpecialCustomers: Customers
    {
        public double UuDai;
        public override double Cost()
        {
            if (SoLuongHang < 50)
            {
                
                return (SoLuongHang*DonGia)*0.3+ThueVAT;
            }
            else if (SoLuongHang >= 50)
            {
                return (SoLuongHang*DonGia)*0.4+ThueVAT;
            }
            else if (SoLuongHang >= 100)
            {
                return (SoLuongHang*DonGia)*0.5+ThueVAT;
            }
            else
            {
                return (SoLuongHang*DonGia)*0.5+ThueVAT;
            }
        }
        public override void Xuat()
        {
            Console.WriteLine("Ten KH: "+TenKH);
            Console.WriteLine("So luong hang: "+SoLuongHang);
            Console.WriteLine("Don gia: "+DonGia);
            if (SoLuongHang < 50)
            {
                Console.WriteLine("Uu dai: "+(UuDai = 0.3));
            }
            else if (SoLuongHang >= 50)
            {
                Console.WriteLine("Uu dai: "+(UuDai = 0.4));
            }
            else if (SoLuongHang >= 100)
            {
                Console.WriteLine("Uu dai: "+(UuDai = 0.5));
            }
            Console.WriteLine("Thue VAT: "+ThueVAT);
            Console.WriteLine("Gia tong: "+Cost());
        }
    }
    class Sale
    {
        static void Main(string[] args)
        {
            Customers[] customers = new Customers[]
            {
                new NormalCutomers{TenKH = "Nguyen Van A", SoLuongHang = 5, DonGia = 20000, MaGiam = 0.05, ThueVAT = 0.1},
                new NormalCutomers{TenKH = "Tran Van B", SoLuongHang = 6, DonGia = 25000, MaGiam = 0.00, ThueVAT = 0.1},
                new NormalCutomers{TenKH = "Le Van C", SoLuongHang = 7, DonGia = 30000, MaGiam = 0.05, ThueVAT = 0.1},
                new NormalCutomers{TenKH = "Truong Van D", SoLuongHang = 8, DonGia = 35000, MaGiam = 0.00, ThueVAT = 0.1},
                new NormalCutomers{TenKH = "Vu Van E", SoLuongHang = 9, DonGia = 40000, MaGiam = 0.05, ThueVAT = 0.1},
                new LoyalCustomers{TenKH = "Nguyen Thi A", SoLuongHang = 20, DonGia = 25000,SoNamThanThiet = 5, ThueVAT = 0.1},
                new LoyalCustomers{TenKH = "Le Thi B", SoLuongHang = 20, DonGia = 25000,SoNamThanThiet = 4, ThueVAT = 0.1},
                new LoyalCustomers{TenKH = "Tran Thi C", SoLuongHang = 20, DonGia = 30000,SoNamThanThiet = 5, ThueVAT = 0.1},
                new LoyalCustomers{TenKH = "Truong Thi D", SoLuongHang = 20, DonGia = 30000,SoNamThanThiet = 3, ThueVAT = 0.1},
                new LoyalCustomers{TenKH = "Vu Thi E", SoLuongHang = 20, DonGia = 40000,SoNamThanThiet = 2, ThueVAT = 0.1},
                new LoyalCustomers{TenKH = "Do Thi F", SoLuongHang = 20, DonGia = 40000,SoNamThanThiet = 10, ThueVAT = 0.1},
                new LoyalCustomers{TenKH = "Vo Thi G", SoLuongHang = 20, DonGia = 45000,SoNamThanThiet = 8, ThueVAT = 0.1},
                new SpecialCustomers{TenKH = "Nguyen A", SoLuongHang = 25, DonGia = 50000, ThueVAT = 0.1},
                new SpecialCustomers{TenKH = "Tran B", SoLuongHang = 55, DonGia = 30000, ThueVAT = 0.1},
                new SpecialCustomers{TenKH = "Le C", SoLuongHang = 105, DonGia = 40000, ThueVAT = 0.1}
            };
            foreach (Customers customers1 in customers)
            {
                customers1.Cost();
                customers1.Xuat();
                Console.WriteLine();
            }
            
            double doanhthuNormal = 0.0;
            double doanhthuLoyal = 0.0;
            double doanhthuSpecial = 0.0;

            foreach (Customers customers1 in customers)
            {
                if (customers1 is NormalCutomers)
                {
                    doanhthuNormal+=customers1.Cost();
                }
                else if (customers1 is LoyalCustomers)
                {
                    doanhthuLoyal+=customers1.Cost();
                }
                else
                {
                    doanhthuSpecial+=customers1.Cost();
                }
            }
            Console.WriteLine("Doanh thu cua nhom NormalCustomers: "+doanhthuNormal);
            Console.WriteLine("Doanh thu cua nhom LoyalCustomers: "+doanhthuLoyal);
            Console.WriteLine("Doanh thu cua nhom SpecialCustomers: "+doanhthuSpecial);

            double doanhthuMax = 0.0;
            doanhthuMax = doanhthuNormal;
            if (doanhthuLoyal > doanhthuMax)
            {
                doanhthuMax = doanhthuLoyal;
            }
            else if (doanhthuSpecial > doanhthuMax)
            {
                doanhthuMax = doanhthuSpecial;
            }

            Console.WriteLine("Nhom doi tuong co doanh thu cao nhat la LoyalCustomers: "+doanhthuMax);
        }
    }
}