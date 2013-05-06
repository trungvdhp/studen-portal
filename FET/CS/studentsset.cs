public static class GlobalMembersStudentsset
{
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


	public const int STUDENTS_SET = 0;
	public const int STUDENTS_YEAR = 1;
	public const int STUDENTS_GROUP = 2;
	public const int STUDENTS_SUBGROUP = 3;

//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
	//class StudentsYear;
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
	//class StudentsGroup;
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
	//class StudentsSubgroup;

//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
	//class Rules;

	public static int yearsAscending(StudentsYear y1, StudentsYear y2)
	{
		return y1.name < y2.name;
	}

	public static int groupsAscending(StudentsGroup g1, StudentsGroup g2)
	{
		return g1.name < g2.name;
	}

	public static int subgroupsAscending(StudentsSubgroup s1, StudentsSubgroup s2)
	{
		return s1.name < s2.name;
	}



//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Timetable gt;
}

/**
This class represents a set of students, for instance years, groups or subgroups.

@author Liviu Lalescu
*/
public class StudentsSet
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(StudentsSet) public: QString name;
	private int numberOfStudents;
	private int type;

	private StudentsSet()
	{
		this.type = GlobalMembersStudentsset.STUDENTS_SET;
		this.numberOfStudents = 0;
	}
	public void Dispose()
	{
	}
}

public class StudentsYear: StudentsSet
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(StudentsYear) public: QList<StudentsGroup*> groupsList;

	private int indexInAugmentedYearsList; //internal

	private StudentsYear() : base()
	{
		this.type = GlobalMembersStudentsset.STUDENTS_YEAR;

		indexInAugmentedYearsList = -1;
	}
	public new void Dispose()
	{
		//it is possible that the removed group to be in another year

		/*while(!groupsList.isEmpty()){
			StudentsGroup* g=groupsList[0];
		
			foreach(StudentsYear* year, gt.rules.yearsList)
				if(year!=this)
					for(int i=0; i<year->groupsList.size(); i++)
						if(year->groupsList[i]==g)
							year->groupsList[i]=NULL;
		
			if(g!=NULL){
				delete groupsList.takeFirst();
			}
			else
				groupsList.removeFirst();
		}*/
		base.Dispose();
	}

	private QString getXmlDescription()
	{
		QString s = "";
		s += "<Year>\n";
		s += "<Name>" + GlobalMembersTimetable_defs.protect(this.name) + "</Name>\n";
		s += "<Number_of_Students>" + CustomFETString.number(this.numberOfStudents) + "</Number_of_Students>\n";
		for (int i = 0; i < this.groupsList.size(); i++)
		{
			StudentsGroup stg = this.groupsList[i];
			s += stg.getXmlDescription();
		}
		s += "</Year>\n";

		return s;
	}
	private QString getDescription()
	{
		QString s = new QString();
		s += tr("YN:%1", "Year name").arg(this.name);
		s += ", ";
		s += tr("NoS:%1", "Number of students").arg(this.numberOfStudents);

		return s;
	}
	private QString getDetailedDescription()
	{
		QString s = "";
		s += tr("Students set - year");
		s += "\n";
		s += tr("Year name=%1").arg(this.name);
		s += "\n";
		s += tr("Number of students=%1").arg(this.numberOfStudents);
		s += "\n";

		return s;
	}
	private QString getDetailedDescriptionWithConstraints(ref Rules r)
	{
		QString s = this.getDetailedDescription();

		s += "--------------------------------------------------\n";
		s += tr("Time constraints directly related to this students year:");
		s += "\n";
		for (int i = 0; i < r.timeConstraintsList.size(); i++)
		{
			TimeConstraint c = r.timeConstraintsList[i];
			if (c.isRelatedToStudentsSet(r, this))
			{
				s += "\n";
				s += c.getDetailedDescription(r);
			}
		}

		s += "--------------------------------------------------\n";
		s += tr("Space constraints directly related to this students year:");
		s += "\n";
		for (int i = 0; i < r.spaceConstraintsList.size(); i++)
		{
			SpaceConstraint c = r.spaceConstraintsList[i];
			if (c.isRelatedToStudentsSet(r, this))
			{
				s += "\n";
				s += c.getDetailedDescription(r);
			}
		}
		s += "--------------------------------------------------\n";

		return s;
	}
}

