public static class GlobalMembersTeacher
{

	public static int teachersAscending(Teacher t1, Teacher t2)
	{
		return t1.name < t2.name;
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
//class Teacher;
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class Rules;



/**
@author Liviu Lalescu
*/
public class Teacher
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(Teacher) public: QList<qint16> activitiesForTeacher;

	private QString name = new QString();

	private Teacher()
	{
	}
	public void Dispose()
	{
	}

	private QString getXmlDescription()
	{
		QString s = "<Teacher>\n";
		s += "	<Name>" + GlobalMembersTimetable_defs.protect(this.name) + "</Name>\n";
		s += "</Teacher>\n";

		return s;
	}
	private QString getDetailedDescription()
	{
		QString s = tr("Teacher");
		s += "\n";
		s += tr("Name=%1", "The name of the teacher").arg(this.name);
		s += "\n";

		return s;
	}
	private QString getDetailedDescriptionWithConstraints(ref Rules r)
	{
		QString s = this.getDetailedDescription();

		s += "--------------------------------------------------\n";
		s += tr("Time constraints directly related to this teacher:");
		s += "\n";
		for (int i = 0; i < r.timeConstraintsList.size(); i++)
		{
			TimeConstraint c = r.timeConstraintsList[i];
			if (c.isRelatedToTeacher(this))
			{
				s += "\n";
				s += c.getDetailedDescription(r);
			}
		}

		s += "--------------------------------------------------\n";
		s += tr("Space constraints directly related to this teacher:");
		s += "\n";
		for (int i = 0; i < r.spaceConstraintsList.size(); i++)
		{
			SpaceConstraint c = r.spaceConstraintsList[i];
			if (c.isRelatedToTeacher(this))
			{
				s += "\n";
				s += c.getDetailedDescription(r);
			}
		}
		s += "--------------------------------------------------\n";

		return s;
	}
}
