using System;
using System.Collections.Generic;

namespace Api.Features.Minions 
{
    public interface IMinionService 
    {
        string GetMinionByName(string name);

        List<string> GetMinionNames();

        string GetRandomMinionName();
    }
}