using System;

namespace Api.Minions 
{
    public interface IMinionService 
    {
        string GetMinionByName(string name);
    }
}