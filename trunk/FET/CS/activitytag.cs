public static class GlobalMembersActivitytag
{

	public static int activityTagsAscending(ActivityTag st1, ActivityTag st2)
	{
		return st1.name < st2.name;
	}
}

//
//
// Description: This file is part of FET
//
//
// Author: Liviu Lalescu <Please see http://lalescu.ro/liviu/ for details about contacting Liviu Lalescu (in particular, you can find here the e-mail address)>
// Copyright (C) 2005 Liviu Lalescu <http://lalescu.ro/liviu/>
//
/***************************************************************************
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 ***************************************************************************/

//
//
// Description: This file is part of FET
//
//
// Author: Liviu Lalescu <Please see http://lalescu.ro/liviu/ for details about contacting Liviu Lalescu (in particular, you can find here the e-mail address)>
// Copyright (C) 2005 Liviu Lalescu <http://lalescu.ro/liviu/>
//
/***************************************************************************
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 ***************************************************************************/



#if NDEBUG
#endif


//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class ActivityTag;
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class Rules;


/**
This class represents an activity tag

@author Liviu Lalescu
*/
public class ActivityTag
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ActivityTag) public: QString name;

	private ActivityTag()
	{
	}
	public void Dispose()
	{
	}

	private QString getXmlDescription()
	{
		QString s = "<Activity_Tag>\n";
		s += "	<Name>" + GlobalMembersTimetable_defs.protect(this.name) + "</Name>\n";
		s += "</Activity_Tag>\n";

		return s;
	}
	private QString getDetailedDescription()
	{
		QString s = tr("Activity tag");
		s += "\n";
		s += tr("Name=%1", "The name of the activity tag").arg(this.name);
		s += "\n";

		return s;
	}
	private QString getDetailedDescriptionWithConstraints(ref Rules r)
	{
		QString s = this.getDetailedDescription();

		s += "--------------------------------------------------\n";
		s += tr("Time constraints directly related to this activity tag:");
		s += "\n";
		for (int i = 0; i < r.timeConstraintsList.size(); i++)
		{
			TimeConstraint c = r.timeConstraintsList[i];
			if (c.isRelatedToActivityTag(this))
			{
				s += "\n";
				s += c.getDetailedDescription(r);
			}
		}

		s += "--------------------------------------------------\n";
		s += tr("Space constraints directly related to this activity tag:");
		s += "\n";
		for (int i = 0; i < r.spaceConstraintsList.size(); i++)
		{
			SpaceConstraint c = r.spaceConstraintsList[i];
			if (c.isRelatedToActivityTag(this))
			{
				s += "\n";
				s += c.getDetailedDescription(r);
			}
		}
		s += "--------------------------------------------------\n";

		return s;
	}
}
