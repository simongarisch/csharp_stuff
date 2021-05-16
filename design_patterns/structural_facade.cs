// csc structural_facade.cs && structural_facade && del structural_facade.exe
using System;


class CPU {
    public void freeze() {
        Console.WriteLine("Freezing processor");
    }

    public void jump(String position) {
        Console.WriteLine("Jumping to: " + position);
    }

    public void execute() {
        Console.WriteLine("Executing");
    }
}


class Memory {
    public void load(String position, String data) {
        Console.WriteLine("Loading from " + position + " data " + data);
    }
}


class SolidStateDrive {
    public String read(String lba, String size) {
        return "data from sector " + lba + " with size " + size;
    }
}


class ComputerFacade {
    CPU cpu;
    Memory memory;
    SolidStateDrive ssd;

    public ComputerFacade() {
        cpu = new CPU();
        memory = new Memory();
        ssd = new SolidStateDrive();
    }

    public void start() {
        this.cpu.freeze();
        this.memory.load("0x00", this.ssd.read("100", "1024"));
        this.cpu.jump("0x00");
        this.cpu.execute();
    }
}


class Program {
    public static void Main() {
        var computer = new ComputerFacade();
        computer.start();
        /*
        Freezing processor
        Loading from 0x00 data data from sector 100 with size 1024
        Jumping to: 0x00
        Executing
         */
    }
}
