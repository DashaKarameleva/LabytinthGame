using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labyrinth.Bullet
{
    public class BulletMagazine
    {
        public Bullet Bullet { get; set; }
        int indexBullet;

       public List<Bullet> Bullets;

        public BulletMagazine()
        {
            Bullets = new List<Bullet>();
            indexBullet = 0;
        }
        public  int CountPatrons { get => Bullets.Count; }
        public void Add(Bullet bullet)
        {
            foreach (var bull in Bullets)
            {
                //if (bull.GetType() == bullet.GetType())
                //{
                    Bullets[Bullets.IndexOf(bull)].Add(bullet.Count);

                    return;
                //}
            }

            if (Bullet == null)
                Bullet = bullet;

            Bullets.Add(bullet);
        }

        public void Del(Bullet bullet)
        {
            Bullets.Remove(bullet);
        }

        public void Switch()
        {
            if (Bullets.Count != 0)
            {
                if (indexBullet != Bullets.Count - 1)
                {
                    indexBullet++;
                    Bullet = Bullets[indexBullet];
                }
                else
                {
                    indexBullet = 0;
                    Bullet = Bullets[indexBullet];
                }
            }
        }

        public void Set(int index)
        {
            Bullet = Bullets[index];
        }
    }
}