public class StudentsGroup: StudentsSet
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(StudentsGroup) public: QList<StudentsSubgroup*> subgroupsList;

	private int indexInInternalGroupsList; //internal

	private StudentsGroup() : base()
	{
		this.type = GlobalMembersStudentsset.STUDENTS_GROUP;

		indexInInternalGroupsList = -1;
	}
	public new void Dispose()
	{
		/*while(!subgroupsList.isEmpty()){
			StudentsSubgroup* s=subgroupsList[0];
		
			foreach(StudentsYear* year, gt.rules.yearsList)
				foreach(StudentsGroup* group, year->groupsList)
					if(group!=this)
						for(int i=0; i<group->subgroupsList.size(); i++)
							if(group->subgroupsList[i]==s){
								cout<<"making NULL group->subgroupsList[i]->name=="<<qPrintable(group->subgroupsList[i]->name)<<endl;
								group->subgroupsList[i]=NULL;
							}
							else
								cout<<"ignoring group->subgroupsList[i]->name=="<<qPrintable(group->subgroupsList[i]->name)<<endl;
		
			if(s!=NULL){
				assert(subgroupsList[0]!=NULL);
				delete subgroupsList.takeFirst();
			}
			else
				subgroupsList.removeFirst();
		}*/
		base.Dispose();
	}

	private QString getXmlDescription()
	{
		QString s = "";
		s += "	<Group>\n";
		s += "	<Name>" + GlobalMembersTimetable_defs.protect(this.name) + "</Name>\n";
		s += "	<Number_of_Students>" + CustomFETString.number(this.numberOfStudents) + "</Number_of_Students>\n";
		for (int i = 0; i < this.subgroupsList.size(); i++)
		{
			StudentsSubgroup sts = this.subgroupsList[i];
			s += sts.getXmlDescription();
		}
		s += "	</Group>\n";

		return s;
	}
	private QString getDescription()
	{
		QString s = "";
		s += tr("GN:%1", "Group name").arg(this.name);
		s += ", ";
		s += tr("NoS:%1", "Number of students").arg(this.numberOfStudents);

		return s;
	}
	private QString getDetailedDescription()
	{
		QString s = "";
		s += tr("Students set - group");
		s += "\n";
		s += tr("Group name=%1").arg(this.name);
		s += "\n";
		s += tr("Number of students=%1").arg(this.numberOfStudents);
		s += "\n";

		return s;
	}
	private QString getDetailedDescriptionWithConstraints(ref Rules r)
	{
		QString s = this.getDetailedDescription();

		s += "--------------------------------------------------\n";
		s += tr("Time constraints directly related to this students group:");
		s += "\n";
		for (int i = 0; i < r.timeConstraintsList.size(); i++)
		{
			TimeConstraint c = r.timeConstraintsList[i];
			if (c.isRelatedToStudentsSet(r, this))
			{
				s += "\n";
				s += c.getDetailedDescription(r);
			}
		}

		s += "--------------------------------------------------\n";
		s += tr("Space constraints directly related to this students group:");
		s += "\n";
		for (int i = 0; i < r.spaceConstraintsList.size(); i++)
		{
			SpaceConstraint c = r.spaceConstraintsList[i];
			if (c.isRelatedToStudentsSet(r, this))
			{
				s += "\n";
				s += c.getDetailedDescription(r);
			}
		}
		s += "--------------------------------------------------\n";

		return s;
	}
}

public class StudentsSubgroup: StudentsSet
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(StudentsSubgroup) public: int indexInInternalSubgroupsList;

	private QList<qint16> activitiesForSubgroup = new QList<qint16>();

	private StudentsSubgroup() : base()
	{
		this.type = GlobalMembersStudentsset.STUDENTS_SUBGROUP;

		indexInInternalSubgroupsList = -1;
	}
	public new void Dispose()
	{
		base.Dispose();
	}

	private QString getXmlDescription()
	{
		QString s = "";
		s += "		<Subgroup>\n";
		s += "		<Name>" + GlobalMembersTimetable_defs.protect(this.name) + "</Name>\n";
		s += "		<Number_of_Students>" + CustomFETString.number(this.numberOfStudents) + "</Number_of_Students>\n";
		s += "		</Subgroup>\n";

		return s;
	}
	private QString getDescription()
	{
		QString s = "";
		s += tr("SgN:%1", "Subgroup name").arg(this.name);
		s += ", ";
		s += tr("NoS:%1", "Number of students").arg(this.numberOfStudents);

		return s;
	}
	private QString getDetailedDescription()
	{
		QString s = "";
		s += tr("Students set - subgroup");
		s += "\n";
		s += tr("Subgroup name=%1").arg(this.name);
		s += "\n";
		s += tr("Number of students=%1").arg(this.numberOfStudents);
		s += "\n";

		return s;
	}
	private QString getDetailedDescriptionWithConstraints(ref Rules r)
	{
		QString s = this.getDetailedDescription();

		s += "--------------------------------------------------\n";
		s += tr("Time constraints directly related to this students subgroup:");
		s += "\n";
		for (int i = 0; i < r.timeConstraintsList.size(); i++)
		{
			TimeConstraint c = r.timeConstraintsList[i];
			if (c.isRelatedToStudentsSet(r, this))
			{
				s += "\n";
				s += c.getDetailedDescription(r);
			}
		}

		s += "--------------------------------------------------\n";
		s += tr("Space constraints directly related to this students subgroup:");
		s += "\n";
		for (int i = 0; i < r.spaceConstraintsList.size(); i++)
		{
			SpaceConstraint c = r.spaceConstraintsList[i];
			if (c.isRelatedToStudentsSet(r, this))
			{
				s += "\n";
				s += c.getDetailedDescription(r);
			}
		}
		s += "--------------------------------------------------\n";

		return s;
	}
}

