using System;

namespace Observer.Coding.Exercise
{
/*
 Imagine a game where one or more rats can attack a player.
 Each individual rat has an Attack value of 1.
 However, rats attack as a swarm, so each rat's Attack value is equal to the total number of rats in play.
 Given that a rat enters play through the constructor and leaves play (dies) via its Dispose() method,
 please implement the Game and Rat classes so that, at any point in the game,
 the Attack value of a rat is always consistent.
 
 This exercise has two simple rules:
 --The Game class cannot have properties or fields. It can only contain events and methods.
 --The Rat class' Attack field is strictly a field, not a property.
 */

    public class Game
    {
        public event EventHandler RatEnters, RatDies;
        public event EventHandler<Rat> NotifyRat;

        public void FireRatEnters(object sender)
        {
            RatEnters?.Invoke(sender, EventArgs.Empty);
        }

        public void FireRatDies(object sender)
        {
            RatDies?.Invoke(sender, EventArgs.Empty);
        }

        public void FireNotifyRat(object sender, Rat whichRat)
        {
            NotifyRat?.Invoke(sender, whichRat);
        }
    }

    public class Rat : IDisposable
    {
        public int Attack = 1;

        private readonly Game _Game;

        public Rat(Game game)
        {
            _Game = game;

            _Game.RatEnters += GameOnRatEnters;

            _Game.NotifyRat += (sender, rat) =>
            {
                if (rat == this) ++Attack;
            };

            _Game.RatDies += (sender, args) => --Attack;

            _Game.FireRatEnters(this);
        }

        private void GameOnRatEnters(object sender, EventArgs e)
        {
            if (sender != this)
            {
                ++Attack;
                _Game.FireNotifyRat(this, (Rat) sender);
            }
        }


        public void Dispose()
        {
            _Game.FireRatDies(this);
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(typeof(Game).GetFields().Length);
            Console.ReadKey();
        }
    }
}