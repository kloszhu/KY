using System;
using System.Collections.Generic;
using System.Linq;

namespace KY.Chart
{
    /// <summary>
    /// Chart class.
    /// 1.A chat happens between visitor and agent.
    /// 2.One chat can only have one visitor and multiple agents.
    /// </summary>
    public class Chart
    {
        public int Id { get; set; }
        public bool IsStart
        {
            get
            {
                if (agents.Count(a=>a.isOnline==true)>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public Visitor visitor { get; set; }
        public List<Agents> agents { get; set; } = new List<Agents>();
        public List<Message> messages { get; set; } = new List<Message>();
        
    }
  
    /// <summary>
    /// Chart message infomaction class.
    /// </summary>
    public class Message
    {
        public string ChartMessage { get; set; }

    }
    /// <summary>
    /// Visitor class:
    /// 4.Agent can be at online and offline status. A visitor can request a chat when agent is online.
    /// 5.A chat is initiated by visitor, and once an agent accept the request, chat starts.
    /// </summary>
    public class Visitor
    {
        public Visitor(int id)
        {
        }
        public Request  RequestChart { get; set; }
        /// <summary>
        /// 5.A chat is initiated by visitor, and once an agent accept the request, chat starts.
        /// </summary>
        /// <param name="agents"></param>
        public virtual void InitiateChart(Agents agents) {
            if (agents.isOnline==true)
            {
                RequestChart = new Request(new Chart(),agents);
            }
           
        }
    }
    /// <summary>
    /// 3.An agent have an Id and Name and can deal with multiple chats at the same time.
    /// </summary>
    public class Agents
    {
        public string Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        ///  4.Agent can be at online and offline status. A visitor can request a chat when agent is online.
        /// </summary>
        public bool isOnline { get; set; }
        public virtual List<Chart> charts { get; set; } = new List<Chart>();

        /// <summary>
        /// 6.During the chat, another agent can join it.
        /// </summary>
        public void otherAgentJoin(Chart chart, Agents agents)
        {
            chart.agents.Add(agents);
        }
    }

    /// <summary>
    /// 5.A chat is initiated by visitor, and once an agent accept the request, chat starts.
    /// </summary>
    public class Request
    {
        public Chart chart { get; set; }
        public Request(Chart chart, Agents agents)
        {
            this.chart = chart;
            this.chart.agents.Add(agents);
            chart.agents.Add(agents);
            agents.charts.Add(this.chart);
        }
    }


}
