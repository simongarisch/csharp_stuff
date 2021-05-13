// csc behavioral_interpreter.cs && behavioral_interpreter && del behavioral_interpreter.exe
using System;
using System.Collections.Generic;


interface IExpression {
    void InterpretContext(Context context);
}


class Context {
    private string ac_model = "";
    private bool isAircraft = false;

    public Context(string ac_model) {
        this.ac_model = ac_model;
    }

    public string getModel() {
        return this.ac_model;
    }

    public int getLength() {
        return this.ac_model.Length;
    }

    public string getLastChar() {
        return this.ac_model[this.ac_model.Length - 1].ToString();
    }

    public string getFirstChar() {
        return this.ac_model[0].ToString();
    }

    public void setIsAircraft(bool isAircraft) {
        this.isAircraft = isAircraft;
    }

    public bool getIsAircraft() {
        return this.isAircraft;
    }
}


class CheckExpression : IExpression {
    public void InterpretContext(Context context) {
        // We assume tthe aircraft models only start with A or B and contains 4 or 5 chars.
        string ac_model = context.getModel();
        if (ac_model.StartsWith("A") || ac_model.StartsWith("B")) {
            if (ac_model.Length == 4 || ac_model.Length == 5) {
                context.setIsAircraft(true);
                Console.WriteLine(ac_model + " is an aircraft...");
            } else {
                context.setIsAircraft(false);
                Console.WriteLine(ac_model + " is not an aircraft...");
            }
        } else {
            context.setIsAircraft(false);
            Console.WriteLine(ac_model + " is not an aircraft...");
        }
    }
}


class BrandExpression : IExpression {
    public void InterpretContext(Context context) {
        if (context.getIsAircraft() == true) {
            if (context.getFirstChar().Equals("A"))
                Console.WriteLine("Brand is Airbus");
            else if (context.getFirstChar().Equals("B"))
                Console.WriteLine("Brand is Boeing");
            }
        else
            Console.WriteLine("Brand could not be interpreted");
    }
}


class ModelExpression : IExpression {
    public void InterpretContext(Context context) {
        if (context.getIsAircraft() == true) {
            Console.WriteLine("Model is : " + context.getModel().Substring(1, 3));
        } else {
            Console.WriteLine("Model could not be interpreted");
        }
    }
}


class TypeExpression : IExpression {
    public void InterpretContext(Context context) {
        if (context.getIsAircraft() == true) {
               string ac_model = context.getModel();
            if (context.getLength() == 5 && context.getLastChar().Equals("F")) {
                Console.WriteLine("Aircraft type is Cargo/Freighter");
            } else {
                Console.WriteLine("Aircraft type is Passenger Transportation");
            }
        } else {
            Console.WriteLine("Type could not be interpreted");
        }
    }
}


class Program {
    public static void Main(string[] args) {
        List<Context> lstAircrafts = new List<Context>();
        List<IExpression> lstExpressions = new List<IExpression>();

        lstAircrafts.Add(new Context("A330"));
        lstAircrafts.Add(new Context("A330F"));
        lstAircrafts.Add(new Context("B777"));
        lstAircrafts.Add(new Context("B777F"));
        lstAircrafts.Add(new Context("TheCode"));

        lstExpressions.Add(new CheckExpression());
        lstExpressions.Add(new BrandExpression());
        lstExpressions.Add(new ModelExpression());
        lstExpressions.Add(new TypeExpression());

        for (int ac_index = 0; ac_index < lstAircrafts.Count; ac_index++) {
            for (int exp_index = 0; exp_index < lstExpressions.Count; exp_index++) {
                lstExpressions[exp_index].InterpretContext(lstAircrafts[ac_index]);
            }
            Console.WriteLine("-----------------------------------");
        }
        Console.ReadLine();

        /*
        B777 is an aircraft...
        Brand is Boeing
        Model is : 777
        Aircraft type is Passenger Transportation
        -----------------------------------
        B777F is an aircraft...
        Brand is Boeing
        Model is : 777
        Aircraft type is Cargo/Freighter
        -----------------------------------
        TheCode is not an aircraft...
        Brand could not be interpreted
        Model could not be interpreted
        Type could not be interpreted
        -----------------------------------
         */
    }
}
