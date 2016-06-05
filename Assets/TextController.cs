using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {
	public Text text;
	public Text Healthlabel;
	public Text OrensLabel;
	
	private enum States {Tavern,Gossip,Survey_0,Drink_0,Witcher,Drink_1,TakeJob,Sleep,Barfight_victory,Oberon,Oberon_1,Bert,Persuade,Deal,Shoveoff};
	private States myState;
	int money= 2;
	int health=100;
	
	// Use this for initialization
	void Start () {
		myState=States.Tavern;
		update_health();
		update_money();
	}
	
	// Update is called once per frame
	void Update () {
		
		print(myState);
		if (myState == States.Tavern) {
			Tavern ();
		} else if (myState == States.Drink_0) {
			Drink_0 ();
		} else if (myState == States.Survey_0) {
			Survey_0 ();
		} else if (myState == States.Gossip) {
			Gossip ();
		} else if (myState == States.Witcher) {
			Witcher ();
		} else if (myState == States.Sleep) {
			Sleep();
		} else if (myState == States.TakeJob) {
			TakeJob ();
		} else if (myState==States.Drink_1) { 
		Drink_1();
		} else if (myState == States.Barfight_victory) {
			Barfight_victory ();
		} else if (myState == States.Oberon) {
			Oberon ();
		} else if (myState == States.Bert) {
			Bert ();
		} else if (myState==States.Oberon_1){
		Oberon_1();
		} else if(myState==States.Persuade) { 
		Persuade();}
		  else if(myState==States.Deal) {
		Deal(); 
		} else if (myState==States.Shoveoff) {
		Shoveoff();}
	}
	//Method to update current health.
	public void update_health(){
		Healthlabel=Healthlabel.GetComponent<Text>();
		Healthlabel.text=health.ToString();
		
	}
	//method to update current money.
	public void update_money(){
		OrensLabel=OrensLabel.GetComponent<Text>();
		OrensLabel.text=money.ToString();
		
	}
	
	void Tavern() {
		
		text.text = "You watch from the tavern window as dusk falls over the town of DawnLake." + 
				" In a past life you were a knight errant, but now the only life you know is that of a mecenary." +
				" Your purse is light of coin, and your sheath weighs heavy. \n\n" +
				"You may:\n" + 
				"\n" +
				
				"A.Drink.\n" +  
				"B.View/Survey the scene.\n" +   
				"C.Ask about rumors and gossip.\n";
		
		if(Input.GetKeyDown(KeyCode.A))                {myState=States.Drink_0;}
		if(Input.GetKeyDown(KeyCode.B))		           {myState=States.Survey_0;}
		if(Input.GetKeyDown(KeyCode.C))                {myState=States.Gossip;}
	    health=100;
		money = 2; 
		update_health ();
		update_money ();}
	   
	
	void Drink_0() {
		text.text= "You take a swig out of the mug; either the innkeep brews strong, or it's the lack of food in your belly," +
				" but the alcohol quickly takes hold in your mind. Memories of a distant past flood your senses." + 
				" You've walked down this road too many times before, and know exactly where it leads," +
				" no amount of pale ale can drown the noise. \n \n" +
				"Press R to return your focus to the Tavern.";
		
		if(Input.GetKeyDown(KeyCode.R))               {myState=States.Tavern;}
		
	}	
	
	void Survey_0() {
		text.text= "The tavern is filled with all manners of activity. Peasent townsfolk converse of trivial manners." +
			" Traveling merchants dine on cooked salmon. The barmaid hastily moves from table to table with ale." +
				" You begin to feel anxious, You never liked wasting time, but the weight of your purse is uncomfortably light. \n\n" +
				"Press R to return your focus to the Tavern.";
		
		if(Input.GetKeyDown(KeyCode.R))	             {myState=States.Tavern;}
	}	
	
	void Gossip(){
		text.text= "The barmaid stops at your table to ask if there is anything you need." + 
			" You make small talk about the town, until the bar maid remarks." +
				" ''A lot of people come to Dawnlake. Travel, trade, and especially the fish!" +
				" although..all three are suffering ever since a migration of Drowners have flocked to" +
				" the river's edge.''\n\n" + " How will you reply? \n\n" +
				
				" A.''Drowners? Trading villages can't afford a Witcher?''\n" +
				" B.''Sounds like a job. There a Miltia captain? Local lord? Alderman?''\n" +
				" C.''Think I need another drink.''\n"; 
		
		if(Input.GetKeyDown(KeyCode.A))           {myState=States.Witcher;}
		if(Input.GetKeyDown(KeyCode.B))           {myState=States.TakeJob;}
		if(Input.GetKeyDown(KeyCode.C))           {myState=States.Drink_1;}
	}
	
	void Witcher() {
		text.text="''A mutant? I can't even recall the last time one came through these parts." +
			" Dawnlake is no stranger to monsters, but this...seems different.'' Her face becomes forlorn." +
				" ''Something needs to be done soon, or lake minows will be the only thing we serve.''  \n\n" +
				" press R to return to conversation options.";
		
		if(Input.GetKeyDown(KeyCode.R))  {myState=States.Gossip;}
		
		
	}	
	
	void TakeJob(){
		text.text= "''The Alderman has collected a pool among the fisherman. Come dawn, they'll be out by the dock," +
			" hollering for brave souls to join another hunting party." +  
				" If you're interested, we have vacant rooms upstairs for 2 orens a night''\n\n" +
				" Times are tough indeed, press S to rent a room and sleep for the night";
		
		money=2-2;
		if(Input.GetKeyDown(KeyCode.S)) {myState=States.Sleep ;} 
		
		
	}
	
	
	void Drink_1() {
		text.text = "''Of Course, I'll refill your tankard.'' The barmaid leaves the table, and waltz her way" +
			    " behind the bar. You take another moment to yourself, digesting everything from your exchange." +
				" your thoughts are quickly interupted by a loud clash. A drunkard lands at the feet of your table." +
				" standing above him is a large bald man, his mustache furrowed in an angry snarl." +
				" ''You! Troll-fucker!'' he belows loudly. A barrage of booze reeked spittle leaving his lips." +
				" ''I knew it!''  You've never been to Dawnlake, and you certainly don't know this man.\n\n" +
				
				"A. Get ready for a fight. \n" +
				"B.''What the hell are you talking about?''\n";
		
		if(Input.GetKeyDown(KeyCode.A)) {myState = States.Barfight_victory;}
		if(Input.GetKeyDown(KeyCode.B)) {myState = States.Bert;}	
	}	
	
	void Barfight_victory() {
		text.text = "You don't hesitate for another moment, instead you throw a left hook punch" +
			" that lands squarely against the man's jaw. He staggers to the right, you've been in enough brawls" +
				" that you hammer your right fist into his right temple. He falls like a sack of potatos." +
				" The foundation of the building shakes as he meets the floor; motionless." +
				" You remind yourself of the hollow honor, you long ago forsake." +
				" You feel no shame, nor guilt. Only the bruises now forming on your fists.\n\n" +
				
				"The other bar patrons look on with awe." +
				" One of them, a man wearing a embroided leather jerkin stands up and walks towards you" +
				" clapping his hands. ''Bravo!'' He exclaims. ''been a long time since i've seen Bert recieve a proper ass-kicking.\n\n" +
				"A:''Who are you?''\n" +
				"B:''Bert? Why did he approach me?''\n" +
				"C:''Shove off, I'm not interested.''\n"; 
		
		if(Input.GetKeyDown (KeyCode.A)) {myState =States.Oberon;}
		if(Input.GetKeyDown (KeyCode.B)) {myState =States.Oberon_1;}
		if(Input.GetKeyDown (KeyCode.C)) {myState=States.Shoveoff;}
		
	}
	
	void Bert(){
		health = 80;
		update_health();
		
		text.text = "''What the h-'' before you can finish your sentence, the man sucker punches you hard in the stomach." +
			" You reel forward as you feel the air escape your lungs. It takes every effort to remain standing, but you do." +
				" The man looks at you, puzzled. His hesitation gives you enough time to arch your shoulders back and propel your skull forward" +
				" into the bridge of his nose. He falls like a sack of potatos." +
				" The foundation of the building shakes as he meets the floor; motionless." +
				" Your ears are ringing, and your vision is dazed. You want to laugh, as you remind yourself of the hollow honor, you long ago forsake." +
				" You feel no shame, nor guilt. Only the throbbing pain in your stomach, and skull." +
				" The other bar patrons look on with awe." +
				" One of them, a man wearing a embroided leather jerkin stands up and walks towards you" +
				" clapping his hands.''Bravo!'' He exclaims. ''been a long time since i've seen Bert recieve a proper ass-kicking.''\n\n" +
				
				"A:''Who are you?''\n" +
				"B:''Bert? Why did he approach me?''\n" +
				"C:''Shove off, I'm not interested.''\n"; 
		
		if(Input.GetKeyDown (KeyCode.A)) {myState =States.Oberon;}
		if(Input.GetKeyDown (KeyCode.B)) {myState =States.Oberon_1;}
		if(Input.GetKeyDown (KeyCode.C)) {myState=States.Shoveoff;}
		
	}
	
	
	void Oberon() {
		text.text = "''Ah, forgive my manners. The names Gil Oberon. I'm a...shall we say, hired professional?" +
			" Yes, I think the term fits. I run a crew, a damn good crew, actually, you've already acquainted yourself with Bert." +
				" Not the brightest, but the man's got a gift for killing, and I have a rising suspicion, you may have a knack for it too.''" +
				" He eyes Bert's unconcious mass. His blood caked nose whistles with every labored breath." +
				" ''Your drinks, your lodging. Allow me to pay, as both an apology, and a hospitality.''" +
				" He grins his yellow teeth at you. ''though I do have a proposition for you to hear.''" +
				" as I said, I run a crew; a drowner hunting party. Our rates are 5 orens a head. I could use someone like you.''" +
				" he nods at you, intentively. ''We leave tommorow, come dawn. I'll make it worth your while, 10 orens for a sign on. 10 if we get back" +
				" What's made in between, I leave to you.\n\n" +
				
				"A:[Persuade]''Make it 20, and I'm sold.''\n" +
				"B:''Sounds reasonable enough, show me a contract''\n"+
				"C:''Not interested.''\n";

	if(Input.GetKeyDown(KeyCode.A)) {myState=States.Persuade;}
	if(Input.GetKeyDown (KeyCode.B)){myState=States.Deal;}
	if(Input.GetKeyDown (KeyCode.C)){myState=States.Shoveoff;}
	
	}
	
	void Oberon_1() {
		text.text = "You've already acquainted yourself with Bert. He eyes Bert's unconcious mass. his blood caked nose whistles with every labored breath" +
			"he isn't the brightest sober, but the man's got a gift for killing, and I have a rising suspicion, you may have a knack for it too.''" +
				"He pauses for a moment, seeming to try and gauge a reaction from you." +
				" ''Ah, forgive my manners. The names Gil Oberon. I'm a...shall we say, hired professional?" +
				" ''Yes, I think the term fits. I run a crew, a damn good crew.'' He looks down at the body of the man besides Bert." +
				" ''Your drinks, your lodging. Allow me to pay, as both an apology and hospitality.''" +
				" He grins his yellow teeth at you. ''Though I do have a propsition I'd like for you to hear." +
				" as I said, I run a crew; a drowner hunting party. Our rates are 5 orens a head. I could use someone like you.''" +
				" he nods at you, intentively. ''We leave tommorow, come dawn. I'll make it worth your while, 10 orens for a sign on. 10 if we get back" +
				" What's made inbetween I leave to you.\n\n" +
				
				"A:[Persuade]''Make it 20, and I'm sold.''\n" +
				"B:''Sounds reasonable enough, show me a contract''\n" +
				"C:''Not interested.''\n";
		if(Input.GetKeyDown (KeyCode.A)) {myState=States.Persuade;}
		if(Input.GetKeyDown (KeyCode.B)) {myState=States.Deal;} 
	    if(Input.GetKeyDown (KeyCode.C)) {myState=States.Shoveoff;}
	    }
	
	void Persuade(){
		text.text= "''Deal. Dusk, Docks.'' he leaves his seat at your table and begins to turn. ''Oh! don't worry about Bert" +
		" only thing he'll remember is the punch, but if yours are as consistent as I've seen, you'll have no problem.'' He motions to" +
		" a group of three other men seated at a table on the far side of the bar. ''No problem at all'' The three men get up and walk in a" +
		" routine stride, as if this is were just another typical night. Two of them begin to drag Bert, while the other picks up the nameless fellow at the feet of" +
		" your table. They all exit.\n\n" +
		
		"Your bill is accounted for.  All that remains is a good night sleep\n" +
		"press S to sleep.";
		
		if(Input.GetKeyDown(KeyCode.S)) {myState=States.Sleep;}
		
	}
	
	void Deal(){
	
	text.text= "''Excellent.'' He takes out a piece of parchment from his coat pocket, and slaps it down on ther table" +
			" You sign, as he grins another yellow mouthful , and shakes your hand. ''It's a deal. Dusk at the docks, tis where we'll all be" +
			"''Oh! don't worry about Bert" +
		    " only thing he'll remember is the punch, but if yours are as consistent as I've seen, you'll have no problem.'' He motions to" +
		    " a group of three other men seated at a table on the far side of the bar. ''No problem at all'' The three men get up and walk in a" +
		    " routine stride, as if this is were just another typical night. Two of them begin to drag Bert, while the other picks up the nameless fellow at the feet of" +
		    " your table. They all exit.\n\n" +		
	
	" Your bill is accounted for. All that remains is a good night sleep.\n" +
	" press S to sleep.";
	
	 if(Input.GetKeyDown (KeyCode.S)) {myState=States.Sleep;}
	  
	
	}
	
	void Shoveoff(){
	text.text= "''I see. Well, enjoy your evening.'' If Gil is disappointed, then he is a hard face to read."+
			"He states at you blankly before dismissing himself from the table. As he heads for the exit, he pauses and turns to face you"+
			" ''Oh! don't worry about Bert. The only thing he'll remember is the punch, but if yours are as consistent as I've seen, you'll have no problem.''" +
			" He motions to a group of three other men seated at a table on the far side of the bar. ''No problem at all'' The three men get up and walk in a" +
			" routine stride, as if this is were just another typical night. Two of them begin to drag Bert, while the other picks up the nameless fellow at the feet of" +
			" your table. They all exit.\n\n" +
			
			"The barmaid makes her way over to you. She nervously places the mug at your table. ''Your drink, friend. Sir Oberon has taken care of your tab, and you room.''"+
			"You thank her, and take a sip from the wooden tankard. Men like Oberon are dangerous, you can't help but look over your shoulder the rest of the night.\n" +
			" Press S to Sleep";
			
			if(Input.GetKeyDown (KeyCode.S)) {myState=States.Sleep;}
					}
	
	void Sleep() {
		text.text= "Your eyes feel heavy, sweet sleep will take you soon. You reflect on the challanges of tommorow." +
			" Drowners are pack creatures. You encountered a pair before. Not particularly smart, but dangerous in groups." +
				" Horrible way to die though." + 
				" Your final thoughts are of water filled lungs; teeth clenched deep in the flesh; dragged to murky depths \n\n" +
                " Congratulations! You've survived the prototype of Dawnlake, press P to play again.";
		
		if(Input.GetKeyDown(KeyCode.P))             {myState=States.Tavern;}
	
			update_money();
			update_health();
			
		
	}
	
	}
	
	
	



