using System;

class Building
{
    public int floors;    // number of floors 
    public int area;      // total square footage of building 
    public int occupants; // number of occupants 


    public Building(int f, int a, int o)
    {
        floors = f;
        area = a;
        occupants = o;
    }

    // Display the area per person.  
    public int areaPerPerson()
    {
        return area / occupants;
    }

    /* Return the maximum number of occupants if each 
       is to have at least the specified minum area. */
    public int maxOccupant(int minArea)
    {
        return area / minArea;
    }
}

// Use the parameterized Building constructor. 
class BuildingDemo
{
    public static void Main()
    {
        Building house = new Building(2, 2500, 4);
        Building office = new Building(3, 4200, 25);

        Console.WriteLine("Maximum occupants for house if each has " +
                          300 + " square feet: " +
                          house.maxOccupant(300));

        Console.WriteLine("Maximum occupants for office if each has " +
                          300 + " square feet: " +
                          office.maxOccupant(300));
        Console.ReadKey();
    }
}