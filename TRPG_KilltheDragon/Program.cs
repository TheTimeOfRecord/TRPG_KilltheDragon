namespace TRPG_KilltheDragon
{
    internal class Program
    {
        


        static void Main(string[] args)
        {
            Goblin goblin = new Goblin();

            Console.WriteLine($"{goblin.Name}의 현재 체력: {goblin.Health}");

            // Goblin이 데미지 받음
            float damage = 2f;
            goblin.TakeDamage(damage);
            Console.WriteLine($"{goblin.Name}이(가) {damage} 데미지를 입었습니다. 남은 체력: {goblin.Health}, 사망 여부: {goblin.IsDead}");

            damage = 3f;
            // Goblin에게 추가적인 데미지
            goblin.TakeDamage(damage);
            Console.WriteLine($"{goblin.Name}이(가) {damage} 데미지를 입었습니다. 남은 체력: {goblin.Health}, 사망 여부: {goblin.IsDead}");
        }



        public interface ICharactor
        {
            string Name { get; set; }
            float Health { get; set; }
            float Attack { get; set; }
            bool IsDead { get; set; }
            float TakeDamage(float damage);
        }

        public class Warrior : ICharactor
        {
            // 인터페이스 멤버 구현
            public string Name { get; set; }
            public float Health { get; set; }
            public float Attack { get; set; }
            public bool IsDead { get; set; }

            //전사 생성자
            public Warrior(string name, float health, float attack)
            {
                Name = name;
                Health = health;
                Attack = attack;
                IsDead = false;  // 처음에는 죽지 않은 상태
            }

            public float TakeDamage(float damage)
            {
                Health -= damage;

                if (Health <= 0)
                {
                    IsDead = true;
                    Health = 0;  // 체력은 음수가 될 수 없으므로 0으로 설정
                }

                return Health;
            }
        }


        public class Monster : ICharactor
        {
            // 인터페이스 멤버 구현
            public string Name { get; set; }
            public float Health { get; set; }
            public float Attack { get; set; }
            public bool IsDead { get; set; }

            //전사 생성자
            public Monster(string name, float health, float attack)
            {
                Name = name;
                Health = health;
                Attack = attack;
                IsDead = false;  // 처음에는 죽지 않은 상태
            }

            public float TakeDamage(float damage)
            {
                Health -= damage;

                if (Health <= 0)
                {
                    IsDead = true;
                    Health = 0;  // 체력은 음수가 될 수 없으므로 0으로 설정
                }

                return Health;
            }
        }

        public class Goblin : Monster
        {
            private static Random random = new Random();

            //고블린 초기화 이름, 체력, 공격력
            public Goblin() : base("Goblin", GetRendomHealth(), GetRendomAttack())
            {
                Health = (float)Math.Round(Health, 2);
                Attack = (float)Math.Round(Attack, 2);
            }
            //고블린의 체력을 4~6으로 초기화
            private static float GetRendomHealth()
            {
                return (float)(random.NextDouble() * (6.0 - 4.0) + 4.0);
            }

            //고블린의 공격력을 0.8~1.2로 초기화
            private static float GetRendomAttack()
            {
                return (float)(random.NextDouble() * (1.2 - 0.8) + 0.8);
            }
        }

        public class Dragon : Monster
        {
            public Dragon(string name, float health, float attack) : base(name, health, attack)
            {
            }
        }
    }
}