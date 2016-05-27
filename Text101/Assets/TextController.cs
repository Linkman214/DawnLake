using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {
	public Text text;
	public Text Healthlabel;
	public Text OrensLabel;
	
	private enum States {Start,Gossip,Survey_0,Drink_0,Witcher,Drink_1,TakeJob,Sleep};
	private States myState;
	int money= 2;
    int health=100;
	// Use this for initialization
	void Start () {
	  myState=States.Start;
	  update_health();
	  update_money();
	}
	
	// Update is called once per frame
	void Update () {
		
		print(myState);
		if (myState==States.Start) 				{state_Start();}
		else if (myState==States.Drink_0)		{state_Drink_0();}
		else if (myState==States.Survey_0)		{state_Survey_0();}
     	else if (myState==States.Gossip)        {state_Gossip();}
     	else if (myState==States.Witcher)	    {state_Witcher();}
		else if (myState==States.Sleep)			{state_Sleep();}
		else if (myState==States.TakeJob)		{state_TakeJob();}	
		
	}
	
	public void update_health(){
	Healthlabel.text=health.ToString();
	Healthlabel=gameObject.GetComponent<Text>();
	}
	
	public void update_money(){
	OrensLabel.text=money.ToString();
	OrensLabel=gameObject.GetComponent<Text>();
	}
	
	void state_Start() {
		
		text.text = "You watch from the tavern window as dusk falls over the town of DawnLake." + 
			" In a past life you were a knight errant, but now the only life you know is that of a mecenary." +
				" Your purse is light of coin, and your sheath weighs heavy \n\n" +
				" You may: \n" + 
				" D: Drink.\n" +  
				" V: View/Survey the scene\n" +   
				" C: Ask about rumors and gossip\n";
		
		if(Input.GetKeyDown(KeyCode.D))                {myState=States.Drink_0;}
		if(Input.GetKeyDown(KeyCode.V))		       {myState=States.Survey_0;}
		if(Input.GetKeyDown(KeyCode.C))                {myState=States.Gossip;}
	}
	
	void state_Drink_0() {
		text.text= "You take a swig out of the mug. Either the innkeep brews strong, or maybe the lack of food in your belly," +
			" but the alcohol quickly takes hold in your mind. Memories of a distant past flood your senses" + 
				" You've walked down this road too many times before, and know exactly where it leads," +
				" no amount of pale ale can drown the noise. \n \n" +
				"Press R to return your focus to the tavern";
		
		if(Input.GetKeyDown(KeyCode.R))               {myState=States.Start;}
		
	}	
	
	void state_Survey_0() {
		text.text= "The tavern is filled with all manners of activity. Peasent townfolk converse of trivial manners." +
			" Traveling merchants dine on cooked salmon. The barmaid hastily moves from table to table with ale" +
				" You begin to feel anxious, You never liked wasting time, but the weight of your purse is uncomfortably light \n\n" +
				"Press R to return your focus to the Tavern";
		
		if(Input.GetKeyDown(KeyCode.R))	             {myState=States.Start;}
	}	
	
	void state_Gossip(){
		text.text= "The barmaid stops at your table to ask if there is anything you need." + 
			" You make small talk about the town, until the bar maid remarks''" +
				" A lot of people come to Dawnlake.  Travel, trade, and especially the fish!" +
				"although..all three are suffering ever since a migration of Drowners have flocked to" +
				" The river's edge'' \n\n" + " How will you reply?" +
				" A.''Drowners? Trading villages can't afford a Witcher?''" +
				" B. ''Sounds like a job. There a Miltia captain? Local lord? Alderman?" +
				" C. ''think I need another drink"; 
		
		if(Input.GetKeyDown(KeyCode.A))           {myState=States.Witcher;}
		if(Input.GetKeyDown(KeyCode.B))           {myState=States.TakeJob;}
		if(Input.GetKeyDown(KeyCode.C))           {myState=States.Drink_1;}
	}
	
	void state_Witcher() {
		text.text= "A mutant? I can't even recall the last time one came through these parts." +
			" town is no stranger to monsters, but this seems different." +
				" something needs to be done, or soon lake minows will be the only thing we serve \n\n" +
				" press R to return to conversation options";
		
		if(Input.GetKeyDown(KeyCode.R))  {myState=States.Gossip;}
		
		
	}	
	
	void state_TakeJob(){
		text.text= "The Alderman has collected a pool among the fisherman. Come dawn, they'll be out by the dock," +
			" hollering for brave souls to join another hunting party." +  
				" If you're interested, we have vacant rooms upstairs for 2 orens a night\n\n" +
				" Times are tough indeed, press S to rent a room and sleep for the night";
				money=money-2;
		update_money();
				
				
		if(Input.GetKeyDown(KeyCode.S))  {myState=States.Sleep;}
		
		
	}
	
	
	void state_Drink_1() {
		text.text= "''Of Course, I'll refill your tankard.'' The barmaid leaves the table, and waltz her way" +
			" behind the bar. You take another moment to yourself, digesting everything from your exchange" +
				" Drowners are pack creatures. You encountered a pair before. Not particularly smart, but dangerous in groups." +
				" Horrible way to die, though... Water filled lungs, teeth clenched deep in flesh, dragged to the murky depths.";
	}	
	
	void state_Sleep(){text.text= "Your eyes feel heavy, sweet sleep will take you soon, your reflect on the challanges of tommorow." +
					" Drowners are pack creatures. You encountered a pair before. Not particularly smart, but dangerous in groups." +
						" Horrible way to die though." + 
							"your final thoughts are of water filled lungs; teeth clenched deep in the flesh; dragged to murky depths \n\n" +
							"Congradulations! You've survived the prototype of Dawnlake, press P to play again.";
							
			if(Input.GetKeyDown(KeyCode.P))             {myState=States.Start;}
			
			}
	

}

