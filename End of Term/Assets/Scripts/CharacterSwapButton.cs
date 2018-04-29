
	{
        //Cycle to Next Turn After Swapping
        GameManager.manager.turnstate = GameManager.TurnState.Menu;

        if (GameManager.manager.curTurn == GameManager.CurrentTurn.ActiveDuo0)
            GameManager.manager.curTurn = GameManager.CurrentTurn.ActiveDuo1;
           
        if (GameManager.manager.curTurn == GameManager.CurrentTurn.ActiveDuo1)
            GameManager.manager.curTurn = GameManager.CurrentTurn.Enemy0;


        switch (bNum) {
	{
		// switch statement - set the active duo member depending on which button this is.
		switch (bNum) {
	{
        //Cycle to Next Turn After Swapping
        GameManager.manager.turnstate = GameManager.TurnState.Menu;

        if (GameManager.manager.curTurn == GameManager.CurrentTurn.ActiveDuo0)
            GameManager.manager.curTurn = GameManager.CurrentTurn.ActiveDuo1;
           
        if (GameManager.manager.curTurn == GameManager.CurrentTurn.ActiveDuo1)
            GameManager.manager.curTurn = GameManager.CurrentTurn.Enemy0;


        switch (bNum) {
		// switch statement - set the active duo member depending on which button this is.