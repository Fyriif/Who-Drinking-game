using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    void Awake()
    {
        //Screen.orientation = ScreenOrientation.Portrait;
        GameCanvas.alpha = 0f;
        GameCanvas.interactable = false;
        GameCanvas.blocksRaycasts = false;

        TitleCanvas.alpha = 1f;
        TitleCanvas.interactable = true;
        TitleCanvas.blocksRaycasts = true;
    }

    //player names
    List<string> playerNames = new List<string>();
 

    //categories selected
    bool normalCat = true;
    bool embarrassCat;
    bool sexCat;

    //colours
    Color darkBlue = new Color32(197, 38, 37, 255);
    Color lightBlue = new Color32(1, 184, 203, 255);
    Color customRed = new Color32(1, 184, 203, 255);
    Color customYellow = new Color32(250, 198, 1, 255);
    Color customPurple = new Color32(98, 37, 118, 255);
    Color customOrange = new Color32(240, 114, 60, 255);
    Color customGreen = new Color32(0, 152, 66, 255);
    Color customPink = new Color32(219, 129, 141, 255);
    Color customBlack = new Color32(0, 0, 0, 255);
    Color customWhite = new Color32(239, 247, 255, 255);

    //stores categories selected
    List<int> chosenCats = new List<int>();

    [SerializeField]
    private Text questionText;

    [SerializeField]
    private Text normalButton;

    [SerializeField]
    private Text embarrassButton;

    [SerializeField]
    private Text sexButton;

    [SerializeField]
    private InputField playerNamesField;

    [SerializeField]
    private Text playersAdded;

    [SerializeField]
    private Text currentPlayer;

    [SerializeField]
    private Text currentCategory;

    [SerializeField]
    private CanvasGroup TitleCanvas;

    [SerializeField]
    private CanvasGroup GameCanvas;

    [SerializeField]
    private Text gameText;

    public void TitleToGame()
    {
        SelectCategories();
        if(normalCat == true || embarrassCat == true || sexCat == true)
        {
            TitleCanvas.alpha = 0f;
            TitleCanvas.interactable = false;
            TitleCanvas.blocksRaycasts = false;

            Screen.orientation = ScreenOrientation.LandscapeLeft;

            GameCanvas.alpha = 1f;
            GameCanvas.interactable = true;
            GameCanvas.blocksRaycasts = true;

            SelectQuestion();
            SelectPlayer();
            RandomCardColour();
        }
        
    }

    public void GameToTitle()
    {
        GameCanvas.alpha = 0f;
        GameCanvas.interactable = false;
        GameCanvas.blocksRaycasts = false;

        TitleCanvas.alpha = 1f;
        TitleCanvas.interactable = true;
        TitleCanvas.blocksRaycasts = true;
    }

    public void AddPlayer()
    {
        playersAdded.text += playerNamesField.text + ", ";
        playerNames.Add(playerNamesField.text);
        playerNamesField.text = "";
    }

    public void SelectNormal()
    {
        if(normalCat == false)
        {
            normalCat = true;
            //normalButton.text = "Normal" + "\n" + "(Selected)";
            normalButton.color = customYellow;
        }
        else
        {
            normalCat = false;
            //normalButton.text = "Normal";
            normalButton.color = customBlack;
        }
        
    }

    public void SelectEmbarass()
    {
        if (embarrassCat == false)
        {
            embarrassCat = true;
            //embarrassButton.text = "Embarrassing" + "\n" + "(Selected)";
            embarrassButton.color = darkBlue;
        }
        else
        {
            embarrassCat = false;
            //embarrassButton.text = "Embarrassing";
            embarrassButton.color = customBlack;
        }
    }

    public void SelectSex()
    {
        if (sexCat == false)
        {
            sexCat = true;
            //sexButton.text = "Sexual" + "\n" + "(Selected)";
            sexButton.color = customRed;
        }
        else
        {
            sexCat = false;
            //sexButton.text = "Sexual";
            sexButton.color = customBlack;
        }
    }

    //adds the chosen categories to list to chose random category
    public void SelectCategories()
    {
        if (normalCat)
        {
            chosenCats.Add(0);
        }
        if (embarrassCat)
        {
            chosenCats.Add(1);
        }
        if (sexCat)
        {
            chosenCats.Add(2);
        }
    }

    public void SelectPlayer()
    {
        currentPlayer.text = playerNames[Random.Range(0, playerNames.Count)];
    }

    public void SelectQuestion()
    {
        SelectPlayer();
        RandomCardColour();

        //picks random category from chosen categories
        int catIndex = chosenCats[Random.Range(0, chosenCats.Count)];
        

        if (catIndex == 0)
        {
            //sets the text property of the assigned game object to random question from normal questions
            questionText.text = normalQuestions[Random.Range(0, normalQuestions.Length)];
            currentCategory.text = "Normal";
            currentCategory.color = customYellow;
        }
        else if (catIndex == 1)
        {
            //sets the text property of the assigned game object to random question from embarrassing questions
            questionText.text = embarrassingQuestions[Random.Range(0, embarrassingQuestions.Length)];
            currentCategory.text = "Embarrassing";
            currentCategory.color = darkBlue;
        }
        else if (catIndex == 2)
        {
            //sets the text property of the assigned game object to random question from sexual questions
            questionText.text = sexualQuestions[Random.Range(0, sexualQuestions.Length)];
            currentCategory.text = "Sexual";
            currentCategory.color = customRed;
        }
    }

    public void RandomCardColour()
    {
        int colourIndex = Random.Range(0, 9);

        if(colourIndex == 0)
        {
            gameText.color = darkBlue;
        }
        if (colourIndex == 1)
        {
            gameText.color = lightBlue;
        }
        if (colourIndex == 2)
        {
            gameText.color = customRed;
        }
        if (colourIndex == 3)
        {
            gameText.color = customYellow;
        }
        if (colourIndex == 4)
        {
            gameText.color = customPurple;
        }
        if (colourIndex == 5)
        {
            gameText.color = customOrange;
        }
        if (colourIndex == 6)
        {
            
            gameText.color = customGreen;
        }
        if (colourIndex == 7)
        {
            gameText.color = customPink;
        }
        if (colourIndex == 8 || colourIndex == 9)
        {
            gameText.color = customWhite;
        }
    }

    //question arrays

    //normal questions (0)
    string[] normalQuestions = {
        "Who is most likely to pick dare over truth?",
        "Who has the most intresting Google search history?",
        "Who is most likely to go to hell?",
        "Who is most likely to sleep through the alarm?",
        "Who is most likely to loose their wallet on a night out?",
        "Who is most likely to adopt a pet?",
        "Who is most likely to appear on Jeremy Kyle Show?",
        "Who is most attractive person in the room?",
        "Who is worst driver?",
        "Who is best driver?",
        "Who is most likely to get a parking ticket?",
        "Who has the worst taste in memes?",
        "Who has the best taste in music?",
        "Who is most likely to cry over little things?",
        "Who is the funniest person in the room?",
        "Who is most likely to slip and fall?",
        "Who is most likely to win the lottery?",
        "Who is most likely to become a millionare",
        "Who has the best fashion sense?",
        "Who has the worst fashion sense?",
        "Who is most likely to fail an exam?",
        "Who is the best singer in the room?",
        "Who is the worst singer in the room?",
        "Who knows the most Disney songs?",
        "Who is most likely to break their phone?",
        "Who is most likely to forget their password?",
        "Who is most likely to get catfished?",
        "Who has the most matches on Tinder?",
        "Who has the least amount of matches on Tinder?",
        "Who is most likely to sing in the shower?",
        "Who is most likely to pull on a night out?",
        "Who is most likely to become a vegeterian?",
        "Who is most likely to become vegan?",
        "Who has the smoothest skin?",
        "Who is most likely to binge Netflix instead of doing work?",
        "Who arrives late to gatherings the most?",
        "Who spends the most money on a night out?",
        "Who gets tempted by takeout the most?",
        "Who is the best cook?",
        "Who is most likely to eat ready meals?",
        "Who is the most lightweight drinker?",
        "Who is the most heavyweight drinker?",
        "Who is most likely to ask for directions if lost?",
        "Who is smarter than people think?",
        "Who is most likely to throw a birthday part for their pet?",
        "Who would be the creepiest clown?",
        "Who would be the most upset if all their possessions were lost in a fire?",
        "Who is most likely to be awake at 4am?",
        "Who is most likely to go to heaven?",
        "Who would find a way to break out of prison successfully?",
        "Who is most likely to survive a zombie apocalypse?",
        "Who would look the best as opposite gender?",
        "Who is most likely to drop some one during trust fall on purpose?",
        "Who would vote for Kanye West as president?",
        "Who is most likely to get drunk first on a night out?",
        "Who is most likely to get blocked by JK Rowling on Twitter?",
        "Who is most likely to end up on a calendar?",
        "Who is most likely to fall asleep in cinema?",
        "Who is most likely to fall asleep in class?",
        "Who is most likely to win Dragons Den?",
        "Who is most likely to get a tattoo?",
        "Who is most likely to get a piercing?",
        "Who is most likely to thank their hair dresser after bad haircut?",
        "Who is most likely to not thank the bus driver?",
        "Who is most likely to have a crush on their teacher?",
        "Who is most likely to have a crush on their friend?",
        "Who is most likely to dye their hair?",
        "Who has the weirdest phobia?",
        "Who is most likely to date a celebrity?",
        "Who's most recent phone picture would you like to see the most?",
        "Who is most likely to recieve the most hugs this Christmas?",
        "Who is most likely to tag others in a crappy meme?",
        "Who is most likely to drown their sorrows in ice cream?",
        "Who can you hear before you actually see them?",
        "Who is most likely to brag about their high school popularity?",
        "Who is most likely to steal a joke?",
        "Who has the highest grades in their GCSE/SAT exams?",
        "Who is most terrified of holding an infant?",
        "Who can hold their breath for longest?",
        "Who is most likely to join the millitary?",
        "Who is the biggest Whovian?",
        "Who is the biggest nerd?",
        "Who is most likely to become a model?",
        "Who is most likely to listen to music while driving?",
        "Who is the best actor?",
        "Who is most likely to get chased by a dog?",
        "Who is most likely to laugh at an inappropriate time/moment?",
        "Who is most likely to blow all their money on impulse buy?",
        "Who is most likely to buy and wear the wrong sized shoes?",
        "Who is most likely to always say exatcly what they think of someone else?",
        "Who is most likely to know all the words to every song on the radio?",
        "Who is most likely to do the most shots tonight?",
        "Who is most likely to cheer for a team based on the colour of their unifroms?",
        "Who is most likely to write a best selling book?",
        "Who is most likely to purposely loose at a drinking game to get more drunk?",
        "Who can do the splits?",
        "Who gets grossed out most easily?",
        "Who is most likely to bake everyone cookies?",
        "Who is most likely to skip gym day?",
        "Who is the clumsiest?",
        "Who is most likely to judge someone for their music taste?",
        "Who is most likely to forget persons name after introductions?",
        "Who is most likely to kiss a snake?",
        "Who is most likely to date someone with children?",
        "Who is most likely to take the most pictures when drunk?",
        "Who is most likely to punch another player if they could get away with it?",
        "Who is the slowest eater in the room?",
        "Who is most likely to not know today's date?",
        "Who sends the most texts per day?",
        "Who is most likely to get drunk with their parents?",
        "Who is most likely to know about latest technology?",
        "Who is most likely to blush?",
        "Who is most likely to win Spelling Bee competition?",
        "Who is most likely to throw a party?",
        "Who is most likely to become a wine snob?",
        "Who is able to do tongue twisters while drunk?",
        "Who has the worst accent?",
        "Who has the best accent?",
    };

    //embarrassing questions (1)
    string[] embarrassingQuestions = {
        "Who is most likely to be a brony/pegasis?",
        "Who is the biggest weeb?",
        "Who is most likelyt to fart loudly in public?",
        "Who is most likely to get slapped?",
        "Who has the worst masturbation habit?",
        "Who is most likely to cheat on their partner?",
        "Who is most likely to read Sonic fanfiction?",
        "Who is most likely to be a furry?",
        "Who is most likely to cheat on a test?",
        "Who is most likely to take drugs?",
        "Who is most likely to get caught naked?",
        "Who has the thickest bush?",
        "Who has the most debt?",
        "Who is most likely to wear socks and sandals?",
        "Who is the sluttiest male?",
        "Who is the sluttiest female?",
        "Who is most likely to forget to brush their teeth?",
        "Who is most likely to not wash their hands after toilet?",
        "Who is most likely to pee themselves in public?",
        "Who is most likely to have a wardrobe malfunction?",
        "Who is most likely to twerk in a club?",
        "Who is most likely to go commando?",
        "Who is most likely to pee in a pool?",
        "Who would win a hot dog eating contest?",
        "Who takes the biggest dumps?",
        "Who has the worst smelling farts?",
        "Who is the most intimidating?",
        "Who was the oldest when they had their first kiss?",
        "Who has never had sex?",
        "Who lost their virginity at the youngest age?",
        "Who is most likely to remain single for next 5 years?",
        "Who would lose an election because of something they did in high school?",
        "Who is most likely to get arrested?",
        "Who would die first if they woke up naked in the middle of the Amazon?",
        "Who wouldnt be able to find their way home without a phone?",
        "Who is most likely to die the youngest?",
        "Who would loose in a fight against an elderly person?",
        "Who has the worst taste in partners?",
        "Who will still be an asshole in 10 years?",
        "Who is most likely to comment on a porn video?",
        "Who is most likely to be stood up for a date?",
        "Who would drink thier own piss for least amount of money?",
        "Who is most likely to win the lottery but loose the ticket?",
        "Who is most likely to fantasize about their relatives?",
        "Who is most likely to go to band camp?",
        "Who is most likely to have a sexual Nick Cage poster?",
        "Who is most likely to do a Fornite dance?",
        "Who is most likely to be put on a no-fly list?",
        "Who is most likely to send money to a Nigerian Prince?",
        "Who is most likely to bite their toenail?",
        "Who is most likely to get a yeast infection?",
        "Who is most likely to end up homeless?",
        "Who is most likely to get a drunk tattoo?",
        "Who is most likely to get drunk at a funeral?",
        "Who is most likely to get friendzoned by their crush?",
        "Who is most likely to dad dance at a club?",
        "Who is most likely to have their nudes leaked?",
        "Who is most likely to join a cult?",
        "Who is most likely to join a pyramid scheme?",
        "Who is most likely to kiss a frog?",
        "Who is most likely to lock their key inside the car?",
        "Who is most likely to get shot?",
        "Who would not be able to keep a secret for more than a day?",
        "Who is most likely to end up a stalker?",
        "Who is most likely to eat gum from underneath the table?",
        "Who is most likely to swear at a child?",
        "Who is most likely to walk into a lamp post?",
        "Who would wear missmatched socks?",
        "Who is most likely to loose thier money at the casino?",
        "Who is most likely to end up as single parent?",
        "Who is most likely to cry in public?",
        "Who is most likely to become a neckbeard?",
        "Who is most likely to crash their ex's wedding?",
        "Who is the most likely to get rejected?",
        "Who is most likely to end up in a hospital after a night out?",
        "Who is most likely to borrow something and never return it?",
        "Who is the biggest Facebook stalker?",
        "Who is most likely to steal a candy from a baby?",
        "Who is most addicted to selfies?",
        "Who has the biggest social media addiction?",
        "Who is most likely to always be sad?",
        "Who is most likely to cry because of a sad movie?",
        "Who is most likely to die of something stupid?",
        "Who is the biggest drama queen?",
        "Who is most likely to sleep with Optimus Prime?",
        "Who is most likely to become a gigolo?",
        "Who is most likely to spend holidays alone?",
        "Who is most likely to eat something gross on a dare?",
        "Who had the cringiest teen years?",
        "Who is most likely to throw a fit during a game of Monopoly?",
        "Who is the least photogenic person?",
        "Who is the worst at sticking to same type of drink?",
        "Who is most likely to have their last words being 'Watch this!'?",
        "Who is most likely to bite another player?",
        "Who is most likely to pee in public?",
        "Who is most likely to offend a stranger?",
        "Who is most likely to wear a coat in summer?",
        "Who is most likely to lie about how much money they make?",
        "Who is most likely to start a fire while drunk?",
        "Who is most likely to say 'I love you' on a first date?",
        "Who is most likely to marry for money?",
        "Who is most likely to take on a bet?",
        "Who is most likely to fall asleep during a party?",
        "Who is most likely to get attacked by a bird?",
        "Who is most likely to lower their dating standards when drunk?",
        "Who is most likely to throw up on someone else?",
        "Who is most likely to overplay how drunk they are?",
        "Who is most likely to underplay how drunk they are?",
        "Who is most likely to go through a goth/scene/emo phase?",
        "Who is able to say the ABC's backwards without fail?",
        "Who is most likely to get nightmares from a horror film?",
        "Who most likely to collect odd items?",
        "Who is most likely to take a Instagram photo of their food?",
        "Who is most likely to sleep in the middle of the day?",
        "Who is most likely to pee in the shower?",
        "Who is most likely to be afraid of the dark?",
    };

    //sexual questions (2)
    string[] sexualQuestions = {
        "Who is most likely to not reciprocate oral sex?",
        "Who is most likely to scream the wrong name during sex?",
        "Who has the most kinks?",
        "Who is most likely to send a nude to a stanger?",
        "Who is most likely to have sex in public?",
        "Who would be considered the most attractive by a random stanger?",
        "Who is most likely to bang someone from Tinder?",
        "Who would bang their date on the first date?",
        "Who is most likely to get peed on?",
        "Who has the worst kinks?",
        "Who would you most likely find nude of on the internet?",
        "Who is most likely to become a porn star?",
        "Who is most likely to flash themselves on a night out?",
        "Who is most likely to watch hentai porn?",
        "Who is most likely sell their nudes?",
        "Who is most likely to get pregnant?",
        "Who would struggle with dirty talk the most?",
        "Who is most likely to become a 40 year old virgin?",
        "Who is most like to have phone sex?",
        "Who is most likely to 'Shove a flute up their pussy'?",
        "Who is most likley to do a threesome?",
        "Who is most likely to do a one night stand and get ghosted?",
        "Who is the most submissive in bed?",
        "Who is the most dominant in bed?",
        "Who is most likely to get a sugar daddy?",
        "Who is most like to hook up at a funeral?",
        "Who is most likely to fuck a profossor for a good grade?",
        "Who is most likely to masturbate to the thought of their friend/coworker?",
        "Who is most likely to use sex toys?",
        "Who is most likely to sext in class?",
        "Who is most likely to discover they're gay?",
        "Who is most likely to have a long distance relationship?",
        "Who is most likely to have sex with a doll?",
        "Who is most likely to have sex with a prostitue?",
        "Who is most likely to buy a sex robot?",
        "Who is the best kisser?",
        "Who can last the longest in bed?",
        "Who cums the quickest?",
        "Who is most likely to have a failed marriage?",
        "Who is most likely to start an orgy?",
        "Who is most likely to own a body pillow?",
        "Who is most likely to have a wet dream?",
        "Who is most likely to have sex in a car?",
        "Who is most likety to join the Mile High Club?",
        "Who is most likely to have sex on a bus?",
        "Who is most likely to own a dildo bike?",
        "Who is most likely to kink shame?",
        "Who is the loudest in the bedroom?",
        "Who has seen the most players in the room, naked?",
        "Who is most likely to recive a massage with a happy ending?",
        "Who is most sexually aroused right now?",
        "Who is most likely to laugh when they hear the number 69?",
        "Who has the nicest ass in the room?",
        "Who would sleep naked?",
        "Who is most likely to hook up with MILF/DILF?",
        "Who is most likely to eat ass?",
        "Who is most likely to sniff their partner's dirty laundry?",
        "Who is most likely to be a masochist?",
        "Who is most likely to go to a strip club?",
        "Who has dated the most amount of people?",
        "Who is most likely to have a big breast fetish?",
        "Who is most likely to have a Asian woman fetish?",
        "Who is most likely to have interracial fetish?",
        "Who is most likely to have cum fetish?",
        "Who is most likely to date a friend's ex?",
        "Who is most likely to marry someone they hate?",
        "Who is most likely to talk about their naked body?",
        "Who is most likely to like being spanked?",
        "Who is most likely to be into BDSM?",
        "Who is most likely to be a cuck?",
        "Who is most likely to end up on FakeTaxi?",
    };

    

}
