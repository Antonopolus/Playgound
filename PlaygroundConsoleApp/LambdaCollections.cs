using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundConsoleApp
{
    delegate bool Filter<T>(T h);
    record Hero(string FirstName, string LastName, string HeroName, bool CanFly);

    class LambdaCollections
    {
        List<Hero> heroes = new List<Hero>  {
        new( "Wae", "Wilson", "Deadpool", true),
        new( "Bruce", "Wayne", "Homelander", true),
        new( "Wae", "Wilson", "Deadpool", false),
        new( "Wae", "Wilson", "Deadpool", false)};


        public LambdaCollections()
        {
            var res = Filter(heroes, h => h.CanFly);

            var heroesWhoCanFly = heroes.Where(hero => hero.CanFly);

            //IEnumerable<T> Filter<T>(IEnumerable<T> items, Filter f)
            IEnumerable<T> Filter<T>(IEnumerable<T> items, Func<T, bool> f)
            {
                foreach (var item in items)
                {
                    if (f(item))
                    {
                        yield return item;
                    }
                }
            }
        }

        //IEnumerable<T> FilterHeros<T>(IEnumerable<T> items)
        //{
        //    items.Where(h => h.)
        //}









    }
}
