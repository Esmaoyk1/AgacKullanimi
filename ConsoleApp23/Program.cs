using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ağaç
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ebeveyn  nesnes oluşturuyoruz. yani kök düğüm
            EbeveyinNode ebeveyinNode1 = new EbeveyinNode("Esmanur", "Oyanık", "123456");

            //kök düğüme çocuklarını oluşturuyoruz sol için
            EbeveyinNode ebeveyinNode2 = new EbeveyinNode("Ahmet", "Bilgin", "123456");

            //kök düğüme çocuklarını oluşturuyoruz sağ için
            EbeveyinNode ebeveyinNode3 = new EbeveyinNode("Gamze", "Coşkun", "123456");

            EbeveyinNode ebeveyinNode4 = new EbeveyinNode("Acun", "Ayan", "123456");
            EbeveyinNode ebeveyinNode5 = new EbeveyinNode("Aylin", "Ay", "123456");
            EbeveyinNode ebeveyinNode6 = new EbeveyinNode("Funda", "Ay", "123456");
            EbeveyinNode ebeveyinNode7 = new EbeveyinNode("Leyla", "Ay", "123456");


            // oluşturuyoruz yaprak nodeları
            YaprakNode yaprakNode1 = new YaprakNode("Abdullah", "Gezer", "123456");
            YaprakNode yaprakNode2 = new YaprakNode("Akın", "Seven", "123456");
            YaprakNode yaprakNode3 = new YaprakNode("Aslı", "Sayar", "123456");
            YaprakNode yaprakNode4 = new YaprakNode("Azra", "Saygın", "123456");
            YaprakNode yaprakNode5 = new YaprakNode("Faruk", "Çimen", "123456");
            YaprakNode yaprakNode6 = new YaprakNode("Furkan", "Seçkin", "123456");
            YaprakNode yaprakNode7 = new YaprakNode("Kerim", "Güven", "123456");
            YaprakNode yaprakNode8 = new YaprakNode("Mehmet", "Çiçek", "123456");

            //birbirine bağlıyoruz düğümleri
            ebeveyinNode1.AddNode(ebeveyinNode2);
            ebeveyinNode1.AddNode(ebeveyinNode3);

            ebeveyinNode2.AddNode(ebeveyinNode4);
            ebeveyinNode2.AddNode(ebeveyinNode5);

            ebeveyinNode3.AddNode(ebeveyinNode6);
            ebeveyinNode3.AddNode(ebeveyinNode7);

            ebeveyinNode4.AddNode(yaprakNode1);
            ebeveyinNode4.AddNode(yaprakNode2);

            ebeveyinNode5.AddNode(yaprakNode3);
            ebeveyinNode5.AddNode(yaprakNode4);

            ebeveyinNode6.AddNode(yaprakNode5);
            ebeveyinNode6.AddNode(yaprakNode6);

            ebeveyinNode7.AddNode(yaprakNode7);
            ebeveyinNode7.AddNode(yaprakNode8);
            ebeveyinNode1.ExecuteOrder();




            Console.ReadLine();
        }
    }
    abstract class Düğüm
    {
        public string isim;
        public string soyisim;
        public string TCno;
        public Düğüm(string isim, string soyisim, string TCno)
        {
            this.isim = isim;
            this.soyisim = soyisim;
            this.TCno = TCno;
        }
        public abstract void AddNode(Düğüm düğüm);
        public abstract void ExecuteOrder();
    }
    class EbeveyinNode : Düğüm
    {
        public Düğüm sağ;
        public Düğüm sol;

        List<Düğüm> düğüms = new List<Düğüm>();
        public EbeveyinNode(string isim, string soyisim, string TCno) : base(isim, soyisim, TCno)
        {
            sol = null;
            sağ = null;
        }
        public override void AddNode(Düğüm düğüm)
        {
            if (string.Compare(this.isim, düğüm.isim) == 0)
            {
                if (string.Compare(this.soyisim, düğüm.soyisim) == -1)
                {
                    this.sol = düğüm;
                    düğüms.Add(düğüm);
                }
                else
                {
                    this.sağ = düğüm;
                    düğüms.Add(düğüm);
                }
            }
            else if (string.Compare(this.isim, düğüm.isim) == -1)
            {
                this.sağ = düğüm;
                düğüms.Add(düğüm);
            }
            else if (string.Compare(this.isim, düğüm.isim) == 1)
            {
                this.sol = düğüm;
                düğüms.Add(düğüm);
            }
        }
        public override void ExecuteOrder()
        {
            Console.WriteLine($"{isim} - {soyisim}");
            foreach (Düğüm düğüm1 in düğüms)
                düğüm1.ExecuteOrder();
        }

    }
    class YaprakNode : Düğüm
    {
        public YaprakNode(string isim, string soyisim, string TCno) : base(isim, soyisim, TCno)
        {
        }

        //Bu fonksiyonun yaprak düğüm için bir anlamı yoktur!
        public override void AddNode(Düğüm düğüm)
            => throw new NotImplementedException();
        public override void ExecuteOrder()
            => Console.WriteLine($"{isim} - {soyisim}");
    }

}