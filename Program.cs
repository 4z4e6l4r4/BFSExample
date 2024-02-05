namespace BFSExample
{
    class Graf
    {
        private int dugumSayisi;
        private List<int>[] komsulukListesi;

        public Graf(int dugumSayisi)
        {
            this.dugumSayisi = dugumSayisi;
            komsulukListesi = new List<int>[dugumSayisi];
            for (int i = 0; i < dugumSayisi; i++)
            {
                komsulukListesi[i] = new List<int>();
            }
        }

        public void KomsuEkle(int dugum, int komsu)
        {
            komsulukListesi[dugum].Add(komsu);
        }

        public void BFS(int baslangicDugumu)
        {
            bool[] ziyaretEdildi = new bool[dugumSayisi];
            Queue<int> kuyruk = new Queue<int>();

            ziyaretEdildi[baslangicDugumu] = true;
            kuyruk.Enqueue(baslangicDugumu);
            int say = 0;
            while (kuyruk.Count != 0)
            {
                say++;
                int dugum = kuyruk.Dequeue();
                Console.Write(dugum + " ");

                foreach (int komsu in komsulukListesi[dugum])
                {
                    if (!ziyaretEdildi[komsu])
                    {
                        ziyaretEdildi[komsu] = true;
                        kuyruk.Enqueue(komsu);
                    }
                }
            }
        }
    }

    internal class Program
    {
        static void Main()
        {
            Graf graf = new Graf(6);
            graf.KomsuEkle(0, 1);
            graf.KomsuEkle(0, 2);
            graf.KomsuEkle(1, 3);
            graf.KomsuEkle(2, 4);
            graf.KomsuEkle(1, 4);
            graf.KomsuEkle(3, 5);
            graf.KomsuEkle(3, 4);
            graf.KomsuEkle(0, 5);

            Console.WriteLine("Genişlik Öncelikli Arama(BFS) Sonucu: ");


            graf.BFS(0);
        }
    }
}