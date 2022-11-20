//link to tutorial : 
//https://www.geeksforgeeks.org/flyweight-design-pattern/?ref=rp

// Terrorist must have weapon and mission
class Terrorist : Player
{
    //Java has a final keyword, but C# does not have
    //its implementation. Use the sealed or readonly
    //keyword in C# for the same implementation.
    //The readonly would allow the variables to be
    //assigned a value only once. A field marked
    //"read-only", can only be set once during the
    //construction of an object.
    //public final String TASK;
    // Intrinsic Attribute
    public readonly string TASK;
    // Extrinsic Attribute
    private string weapon = "";//it is empty string for now
    public Terrorist()
    {
        TASK = "PLANT A BOMB";
    }
    public void assignWeapon(string weapon)
    {
        // Assign a weapon
        this.weapon = weapon;
    }
    public void mission()
    {
        //Java 'System.out.printIn'
        //is equalent of
        //C# 'Console.WriteLine'
        //Java 'System.out.print'
        //is equalent of
        //C# 'Console.Write'
        //Work on the Mission
        Console.WriteLine("Terrorist with weapon "
            + weapon + "|" + " Task is " + TASK);
    }
}
// CounterTerrorist must have weapon and mission
class CounterTerrorist : Player
{
    // Intrinsic Attribute
    public readonly string TASK;
    // Extrinsic Attribute
    private string weapon = "";
    //cs8618 - string is reference type and can't be null
    //that's why ' = "";' was added
    public CounterTerrorist()
    {
        TASK = "DIFFUSE BOMB";
    }
    public void assignWeapon(string weapon)
    {
        this.weapon = weapon;
    }
    public void mission()
    {
        Console.WriteLine("Counter Terrorist with weapon "
             + weapon + "|" + " Task is " + TASK);
    }
}
/// <summary>
/// Class used to get a player using HashMap (Returns
/// an existing player if a player of given type exists.
/// Else creates a new player and returns it.
/// HashMap is in Java, not C#. The equivalent of
/// HashMap in C# is Dictionary that is used as a
/// collection of key-value pair.
/// </summary>
class PlayerFactory
{
    //HashMap is in Java, not C#. The equivalent of
    //HashMap in C# is Dictionary that is used as a
    //collection of key-value pair.
    /* HashMap stores the reference to the object
       of Terrorist(TS) or CounterTerrorist(CT).  */
    private static Dictionary<string, Player> hm = 
        new Dictionary<string, Player>();
    // Method to get a player
    public static Player getPlayer(string type)
    {
        Player p = null;
        /* If an object for TS or CT has already been
           created simply return its reference */
        if (hm.ContainsKey(type))
        {
            //the same as 'p = hm.get(type);' in java
            //this is how to get value from a dictionary
            p = hm[type];
        }
        else
        {
            /* create an object of TS/CT  */
            switch (type)
            {
                case "Terrorist":
                    //this will appears only once
                    Console.WriteLine("Terrorist created");
                    p = new Terrorist();
                    break;
                case "Counter Terrorist":
                    //this will appears only once
                    Console.WriteLine("Counter Terrorist created");
                    p = new CounterTerrorist();
                    break;
                    default:
                    Console.WriteLine("Unreachable code!");
                    break;
            }
            //the same as 'hm.put(type, p);' in java
            // Once created insert it into the
            // HashMap or hm or Dictionary
            hm.Add(type, p);
        }
        return p;
    }
}
/// <summary>
/// Flyweight pattern is one of the structural design patterns 
/// as this pattern provides ways to decrease object count 
/// thus improving application required objects structure. 
/// Flyweight pattern is used when we need to create a large 
/// number of similar objects (say 10(ten to the fifth power)5). 
/// One important 
/// feature of flyweight objects is that they are immutable. 
/// This means that they cannot be modified once they have 
/// been constructed.
///Why do we care for number of objects in our program ?
///Less number of objects reduces the memory usage, and it 
///manages to keep us away from errors related to memory 
///like java.lang.OutOfMemoryError.
///Although creating an object in Java is really fast, we 
///can still reduce the execution time of our program by 
///sharing objects.
///In Flyweight pattern we use a HashMap that stores 
///reference to the object which have already been 
///created, every object is associated with a key. 
///Now when a client wants to create an object, he 
///simply has to pass a key associated with it and if 
///the object has already been created we simply get 
///the reference to that object else it creates a 
///new object and then returns it reference to 
///the client.
///===========================================================
///Intrinsic and Extrinsic States
///To understand Intrinsic and Extrinsic state, let us 
///consider an example.
///Suppose in a text editor when we enter a character, 
///an object of Character class is created, the attributes 
///of the Character class are { name, font, size }. We do 
///not need to create an object every time client enters 
///a character since letter ‘B’ is no different from 
///another ‘B’ . If client again types a ‘B’ we simply 
///return the object which we have already created before. 
///Now all these are intrinsic states (name, font, size), 
///since they can be shared among the different objects 
///as they are similar to each other.
///Now we add to more attributes to the Character class, 
///they are row and column. They specify the position of 
///a character in the document. Now these attributes will 
///not be similar even for same characters, since no two 
///characters will have the same position in a document, 
///these states are termed as extrinsic states, and they 
///can’t be shared among objects.
///Implementation : We implement the creation of 
///Terrorists and Counter Terrorists In the game of 
///Counter Strike. So we have 2 classes one for 
///Terrorist(T) and other for Counter Terrorist(CT). 
///Whenever a player asks for a weapon we assign him 
///the asked weapon. In the mission, terrorist’s task 
///is to plant a bomb while the counter terrorists 
///have to diffuse the bomb.
///Why to use Flyweight Design Pattern in this example? 
///Here we use the Fly Weight design pattern, since 
///here we need to reduce the object count for players. 
///Now we have n number of players playing CS 1.6, if 
///we do not follow the Fly Weight Design Pattern then 
///we will have to create n number of objects, one for 
///each player. But now we will only have to create 2 
///objects one for terrorists and other for counter 
///terrorists, we will reuse then again and again 
///whenever required.
///Intrinsic State : Here ‘task’ is an intrinsic state 
///for both types of players, since this is always same 
///for T’s / CT’s.We can have some other states like 
///their color or any other properties which are similar 
///for all the Terrorists / Counter Terrorists in their 
///respective Terrorists / Counter Terrorists class.
///Extrinsic State : Weapon is an extrinsic state since 
///each player can carry any weapon of his/her choice. 
///Weapon need to be passed as a parameter by the 
///client itself.
/// </summary>
class CounterStrike // Driver class
{
    // All player types and weapon (used by getRandPlayerType()
    // and getRandWeapon()
    private static string[] playerType =
    {
        "Terrorist", "Counter Terrorist"
    };
    private static string[] weapons =
    {
        "AK-47","Maverick","Gut knife","Desert Eagle"
    };
    // Driver code
    static void Main(string[] args)
    {
        int amountOfPlayers = 10;
        /* Assume that we have a total of 10 players
           in the game. */
        for (int i = 0; i < amountOfPlayers; i++)
        {
            /* getPlayer() is called simply using the class
               name since the method is a static one */
            Player p = PlayerFactory.getPlayer(getRandPlayerType());
            /* Assign a weapon chosen randomly uniformly
               from the weapon array  */
            p.assignWeapon(getRandWeapon());
            // Send this player on a mission
            p.mission();
        }
    }
    // Utility methods to get a random player type and
    // weapon
    public static string getRandPlayerType()
    {
        Random r = new Random();
        // Will return an integer between [0,2)
        int randInt = r.Next(playerType.Length);
        //Get dictionary value by key
        // return the player stored at index 'randInt'
        return playerType[randInt];
    }
    public static string getRandWeapon()
    {
        Random r = new Random();
        // Will return an integer between [0,5)
        int randInt = r.Next(weapons.Length);
        //Get dictionary value by key
        // Return the weapon stored at index 'randInt'
        return weapons[randInt];
    }
}
// A common interface for all players
interface Player
{
    public void assignWeapon(string weapon);
    public void mission();
}
/* Outputs:
Terrorist created
Terrorist with weapon Maverick| Task is PLANT A BOMB
Counter Terrorist created
Counter Terrorist with weapon Maverick| Task is DIFFUSE BOMB
Terrorist with weapon AK-47| Task is PLANT A BOMB
Terrorist with weapon Maverick| Task is PLANT A BOMB
Counter Terrorist with weapon AK-47| Task is DIFFUSE BOMB
Terrorist with weapon AK-47| Task is PLANT A BOMB
Counter Terrorist with weapon AK-47| Task is DIFFUSE BOMB
Counter Terrorist with weapon AK-47| Task is DIFFUSE BOMB
Counter Terrorist with weapon AK-47| Task is DIFFUSE BOMB
Counter Terrorist with weapon Maverick| Task is DIFFUSE BOMB
*/