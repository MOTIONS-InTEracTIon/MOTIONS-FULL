using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamelogic;

public class TIIESVisualizationController : MonoBehaviour {

	public VisualizationCanvasController visualizationController;
	string visualizationName = "TIIES";
	string[] TIIESVisualizationActionsNames = new string[]
	{
		"Select/Deselect topic 1",
		"Select/Deselect topic 2",
		"Select/Deselect topic 3",
		"Select/Deselect topic 4",
		"Show/hide topic 1",
		"Show/hide topic 2",
		"Show/hide topic 3",
		"Show/hide topic 4",
		"Change to next plane",
		"Change to previous plane"

	};

	private void OnEnable()
	{
		if (visualizationController != null)
		{
			SelectThisVisualization ();

			visualizationController.scrollDown.LaunchScrollDown ("TIIES visualization description", "This visualization is designed to be displayed in a monitor, and shows digital information objects in a plane configuration");
			visualizationController.availableActionsTitle = "TIIES visualizationes actions";
			visualizationController.availableActionsList = "[·]Advance to next plane in the object query panel: If the amount of objects is too big and can't be show in the object query panel, the remaining will be placed in another view, called plane. This action highlights the images in the next Plane." +
			"\n[·]Go back to previous plane in the object query panel: If the advance to the next plane action was taken, this action allows to go back and highlight the objects of the previous Plane" +
			"\n[·]Mark/unmark as category: Marks (or, if already marked, unmarks) the current highlighted object as part of one category. There are four different actions, Mark as category 1, 2, 3 and 4." +
			"\n[·]Show category: Shows the objects marked under the category. There are four different actions, Show category 1, 2, 3 and 4.";


		}
	
	}

	public void SelectThisVisualization()
	{
		string Scope = ProfileManager.Instance.currentEvaluationScope;

		GLPlayerPrefs.SetString(Scope, "CurrentVisualization", visualizationName);
		visualizationController.UpdateCurrentSelectedVisualizationText();
		ActionManager.Instance.UpdateVisualizationActionNames (TIIESVisualizationActionsNames);

		GLPlayerPrefs.SetBool (Scope, "TIIESMode", true);
		GLPlayerPrefs.SetBool (Scope, "BGIIESMode", false);

	}




}
