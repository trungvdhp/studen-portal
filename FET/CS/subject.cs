public static class GlobalMembersSubject
{

	public static int subjectsAscending(Subject s1, Subject s2)
	{
		return s1.name < s2.name;
	}
}

//
//
// Description: This file is part of FET
//
//
// Author: Liviu Lalescu <Please see http://lalescu.ro/liviu/ for details about contacting Liviu Lalescu (in particular, you can find here the e-mail address)>
// Copyright (C) 2003 Liviu Lalescu <http://lalescu.ro/liviu/>
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
// Copyright (C) 2003 Liviu Lalescu <http://lalescu.ro/liviu/>
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
//class Subject;
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class Rules;


/**
This class represents a subject

@author Liviu Lalescu
*/
public class Subject
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(Subject) public: QString name;

	private Subject()
	{
	}
	public void Dispose()
	{
	}

	private QString getXmlDescription()
	{
		QString s = "<Subject>\n";
		s += "	<Name>" + GlobalMembersTimetable_defs.protect(this.name) + "</Name>\n";
		s += "</Subject>\n";

		return s;
	}
	private QString getDetailedDescription()
	{
		QString s = tr("Subject");
		s += "\n";
		s += tr("Name=%1", "The name of the subject").arg(this.name);
		s += "\n";

		return s;
	}
	private QString getDetailedDescriptionWithConstraints(ref Rules r)
	{
		QString s = this.getDetailedDescription();

		s += "--------------------------------------------------\n";
		s += tr("Time constraints directly related to this subject:");
		s += "\n";
		for (int i = 0; i < r.timeConstraintsList.size(); i++)
		{
			TimeConstraint c = r.timeConstraintsList[i];
			if (c.isRelatedToSubject(this))
			{
				s += "\n";
				s += c.getDetailedDescription(r);
			}
		}

		s += "--------------------------------------------------\n";
		s += tr("Space constraints directly related to this subject:");
		s += "\n";
		for (int i = 0; i < r.spaceConstraintsList.size(); i++)
		{
			SpaceConstraint c = r.spaceConstraintsList[i];
			if (c.isRelatedToSubject(this))
			{
				s += "\n";
				s += c.getDetailedDescription(r);
			}
		}
		s += "--------------------------------------------------\n";

		return s;
	}
}
