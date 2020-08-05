﻿using System.Collections.Generic;
using System;
/// <summary>
/// 备忘录模式
/// </summary>
public class MementoPattern 
{
    public class Memento
    {
        private string _state;

        public Memento(string state)
        {
            _state = state;
        }

        public string GetState()
        {
            return _state;
        }
    }

    public class Originator
    {
        private string _state;

        public void SetState(string state)
        {
            _state = state;
        }

        public string GetState()
        {
            return _state;
        }

        public Memento SaveStateToMemento()
        {
            return new Memento(_state);
        }

        public void GetStateFromMemento(Memento memento)
        {
            _state = memento.GetState();
        }
    }

    public class CareTaker
    {
        private List<Memento> _mementos = new List<Memento>();

        public void Add(Memento memento)
        {
            _mementos.Add(memento);
        }

        public Memento Get(int index)
        {
            return _mementos[index];
        }
    }

    public void Main()
    {
        Originator originator = new Originator();
        CareTaker careTaker = new CareTaker();


        originator.SetState("State #1");
        originator.SetState("State #2");
        careTaker.Add(originator.SaveStateToMemento());
        originator.SetState("State #3");
        careTaker.Add(originator.SaveStateToMemento());
        originator.SetState("State #4");

        Console.WriteLine("Current State: " + originator.GetState());
        originator.GetStateFromMemento(careTaker.Get(0));
        Console.WriteLine("First saved State: " + originator.GetState());
        originator.GetStateFromMemento(careTaker.Get(1));
        Console.WriteLine("Second saved State: " + originator.GetState());
    }
}
