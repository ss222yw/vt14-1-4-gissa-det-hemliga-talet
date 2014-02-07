using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gissa.Model
{
    // Publik uppräkningsbar typ (enum) som returvärde.
    public enum Outcome { Indefinite, Low, High, Correct, NoMoreGuesses, PreviousGuess };
    // Publik klass SecretNumber.
    public class SecretNumber
    {
        //Fält _number innehåller det hemliga talet.
        private int _number;

        // Fält _previousGuesses lagrar samtliga gissningar gjorda sedan aktuellt hemligt tal slumpades fram.
        private List<int> _previousGuesses;

        //Konstant MaxNumberOfGuesses ger antalet försök en användare har på sig att gissa det hemliga talet
        public const int MaxNumberOfGuesses = 7;

        //Egenskapen CanMakeGuess ger ett värde som indikerar om en gissning kan göras eller inte.
        public bool CanMakeGuess
        {
            get
            {
                return Count < MaxNumberOfGuesses && !_previousGuesses.Contains(_number);
            }
        }

        //Egenskapen Count ger antalet gjorda gissningar sedan det hemliga talet slumpades fram.
        public int Count
        {
            get
            {
                // returnerar hur stor mängd gissningar som gjorts.
                return _previousGuesses.Count();
            }

        }

        // Egenskapen Number ger eller sätter det hemliga talet Så länge som en gissning kan göras ger egenskapen värdet null. Kan inte en gissning göras ger egenskapen det hemliga talets värde.Och tack och lov till databas eftersom finns det med int? som är Nullable 
        public int? Number
        {
            get
            {
                //Så länge man har gissnar att gissa så retunerar null.
                if (CanMakeGuess)
                {
                    return null;
                }
                // Annars retunerar det hemliga talet.
                return _number;
            }
        }

        //Publik egenskap Outcome ger resultatet av den senast utförda gissningen.
        public Outcome Outcome { get; private set; }

        //Ger en refrens till list så det skrivas i ordning .
        public IEnumerable<int> PreviousGuesses
        {
            get
            {
                return _previousGuesses.AsReadOnly();
            }
        }


        // Publik metod Initialize skapar klassens medlemmar.
        public void Initialize()
        {
            // Töma gissnagarna.
            _previousGuesses.Clear();
            Outcome = Outcome.Indefinite;
            //Slumpar hemliga talet mellan 1 och 100.
            Random randomNumber = new Random();
            _number = randomNumber.Next(1, 101);
        }

        // publik  metod MakeGuess returnerar ett värde av typen Outcome som säger om det gissade talet är rätt.
        public Outcome MakeGuess(int guessNumber)
        {

            if (guessNumber < 1 || guessNumber > 100)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (Count > MaxNumberOfGuesses)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (Count == MaxNumberOfGuesses)
            {
                return Outcome = Outcome.NoMoreGuesses;
            }

            if (PreviousGuesses.Contains(guessNumber))
            {
                return Outcome = Outcome.PreviousGuess;
            }
            _previousGuesses.Add(guessNumber);

            if (guessNumber > _number)
            {
                return Outcome = Outcome.High;
            }

            else if (guessNumber < _number)
            {
                return Outcome = Outcome.Low;
            }

            else
            {
                return Outcome = Outcome.Correct;
            }


        }

        // Konstruktor SecretNumber som retunerar metoden Initialize().
        public SecretNumber()
        {

            _previousGuesses = new List<int>(MaxNumberOfGuesses);
            Initialize();
        }


    }
}