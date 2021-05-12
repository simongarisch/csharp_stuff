// csc creational_builder.cs && creational_builder && del creational_builder.exe
using System;


interface IBuilder {
    String BuildFoundation();
    String BuildLevels();
}


class FlatBuilder : IBuilder {
    public String BuildFoundation() {
        return "small";
    }

    public String BuildLevels() {
        return "many";
    }
}


class HouseBuilder : IBuilder {
    public String BuildFoundation() {
        return "large";
    }

    public String BuildLevels() {
        return "one";
    }
}


class EngineerDirector {
    public String ConstructBuilding(IBuilder builder) {
        String foundation = builder.BuildFoundation();
        String levels = builder.BuildLevels();
        return foundation + " foundation and " + levels + " levels";
    }
}


class Program {
    public static void Main() {
        EngineerDirector director = new EngineerDirector();
        Console.WriteLine(director.ConstructBuilding(new FlatBuilder())); // small foundation and many levels
        Console.WriteLine(director.ConstructBuilding(new HouseBuilder())); // large foundation and one levels
    }
}
