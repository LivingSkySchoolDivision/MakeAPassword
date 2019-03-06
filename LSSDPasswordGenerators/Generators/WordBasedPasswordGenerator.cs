﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSSDPasswordGenerators.Generators
{
    public class WordBasedPasswordGenerator
    {
        private Random _random = new Random(Guid.NewGuid().GetHashCode());
        private readonly List<string> _separators = new List<string>() { "-", "" };
        private readonly List<string> _wordList = new List<string>()
        {
            "abacus","abrupt","absolute","abundant","accurate","acorn","admiral","advanced","adventure","afternoon","agile","airplane","alien","aliens","allied","alpha","amazing","ancient","andorian","android","angry","animated","ankle","answer","anthem","ape","apple","april","area","armchair","asterisk","atom","atomic","august","autumn","backstory","bacon","badger","banana","bandit","bank","bard","bargain","baseball","basic","basket","beak","beam","beans","bear","beta","better","big","bird","bitter","blank","blasting","blimp","blob","blooming","blooper","blue","blueberry","blurt","bonanza","book","bookcase","boot","boots","branch","bread","breakfast","breeze","bridge","bright","broken","brush","buffalo","bunny","burnt","bus","button","cactus","cake","calm","campfire","canadian","candy","captain","car","carpet","carrot","cartoon","castle","cat","catfish","caution","ceramic","ceremony","chair","changed","character","checkout","cherry","chess","chicken","chocolate","circle","circus","citrus","clarinet","clause","cloaked","cloud","clumsy","coach","code","coffee","cold","coldness","colony","comet","command","common","compartment","compass","complete","computer","cookie","copper","corn","costume","cotten","country","cow","crab","crate","creative","crispy","cromulent","crowd","crust","cube","cupcake","curious","curly","custard","cute","cyber","dad","dashing","data","december","deck","delegate","delta","description","diamond","diet","digital","dinner","dinosaur","discovery","dishwasher","display","doctor","dog","door","dotted","double","dragon","dragonfly","dream","dreaming","droplet","drum","dry","dubious","duck","ducky","during","dynamic","eagle","ear","easy","effects","eight","either","elbow","elephant","eleven","elf","elk","emerald","employee","empty","engine","epsilon","exam","example","exclaim","exotic","expensive","face","falcon","famous","fancy","fantasy","february","fifty","file","firefly","first","fishbowl","five","floor","floppy","flower","flowing","fluffy","foam","food","force","forest","forgotten","fortune","fossil","four","fourteen","fourth","fox","free","friday","friend","friendship","frog","fruit","funny","future","fuzzy","galactic","galaxy","game","gamma","ghost","giant","giggly","glacier","glad","glitchy","glowing","gluten-free","gnome","goblin","gold","golden","goodbye","goose","grain","granting","grape","grapefruit","great","green","groovy","grumpy","half","hamster","harmless","hat","hawk","heavy","hello","high-speed","holiday","home","honey","horizon","horn","horse","hostile","huge","humble","hundred","ice","ideal","imperial","important","infamous","inflatable","interplanetary","jam","january","jinkies","july","jumping","june","jungle","key","keyboard","king","kitchen","kitten","knight","known","kraken","lake","laptop","large","leaf","learning","lego","lemon","lettuce","lion","listening","lizard","local","locked","locket","logic","logical","loop","lovely","lucky","lunar","lunch","machine","magnetic","magnificent","majority","mango","march","marker","marshmallow","mascot","mask","master","may","maze","meal","memory","metal","metric","million","mini","mint","mirror","missing","mobile","modern","mom","monday","monkey","moon","mop","mountain","muffin","multi","murky","music","napkin","narrow","nature","near","nearby","neat","neither","neon","newspaper","nice","nine","nintendo","noisy","noodles","notebook","november","oatmeal","obscure","ocean","october","octopus","odd","old","oldest","omega","one","onion","orange","orb","organic","outpost","oval","owl","padded","palace","panther","pants","paper","passage","pattern","peanut-butter","pegasus","pencil","penguin","phrase","piano","picture","pie","pioneer","pizza","plain","plant","platform","playful","plenty","plotting","plus","poised","polite","pond","pony","popcorn","pressed","previous","prickly","prime","prince","princess","private","pumpkin","puppy","purple","puzzle","rabbit","radio","radioactive","railroad","rain","rainbow","raining","rank","raspberry","rather","raven","ravioli","ray","realistic","record","rectangle","red","renewing","repaired","reward","ribbon","rich","rider","river","road","robot","romulan","roof","room","round","royal","running","safe","sail","salad","salamander","salsa","sandwich","saturday","saved","saving","scale","scattering","science","second","secret","secure","security","september","service","seven","seventy","several","shadow","shark","sheep","shield","shoe","shoes","short","sigil","signature","silver","sink","six","sixty","skinny","sky","sleeping","small","smart","smile","snare","snow","snowy","solar","sometimes","somewhat","song","soup","space","spaceship","spaghetti","sparse","speed","spider","spill","split","sprint","spy","square","squid","stairs","stalemate","starfish","stellar","storm","strange","strangest","strawberry","strong","summer","sunday","super","supernova","surface","surprise","surrounding","sweet","swift","swimming","tablecloth","tablet","tabletop","tallest","tapping","tea","technology","telephone","television","ten","terran","test","tested","thankful","thanks","the","theory","theta","thing","third","thirteen","thirty","this","thousand","three","thundering","thursday","tiger","time","tiny","today","tomorrow","total","towel","tractor","train","tranquil","trapped","travel","treasure","triangle","tribal","trill","triple","trivia","trivial","truck","trumpet","trusted","tuba","tuesday","tunnel","turnip","twelve","twenty","two","ultra","underscore","uniform","unknown","unlocked","unlucky","unpopular","upright","urgent","usual","val","van","vapor","vast","version","video","villain","vine","viola","violet","violin","voice","volcano","volume","vowel","wacky","wagon","walking","wand","want","warp","wary","water","waterfall","weather","website","wednesday","whim","whispering","wiggles","wiggly","wild","windy","winter","wireless","wise","witch","wizard","wolf","wooden","worst","written","wrong","zerg","zeta","zinc","zombie"
        };

        public WordBasedPasswordGenerator()
        {
            // Scramble up the random number generator a little more just for kicks
            for (int x = 0; x < DateTime.Now.Second; x++)
            {
                _random.Next(0, 1);
            }
        }

        public string GeneratePassword(int Length, PasswordComplexity complexity)
        {
            switch (complexity)
            {
                case PasswordComplexity.Medium:
                    return generateMediumComplexityPassword(Length);
                case PasswordComplexity.High:
                    return generateHighComplexityPassword(Length);
                default:
                    return generateHighComplexityPassword(Length);
            }
        }

        // Low complexity = No separators
        // High copmlexity = Special character separators
        // Random numbers injected

        private string getRandomWord()
        {
            return _wordList[_random.Next(0, _wordList.Count)];
        }

        private string getRandomSpacer()
        {
            return _separators[_random.Next(0, _separators.Count)];
        }

        private string capitalize(string word)
        {
            if (word.Length < 1)
            {
                return word;
            }

            return word[0].ToString().ToUpper() + word.Substring(1, word.Length - 1);
        }

        private string generateMediumComplexityPassword(int length)
        {
            // Basically throw random words together until the length requirement is met
            List<string> words = new List<string>();

            // Add a starting word            
            words.Add(getRandomWord());
            int characterCount = words[0].Length;

            // Add more words
            do
            {
                string word = this.getRandomWord();
                characterCount += word.Length;
                words.Add(word);
            }
            while (characterCount < length);

            // Once we have enough words, assemble the password
            StringBuilder assembledPassword = new StringBuilder();
            foreach (string word in words)
            {
                assembledPassword.Append(capitalize(word));
            }

            return assembledPassword.ToString();
        }

        private string generateHighComplexityPassword(int length)
        {
            // Basically throw random words together until the length requirement is met
            List<string> words = new List<string>();

            // Add a starting word            
            words.Add(getRandomWord());
            int characterCount = words[0].Length;

            string spacerCharacter = getRandomSpacer();

            // Add more words
            do
            {
                // Add a special character as a spacer between words
                words.Add(spacerCharacter);
                characterCount += spacerCharacter.Length;

                // Add the word
                string word = this.getRandomWord();
                characterCount += word.Length;
                words.Add(word);
            }
            while (characterCount < length);

            // Once we have enough words, assemble the password
            StringBuilder assembledPassword = new StringBuilder();
            foreach (string word in words)
            {
                assembledPassword.Append(capitalize(word));
            }

            return assembledPassword.ToString();
        }

       
    }
}
