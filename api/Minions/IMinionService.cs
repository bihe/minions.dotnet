using System;
using System.Collections.Generic;

namespace Api.Minions 
{
    public interface IMinionService 
    {
        string GetMinionByName(string name);

        List<string> GetMinionNames();

        string GetRandomMinionName();
    }
}