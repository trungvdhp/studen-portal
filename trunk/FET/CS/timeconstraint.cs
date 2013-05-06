using System.Diagnostics;
using System;

public static class GlobalMembersTimeconstraint
{


	public const int CONSTRAINT_GENERIC_TIME = 0;

	public const int CONSTRAINT_BASIC_COMPULSORY_TIME = 1;
	public const int CONSTRAINT_BREAK_TIMES = 2;

	public const int CONSTRAINT_TEACHER_NOT_AVAILABLE_TIMES = 3;
	public const int CONSTRAINT_TEACHERS_MAX_HOURS_DAILY = 4;
	public const int CONSTRAINT_TEACHER_MAX_DAYS_PER_WEEK = 5;
	public const int CONSTRAINT_TEACHERS_MAX_GAPS_PER_WEEK = 6;
	public const int CONSTRAINT_TEACHER_MAX_GAPS_PER_WEEK = 7;
	public const int CONSTRAINT_TEACHER_MAX_HOURS_DAILY = 8;
	public const int CONSTRAINT_TEACHERS_MAX_HOURS_CONTINUOUSLY = 9;
	public const int CONSTRAINT_TEACHER_MAX_HOURS_CONTINUOUSLY = 10;

	public const int CONSTRAINT_TEACHERS_MIN_HOURS_DAILY = 11;
	public const int CONSTRAINT_TEACHER_MIN_HOURS_DAILY = 12;
	public const int CONSTRAINT_TEACHERS_MAX_GAPS_PER_DAY = 13;
	public const int CONSTRAINT_TEACHER_MAX_GAPS_PER_DAY = 14;

	public const int CONSTRAINT_STUDENTS_EARLY_MAX_BEGINNINGS_AT_SECOND_HOUR = 15;
	public const int CONSTRAINT_STUDENTS_SET_EARLY_MAX_BEGINNINGS_AT_SECOND_HOUR = 16;
	public const int CONSTRAINT_STUDENTS_SET_NOT_AVAILABLE_TIMES = 17;
	public const int CONSTRAINT_STUDENTS_MAX_GAPS_PER_WEEK = 18;
	public const int CONSTRAINT_STUDENTS_SET_MAX_GAPS_PER_WEEK = 19;

	public const int CONSTRAINT_STUDENTS_MAX_HOURS_DAILY = 20;
	public const int CONSTRAINT_STUDENTS_SET_MAX_HOURS_DAILY = 21;
	public const int CONSTRAINT_STUDENTS_MAX_HOURS_CONTINUOUSLY = 22;
	public const int CONSTRAINT_STUDENTS_SET_MAX_HOURS_CONTINUOUSLY = 23;

	public const int CONSTRAINT_STUDENTS_MIN_HOURS_DAILY = 24;
	public const int CONSTRAINT_STUDENTS_SET_MIN_HOURS_DAILY = 25;

	public const int CONSTRAINT_ACTIVITY_ENDS_STUDENTS_DAY = 26;
	public const int CONSTRAINT_ACTIVITY_PREFERRED_STARTING_TIME = 27;
	public const int CONSTRAINT_ACTIVITIES_SAME_STARTING_TIME = 28;
	public const int CONSTRAINT_ACTIVITIES_NOT_OVERLAPPING = 29;
	public const int CONSTRAINT_MIN_DAYS_BETWEEN_ACTIVITIES = 30;
	public const int CONSTRAINT_ACTIVITY_PREFERRED_TIME_SLOTS = 31;
	public const int CONSTRAINT_ACTIVITIES_PREFERRED_TIME_SLOTS = 32;
	public const int CONSTRAINT_ACTIVITY_PREFERRED_STARTING_TIMES = 33;
	public const int CONSTRAINT_ACTIVITIES_PREFERRED_STARTING_TIMES = 34;
	public const int CONSTRAINT_ACTIVITIES_SAME_STARTING_HOUR = 35;
	public const int CONSTRAINT_ACTIVITIES_SAME_STARTING_DAY = 36;
	public const int CONSTRAINT_TWO_ACTIVITIES_CONSECUTIVE = 37;
	public const int CONSTRAINT_TWO_ACTIVITIES_ORDERED = 38;
	public const int CONSTRAINT_MIN_GAPS_BETWEEN_ACTIVITIES = 39;
	public const int CONSTRAINT_SUBACTIVITIES_PREFERRED_TIME_SLOTS = 40;
	public const int CONSTRAINT_SUBACTIVITIES_PREFERRED_STARTING_TIMES = 41;

	public const int CONSTRAINT_TEACHER_INTERVAL_MAX_DAYS_PER_WEEK = 42;
	public const int CONSTRAINT_TEACHERS_INTERVAL_MAX_DAYS_PER_WEEK = 43;
	public const int CONSTRAINT_STUDENTS_SET_INTERVAL_MAX_DAYS_PER_WEEK = 44;
	public const int CONSTRAINT_STUDENTS_INTERVAL_MAX_DAYS_PER_WEEK = 45;

	public const int CONSTRAINT_ACTIVITIES_END_STUDENTS_DAY = 46;

	public const int CONSTRAINT_TWO_ACTIVITIES_GROUPED = 47;

	public const int CONSTRAINT_TEACHERS_ACTIVITY_TAG_MAX_HOURS_CONTINUOUSLY = 48;
	public const int CONSTRAINT_TEACHER_ACTIVITY_TAG_MAX_HOURS_CONTINUOUSLY = 49;
	public const int CONSTRAINT_STUDENTS_ACTIVITY_TAG_MAX_HOURS_CONTINUOUSLY = 50;
	public const int CONSTRAINT_STUDENTS_SET_ACTIVITY_TAG_MAX_HOURS_CONTINUOUSLY = 51;

	public const int CONSTRAINT_TEACHERS_MAX_DAYS_PER_WEEK = 52;

	public const int CONSTRAINT_THREE_ACTIVITIES_GROUPED = 53;
	public const int CONSTRAINT_MAX_DAYS_BETWEEN_ACTIVITIES = 54;

	public const int CONSTRAINT_TEACHERS_MIN_DAYS_PER_WEEK = 55;
	public const int CONSTRAINT_TEACHER_MIN_DAYS_PER_WEEK = 56;

	public const int CONSTRAINT_TEACHERS_ACTIVITY_TAG_MAX_HOURS_DAILY = 57;
	public const int CONSTRAINT_TEACHER_ACTIVITY_TAG_MAX_HOURS_DAILY = 58;
	public const int CONSTRAINT_STUDENTS_ACTIVITY_TAG_MAX_HOURS_DAILY = 59;
	public const int CONSTRAINT_STUDENTS_SET_ACTIVITY_TAG_MAX_HOURS_DAILY = 60;

	public const int CONSTRAINT_STUDENTS_MAX_GAPS_PER_DAY = 61;
	public const int CONSTRAINT_STUDENTS_SET_MAX_GAPS_PER_DAY = 62;

	public const int CONSTRAINT_ACTIVITIES_OCCUPY_MAX_TIME_SLOTS_FROM_SELECTION = 63;
	public const int CONSTRAINT_ACTIVITIES_MAX_SIMULTANEOUS_IN_SELECTED_TIME_SLOTS = 64;

/////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////


	public static QString getActivityDetailedDescription(ref Rules r, int id)
	{
		QString s = new QString();

		int ai;
		for (ai = 0; ai < r.activitiesList.size(); ai++)
			if (r.activitiesList[ai].id == id)
				break;

		if (ai == r.activitiesList.size())
		{
			s += QCoreApplication.translate("Activity", "Invalid (inexistent) id for activity");
			return s;
		}
		Debug.Assert(ai < r.activitiesList.size());

		Activity act = r.activitiesList.at(ai);

		if (act.activityTagsNames.count() > 0)
		{
			s += QCoreApplication.translate("Activity", "T:%1, S:%2, AT:%3, St:%4", "This is an important translation for an activity's detailed description, please take care (it appears in many places in constraints)." + "The abbreviations are: Teachers, Subject, Activity tags, Students. This variant includes activity tags").arg(act.teachersNames.join(",")).arg(act.subjectName).arg(act.activityTagsNames.join(",")).arg(act.studentsNames.join(","));
		}
		else
		{
			s += QCoreApplication.translate("Activity", "T:%1, S:%2, St:%3", "This is an important translation for an activity's detailed description, please take care (it appears in many places in constraints)." + "The abbreviations are: Teachers, Subject, Students. There are no activity tags here").arg(act.teachersNames.join(",")).arg(act.subjectName).arg(act.studentsNames.join(","));
		}
		return s;
	}





	#if ! FET_COMMAND_LINE
	#else
	#endif
	#if FET_COMMAND_LINE
	#else
	#endif
	#if FET_COMMAND_LINE
	#endif


	//for min max functions

	internal static QString trueFalse(bool x)
	{
		if (!x)
			return new QString("false");
		else
			return new QString("true");
	}

	internal static QString yesNoTranslated(bool x)
	{
		if (!x)
			return QCoreApplication.translate("TimeConstraint", "no", "no - meaning negation");
		else
			return QCoreApplication.translate("TimeConstraint", "yes", "yes - meaning affirmative");
	}

	//The following 2 matrices are kept to make the computation faster
	//They are calculated only at the beginning of the computation of the fitness
	//of the solution.
	/*static qint8 subgroupsMatrix[MAX_TOTAL_SUBGROUPS][MAX_DAYS_PER_WEEK][MAX_HOURS_PER_DAY];
	static qint8 teachersMatrix[MAX_TEACHERS][MAX_DAYS_PER_WEEK][MAX_HOURS_PER_DAY];*/
	internal static Matrix3D<qint8> subgroupsMatrix = new Matrix3D<qint8>();
	internal static Matrix3D<qint8> teachersMatrix = new Matrix3D<qint8>();

	internal static int teachers_conflicts = -1;
	internal static int subgroups_conflicts = -1;

	//extern bool breakDayHour[MAX_DAYS_PER_WEEK][MAX_HOURS_PER_DAY];
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Matrix2D<bool> breakDayHour;

	/*extern bool teacherNotAvailableDayHour[MAX_TEACHERS][MAX_DAYS_PER_WEEK][MAX_HOURS_PER_DAY];
	
	extern bool subgroupNotAvailableDayHour[MAX_TOTAL_SUBGROUPS][MAX_DAYS_PER_WEEK][MAX_HOURS_PER_DAY];*/
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Matrix3D<bool> teacherNotAvailableDayHour;

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Matrix3D<bool> subgroupNotAvailableDayHour;
}

/*
File timeconstraint.cpp
*/

/*
Copyright 2002, 2003 Lalescu Liviu.

This file is part of FET.

FET is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

FET is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with FET; if not, write to the Free Software
Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
*/

#if NDEBUG
#endif
/*
File timeconstraint.h
*/

/*
Copyright 2002, 2003 Lalescu Liviu.

This file is part of FET.

FET is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

FET is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with FET; if not, write to the Free Software
Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
*/





//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class Rules;
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class Solution;
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class TimeConstraint;
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class Activity;
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class Teacher;
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class Subject;
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class ActivityTag;
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class StudentsSet;

//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class QWidget;

/**
This class represents a time constraint
*/
public interface TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(TimeConstraint) public: double weightPercentage;
	/**
	The percentage weight of this constraint, 100% compulsory, 0% non-compulsory
	*/

	private bool active;

	private QString comments = new QString();

	/**
	Specifies the type of this constraint (using the above constants).
	*/
	private int type;

	/**
	True for mandatory constraints, false for non-mandatory constraints.
	*/
	//bool compulsory;

	/**
	Dummy constructor - needed for the static array of constraints.
	Any other use should be avoided.
	*/
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	TimeConstraint();

	public virtual void Dispose()

	/**
	DEPRECATED COMMENT
	Constructor - please note that the maximum allowed weight is 100.0
	The reason: unallocated activities must have very big conflict weight,
	and any other restrictions must have much more lower weight,
	so that the timetable can evolve when starting with uninitialized activities.
	*/
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	TimeConstraint(double wp);

	/**
	The function that calculates the fitness of a solution, according to this
	constraint. We need the rules to compute this fitness factor.
	If conflictsString!=NULL,
	it will be initialized with a text explaining where this restriction is broken.
	*/
	double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: virtual double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>& dl, QString* conflictsString=null)=0;
	double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString);

	/**
	Returns an XML description of this constraint
	*/
	QString getXmlDescription(ref Rules r);

	/**
	Computes the internal structure for this constraint.
	
	It returns false if the constraint is an activity related
	one and it depends on only inactive activities.
	*/
	bool computeInternalStructure(QWidget parent, ref Rules r);

	bool hasInactiveActivities(ref Rules r);

	/**
	Returns a small description string for this constraint
	*/
	QString getDescription(ref Rules r);

	/**
	Returns a detailed description string for this constraint
	*/
	QString getDetailedDescription(ref Rules r);

	/**
	Returns true if this constraint is related to this activity
	*/
	bool isRelatedToActivity(ref Rules r, Activity a);

	/**
	Returns true if this constraint is related to this teacher
	*/
	bool isRelatedToTeacher(Teacher t);

	/**
	Returns true if this constraint is related to this subject
	*/
	bool isRelatedToSubject(Subject s);

	/**
	Returns true if this constraint is related to this activity tag
	*/
	bool isRelatedToActivityTag(ActivityTag s);

	/**
	Returns true if this constraint is related to this students set
	*/
	bool isRelatedToStudentsSet(ref Rules r, StudentsSet s);

	bool hasWrongDayOrHour(ref Rules r);
	bool canRepairWrongDayOrHour(ref Rules r);
	bool repairWrongDayOrHour(ref Rules r);
}

/**
This class comprises all the basic compulsory constraints (constraints
which must be fulfilled for any timetable) - the time allocation part
*/
public abstract partial class ConstraintBasicCompulsoryTime: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintBasicCompulsoryTime) public: ConstraintBasicCompulsoryTime();

	private ConstraintBasicCompulsoryTime(double wp) : base(wp)
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_BASIC_COMPULSORY_TIME;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);
		Q_UNUSED(r);

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintBasicCompulsoryTime>\n";
		Debug.Assert(this.weightPercentage == 100.0);
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintBasicCompulsoryTime>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		return begin + tr("Basic compulsory constraints (time)") + ", " + tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage)) + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("These are the basic compulsory constraints (referring to time allocation) for any timetable");
		s += "\n";

		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("The basic time constraints try to avoid:");
		s += "\n";
		s += new QString("- ");
		s += tr("teachers assigned to more than one activity simultaneously");
		s += "\n";
		s += new QString("- ");
		s += tr("students assigned to more than one activity simultaneously");
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		Debug.Assert(r.internalStructureComputed);

		int teachersConflicts;
		int subgroupsConflicts;

		Debug.Assert(weightPercentage == 100.0);

		//This constraint fitness calculation routine is called firstly,
		//so we can compute the teacher and subgroups conflicts faster this way.
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;

			GlobalMembersTimeconstraint.subgroups_conflicts = subgroupsConflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = teachersConflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}
		else
		{
			Debug.Assert(GlobalMembersTimeconstraint.subgroups_conflicts >= 0);
			Debug.Assert(GlobalMembersTimeconstraint.teachers_conflicts >= 0);
			subgroupsConflicts = GlobalMembersTimeconstraint.subgroups_conflicts;
			teachersConflicts = GlobalMembersTimeconstraint.teachers_conflicts;
		}

		int i;
		int dd;

		int unallocated; //unallocated activities
		int late; //late activities
		int nte; //number of teacher exhaustions
		int nse; //number of students exhaustions

		//Part without logging..................................................................
		if (conflictsString == null)
		{
			//Unallocated or late activities
			unallocated = 0;
			late = 0;
			for (i = 0; i < r.nInternalActivities; i++)
			{
				if (c.times[i] == GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
					//Firstly, we consider a big clash each unallocated activity.
					//Needs to be very a large constant, bigger than any other broken constraint.
					unallocated += 10000; //r.internalActivitiesList[i].duration * r.internalActivitiesList[i].nSubgroups *
					//(an unallocated activity for a year is more important than an unallocated activity for a subgroup)
				}
				else
				{
					//Calculates the number of activities that are scheduled too late (in fact we
					//calculate a function that increases as the activity is getting late)
					int h = c.times[i] / r.nDaysPerWeek;
					dd = r.internalActivitiesList[i].duration;
					if (h + dd > r.nHoursPerDay)
					{
						int tmp;
						tmp = 1;
						late += (h + dd - r.nHoursPerDay) * tmp * r.internalActivitiesList[i].iSubgroupsList.count();
						//multiplied with the number
						//of subgroups implied, for seeing the importance of the
						//activity
					}
				}
			}

			Debug.Assert(late == 0);

			//Below, for teachers and students, please remember that 2 means a weekly activity
			//and 1 fortnightly one. So, if the matrix teachersMatrix[teacher][day][hour]==2, it is ok.

			//Calculates the number of teachers exhaustion (when he has to teach more than
			//one activity at the same time)
			/*nte=0;
			for(i=0; i<r.nInternalTeachers; i++)
				for(int j=0; j<r.nDaysPerWeek; j++)
					for(int k=0; k<r.nHoursPerDay; k++){
						int tmp=teachersMatrix[i][j][k]-2;
						if(tmp>0)
							nte+=tmp;
					}*/
			nte = teachersConflicts; //faster

			Debug.Assert(nte == 0);

			//Calculates the number of subgroups exhaustion (a subgroup cannot attend two
			//activities at the same time)
			/*nse=0;
			for(i=0; i<r.nInternalSubgroups; i++)
				for(int j=0; j<r.nDaysPerWeek; j++)
					for(int k=0; k<r.nHoursPerDay; k++){
						int tmp=subgroupsMatrix[i][j][k]-2;
						if(tmp>0)
							nse += tmp;
					}*/
			nse = subgroupsConflicts; //faster

			Debug.Assert(nse == 0);
		}
		//part with logging....................................................................
		else
		{
			//Unallocated or late activities
			unallocated = 0;
			late = 0;
			for (i = 0; i < r.nInternalActivities; i++)
			{
				if (c.times[i] == GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
					//Firstly, we consider a big clash each unallocated activity.
					//Needs to be very a large constant, bigger than any other broken constraint.
					unallocated += 10000; //r.internalActivitiesList[i].duration * r.internalActivitiesList[i].nSubgroups *
					//(an unallocated activity for a year is more important than an unallocated activity for a subgroup)
					if (conflictsString != null)
					{
						QString s = tr("Time constraint basic compulsory broken: unallocated activity with id=%1 (%2)", "%2 is the detailed description of activity - teachers, subject, students").arg(r.internalActivitiesList[i].id).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, r.internalActivitiesList[i].id));
						s += " - ";
						s += tr("this increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100 * 10000));
						//s += "\n";

						dl.append(s);
						cl.append(weightPercentage / 100 * 10000);

						conflictsString += s + "\n";
					}
				}
				else
				{
					//Calculates the number of activities that are scheduled too late (in fact we
					//calculate a function that increases as the activity is getting late)
					int h = c.times[i] / r.nDaysPerWeek;
					dd = r.internalActivitiesList[i].duration;
					if (h + dd > r.nHoursPerDay)
					{
						Debug.Assert(0);

						int tmp;
						tmp = 1;
						late += (h + dd - r.nHoursPerDay) * tmp * r.internalActivitiesList[i].iSubgroupsList.count();
						//multiplied with the number
						//of subgroups implied, for seeing the importance of the
						//activity

						if (conflictsString != null)
						{
							QString s = tr("Time constraint basic compulsory");
							s += ": ";
							s += tr("activity with id=%1 is late.").arg(r.internalActivitiesList[i].id);
							s += " ";
							s += tr("This increases the conflicts total by %1").arg(CustomFETString.number((h + dd - r.nHoursPerDay) * tmp * r.internalActivitiesList[i].iSubgroupsList.count() * weightPercentage / 100));
							s += "\n";

							dl.append(s);
							cl.append((h + dd - r.nHoursPerDay) * tmp * r.internalActivitiesList[i].iSubgroupsList.count() * weightPercentage / 100);

							conflictsString += s + "\n";
						}
					}
				}
			}

			//Below, for teachers and students, please remember that 2 means a weekly activity
			//and 1 fortnightly one. So, if the matrix teachersMatrix[teacher][day][hour]==2,
			//that is ok.

			//Calculates the number of teachers exhaustion (when he has to teach more than
			//one activity at the same time)
			nte = 0;
			for (i = 0; i < r.nInternalTeachers; i++)
				for (int j = 0; j < r.nDaysPerWeek; j++)
					for (int k = 0; k < r.nHoursPerDay; k++)
					{
						int tmp = GlobalMembersTimeconstraint.teachersMatrix[i][j][k] - 1;
						if (tmp > 0)
						{
							if (conflictsString != null)
							{
								QString s = tr("Time constraint basic compulsory");
								s += ": ";
								s += tr("teacher with name %1 has more than one allocated activity on day %2, hour %3").arg(r.internalTeachersList[i].name).arg(r.daysOfTheWeek[j]).arg(r.hoursOfTheDay[k]);
								s += ". ";
								s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(tmp * weightPercentage / 100));

								conflictsString += s + "\n";

								dl.append(s);
								cl.append(tmp * weightPercentage / 100);
							}
							nte += tmp;
						}
					}

			Debug.Assert(nte == 0);

			//Calculates the number of subgroups exhaustion (a subgroup cannot attend two
			//activities at the same time)
			nse = 0;
			for (i = 0; i < r.nInternalSubgroups; i++)
				for (int j = 0; j < r.nDaysPerWeek; j++)
					for (int k = 0; k < r.nHoursPerDay; k++)
					{
						int tmp = GlobalMembersTimeconstraint.subgroupsMatrix[i][j][k] - 1;
						if (tmp > 0)
						{
							if (conflictsString != null)
							{
								QString s = tr("Time constraint basic compulsory");
								s += ": ";
								s += tr("subgroup %1 has more than one allocated activity on day %2, hour %3").arg(r.internalSubgroupsList[i].name).arg(r.daysOfTheWeek[j]).arg(r.hoursOfTheDay[k]);
								s += ". ";
								s += tr("This increases the conflicts total by %1").arg(CustomFETString.number((GlobalMembersTimeconstraint.subgroupsMatrix[i][j][k] - 1) * weightPercentage / 100));

								dl.append(s);
								cl.append((GlobalMembersTimeconstraint.subgroupsMatrix[i][j][k] - 1) * weightPercentage / 100);

								conflictsString += s + "\n";
							}
							nse += tmp;
						}
					}

			Debug.Assert(nse == 0);
		}

		/*if(nte!=teachersConflicts){
			cout<<"nte=="<<nte<<", teachersConflicts=="<<teachersConflicts<<endl;
			cout<<c.getTeachersMatrix(r, teachersMatrix)<<endl;
		}
		if(nse!=subgroupsConflicts){
			cout<<"nse=="<<nse<<", subgroupsConflicts=="<<subgroupsConflicts<<endl;
			cout<<c.getSubgroupsMatrix(r, subgroupsMatrix)<<endl;
		}*/

		/*assert(nte==teachersConflicts); //just a check, works only on logged fitness calculation
		assert(nse==subgroupsConflicts);*/

		//return int (ceil ( weight * (unallocated + late + nte + nse) ) ); //conflicts factor
		return weightPercentage / 100 * (unallocated + late + nte + nse); //conflicts factor
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(a);
		Q_UNUSED(r);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0);

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0); //should check hasWrongDayOrHour, firstly

		return true;
	}
}

public abstract class ConstraintTeacherNotAvailableTimes: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTeacherNotAvailableTimes) public: QList<int> days;
	private QList<int> hours = new QList<int>();

	/**
	The teacher's name
	*/
	private QString teacher = new QString();

	/**
	The teacher's id, or index in the rules
	*/
	private int teacher_ID;


	/////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintTeacherNotAvailableTimes() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_NOT_AVAILABLE_TIMES;
	}

	private ConstraintTeacherNotAvailableTimes(double wp, QString tn, QList<int> d, QList<int> h) : base(wp)
	{
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->teacher=tn;
		this.teacher.CopyFrom(tn);
		Debug.Assert(d.count() == h.count());
		this.days = d;
		this.hours = h;
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_NOT_AVAILABLE_TIMES;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		this.teacher_ID = r.searchTeacher(this.teacher);

		if (this.teacher_ID < 0)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint teacher not available times is wrong because it refers to inexistent teacher." + " Please correct it (removing it might be a solution). Please report potential bug. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}

		Debug.Assert(days.count() == hours.count());
		for (int k = 0; k < days.count(); k++)
		{
			if (this.days.at(k) >= r.nDaysPerWeek)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint teacher not available times is wrong because it refers to removed day. Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
			if (this.hours.at(k) >= r.nHoursPerDay)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint teacher not available times is wrong because an hour is too late (after the last acceptable slot). Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
		}

		Debug.Assert(this.teacher_ID >= 0);
		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		QString s = "<ConstraintTeacherNotAvailableTimes>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Teacher>" + GlobalMembersTimetable_defs.protect(this.teacher) + "</Teacher>\n";

		s += "	<Number_of_Not_Available_Times>" + CustomFETString.number(this.days.count()) + "</Number_of_Not_Available_Times>\n";
		Debug.Assert(days.count() == hours.count());
		for (int i = 0; i < days.count(); i++)
		{
			s += "	<Not_Available_Time>\n";
			if (this.days.at(i) >= 0)
				s += "		<Day>" + GlobalMembersTimetable_defs.protect(r.daysOfTheWeek[this.days.at(i)]) + "</Day>\n";
			if (this.hours.at(i) >= 0)
				s += "		<Hour>" + GlobalMembersTimetable_defs.protect(r.hoursOfTheDay[this.hours.at(i)]) + "</Hour>\n";
			s += "	</Not_Available_Time>\n";
		}

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTeacherNotAvailableTimes>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = tr("Teacher not available");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("T:%1", "Teacher").arg(this.teacher);
		s += ", ";

		s += tr("NA at:", "Not available at");
		s += " ";
		Debug.Assert(days.count() == hours.count());
		for (int i = 0; i < days.count(); i++)
		{
			if (this.days.at(i) >= 0)
			{
				s += r.daysOfTheWeek[this.days.at(i)];
				s += " ";
			}
			if (this.hours.at(i) >= 0)
			{
				s += r.hoursOfTheDay[this.hours.at(i)];
			}
			if (i < days.count() - 1)
				s += "; ";
		}

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		QString s = tr("Time constraint");
		s += "\n";
		s += tr("A teacher is not available");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Teacher=%1").arg(this.teacher);
		s += "\n";

		s += tr("Not available at:");
		s += "\n";
		Debug.Assert(days.count() == hours.count());
		for (int i = 0; i < days.count(); i++)
		{
			if (this.days.at(i) >= 0)
			{
				s += r.daysOfTheWeek[this.days.at(i)];
				s += " ";
			}
			if (this.hours.at(i) >= 0)
			{
				s += r.hoursOfTheDay[this.hours.at(i)];
			}
			if (i < days.count() - 1)
				s += "; ";
		}
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString *conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;

			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		//Calculates the number of hours when the teacher is supposed to be teaching, but he is not available
		//This function consideres all the hours, I mean if there are for example 5 weekly courses
		//scheduled on that hour (which is already a broken compulsory restriction - we only
		//are allowed 1 weekly course for a certain teacher at a certain hour) we calculate
		//5 broken restrictions for that function.
		//TODO: decide if it is better to consider only 2 or 10 as a return value in this particular case
		//(currently it is 10)
		int tch = this.teacher_ID;

		int nbroken;

		nbroken = 0;

		Debug.Assert(days.count() == hours.count());
		for (int k = 0; k < days.count(); k++)
		{
			int d = days.at(k);
			int h = hours.at(k);

			if (GlobalMembersTimeconstraint.teachersMatrix[tch][d][h] > 0)
			{
				nbroken += GlobalMembersTimeconstraint.teachersMatrix[tch][d][h];

				if (conflictsString != null)
				{
					QString s = tr("Time constraint teacher not available");
					s += " ";
					s += tr("broken for teacher: %1 on day %2, hour %3").arg(r.internalTeachersList[tch].name).arg(r.daysOfTheWeek[d]).arg(r.hoursOfTheDay[h]);
					s += ". ";
					s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(GlobalMembersTimeconstraint.teachersMatrix[tch][d][h] * weightPercentage / 100));

					dl.append(s);
					cl.append(GlobalMembersTimeconstraint.teachersMatrix[tch][d][h] * weightPercentage / 100);

					conflictsString += s + "\n";
				}
			}
		}

		if (weightPercentage == 100.0)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(a);
		Q_UNUSED(r);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		if (this.teacher == t.name)
			return true;
		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(days.count() == hours.count());

		for (int i = 0; i < days.count(); i++)
			if (days.at(i)<0 || days.at(i) >= r.nDaysPerWeek || hours.at(i)<0 || hours.at(i) >= r.nHoursPerDay)
				return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		Debug.Assert(days.count() == hours.count());

		QList<int> newDays = new QList<int>();
		QList<int> newHours = new QList<int>();

		for (int i = 0; i < days.count(); i++)
			if (days.at(i) >= 0 && days.at(i)<r.nDaysPerWeek && hours.at(i) >= 0 && hours.at(i) < r.nHoursPerDay)
			{
				newDays.append(days.at(i));
				newHours.append(hours.at(i));
			}

		days = newDays;
		hours = newHours;

		r.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(r);

		return true;
	}
}

public abstract class ConstraintStudentsSetNotAvailableTimes: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintStudentsSetNotAvailableTimes) public: QList<int> days;
	private QList<int> hours = new QList<int>();

	/**
	The name of the students
	*/
	private QString students = new QString();

	/**
	The subgroups involved in this restriction
	*/
	private QList<int> iSubgroupsList = new QList<int>();


	/////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintStudentsSetNotAvailableTimes() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_NOT_AVAILABLE_TIMES;
	}

	private ConstraintStudentsSetNotAvailableTimes(double wp, QString sn, QList<int> d, QList<int> h) : base(wp)
	{
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->students = sn;
		this.students.CopyFrom(sn);
		Debug.Assert(d.count() == h.count());
		this.days = d;
		this.hours = h;
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_NOT_AVAILABLE_TIMES;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		StudentsSet ss = r.searchAugmentedStudentsSet(this.students);

		if (ss == null)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint students set not available is wrong because it refers to inexistent students set." + " Please correct it (removing it might be a solution). Please report potential bug. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}

		Debug.Assert(days.count() == hours.count());
		for (int k = 0; k < days.count(); k++)
		{
			if (this.days.at(k) >= r.nDaysPerWeek)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint students set not available times is wrong because it refers to removed day. Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
			if (this.hours.at(k) >= r.nHoursPerDay)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint students set not available times is wrong because an hour is too late (after the last acceptable slot). Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
		}

		Debug.Assert(ss);

		this.iSubgroupsList.clear();
		if (ss.type == GlobalMembersStudentsset.STUDENTS_SUBGROUP)
		{
			int tmp;
			tmp = ((StudentsSubgroup)ss).indexInInternalSubgroupsList;
			Debug.Assert(tmp >= 0);
			Debug.Assert(tmp < r.nInternalSubgroups);
			if (!this.iSubgroupsList.contains(tmp))
				this.iSubgroupsList.append(tmp);
		}
		else if (ss.type == GlobalMembersStudentsset.STUDENTS_GROUP)
		{
			StudentsGroup stg = (StudentsGroup)ss;
			for (int i = 0; i < stg.subgroupsList.size(); i++)
			{
				StudentsSubgroup sts = stg.subgroupsList[i];
				int tmp;
				tmp = sts.indexInInternalSubgroupsList;
				Debug.Assert(tmp >= 0);
				Debug.Assert(tmp < r.nInternalSubgroups);
				if (!this.iSubgroupsList.contains(tmp))
					this.iSubgroupsList.append(tmp);
			}
		}
		else if (ss.type == GlobalMembersStudentsset.STUDENTS_YEAR)
		{
			StudentsYear sty = (StudentsYear)ss;
			for (int i = 0; i < sty.groupsList.size(); i++)
			{
				StudentsGroup stg = sty.groupsList[i];
				for (int j = 0; j < stg.subgroupsList.size(); j++)
				{
					StudentsSubgroup sts = stg.subgroupsList[j];
					int tmp;
					tmp = sts.indexInInternalSubgroupsList;
					Debug.Assert(tmp >= 0);
					Debug.Assert(tmp < r.nInternalSubgroups);
					if (!this.iSubgroupsList.contains(tmp))
						this.iSubgroupsList.append(tmp);
				}
			}
		}
		else
			Debug.Assert(0);
		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		QString s = "<ConstraintStudentsSetNotAvailableTimes>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Students>" + GlobalMembersTimetable_defs.protect(this.students) + "</Students>\n";

		s += "	<Number_of_Not_Available_Times>" + CustomFETString.number(this.days.count()) + "</Number_of_Not_Available_Times>\n";
		Debug.Assert(days.count() == hours.count());
		for (int i = 0; i < days.count(); i++)
		{
			s += "	<Not_Available_Time>\n";
			if (this.days.at(i) >= 0)
				s += "		<Day>" + GlobalMembersTimetable_defs.protect(r.daysOfTheWeek[this.days.at(i)]) + "</Day>\n";
			if (this.hours.at(i) >= 0)
				s += "		<Hour>" + GlobalMembersTimetable_defs.protect(r.hoursOfTheDay[this.hours.at(i)]) + "</Hour>\n";
			s += "	</Not_Available_Time>\n";
		}

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintStudentsSetNotAvailableTimes>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s = tr("Students set not available");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("St:%1", "Students").arg(this.students);
		s += ", ";

		s += tr("NA at:", "Not available at");
		s += " ";
		Debug.Assert(days.count() == hours.count());
		for (int i = 0; i < days.count(); i++)
		{
			if (this.days.at(i) >= 0)
			{
				s += r.daysOfTheWeek[this.days.at(i)];
				s += " ";
			}
			if (this.hours.at(i) >= 0)
			{
				s += r.hoursOfTheDay[this.hours.at(i)];
			}
			if (i < days.count() - 1)
				s += "; ";
		}

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		QString s = tr("Time constraint");
		s += "\n";
		s += tr("A students set is not available");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		s += tr("Students=%1").arg(this.students);
		s += "\n";

		s += tr("Not available at:");
		s += "\n";

		Debug.Assert(days.count() == hours.count());
		for (int i = 0; i < days.count(); i++)
		{
			if (this.days.at(i) >= 0)
			{
				s += r.daysOfTheWeek[this.days.at(i)];
				s += " ";
			}
			if (this.hours.at(i) >= 0)
			{
				s += r.hoursOfTheDay[this.hours.at(i)];
			}
			if (i < days.count() - 1)
				s += "; ";
		}
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString *conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		nbroken = 0;
		for (int m = 0; m < this.iSubgroupsList.count(); m++)
		{
			int sbg = this.iSubgroupsList.at(m);

			Debug.Assert(days.count() == hours.count());
			for (int k = 0; k < days.count(); k++)
			{
				int d = days.at(k);
				int h = hours.at(k);

				if (GlobalMembersTimeconstraint.subgroupsMatrix[sbg][d][h] > 0)
				{
					nbroken += GlobalMembersTimeconstraint.subgroupsMatrix[sbg][d][h];

					if (conflictsString != null)
					{
						QString s = tr("Time constraint students set not available");
						s += " ";
						s += tr("broken for subgroup: %1 on day %2, hour %3").arg(r.internalSubgroupsList[sbg].name).arg(r.daysOfTheWeek[d]).arg(r.hoursOfTheDay[h]);
						s += ". ";
						s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(GlobalMembersTimeconstraint.subgroupsMatrix[sbg][d][h] * weightPercentage / 100));

						dl.append(s);
						cl.append(GlobalMembersTimeconstraint.subgroupsMatrix[sbg][d][h] * weightPercentage / 100);

						conflictsString += s + "\n";
					}
				}
			}
		}

		if (weightPercentage == 100.0)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(a);
		Q_UNUSED(r);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		return r.setsShareStudents(this.students, s.name);
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(days.count() == hours.count());

		for (int i = 0; i < days.count(); i++)
			if (days.at(i)<0 || days.at(i) >= r.nDaysPerWeek || hours.at(i)<0 || hours.at(i) >= r.nHoursPerDay)
				return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		Debug.Assert(days.count() == hours.count());

		QList<int> newDays = new QList<int>();
		QList<int> newHours = new QList<int>();

		for (int i = 0; i < days.count(); i++)
			if (days.at(i) >= 0 && days.at(i)<r.nDaysPerWeek && hours.at(i) >= 0 && hours.at(i) < r.nHoursPerDay)
			{
				newDays.append(days.at(i));
				newHours.append(hours.at(i));
			}

		days = newDays;
		hours = newHours;

		r.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(r);

		return true;
	}
}

public abstract class ConstraintActivitiesSameStartingTime: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintActivitiesSameStartingTime) public: int n_activities;
	/**
	The number of activities involved in this constraint
	*/

	/**
	The activities involved in this constraint (id)
	*/
	private QList<int> activitiesId = new QList<int>();
	//int activitiesId[MAX_CONSTRAINT_ACTIVITIES_SAME_STARTING_TIME];

	/**
	The number of activities involved in this constraint - internal structure
	*/
	private int _n_activities;

	/**
	The activities involved in this constraint (indexes in the rules) - internal structure
	*/
	//int _activities[MAX_CONSTRAINT_ACTIVITIES_SAME_STARTING_TIME];
	private QList<int> _activities = new QList<int>();


	/////////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintActivitiesSameStartingTime() : base()
	{
		type = GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_SAME_STARTING_TIME;
	}

	/**
	Constructor, using:
	the weight, the number of activities and the list of activities' id-s.
	*/
	//ConstraintActivitiesSameStartingTime(double wp, int n_act, const int act[]);
	private ConstraintActivitiesSameStartingTime(double wp, int nact, QList<int> act) : base(wp)
	{
		Debug.Assert(nact >= 2);
		Debug.Assert(act.count() == nact);
		this.n_activities = nact;
		this.activitiesId.clear();
		for (int i = 0; i < nact; i++)
			this.activitiesId.append(act.at(i));

		this.type = GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_SAME_STARTING_TIME;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		//compute the indices of the activities,
		//based on their unique ID

		Debug.Assert(this.n_activities == this.activitiesId.count());

		this._activities.clear();
		for (int i = 0; i < this.n_activities; i++)
		{
			int j;
			Activity act;
			for (j = 0; j < r.nInternalActivities; j++)
			{
				act = r.internalActivitiesList[j];
				if (act.id == this.activitiesId[i])
				{
					this._activities.append(j);
					break;
				}
			}
		}
		this._n_activities = this._activities.count();

		if (this._n_activities <= 1)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (because you need 2 or more activities. Please correct it):\n%1").arg(this.getDetailedDescription(ref r)));
			//assert(0);
			return false;
		}

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		int count = 0;

		for (int i = 0; i < this.n_activities; i++)
			if (r.inactiveActivities.contains(this.activitiesId[i]))
				count++;

		if (this.n_activities - count <= 1)
			return true;
		else
			return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintActivitiesSameStartingTime>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Number_of_Activities>" + CustomFETString.number(this.n_activities) + "</Number_of_Activities>\n";
		for (int i = 0; i < this.n_activities; i++)
			s += "	<Activity_Id>" + CustomFETString.number(this.activitiesId[i]) + "</Activity_Id>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintActivitiesSameStartingTime>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Activities same starting time");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("NA:%1", "Number of activities").arg(this.n_activities);
		s += ", ";
		for (int i = 0; i < this.n_activities; i++)
		{
			s += tr("Id:%1", "Id of activity").arg(this.activitiesId[i]);
			if (i < this.n_activities - 1)
				s += ", ";
		}

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		QString s = new QString();

		s = tr("Time constraint");
		s += "\n";
		s += tr("Activities must have the same starting time");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Number of activities=%1").arg(this.n_activities);
		s += "\n";
		for (int i = 0; i < this.n_activities; i++)
		{
			s += tr("Activity with id=%1 (%2)", "%1 is the id, %2 is the detailed description of the activity").arg(this.activitiesId[i]).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activitiesId[i]));
			s += "\n";
		}

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		Debug.Assert(r.internalStructureComputed);

		int nbroken;

		//We do not use the matrices 'subgroupsMatrix' nor 'teachersMatrix'.

		//sum the differences in the scheduled time for all pairs of activities.

		//without logging
		if (conflictsString == null)
		{
			nbroken = 0;
			for (int i = 1; i < this._n_activities; i++)
			{
				int t1 = c.times[this._activities[i]];
				if (t1 != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
					int day1 = t1 % r.nDaysPerWeek;
					int hour1 = t1 / r.nDaysPerWeek;
					for (int j = 0; j < i; j++)
					{
						int t2 = c.times[this._activities[j]];
						if (t2 != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
						{
							int day2 = t2 % r.nDaysPerWeek;
							int hour2 = t2 / r.nDaysPerWeek;
							int tmp = 0;

							tmp = Math.Abs(day1 - day2) + Math.Abs(hour1 - hour2);

							if (tmp > 0)
								tmp = 1;

							nbroken += tmp;
						}
					}
				}
			}
		}
		//with logging
		else
		{
			nbroken = 0;
			for (int i = 1; i < this._n_activities; i++)
			{
				int t1 = c.times[this._activities[i]];
				if (t1 != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
					int day1 = t1 % r.nDaysPerWeek;
					int hour1 = t1 / r.nDaysPerWeek;
					for (int j = 0; j < i; j++)
					{
						int t2 = c.times[this._activities[j]];
						if (t2 != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
						{
							int day2 = t2 % r.nDaysPerWeek;
							int hour2 = t2 / r.nDaysPerWeek;
							int tmp = 0;

							tmp = Math.Abs(day1 - day2) + Math.Abs(hour1 - hour2);

							if (tmp > 0)
								tmp = 1;

							nbroken += tmp;

							if (tmp > 0 && conflictsString != null)
							{
								QString s = tr("Time constraint activities same starting time broken, because activity with id=%1 (%2) is not at the same starting time with activity with id=%3 (%4)", "%1 is the id, %2 is the detailed description of the activity, %3 id, %4 det. descr.").arg(this.activitiesId[i]).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activitiesId[i])).arg(this.activitiesId[j]).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activitiesId[j]));
								s += ". ";
								s += tr("Conflicts factor increase=%1").arg(CustomFETString.number(tmp * weightPercentage / 100));

								dl.append(s);
								cl.append(tmp * weightPercentage / 100);

								conflictsString += s + "\n";
							}
						}
					}
				}
			}
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100 * nbroken;
	}

	private void removeUseless(ref Rules r)
	{
		//remove the activitiesId which no longer exist (used after the deletion of an activity)

		Debug.Assert(this.n_activities == this.activitiesId.count());

		QList<int> tmpList = new QList<int>();

		for (int i = 0; i < this.n_activities; i++)
		{
			for (int k = 0; k < r.activitiesList.size(); k++)
			{
				Activity act = r.activitiesList[k];
				if (act.id == this.activitiesId[i])
				{
					tmpList.append(act.id);
					break;
				}
			}
		}

		this.activitiesId = tmpList;
		this.n_activities = this.activitiesId.count();

		r.internalStructureComputed = false;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);

		for (int i = 0; i < this.n_activities; i++)
			if (this.activitiesId[i] == a.id)
				return true;
		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0);

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0); //should check hasWrongDayOrHour, firstly

		return true;
	}
}

/**
This is a constraint.
It aims at scheduling a set of activities so that they do not overlap.
The number of conflicts is considered the number of overlapping
hours.
*/
public abstract class ConstraintActivitiesNotOverlapping: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintActivitiesNotOverlapping) public: int n_activities;
	/**
	The number of activities involved in this constraint
	*/

	/**
	The activities involved in this constraint (id)
	*/
	private QList<int> activitiesId = new QList<int>();
	//int activitiesId[MAX_CONSTRAINT_ACTIVITIES_NOT_OVERLAPPING];

	/**
	The number of activities involved in this constraint - internal structure
	*/
	private int _n_activities;

	/**
	The activities involved in this constraint (index in the rules) - internal structure
	*/
	//int _activities[MAX_CONSTRAINT_ACTIVITIES_NOT_OVERLAPPING];
	private QList<int> _activities = new QList<int>();


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintActivitiesNotOverlapping() : base()
	{
		type = GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_NOT_OVERLAPPING;
	}

	/**
	Constructor, using:
	the weight, the number of activities and the list of activities.
	*/
	private ConstraintActivitiesNotOverlapping(double wp, int nact, QList<int> act) : base(wp)
	{
		  Debug.Assert(nact >= 2);
		  Debug.Assert(act.count() == nact);
		this.n_activities = nact;
		this.activitiesId.clear();
		for (int i = 0; i < nact; i++)
			this.activitiesId.append(act.at(i));

		this.type = GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_NOT_OVERLAPPING;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		//compute the indices of the activities,
		//based on their unique ID

		Debug.Assert(this.n_activities == this.activitiesId.count());

		this._activities.clear();
		for (int i = 0; i < this.n_activities; i++)
		{
			int j;
			Activity act;
			for (j = 0; j < r.nInternalActivities; j++)
			{
				act = r.internalActivitiesList[j];
				if (act.id == this.activitiesId[i])
				{
					this._activities.append(j);
					break;
				}
			}
		}
		this._n_activities = this._activities.count();

		if (this._n_activities <= 1)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (because you need 2 or more activities. Please correct it):\n%1").arg(this.getDetailedDescription(ref r)));
			//assert(0);
			return false;
		}

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		int count = 0;

		for (int i = 0; i < this.n_activities; i++)
			if (r.inactiveActivities.contains(this.activitiesId[i]))
				count++;

		if (this.n_activities - count <= 1)
			return true;
		else
			return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintActivitiesNotOverlapping>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Number_of_Activities>" + CustomFETString.number(this.n_activities) + "</Number_of_Activities>\n";
		for (int i = 0; i < this.n_activities; i++)
			s += "	<Activity_Id>" + CustomFETString.number(this.activitiesId[i]) + "</Activity_Id>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintActivitiesNotOverlapping>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Activities not overlapping");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("NA:%1", "Number of activities").arg(this.n_activities);
		s += ", ";
		for (int i = 0; i < this.n_activities; i++)
		{
			s += tr("Id:%1", "Id of activity").arg(this.activitiesId[i]);
			if (i < this.n_activities - 1)
				s += ", ";
		}

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		QString s = tr("Time constraint");
		s += "\n";
		s += tr("Activities must not overlap");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Number of activities=%1").arg(this.n_activities);
		s += "\n";
		for (int i = 0; i < this.n_activities; i++)
		{
			s += tr("Activity with id=%1 (%2)", "%1 is the id, %2 is the detailed description of the activity").arg(this.activitiesId[i]).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activitiesId[i]));
			s += "\n";
		}

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		Debug.Assert(r.internalStructureComputed);

		int nbroken;

		//We do not use the matrices 'subgroupsMatrix' nor 'teachersMatrix'.

		//sum the overlapping hours for all pairs of activities.
		//without logging
		if (conflictsString == null)
		{
			nbroken = 0;
			for (int i = 1; i < this._n_activities; i++)
			{
				int t1 = c.times[this._activities[i]];
				if (t1 != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
					int day1 = t1 % r.nDaysPerWeek;
					int hour1 = t1 / r.nDaysPerWeek;
					int duration1 = r.internalActivitiesList[this._activities[i]].duration;

					for (int j = 0; j < i; j++)
					{
						int t2 = c.times[this._activities[j]];
						if (t2 != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
						{
							int day2 = t2 % r.nDaysPerWeek;
							int hour2 = t2 / r.nDaysPerWeek;
							int duration2 = r.internalActivitiesList[this._activities[j]].duration;

							//the number of overlapping hours
							int tt = 0;
							if (day1 == day2)
							{
								int start = GlobalMembersGenerate.max(hour1, hour2);
								int stop = min(hour1 + duration1, hour2 + duration2);
								if (stop > start)
									tt += stop - start;
							}

							nbroken += tt;
						}
					}
				}
			}
		}
		//with logging
		else
		{
			nbroken = 0;
			for (int i = 1; i < this._n_activities; i++)
			{
				int t1 = c.times[this._activities[i]];
				if (t1 != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
					int day1 = t1 % r.nDaysPerWeek;
					int hour1 = t1 / r.nDaysPerWeek;
					int duration1 = r.internalActivitiesList[this._activities[i]].duration;

					for (int j = 0; j < i; j++)
					{
						int t2 = c.times[this._activities[j]];
						if (t2 != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
						{
							int day2 = t2 % r.nDaysPerWeek;
							int hour2 = t2 / r.nDaysPerWeek;
							int duration2 = r.internalActivitiesList[this._activities[j]].duration;

							//the number of overlapping hours
							int tt = 0;
							if (day1 == day2)
							{
								int start = GlobalMembersGenerate.max(hour1, hour2);
								int stop = min(hour1 + duration1, hour2 + duration2);
								if (stop > start)
									tt += stop - start;
							}

							//The overlapping hours, considering weekly activities more important than fortnightly ones
							int tmp = tt;

							nbroken += tmp;

							if (tt > 0 && conflictsString != null)
							{

								QString s = tr("Time constraint activities not overlapping broken: activity with id=%1 (%2) overlaps with activity with id=%3 (%4) on a number of %5 periods", "%1 is the id, %2 is the detailed description of the activity, %3 id, %4 det. descr.").arg(this.activitiesId[i]).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activitiesId[i])).arg(this.activitiesId[j]).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activitiesId[j])).arg(tt);
								s += ", ";
								s += tr("conflicts factor increase=%1").arg(CustomFETString.number(tmp * weightPercentage / 100));

								dl.append(s);
								cl.append(tmp * weightPercentage / 100);

								conflictsString += s + "\n";
							}
						}
					}
				}
			}
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100 * nbroken;
	}

	private void removeUseless(ref Rules r)
	{
		//remove the activitiesId which no longer exist (used after the deletion of an activity)

		Debug.Assert(this.n_activities == this.activitiesId.count());

		QList<int> tmpList = new QList<int>();

		for (int i = 0; i < this.n_activities; i++)
		{
			for (int k = 0; k < r.activitiesList.size(); k++)
			{
				Activity act = r.activitiesList[k];
				if (act.id == this.activitiesId[i])
				{
					tmpList.append(act.id);
					break;
				}
			}
		}

		this.activitiesId = tmpList;
		this.n_activities = this.activitiesId.count();

		r.internalStructureComputed = false;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);

		for (int i = 0; i < this.n_activities; i++)
			if (this.activitiesId[i] == a.id)
				return true;
		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0);

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0); //should check hasWrongDayOrHour, firstly

		return true;
	}
}

/**
This is a constraint.
It aims at scheduling a set of activities so that they
have a minimum of N days between any two of them.
*/
public abstract class ConstraintMinDaysBetweenActivities: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintMinDaysBetweenActivities) public: bool consecutiveIfSameDay;

	/**
	The number of activities involved in this constraint
	*/
	private int n_activities;

	/**
	The activities involved in this constraint (id)
	*/
	private QList<int> activitiesId = new QList<int>();
	//int activitiesId[MAX_CONSTRAINT_MIN_DAYS_BETWEEN_ACTIVITIES];

	/**
	The number of minimum days between each 2 activities
	*/
	private int minDays;

	//internal structure (redundant)

	/**
	The number of activities involved in this constraint - internal structure
	*/
	private int _n_activities;

	/**
	The activities involved in this constraint (index in the rules) - internal structure
	*/
	private QList<int> _activities = new QList<int>();
	//int _activities[MAX_CONSTRAINT_MIN_DAYS_BETWEEN_ACTIVITIES];


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintMinDaysBetweenActivities() : base()
	{
		type = GlobalMembersTimeconstraint.CONSTRAINT_MIN_DAYS_BETWEEN_ACTIVITIES;
	}

	/**
	Constructor, using:
	the weight, the number of activities and the list of activities.
	*/
	//ConstraintMinDaysBetweenActivities(double wp, bool adjacentIfBroken, int n_act, const int act[], int n);
	private ConstraintMinDaysBetweenActivities(double wp, bool cisd, int nact, QList<int> act, int n) : base(wp)
	{
		this.consecutiveIfSameDay = cisd;

		Debug.Assert(nact >= 2);
		Debug.Assert(act.count() == nact);
		this.n_activities = nact;
		this.activitiesId.clear();
		for (int i = 0; i < nact; i++)
			this.activitiesId.append(act.at(i));

		Debug.Assert(n > 0);
		this.minDays = n;

		this.type = GlobalMembersTimeconstraint.CONSTRAINT_MIN_DAYS_BETWEEN_ACTIVITIES;
	}

	/**
	Comparison operator - to be sure that we do not introduce duplicates
	*/
	private static bool operator == (ConstraintMinDaysBetweenActivities ImpliedObject, ref ConstraintMinDaysBetweenActivities c)
	{
		Debug.Assert(ImpliedObject.n_activities == ImpliedObject.activitiesId.count());
		Debug.Assert(c.n_activities == c.activitiesId.count());

		if (ImpliedObject.n_activities != c.n_activities)
			return false;
		for (int i = 0; i < ImpliedObject.n_activities; i++)
			if (ImpliedObject.activitiesId[i] != c.activitiesId[i])
				return false;
		if (ImpliedObject.minDays != c.minDays)
			return false;
		if (ImpliedObject.weightPercentage != c.weightPercentage)
			return false;
		if (ImpliedObject.consecutiveIfSameDay != c.consecutiveIfSameDay)
			return false;
		return true;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		//compute the indices of the activities,
		//based on their unique ID

		Debug.Assert(this.n_activities == this.activitiesId.count());

		this._activities.clear();
		for (int i = 0; i < this.n_activities; i++)
		{
			int j;
			Activity act;
			for (j = 0; j < r.nInternalActivities; j++)
			{
				act = r.internalActivitiesList[j];
				if (act.id == this.activitiesId[i])
				{
					this._activities.append(j);
					break;
				}
			}
		}
		this._n_activities = this._activities.count();

		if (this._n_activities <= 1)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (because you need 2 or more activities. Please correct it):\n%1").arg(this.getDetailedDescription(ref r)));
			//assert(0);
			return false;
		}

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		int count = 0;

		for (int i = 0; i < this.n_activities; i++)
			if (r.inactiveActivities.contains(this.activitiesId[i]))
				count++;

		if (this.n_activities - count <= 1)
			return true;
		else
			return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintMinDaysBetweenActivities>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Consecutive_If_Same_Day>";
		s += GlobalMembersSpaceconstraint.trueFalse(this.consecutiveIfSameDay);
		s += "</Consecutive_If_Same_Day>\n";
		s += "	<Number_of_Activities>" + CustomFETString.number(this.n_activities) + "</Number_of_Activities>\n";
		for (int i = 0; i < this.n_activities; i++)
			s += "	<Activity_Id>" + CustomFETString.number(this.activitiesId[i]) + "</Activity_Id>\n";
		s += "	<MinDays>" + CustomFETString.number(this.minDays) + "</MinDays>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintMinDaysBetweenActivities>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Min days between activities");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("NA:%1", "Number of activities").arg(this.n_activities);
		s += ", ";
		for (int i = 0; i < this.n_activities; i++)
		{
			s += tr("Id:%1", "Id of activity").arg(this.activitiesId[i]);
			s += ", ";
		}
		s += tr("mD:%1", "Min days").arg(this.minDays);
		s += ", ";
		s += tr("CSD:%1", "Consecutive if same day").arg(GlobalMembersSpaceconstraint.yesNoTranslated(this.consecutiveIfSameDay));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		QString s = tr("Time constraint");
		s += "\n";
		s += tr("Minimum number of days between activities");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Number of activities=%1").arg(this.n_activities);
		s += "\n";
		for (int i = 0; i < this.n_activities; i++)
		{
			s += tr("Activity with id=%1 (%2)", "%1 is the id, %2 is the detailed description of the activity").arg(this.activitiesId[i]).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activitiesId[i]));
			s += "\n";
		}
		s += tr("Minimum number of days=%1").arg(this.minDays);
		s += "\n";
		s += tr("Consecutive if same day=%1").arg(GlobalMembersSpaceconstraint.yesNoTranslated(this.consecutiveIfSameDay));
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		Debug.Assert(r.internalStructureComputed);

		int nbroken;

		//We do not use the matrices 'subgroupsMatrix' nor 'teachersMatrix'.

		//sum the overlapping hours for all pairs of activities.
		//without logging
		if (conflictsString == null)
		{
			nbroken = 0;
			for (int i = 1; i < this._n_activities; i++)
			{
				int t1 = c.times[this._activities[i]];
				if (t1 != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
					int day1 = t1 % r.nDaysPerWeek;
					int hour1 = t1 / r.nDaysPerWeek;
					int duration1 = r.internalActivitiesList[this._activities[i]].duration;

					for (int j = 0; j < i; j++)
					{
						int t2 = c.times[this._activities[j]];
						if (t2 != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
						{
							int day2 = t2 % r.nDaysPerWeek;
							int hour2 = t2 / r.nDaysPerWeek;
							int duration2 = r.internalActivitiesList[this._activities[j]].duration;

							int tmp;
							int tt = 0;
							int dist = Math.Abs(day1 - day2);
							if (dist < minDays)
							{
								tt = minDays - dist;

								if (this.consecutiveIfSameDay && day1 == day2)
									Debug.Assert(day1 == day2 && (hour1 + duration1 == hour2 || hour2 + duration2 == hour1));
							}

							tmp = tt;

							nbroken += tmp;
						}
					}
				}
			}
		}
		//with logging
		else
		{
			nbroken = 0;
			for (int i = 1; i < this._n_activities; i++)
			{
				int t1 = c.times[this._activities[i]];
				if (t1 != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
					int day1 = t1 % r.nDaysPerWeek;
					int hour1 = t1 / r.nDaysPerWeek;
					int duration1 = r.internalActivitiesList[this._activities[i]].duration;

					for (int j = 0; j < i; j++)
					{
						int t2 = c.times[this._activities[j]];
						if (t2 != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
						{
							int day2 = t2 % r.nDaysPerWeek;
							int hour2 = t2 / r.nDaysPerWeek;
							int duration2 = r.internalActivitiesList[this._activities[j]].duration;

							int tmp;
							int tt = 0;
							int dist = Math.Abs(day1 - day2);

							if (dist < minDays)
							{
								tt = minDays - dist;

								if (this.consecutiveIfSameDay && day1 == day2)
									Debug.Assert(day1 == day2 && (hour1 + duration1 == hour2 || hour2 + duration2 == hour1));
							}

							tmp = tt;

							nbroken += tmp;

							if (tt > 0 && conflictsString != null)
							{
								QString s = tr("Time constraint min days between activities broken: activity with id=%1 (%2) conflicts with activity with id=%3 (%4), being %5 days too close, on days %6 and %7", "%1 is the id, %2 is the detailed description of the activity, %3 id, %4 det. descr. Close here means near").arg(this.activitiesId[i]).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activitiesId[i])).arg(this.activitiesId[j]).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activitiesId[j])).arg(tt).arg(r.daysOfTheWeek[day1]).arg(r.daysOfTheWeek[day2]);
								 ;

								s += ", ";
								s += tr("conflicts factor increase=%1").arg(CustomFETString.number(tmp * weightPercentage / 100));
								s += ".";

								if (this.consecutiveIfSameDay && day1 == day2)
								{
									s += " ";
									s += tr("The activities are placed consecutively in the timetable, because you selected this option" + " in case the activities are in the same day");
								}

								dl.append(s);
								cl.append(tmp * weightPercentage / 100);

								conflictsString += s + "\n";
							}
						}
					}
				}
			}
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100 * nbroken;
	}

	private void removeUseless(ref Rules r)
	{
		//remove the activitiesId which no longer exist (used after the deletion of an activity)

		Debug.Assert(this.n_activities == this.activitiesId.count());

		QList<int> tmpList = new QList<int>();

		for (int i = 0; i < this.n_activities; i++)
		{
			for (int k = 0; k < r.activitiesList.size(); k++)
			{
				Activity act = r.activitiesList[k];
				if (act.id == this.activitiesId[i])
				{
					tmpList.append(act.id);
					break;
				}
			}
		}

		this.activitiesId = tmpList;
		this.n_activities = this.activitiesId.count();

		r.internalStructureComputed = false;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);

		for (int i = 0; i < this.n_activities; i++)
			if (this.activitiesId[i] == a.id)
				return true;
		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (minDays >= r.nDaysPerWeek)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (minDays >= r.nDaysPerWeek)
			minDays = r.nDaysPerWeek - 1;

		return true;
	}
}

public abstract class ConstraintMaxDaysBetweenActivities: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintMaxDaysBetweenActivities) public: int n_activities;
	/**
	The number of activities involved in this constraint
	*/

	/**
	The activities involved in this constraint (id)
	*/
	private QList<int> activitiesId = new QList<int>();

	/**
	The number of maximum days between each 2 activities
	*/
	private int maxDays;

	//internal structure (redundant)

	/**
	The number of activities involved in this constraint - internal structure
	*/
	private int _n_activities;

	/**
	The activities involved in this constraint (index in the rules) - internal structure
	*/
	private QList<int> _activities = new QList<int>();


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintMaxDaysBetweenActivities() : base()
	{
		type = GlobalMembersTimeconstraint.CONSTRAINT_MAX_DAYS_BETWEEN_ACTIVITIES;
	}

	/**
	Constructor, using:
	the weight, the number of activities and the list of activities.
	*/
	private ConstraintMaxDaysBetweenActivities(double wp, int nact, QList<int> act, int n) : base(wp)
	{
		  Debug.Assert(nact >= 2);
		  Debug.Assert(act.count() == nact);
		this.n_activities = nact;
		this.activitiesId.clear();
		for (int i = 0; i < nact; i++)
			this.activitiesId.append(act.at(i));

		Debug.Assert(n >= 0);
		this.maxDays = n;

		this.type = GlobalMembersTimeconstraint.CONSTRAINT_MAX_DAYS_BETWEEN_ACTIVITIES;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		//compute the indices of the activities,
		//based on their unique ID

		Debug.Assert(this.n_activities == this.activitiesId.count());

		this._activities.clear();
		for (int i = 0; i < this.n_activities; i++)
		{
			int j;
			Activity act;
			for (j = 0; j < r.nInternalActivities; j++)
			{
				act = r.internalActivitiesList[j];
				if (act.id == this.activitiesId[i])
				{
					this._activities.append(j);
					break;
				}
			}
		}
		this._n_activities = this._activities.count();

		if (this._n_activities <= 1)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (because you need 2 or more activities. Please correct it):\n%1").arg(this.getDetailedDescription(ref r)));
			//assert(0);
			return false;
		}

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		int count = 0;

		for (int i = 0; i < this.n_activities; i++)
			if (r.inactiveActivities.contains(this.activitiesId[i]))
				count++;

		if (this.n_activities - count <= 1)
			return true;
		else
			return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintMaxDaysBetweenActivities>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Number_of_Activities>" + CustomFETString.number(this.n_activities) + "</Number_of_Activities>\n";
		for (int i = 0; i < this.n_activities; i++)
			s += "	<Activity_Id>" + CustomFETString.number(this.activitiesId[i]) + "</Activity_Id>\n";
		s += "	<MaxDays>" + CustomFETString.number(this.maxDays) + "</MaxDays>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintMaxDaysBetweenActivities>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Max days between activities");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("NA:%1", "Number of activities").arg(this.n_activities);
		s += ", ";
		for (int i = 0; i < this.n_activities; i++)
		{
			s += tr("Id:%1", "Id of activity").arg(this.activitiesId[i]);
			s += ", ";
		}
		s += tr("MD:%1", "Abbreviation for maximum days").arg(this.maxDays);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		QString s = tr("Time constraint");
		s += "\n";
		s += tr("Maximum number of days between activities");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Number of activities=%1").arg(this.n_activities);
		s += "\n";
		for (int i = 0; i < this.n_activities; i++)
		{
			s += tr("Activity with id=%1 (%2)", "%1 is the id, %2 is the detailed description of the activity").arg(this.activitiesId[i]).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activitiesId[i]));
			s += "\n";
		}
		s += tr("Maximum number of days=%1").arg(this.maxDays);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		Debug.Assert(r.internalStructureComputed);

		int nbroken;

		//We do not use the matrices 'subgroupsMatrix' nor 'teachersMatrix'.

		//sum the overlapping hours for all pairs of activities.
		//without logging
		if (conflictsString == null)
		{
			nbroken = 0;
			for (int i = 1; i < this._n_activities; i++)
			{
				int t1 = c.times[this._activities[i]];
				if (t1 != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
					int day1 = t1 % r.nDaysPerWeek;
					//int hour1=t1/r.nDaysPerWeek;
					//int duration1=r.internalActivitiesList[this->_activities[i]].duration;

					for (int j = 0; j < i; j++)
					{
						int t2 = c.times[this._activities[j]];
						if (t2 != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
						{
							int day2 = t2 % r.nDaysPerWeek;
							//int hour2=t2/r.nDaysPerWeek;
							//int duration2=r.internalActivitiesList[this->_activities[j]].duration;

							int tmp;
							int tt = 0;
							int dist = Math.Abs(day1 - day2);
							if (dist > maxDays)
							{
								tt = dist - maxDays;

								//if(this->consecutiveIfSameDay && day1==day2)
								//	assert( day1==day2 && (hour1+duration1==hour2 || hour2+duration2==hour1) );
							}

							tmp = tt;

							nbroken += tmp;
						}
					}
				}
			}
		}
		//with logging
		else
		{
			nbroken = 0;
			for (int i = 1; i < this._n_activities; i++)
			{
				int t1 = c.times[this._activities[i]];
				if (t1 != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
					int day1 = t1 % r.nDaysPerWeek;
					//int hour1=t1/r.nDaysPerWeek;
					//int duration1=r.internalActivitiesList[this->_activities[i]].duration;

					for (int j = 0; j < i; j++)
					{
						int t2 = c.times[this._activities[j]];
						if (t2 != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
						{
							int day2 = t2 % r.nDaysPerWeek;
							//int hour2=t2/r.nDaysPerWeek;
							//int duration2=r.internalActivitiesList[this->_activities[j]].duration;

							int tmp;
							int tt = 0;
							int dist = Math.Abs(day1 - day2);

							if (dist > maxDays)
							{
								tt = dist - maxDays;

								//if(this->consecutiveIfSameDay && day1==day2)
								//	assert( day1==day2 && (hour1+duration1==hour2 || hour2+duration2==hour1) );
							}

							tmp = tt;

							nbroken += tmp;

							if (tt > 0 && conflictsString != null)
							{
								QString s = tr("Time constraint max days between activities broken: activity with id=%1 (%2) conflicts with activity with id=%3 (%4), being %5 days too far away" + ", on days %6 and %7", "%1 is the id, %2 is the detailed description of the activity, %3 id, %4 det. descr.").arg(this.activitiesId[i]).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activitiesId[i])).arg(this.activitiesId[j]).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activitiesId[j])).arg(tt).arg(r.daysOfTheWeek[day1]).arg(r.daysOfTheWeek[day2]);

								s += ", ";
								s += tr("conflicts factor increase=%1").arg(CustomFETString.number(tmp * weightPercentage / 100));
								s += ".";

								dl.append(s);
								cl.append(tmp * weightPercentage / 100);

								conflictsString += s + "\n";
							}
						}
					}
				}
			}
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100 * nbroken;
	}

	private void removeUseless(ref Rules r)
	{
		//remove the activitiesId which no longer exist (used after the deletion of an activity)

		Debug.Assert(this.n_activities == this.activitiesId.count());

		QList<int> tmpList = new QList<int>();

		for (int i = 0; i < this.n_activities; i++)
		{
			for (int k = 0; k < r.activitiesList.size(); k++)
			{
				Activity act = r.activitiesList[k];
				if (act.id == this.activitiesId[i])
				{
					tmpList.append(act.id);
					break;
				}
			}
		}

		this.activitiesId = tmpList;
		this.n_activities = this.activitiesId.count();

		r.internalStructureComputed = false;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);

		for (int i = 0; i < this.n_activities; i++)
			if (this.activitiesId[i] == a.id)
				return true;
		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxDays >= r.nDaysPerWeek)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxDays >= r.nDaysPerWeek)
			maxDays = r.nDaysPerWeek - 1;

		return true;
	}
}

public abstract class ConstraintMinGapsBetweenActivities: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintMinGapsBetweenActivities) public: int n_activities;
	/**
	The number of activities involved in this constraint
	*/

	/**
	The activities involved in this constraint (id)
	*/
	private QList<int> activitiesId = new QList<int>();

	/**
	The number of minimum gaps between each 2 activities, if on the same day
	*/
	private int minGaps;

	//internal structure (redundant)

	/**
	The number of activities involved in this constraint - internal structure
	*/
	private int _n_activities;

	/**
	The activities involved in this constraint (index in the rules) - internal structure
	*/
	private QList<int> _activities = new QList<int>();


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintMinGapsBetweenActivities() : base()
	{
		type = GlobalMembersTimeconstraint.CONSTRAINT_MIN_GAPS_BETWEEN_ACTIVITIES;
	}

	/**
	Constructor, using:
	the weight, the number of activities and the list of activities.
	*/
	//ConstraintMinGapsBetweenActivities(double wp, int n_act, const int act[], int ngaps);
	private ConstraintMinGapsBetweenActivities(double wp, int nact, QList<int> actList, int ngaps) : base(wp)
	{
		this.n_activities = nact;
		Debug.Assert(nact == actList.count());
		this.activitiesId.clear();
		for (int i = 0; i < nact; i++)
			this.activitiesId.append(actList.at(i));

		Debug.Assert(ngaps > 0);
		this.minGaps = ngaps;

		this.type = GlobalMembersTimeconstraint.CONSTRAINT_MIN_GAPS_BETWEEN_ACTIVITIES;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		//compute the indices of the activities,
		//based on their unique ID

		Debug.Assert(this.n_activities == this.activitiesId.count());

		this._activities.clear();
		for (int i = 0; i < this.n_activities; i++)
		{
			int j;
			Activity act;
			for (j = 0; j < r.nInternalActivities; j++)
			{
				act = r.internalActivitiesList[j];
				if (act.id == this.activitiesId[i])
				{
					this._activities.append(j);
					break;
				}
			}
		}
		this._n_activities = this._activities.count();

		if (this._n_activities <= 1)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (because you need 2 or more activities. Please correct it):\n%1").arg(this.getDetailedDescription(ref r)));
			//assert(0);
			return false;
		}

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		int count = 0;

		for (int i = 0; i < this.n_activities; i++)
			if (r.inactiveActivities.contains(this.activitiesId[i]))
				count++;

		if (this.n_activities - count <= 1)
			return true;
		else
			return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintMinGapsBetweenActivities>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Number_of_Activities>" + CustomFETString.number(this.n_activities) + "</Number_of_Activities>\n";
		for (int i = 0; i < this.n_activities; i++)
			s += "	<Activity_Id>" + CustomFETString.number(this.activitiesId[i]) + "</Activity_Id>\n";
		s += "	<MinGaps>" + CustomFETString.number(this.minGaps) + "</MinGaps>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintMinGapsBetweenActivities>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Min gaps between activities");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("NA:%1", "Number of activities").arg(this.n_activities);
		s += ", ";
		for (int i = 0; i < this.n_activities; i++)
		{
			s += tr("Id:%1", "Id of activity").arg(this.activitiesId[i]);
			s += ", ";
		}
		s += tr("mG:%1", "Minimum number of gaps").arg(this.minGaps);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		QString s = tr("Time constraint");
		s += "\n";
		s += tr("Minimum gaps between activities (if activities on the same day)");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Number of activities=%1").arg(this.n_activities);
		s += "\n";
		for (int i = 0; i < this.n_activities; i++)
		{
			s += tr("Activity with id=%1 (%2)", "%1 is the id, %2 is the detailed description of the activity").arg(this.activitiesId[i]).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activitiesId[i]));
			s += "\n";
		}
		s += tr("Minimum number of gaps=%1").arg(this.minGaps);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		Debug.Assert(r.internalStructureComputed);

		int nbroken;

		//We do not use the matrices 'subgroupsMatrix' nor 'teachersMatrix'.

		nbroken = 0;
		for (int i = 1; i < this._n_activities; i++)
		{
			int t1 = c.times[this._activities[i]];
			if (t1 != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
				int day1 = t1 % r.nDaysPerWeek;
				int hour1 = t1 / r.nDaysPerWeek;
				int duration1 = r.internalActivitiesList[this._activities[i]].duration;

				for (int j = 0; j < i; j++)
				{
					int t2 = c.times[this._activities[j]];
					if (t2 != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
					{
						int day2 = t2 % r.nDaysPerWeek;
						int hour2 = t2 / r.nDaysPerWeek;
						int duration2 = r.internalActivitiesList[this._activities[j]].duration;

						int tmp;
						int tt = 0;
						int dist = Math.Abs(day1 - day2);

						if (dist == 0) //same day
						{
							Debug.Assert(day1 == day2);
							if (hour2 >= hour1)
							{
								//assert(hour1+duration1<=hour2); not true for activities which are not incompatible
								if (hour1 + duration1 + minGaps > hour2)
									tt = (hour1 + duration1 + minGaps) - hour2;
							}
							else
							{
								//assert(hour2+duration2<=hour1); not true for activities which are not incompatible
								if (hour2 + duration2 + minGaps > hour1)
									tt = (hour2 + duration2 + minGaps) - hour1;
							}
						}

						tmp = tt;

						nbroken += tmp;

						if (tt > 0 && conflictsString != null)
						{
							QString s = tr("Time constraint min gaps between activities broken: activity with id=%1 (%2) conflicts with activity with id=%3 (%4), they are on the same day %5 and there are %6 extra hours between them", "%1 is the id, %2 is the detailed description of the activity, %3 id, %4 det. descr.").arg(this.activitiesId[i]).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activitiesId[i])).arg(this.activitiesId[j]).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activitiesId[j])).arg(r.daysOfTheWeek[day1]).arg(tt);

							s += ", ";
							s += tr("conflicts factor increase=%1").arg(CustomFETString.number(tmp * weightPercentage / 100));
							s += ".";

							dl.append(s);
							cl.append(tmp * weightPercentage / 100);

							conflictsString += s + "\n";
						}
					}
				}
			}
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100 * nbroken;
	}

	private void removeUseless(ref Rules r)
	{
		//remove the activitiesId which no longer exist (used after the deletion of an activity)

		Debug.Assert(this.n_activities == this.activitiesId.count());

		QList<int> tmpList = new QList<int>();

		for (int i = 0; i < this.n_activities; i++)
		{
			for (int k = 0; k < r.activitiesList.size(); k++)
			{
				Activity act = r.activitiesList[k];
				if (act.id == this.activitiesId[i])
				{
					tmpList.append(act.id);
					break;
				}
			}
		}

		this.activitiesId = tmpList;
		this.n_activities = this.activitiesId.count();

		r.internalStructureComputed = false;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);

		for (int i = 0; i < this.n_activities; i++)
			if (this.activitiesId[i] == a.id)
				return true;
		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (minGaps > r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (minGaps > r.nHoursPerDay)
			minGaps = r.nHoursPerDay;

		return true;
	}
}

/**
This is a constraint, aimed at obtaining timetables
which do not allow more than X hours in a day for any teacher
*/
public abstract class ConstraintTeachersMaxHoursDaily: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTeachersMaxHoursDaily) public: int maxHoursDaily;
	/**
	The maximum hours daily
	*/


	///////////////////////////////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintTeachersMaxHoursDaily() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHERS_MAX_HOURS_DAILY;
	}

	private ConstraintTeachersMaxHoursDaily(double wp, int maxhours) : base(wp)
	{
		Debug.Assert(maxhours > 0);
		this.maxHoursDaily = maxhours;

		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHERS_MAX_HOURS_DAILY;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintTeachersMaxHoursDaily>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Maximum_Hours_Daily>" + CustomFETString.number(this.maxHoursDaily) + "</Maximum_Hours_Daily>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTeachersMaxHoursDaily>\n";
		return s;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);
		Q_UNUSED(r);

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Teachers max hours daily"), s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("MH:%1", "Maximum hours (daily)").arg(this.maxHoursDaily);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("All teachers must respect the maximum number of hours daily");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Maximum hours daily=%1").arg(this.maxHoursDaily);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		//without logging
		if (conflictsString == null)
		{
			nbroken = 0;
			for (int i = 0; i < r.nInternalTeachers; i++)
			{
				for (int d = 0; d < r.nDaysPerWeek; d++)
				{
					int n_hours_daily = 0;
					for (int h = 0; h < r.nHoursPerDay; h++)
						if (GlobalMembersTimeconstraint.teachersMatrix[i][d][h] > 0)
							n_hours_daily++;

					if (n_hours_daily > this.maxHoursDaily)
						nbroken++;
				}
			}
		}
		//with logging
		else
		{
			nbroken = 0;
			for (int i = 0; i < r.nInternalTeachers; i++)
			{
				for (int d = 0; d < r.nDaysPerWeek; d++)
				{
					int n_hours_daily = 0;
					for (int h = 0; h < r.nHoursPerDay; h++)
						if (GlobalMembersTimeconstraint.teachersMatrix[i][d][h] > 0)
							n_hours_daily++;

					if (n_hours_daily > this.maxHoursDaily)
					{
						nbroken++;

						if (conflictsString != null)
						{
							QString s = (tr("Time constraint teachers max %1 hours daily broken for teacher %2, on day %3, length=%4.").arg(CustomFETString.number(this.maxHoursDaily)).arg(r.internalTeachersList[i].name).arg(r.daysOfTheWeek[d]).arg(n_hours_daily)) + " " + (tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100)));

							dl.append(s);
							cl.append(weightPercentage / 100);

							conflictsString += s + "\n";
						}
					}
				}
			}
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return true;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxHoursDaily > r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxHoursDaily > r.nHoursPerDay)
			maxHoursDaily = r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintTeacherMaxHoursDaily: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTeacherMaxHoursDaily) public: int maxHoursDaily;
	/**
	The maximum hours daily
	*/

	private QString teacherName = new QString();

	private int teacher_ID;


	///////////////////////////////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintTeacherMaxHoursDaily() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_MAX_HOURS_DAILY;
	}

	private ConstraintTeacherMaxHoursDaily(double wp, int maxhours, QString teacher) : base(wp)
	{
		Debug.Assert(maxhours > 0);
		this.maxHoursDaily = maxhours;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->teacherName=teacher;
		this.teacherName.CopyFrom(teacher);

		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_MAX_HOURS_DAILY;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintTeacherMaxHoursDaily>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Teacher_Name>" + GlobalMembersTimetable_defs.protect(this.teacherName) + "</Teacher_Name>\n";
		s += "	<Maximum_Hours_Daily>" + CustomFETString.number(this.maxHoursDaily) + "</Maximum_Hours_Daily>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTeacherMaxHoursDaily>\n";
		return s;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);

		this.teacher_ID = r.searchTeacher(this.teacherName);
		Debug.Assert(this.teacher_ID >= 0);
		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Teacher max hours daily");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("T:%1", "Teacher").arg(this.teacherName);
		s += ", ";
		s += tr("MH:%1", "Maximum hours (daily)").arg(this.maxHoursDaily);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("A teacher must respect the maximum number of hours daily");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Teacher=%1").arg(this.teacherName);
		s += "\n";
		s += tr("Maximum hours daily=%1").arg(this.maxHoursDaily);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		//without logging
		if (conflictsString == null)
		{
			nbroken = 0;
			int i = this.teacher_ID;
			for (int d = 0; d < r.nDaysPerWeek; d++)
			{
				int n_hours_daily = 0;
				for (int h = 0; h < r.nHoursPerDay; h++)
					if (GlobalMembersTimeconstraint.teachersMatrix[i][d][h] > 0)
						n_hours_daily++;

				if (n_hours_daily > this.maxHoursDaily)
				{
					nbroken++;
				}
			}
		}
		//with logging
		else
		{
			nbroken = 0;
			int i = this.teacher_ID;
			for (int d = 0; d < r.nDaysPerWeek; d++)
			{
				int n_hours_daily = 0;
				for (int h = 0; h < r.nHoursPerDay; h++)
					if (GlobalMembersTimeconstraint.teachersMatrix[i][d][h] > 0)
						n_hours_daily++;

				if (n_hours_daily > this.maxHoursDaily)
				{
					nbroken++;

					if (conflictsString != null)
					{
						QString s = (tr("Time constraint teacher max %1 hours daily broken for teacher %2, on day %3, length=%4.").arg(CustomFETString.number(this.maxHoursDaily)).arg(r.internalTeachersList[i].name).arg(r.daysOfTheWeek[d]).arg(n_hours_daily)) + " " + (tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100)));

						dl.append(s);
						cl.append(weightPercentage / 100);

						conflictsString += s + "\n";
					}
				}
			}
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		if (this.teacherName == t.name)
			return true;
		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxHoursDaily > r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxHoursDaily > r.nHoursPerDay)
			maxHoursDaily = r.nHoursPerDay;

		return true;
	}
}

/**
This is a constraint, aimed at obtaining timetables
which do not allow more than X hours in a row for any teacher
*/
public abstract class ConstraintTeachersMaxHoursContinuously: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTeachersMaxHoursContinuously) public: int maxHoursContinuously;
	/**
	The maximum hours continuously
	*/


	///////////////////////////////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintTeachersMaxHoursContinuously() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHERS_MAX_HOURS_CONTINUOUSLY;
	}

	private ConstraintTeachersMaxHoursContinuously(double wp, int maxhours) : base(wp)
	{
		Debug.Assert(maxhours > 0);
		this.maxHoursContinuously = maxhours;

		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHERS_MAX_HOURS_CONTINUOUSLY;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintTeachersMaxHoursContinuously>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Maximum_Hours_Continuously>" + CustomFETString.number(this.maxHoursContinuously) + "</Maximum_Hours_Continuously>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTeachersMaxHoursContinuously>\n";
		return s;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);
		Q_UNUSED(r);

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Teachers max hours continuously");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("MH:%1", "Maximum hours (continuously)").arg(this.maxHoursContinuously);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("All teachers must respect the maximum number of hours continuously");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Maximum hours continuously=%1").arg(this.maxHoursContinuously);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		nbroken = 0;
		for (int i = 0; i < r.nInternalTeachers; i++)
		{
			for (int d = 0; d < r.nDaysPerWeek; d++)
			{
				int nc = 0;
				for (int h = 0; h < r.nHoursPerDay; h++)
				{
					if (GlobalMembersTimeconstraint.teachersMatrix[i][d][h] > 0)
						nc++;
					else
					{
						if (nc > this.maxHoursContinuously)
						{
							nbroken++;

							if (conflictsString != null)
							{
								QString s = (tr("Time constraint teachers max %1 hours continuously broken for teacher %2, on day %3, length=%4.").arg(CustomFETString.number(this.maxHoursContinuously)).arg(r.internalTeachersList[i].name).arg(r.daysOfTheWeek[d]).arg(nc)) + " " + (tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100)));

								dl.append(s);
								cl.append(weightPercentage / 100);

								conflictsString += s + "\n";
							}
						}

						nc = 0;
					}
				}

				if (nc > this.maxHoursContinuously)
				{
					nbroken++;

					if (conflictsString != null)
					{
						QString s = (tr("Time constraint teachers max %1 hours continuously broken for teacher %2, on day %3, length=%4.").arg(CustomFETString.number(this.maxHoursContinuously)).arg(r.internalTeachersList[i].name).arg(r.daysOfTheWeek[d]).arg(nc)) + " " + (tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100)));

						dl.append(s);
						cl.append(weightPercentage / 100);

						conflictsString += s + "\n";
					}
				}
			}
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return true;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxHoursContinuously > r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxHoursContinuously > r.nHoursPerDay)
			maxHoursContinuously = r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintTeacherMaxHoursContinuously: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTeacherMaxHoursContinuously) public: int maxHoursContinuously;
	/**
	The maximum hours continuously
	*/

	private QString teacherName = new QString();

	private int teacher_ID;


	///////////////////////////////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintTeacherMaxHoursContinuously() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_MAX_HOURS_CONTINUOUSLY;
	}

	private ConstraintTeacherMaxHoursContinuously(double wp, int maxhours, QString teacher) : base(wp)
	{
		Debug.Assert(maxhours > 0);
		this.maxHoursContinuously = maxhours;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->teacherName=teacher;
		this.teacherName.CopyFrom(teacher);

		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_MAX_HOURS_CONTINUOUSLY;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintTeacherMaxHoursContinuously>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Teacher_Name>" + GlobalMembersTimetable_defs.protect(this.teacherName) + "</Teacher_Name>\n";
		s += "	<Maximum_Hours_Continuously>" + CustomFETString.number(this.maxHoursContinuously) + "</Maximum_Hours_Continuously>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTeacherMaxHoursContinuously>\n";
		return s;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);

		this.teacher_ID = r.searchTeacher(this.teacherName);
		Debug.Assert(this.teacher_ID >= 0);
		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Teacher max hours continuously");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("T:%1", "Teacher").arg(this.teacherName);
		s += ", ";
		s += tr("MH:%1", "Maximum hours continuously").arg(this.maxHoursContinuously);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("A teacher must respect the maximum number of hours continuously");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Teacher=%1").arg(this.teacherName);
		s += "\n";
		s += tr("Maximum hours continuously=%1").arg(this.maxHoursContinuously);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		nbroken = 0;
		int i = this.teacher_ID;
		for (int d = 0; d < r.nDaysPerWeek; d++)
		{
			int nc = 0;
			for (int h = 0; h < r.nHoursPerDay; h++)
			{
				if (GlobalMembersTimeconstraint.teachersMatrix[i][d][h] > 0)
					nc++;
				else
				{
					if (nc > this.maxHoursContinuously)
					{
						nbroken++;

						if (conflictsString != null)
						{
							QString s = (tr("Time constraint teacher max %1 hours continuously broken for teacher %2, on day %3, length=%4.").arg(CustomFETString.number(this.maxHoursContinuously)).arg(r.internalTeachersList[i].name).arg(r.daysOfTheWeek[d]).arg(nc)) + " " + (tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100)));

							dl.append(s);
							cl.append(weightPercentage / 100);

							conflictsString += s + "\n";
						}
					}

					nc = 0;
				}
			}

			if (nc > this.maxHoursContinuously)
			{
				nbroken++;

				if (conflictsString != null)
				{
					QString s = (tr("Time constraint teacher max %1 hours continuously broken for teacher %2, on day %3, length=%4.").arg(CustomFETString.number(this.maxHoursContinuously)).arg(r.internalTeachersList[i].name).arg(r.daysOfTheWeek[d]).arg(nc)) + " " + (tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100)));

					dl.append(s);
					cl.append(weightPercentage / 100);

					conflictsString += s + "\n";
				}
			}
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		if (this.teacherName == t.name)
			return true;
		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxHoursContinuously > r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxHoursContinuously > r.nHoursPerDay)
			maxHoursContinuously = r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintTeachersActivityTagMaxHoursContinuously: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTeachersActivityTagMaxHoursContinuously) public: int maxHoursContinuously;
	/**
	The maximum hours continuously
	*/

	private QString activityTagName = new QString();

	private int activityTagIndex;

	private QList<int> canonicalTeachersList = new QList<int>();


	///////////////////////////////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintTeachersActivityTagMaxHoursContinuously() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHERS_ACTIVITY_TAG_MAX_HOURS_CONTINUOUSLY;
	}

	private ConstraintTeachersActivityTagMaxHoursContinuously(double wp, int maxhours, QString activityTag) : base(wp)
	{
		Debug.Assert(maxhours > 0);
		this.maxHoursContinuously = maxhours;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->activityTagName=activityTag;
		this.activityTagName.CopyFrom(activityTag);

		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHERS_ACTIVITY_TAG_MAX_HOURS_CONTINUOUSLY;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintTeachersActivityTagMaxHoursContinuously>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Activity_Tag_Name>" + GlobalMembersTimetable_defs.protect(this.activityTagName) + "</Activity_Tag_Name>\n";
		s += "	<Maximum_Hours_Continuously>" + CustomFETString.number(this.maxHoursContinuously) + "</Maximum_Hours_Continuously>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTeachersActivityTagMaxHoursContinuously>\n";
		return s;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);

		this.activityTagIndex = r.searchActivityTag(this.activityTagName);
		Debug.Assert(this.activityTagIndex >= 0);

		this.canonicalTeachersList.clear();
		for (int i = 0; i < r.nInternalTeachers; i++)
		{
			bool found = false;

			Teacher tch = r.internalTeachersList[i];
			foreach (int actIndex, tch.activitiesForTeacher)
			{
				if (r.internalActivitiesList[actIndex].iActivityTagsSet.contains(this.activityTagIndex))
				{
					found = true;
					break;
				}
			}

			if (found)
				this.canonicalTeachersList.append(i);
		}

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Teachers for activity tag %1 have max %2 hours continuously").arg(this.activityTagName).arg(this.maxHoursContinuously);
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("All teachers, for an activity tag, must respect the maximum number of hours continuously");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Activity tag=%1").arg(this.activityTagName);
		s += "\n";
		s += tr("Maximum hours continuously=%1").arg(this.maxHoursContinuously);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		nbroken = 0;
		foreach (int i, this.canonicalTeachersList)
		{
			Teacher tch = r.internalTeachersList[i];
			int[,] crtTeacherTimetableActivityTag = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK, GlobalMembersTimetable_defs.MAX_HOURS_PER_DAY];
			for (int d = 0; d < r.nDaysPerWeek; d++)
				for (int h = 0; h < r.nHoursPerDay; h++)
					crtTeacherTimetableActivityTag[d, h] = -1;
			foreach (int ai, tch.activitiesForTeacher)if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
				int d = c.times[ai] % r.nDaysPerWeek;
				int h = c.times[ai] / r.nDaysPerWeek;
				for (int dur = 0; dur < r.internalActivitiesList[ai].duration; dur++)
				{
					Debug.Assert(h + dur < r.nHoursPerDay);
					Debug.Assert(crtTeacherTimetableActivityTag[d, h + dur] == -1);
					if (r.internalActivitiesList[ai].iActivityTagsSet.contains(this.activityTagIndex))
						crtTeacherTimetableActivityTag[d, h + dur] = this.activityTagIndex;
				}
			}

			for (int d = 0; d < r.nDaysPerWeek; d++)
			{
				int nc = 0;
				for (int h = 0; h < r.nHoursPerDay; h++)
				{
					bool inc = false;
					if (crtTeacherTimetableActivityTag[d, h] == this.activityTagIndex)
						inc = true;

					if (inc)
					{
						nc++;
					}
					else
					{
						if (nc > this.maxHoursContinuously)
						{
							nbroken++;

							if (conflictsString != null)
							{
								QString s = (tr("Time constraint teachers activity tag %1 max %2 hours continuously broken for teacher %3, on day %4, length=%5.").arg(this.activityTagName).arg(CustomFETString.number(this.maxHoursContinuously)).arg(r.internalTeachersList[i].name).arg(r.daysOfTheWeek[d]).arg(nc)) + " " + (tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100)));

								dl.append(s);
								cl.append(weightPercentage / 100);

								conflictsString += s + "\n";
							}
						}

						nc = 0;
					}
				}

				if (nc > this.maxHoursContinuously)
				{
					nbroken++;

					if (conflictsString != null)
					{
						QString s = (tr("Time constraint teachers activity tag %1 max %2 hours continuously broken for teacher %3, on day %4, length=%5.").arg(this.activityTagName).arg(CustomFETString.number(this.maxHoursContinuously)).arg(r.internalTeachersList[i].name).arg(r.daysOfTheWeek[d]).arg(nc)) + " " + (tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100)));

						dl.append(s);
						cl.append(weightPercentage / 100);

						conflictsString += s + "\n";
					}
				}
			}
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return true;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		return s.name == this.activityTagName;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxHoursContinuously > r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxHoursContinuously > r.nHoursPerDay)
			maxHoursContinuously = r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintTeacherActivityTagMaxHoursContinuously: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTeacherActivityTagMaxHoursContinuously) public: int maxHoursContinuously;
	/**
	The maximum hours continuously
	*/

	private QString teacherName = new QString();

	private QString activityTagName = new QString();

	private int teacher_ID;

	private int activityTagIndex;

	private QList<int> canonicalTeachersList = new QList<int>();


	///////////////////////////////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////////////////////////////
	private ConstraintTeacherActivityTagMaxHoursContinuously() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_ACTIVITY_TAG_MAX_HOURS_CONTINUOUSLY;
	}

	private ConstraintTeacherActivityTagMaxHoursContinuously(double wp, int maxhours, QString teacher, QString activityTag) : base(wp)
	{
		Debug.Assert(maxhours > 0);
		this.maxHoursContinuously = maxhours;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->teacherName=teacher;
		this.teacherName.CopyFrom(teacher);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->activityTagName=activityTag;
		this.activityTagName.CopyFrom(activityTag);

		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_ACTIVITY_TAG_MAX_HOURS_CONTINUOUSLY;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintTeacherActivityTagMaxHoursContinuously>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Teacher_Name>" + GlobalMembersTimetable_defs.protect(this.teacherName) + "</Teacher_Name>\n";
		s += "	<Activity_Tag_Name>" + GlobalMembersTimetable_defs.protect(this.activityTagName) + "</Activity_Tag_Name>\n";
		s += "	<Maximum_Hours_Continuously>" + CustomFETString.number(this.maxHoursContinuously) + "</Maximum_Hours_Continuously>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTeacherActivityTagMaxHoursContinuously>\n";
		return s;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);

		this.teacher_ID = r.searchTeacher(this.teacherName);
		Debug.Assert(this.teacher_ID >= 0);

		this.activityTagIndex = r.searchActivityTag(this.activityTagName);
		Debug.Assert(this.activityTagIndex >= 0);

		this.canonicalTeachersList.clear();
		int i = this.teacher_ID;
		bool found = false;

		Teacher tch = r.internalTeachersList[i];
		foreach (int actIndex, tch.activitiesForTeacher)
		{
			if (r.internalActivitiesList[actIndex].iActivityTagsSet.contains(this.activityTagIndex))
			{
				found = true;
				break;
			}
		}

		if (found)
			this.canonicalTeachersList.append(i);

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Teacher %1 for activity tag %2 has max %3 hours continuously").arg(this.teacherName).arg(this.activityTagName).arg(this.maxHoursContinuously);
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("A teacher for an activity tag must respect the maximum number of hours continuously");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Teacher=%1").arg(this.teacherName);
		s += "\n";
		s += tr("Activity tag=%1").arg(this.activityTagName);
		s += "\n";
		s += tr("Maximum hours continuously=%1").arg(this.maxHoursContinuously);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		nbroken = 0;
		foreach (int i, this.canonicalTeachersList)
		{
			Teacher tch = r.internalTeachersList[i];
			int[,] crtTeacherTimetableActivityTag = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK, GlobalMembersTimetable_defs.MAX_HOURS_PER_DAY];
			for (int d = 0; d < r.nDaysPerWeek; d++)
				for (int h = 0; h < r.nHoursPerDay; h++)
					crtTeacherTimetableActivityTag[d, h] = -1;
			foreach (int ai, tch.activitiesForTeacher)if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
				int d = c.times[ai] % r.nDaysPerWeek;
				int h = c.times[ai] / r.nDaysPerWeek;
				for (int dur = 0; dur < r.internalActivitiesList[ai].duration; dur++)
				{
					Debug.Assert(h + dur < r.nHoursPerDay);
					Debug.Assert(crtTeacherTimetableActivityTag[d, h + dur] == -1);
					if (r.internalActivitiesList[ai].iActivityTagsSet.contains(this.activityTagIndex))
						crtTeacherTimetableActivityTag[d, h + dur] = this.activityTagIndex;
				}
			}

			for (int d = 0; d < r.nDaysPerWeek; d++)
			{
				int nc = 0;
				for (int h = 0; h < r.nHoursPerDay; h++)
				{
					bool inc = false;

					if (crtTeacherTimetableActivityTag[d, h] == this.activityTagIndex)
						inc = true;

					if (inc)
						nc++;
					else
					{
						if (nc > this.maxHoursContinuously)
						{
							nbroken++;

							if (conflictsString != null)
							{
								QString s = (tr("Time constraint teacher activity tag max %1 hours continuously broken for teacher %2, activity tag %3, on day %4, length=%5.").arg(CustomFETString.number(this.maxHoursContinuously)).arg(r.internalTeachersList[i].name).arg(this.activityTagName).arg(r.daysOfTheWeek[d]).arg(nc)) + " " + (tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100)));

								dl.append(s);
								cl.append(weightPercentage / 100);

								conflictsString += s + "\n";
							}
						}

						nc = 0;
					}
				}

				if (nc > this.maxHoursContinuously)
				{
					nbroken++;

					if (conflictsString != null)
					{
						QString s = (tr("Time constraint teacher activity tag max %1 hours continuously broken for teacher %2, activity tag %3, on day %4, length=%5.").arg(CustomFETString.number(this.maxHoursContinuously)).arg(r.internalTeachersList[i].name).arg(this.activityTagName).arg(r.daysOfTheWeek[d]).arg(nc)) + " " + (tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100)));

						dl.append(s);
						cl.append(weightPercentage / 100);

						conflictsString += s + "\n";
					}
				}
			}
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		if (this.teacherName == t.name)
			return true;
		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		return this.activityTagName == s.name;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxHoursContinuously > r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxHoursContinuously > r.nHoursPerDay)
			maxHoursContinuously = r.nHoursPerDay;

		return true;
	}
}

/**
This is a constraint.
The resulting timetable must respect the requirement
that this teacher must not have too much working
days per week.
*/
public abstract class ConstraintTeacherMaxDaysPerWeek: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTeacherMaxDaysPerWeek) public: int maxDaysPerWeek;
	/**
	The number of maximum allowed working days per week (-1 for don't care)
	*/

	/**
	The teacher's name
	*/
	private QString teacherName = new QString();

	/**
	The teacher's id, or index in the rules
	*/
	private int teacher_ID;


	///////////////////////////////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintTeacherMaxDaysPerWeek() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_MAX_DAYS_PER_WEEK;
	}

	private ConstraintTeacherMaxDaysPerWeek(double wp, int maxnd, QString tn) : base(wp)
	{
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->teacherName = tn;
		this.teacherName.CopyFrom(tn);
		this.maxDaysPerWeek = maxnd;
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_MAX_DAYS_PER_WEEK;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);

		this.teacher_ID = r.searchTeacher(this.teacherName);
		Debug.Assert(this.teacher_ID >= 0);
		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintTeacherMaxDaysPerWeek>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Teacher_Name>" + GlobalMembersTimetable_defs.protect(this.teacherName) + "</Teacher_Name>\n";
		s += "	<Max_Days_Per_Week>" + CustomFETString.number(this.maxDaysPerWeek) + "</Max_Days_Per_Week>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTeacherMaxDaysPerWeek>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = tr("Teacher max days per week");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("T:%1", "Teacher").arg(this.teacherName);
		s += ", ";
		s += tr("MD:%1", "Max days (per week)").arg(this.maxDaysPerWeek);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("A teacher must respect the maximum number of days per week");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Teacher=%1").arg(this.teacherName);
		s += "\n";
		s += tr("Maximum days per week=%1").arg(this.maxDaysPerWeek);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString *conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		//without logging
		if (conflictsString == null)
		{
			nbroken = 0;
			//count sort
			int t = this.teacher_ID;
			int[] nd = new int[GlobalMembersTimetable_defs.MAX_HOURS_PER_DAY + 1];
			for (int h = 0; h <= r.nHoursPerDay; h++)
				nd[h] = 0;
			for (int d = 0; d < r.nDaysPerWeek; d++)
			{
				int nh = 0;
				for (int h = 0; h < r.nHoursPerDay; h++)
					nh += GlobalMembersTimeconstraint.teachersMatrix[t][d][h] >= 1 ? 1 : 0;
				nd[nh]++;
			}
			//return the minimum occupied days which do not respect this constraint
			int i = r.nDaysPerWeek - this.maxDaysPerWeek;
			for (int k = 0; k <= r.nHoursPerDay; k++)
			{
				if (nd[k] > 0)
				{
					if (i > nd[k])
					{
						i -= nd[k];
						nbroken += nd[k] * k;
					}
					else
					{
						nbroken += i * k;
						break;
					}
				}
			}
		}
		//with logging
		else
		{
			nbroken = 0;
			//count sort
			int t = this.teacher_ID;
			int[] nd = new int[GlobalMembersTimetable_defs.MAX_HOURS_PER_DAY + 1];
			for (int h = 0; h <= r.nHoursPerDay; h++)
				nd[h] = 0;
			for (int d = 0; d < r.nDaysPerWeek; d++)
			{
				int nh = 0;
				for (int h = 0; h < r.nHoursPerDay; h++)
					nh += GlobalMembersTimeconstraint.teachersMatrix[t][d][h] >= 1 ? 1 : 0;
				nd[nh]++;
			}
			//return the minimum occupied days which do not respect this constraint
			int i = r.nDaysPerWeek - this.maxDaysPerWeek;
			for (int k = 0; k <= r.nHoursPerDay; k++)
			{
				if (nd[k] > 0)
				{
					if (i > nd[k])
					{
						i -= nd[k];
						nbroken += nd[k] * k;
					}
					else
					{
						nbroken += i * k;
						break;
					}
				}
			}

			if (nbroken > 0)
			{
				QString s = tr("Time constraint teacher max days per week broken for teacher: %1.").arg(r.internalTeachersList[t].name);
				s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(nbroken * weightPercentage / 100));

				dl.append(s);
				cl.append(nbroken * weightPercentage / 100);

				conflictsString += s + "\n";
			}
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		if (this.teacherName == t.name)
			return true;
		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxDaysPerWeek > r.nDaysPerWeek)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxDaysPerWeek > r.nDaysPerWeek)
			maxDaysPerWeek = r.nDaysPerWeek;

		return true;
	}
}

public abstract class ConstraintTeachersMaxDaysPerWeek: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTeachersMaxDaysPerWeek) public: int maxDaysPerWeek;
	/**
	The number of maximum allowed working days per week (-1 for don't care)
	*/


	///////////////////////////////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintTeachersMaxDaysPerWeek() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHERS_MAX_DAYS_PER_WEEK;
	}

	private ConstraintTeachersMaxDaysPerWeek(double wp, int maxnd) : base(wp)
	{
		this.maxDaysPerWeek = maxnd;
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHERS_MAX_DAYS_PER_WEEK;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);
		Q_UNUSED(r);

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintTeachersMaxDaysPerWeek>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Max_Days_Per_Week>" + CustomFETString.number(this.maxDaysPerWeek) + "</Max_Days_Per_Week>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTeachersMaxDaysPerWeek>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = tr("Teachers max days per week");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("MD:%1", "Max days (per week)").arg(this.maxDaysPerWeek);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("All teachers must respect the maximum number of days per week");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Maximum days per week=%1").arg(this.maxDaysPerWeek);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString *conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		//without logging
		if (conflictsString == null)
		{
			nbroken = 0;
			//count sort

			for (int t = 0; t < r.nInternalTeachers; t++)
			{
				int[] nd = new int[GlobalMembersTimetable_defs.MAX_HOURS_PER_DAY + 1];
				for (int h = 0; h <= r.nHoursPerDay; h++)
					nd[h] = 0;
				for (int d = 0; d < r.nDaysPerWeek; d++)
				{
					int nh = 0;
					for (int h = 0; h < r.nHoursPerDay; h++)
						nh += GlobalMembersTimeconstraint.teachersMatrix[t][d][h] >= 1 ? 1 : 0;
					nd[nh]++;
				}
				//return the minimum occupied days which do not respect this constraint
				int i = r.nDaysPerWeek - this.maxDaysPerWeek;
				for (int k = 0; k <= r.nHoursPerDay; k++)
				{
					if (nd[k] > 0)
					{
						if (i > nd[k])
						{
							i -= nd[k];
							nbroken += nd[k] * k;
						}
						else
						{
							nbroken += i * k;
							break;
						}
					}
				}

			}
		}
		//with logging
		else
		{
			nbroken = 0;

			for (int t = 0; t < r.nInternalTeachers; t++)
			{
				int nbr = 0;

				//count sort
				int[] nd = new int[GlobalMembersTimetable_defs.MAX_HOURS_PER_DAY + 1];
				for (int h = 0; h <= r.nHoursPerDay; h++)
					nd[h] = 0;
				for (int d = 0; d < r.nDaysPerWeek; d++)
				{
					int nh = 0;
					for (int h = 0; h < r.nHoursPerDay; h++)
						nh += GlobalMembersTimeconstraint.teachersMatrix[t][d][h] >= 1 ? 1 : 0;
					nd[nh]++;
				}
				//return the minimum occupied days which do not respect this constraint
				int i = r.nDaysPerWeek - this.maxDaysPerWeek;
				for (int k = 0; k <= r.nHoursPerDay; k++)
				{
					if (nd[k] > 0)
					{
						if (i > nd[k])
						{
							i -= nd[k];
							nbroken += nd[k] * k;
							nbr += nd[k] * k;
						}
						else
						{
							nbroken += i * k;
							nbr += i * k;
							break;
						}
					}
				}

				if (nbr > 0)
				{
					QString s = tr("Time constraint teachers max days per week broken for teacher: %1.").arg(r.internalTeachersList[t].name);
					s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(nbr * weightPercentage / 100));

					dl.append(s);
					cl.append(nbr * weightPercentage / 100);

					conflictsString += s + "\n";
				}

			}

		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return true;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxDaysPerWeek > r.nDaysPerWeek)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxDaysPerWeek > r.nDaysPerWeek)
			maxDaysPerWeek = r.nDaysPerWeek;

		return true;
	}
}

public abstract class ConstraintTeacherMinDaysPerWeek: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTeacherMinDaysPerWeek) public: int minDaysPerWeek;

	/**
	The teacher's name
	*/
	private QString teacherName = new QString();

	/**
	The teacher's id, or index in the rules
	*/
	private int teacher_ID;


	///////////////////////////////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintTeacherMinDaysPerWeek() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_MIN_DAYS_PER_WEEK;
	}

	private ConstraintTeacherMinDaysPerWeek(double wp, int mindays, QString teacher) : base(wp)
	{
		Debug.Assert(mindays > 0);
		this.minDaysPerWeek = mindays;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->teacherName=teacher;
		this.teacherName.CopyFrom(teacher);

		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_MIN_DAYS_PER_WEEK;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);

		this.teacher_ID = r.searchTeacher(this.teacherName);
		Debug.Assert(this.teacher_ID >= 0);
		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintTeacherMinDaysPerWeek>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Teacher_Name>" + GlobalMembersTimetable_defs.protect(this.teacherName) + "</Teacher_Name>\n";
		s += "	<Minimum_Days_Per_Week>" + CustomFETString.number(this.minDaysPerWeek) + "</Minimum_Days_Per_Week>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTeacherMinDaysPerWeek>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Teacher min days per week");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("T:%1", "Teacher").arg(this.teacherName);
		s += ", ";
		s += tr("mD:%1", "Minimum days per week").arg(this.minDaysPerWeek);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("A teacher must respect the minimum number of days per week");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Teacher=%1").arg(this.teacherName);
		s += "\n";
		s += tr("Minimum days per week=%1").arg(this.minDaysPerWeek);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		nbroken = 0;
		int i = this.teacher_ID;
		int nd = 0;
		for (int d = 0; d < r.nDaysPerWeek; d++)
		{
			for (int h = 0; h < r.nHoursPerDay; h++)
			{
				if (GlobalMembersTimeconstraint.teachersMatrix[i][d][h] > 0)
				{
					nd++;
					break;
				}
			}
		}

		if (nd < this.minDaysPerWeek)
		{
			nbroken += this.minDaysPerWeek - nd;

			if (conflictsString != null)
			{
				QString s = (tr("Time constraint teacher min %1 days per week broken for teacher %2.").arg(CustomFETString.number(this.minDaysPerWeek)).arg(r.internalTeachersList[i].name)) + " " + tr("This increases the conflicts total by %1").arg(CustomFETString.number((double)nbroken * weightPercentage / 100));

				dl.append(s);
				cl.append((double)nbroken * weightPercentage / 100);

				conflictsString += s + "\n";
			}
		}

		if (c.nPlacedActivities == r.nInternalActivities)
			if (weightPercentage == 100)
				Debug.Assert(nbroken == 0);

		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		if (this.teacherName == t.name)
			return true;
		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (minDaysPerWeek > r.nDaysPerWeek)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (minDaysPerWeek > r.nDaysPerWeek)
			minDaysPerWeek = r.nDaysPerWeek;

		return true;
	}
}

public abstract class ConstraintTeachersMinDaysPerWeek: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTeachersMinDaysPerWeek) public: int minDaysPerWeek;


	///////////////////////////////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintTeachersMinDaysPerWeek() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHERS_MIN_DAYS_PER_WEEK;
	}

	private ConstraintTeachersMinDaysPerWeek(double wp, int mindays) : base(wp)
	{
		Debug.Assert(mindays > 0);
		this.minDaysPerWeek = mindays;

		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHERS_MIN_DAYS_PER_WEEK;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);
		Q_UNUSED(r);

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintTeachersMinDaysPerWeek>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Minimum_Days_Per_Week>" + CustomFETString.number(this.minDaysPerWeek) + "</Minimum_Days_Per_Week>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTeachersMinDaysPerWeek>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Teachers min days per week");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("mD:%1", "Minimum days per week").arg(this.minDaysPerWeek);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("All teachers must respect the minimum number of days per week");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Minimum days per week=%1").arg(this.minDaysPerWeek);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbrokentotal = 0;
		for (int i = 0; i < r.nInternalTeachers; i++)
		{
			int nbroken;

			nbroken = 0;
			//int i=this->teacher_ID;
			int nd = 0;
			for (int d = 0; d < r.nDaysPerWeek; d++)
			{
				for (int h = 0; h < r.nHoursPerDay; h++)
				{
					if (GlobalMembersTimeconstraint.teachersMatrix[i][d][h] > 0)
					{
						nd++;
						break;
					}
				}
			}

			if (nd < this.minDaysPerWeek)
			{
				nbroken += this.minDaysPerWeek - nd;
				nbrokentotal += nbroken;

				if (conflictsString != null)
				{
					QString s = (tr("Time constraint teachers min %1 days per week broken for teacher %2.").arg(CustomFETString.number(this.minDaysPerWeek)).arg(r.internalTeachersList[i].name)) + " " + tr("This increases the conflicts total by %1").arg(CustomFETString.number((double)nbroken * weightPercentage / 100));

					dl.append(s);
					cl.append((double)nbroken * weightPercentage / 100);

					conflictsString += s + "\n";
				}
			}
		}

		if (c.nPlacedActivities == r.nInternalActivities)
			if (weightPercentage == 100)
				Debug.Assert(nbrokentotal == 0);

		return weightPercentage / 100 * nbrokentotal;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);
		return true;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (minDaysPerWeek > r.nDaysPerWeek)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (minDaysPerWeek > r.nDaysPerWeek)
			minDaysPerWeek = r.nDaysPerWeek;

		return true;
	}
}

/**
This is a constraint.
It constrains the timetable to not schedule any activity
in the specified day, during the start hour and end hour.
*/
public abstract class ConstraintBreakTimes: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintBreakTimes) public: QList<int> days;
	private QList<int> hours = new QList<int>();


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintBreakTimes() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_BREAK_TIMES;
	}

	private ConstraintBreakTimes(double wp, QList<int> d, QList<int> h) : base(wp)
	{
		this.days = d;
		this.hours = h;
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_BREAK_TIMES;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(r);

		Debug.Assert(days.count() == hours.count());
		for (int k = 0; k < days.count(); k++)
		{
			if (this.days.at(k) >= r.nDaysPerWeek)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint break times is wrong because it refers to removed day. Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
			if (this.hours.at(k) >= r.nHoursPerDay)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint break times is wrong because an hour is too late (after the last acceptable slot). Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
		}

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		QString s = "<ConstraintBreakTimes>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";

		s += "	<Number_of_Break_Times>" + CustomFETString.number(this.days.count()) + "</Number_of_Break_Times>\n";
		Debug.Assert(days.count() == hours.count());
		for (int i = 0; i < days.count(); i++)
		{
			s += "	<Break_Time>\n";
			if (this.days.at(i) >= 0)
				s += "		<Day>" + GlobalMembersTimetable_defs.protect(r.daysOfTheWeek[this.days.at(i)]) + "</Day>\n";
			if (this.hours.at(i) >= 0)
				s += "		<Hour>" + GlobalMembersTimetable_defs.protect(r.hoursOfTheDay[this.hours.at(i)]) + "</Hour>\n";
			s += "	</Break_Time>\n";
		}

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintBreakTimes>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Break times");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";

		s += tr("B at:", "Break at");
		s += " ";
		Debug.Assert(days.count() == hours.count());
		for (int i = 0; i < days.count(); i++)
		{
			if (this.days.at(i) >= 0)
			{
				s += r.daysOfTheWeek[this.days.at(i)];
				s += " ";
			}
			if (this.hours.at(i) >= 0)
			{
				s += r.hoursOfTheDay[this.hours.at(i)];
			}
			if (i < days.count() - 1)
				s += "; ";
		}

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		QString s = tr("Time constraint");
		s += "\n";
		s += tr("Break times");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		s += tr("Break at:");
		s += "\n";
		Debug.Assert(days.count() == hours.count());
		for (int i = 0; i < days.count(); i++)
		{
			if (this.days.at(i) >= 0)
			{
				s += r.daysOfTheWeek[this.days.at(i)];
				s += " ";
			}
			if (this.hours.at(i) >= 0)
			{
				s += r.hoursOfTheDay[this.hours.at(i)];
			}
			if (i < days.count() - 1)
				s += "; ";
		}
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		//DEPRECATED COMMENT
		//For the moment, this function sums the number of hours each teacher
		//is teaching in this break period.
		//This function consideres all the hours, I mean if there are for example 5 weekly courses
		//scheduled on that hour (which is already a broken hard restriction - we only
		//are allowed 1 weekly course for a certain teacher at a certain hour) we calculate
		//5 broken restrictions for this break period.
		//TODO: decide if it is better to consider only 2 or 10 as a return value in this particular case
		//(currently it is 10)

		int nbroken;

		nbroken = 0;

		for (int i = 0; i < r.nInternalActivities; i++)
		{
			int dayact = c.times[i] % r.nDaysPerWeek;
			int houract = c.times[i] / r.nDaysPerWeek;

			Debug.Assert(days.count() == hours.count());
			for (int kk = 0; kk < days.count(); kk++)
			{
				int d = days.at(kk);
				int h = hours.at(kk);

				int dur = r.internalActivitiesList[i].duration;
				if (d == dayact && !(houract + dur <= h || houract>h))
				{
					nbroken++;

					if (conflictsString != null)
					{
						QString s = tr("Time constraint break not respected for activity with id %1, on day %2, hours %3").arg(r.internalActivitiesList[i].id).arg(r.daysOfTheWeek[dayact]).arg(r.daysOfTheWeek[houract]);
						s += ". ";
						s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100));

						dl.append(s);
						cl.append(weightPercentage / 100);

						conflictsString += s + "\n";
					}
				}
			}
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(days.count() == hours.count());

		for (int i = 0; i < days.count(); i++)
			if (days.at(i)<0 || days.at(i) >= r.nDaysPerWeek || hours.at(i)<0 || hours.at(i) >= r.nHoursPerDay)
				return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		Debug.Assert(days.count() == hours.count());

		QList<int> newDays = new QList<int>();
		QList<int> newHours = new QList<int>();

		for (int i = 0; i < days.count(); i++)
			if (days.at(i) >= 0 && days.at(i)<r.nDaysPerWeek && hours.at(i) >= 0 && hours.at(i) < r.nHoursPerDay)
			{
				newDays.append(days.at(i));
				newHours.append(hours.at(i));
			}

		days = newDays;
		hours = newHours;

		r.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(r);

		return true;
	}
}

/**
This is a constraint. It adds, to the fitness of
the solution, a conflicts factor computed from the gaps
existing in the timetable (regarding the students).
The overall result is a timetable having less gaps for the students.
*/
public abstract class ConstraintStudentsMaxGapsPerWeek: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintStudentsMaxGapsPerWeek) public: int maxGaps;


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintStudentsMaxGapsPerWeek() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_MAX_GAPS_PER_WEEK;
	}

	private ConstraintStudentsMaxGapsPerWeek(double wp, int mg) : base(wp)
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_MAX_GAPS_PER_WEEK;
		this.maxGaps = mg;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);
		Q_UNUSED(r);

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintStudentsMaxGapsPerWeek>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Max_Gaps>" + CustomFETString.number(this.maxGaps) + "</Max_Gaps>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintStudentsMaxGapsPerWeek>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Students max gaps per week");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("MG:%1", "Max gaps (per week)").arg(this.maxGaps);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("All students must respect the maximum number of gaps per week");
		s += "\n";
		s += tr("(breaks and students set not available not counted)");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Maximum gaps per week=%1").arg(this.maxGaps);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//returns a number equal to the number of gaps of the subgroups (in hours)

		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nGaps;
		int tmp;
		int i;

		int tIllegalGaps = 0;

		for (i = 0; i < r.nInternalSubgroups; i++)
		{
			nGaps = 0;
			for (int j = 0; j < r.nDaysPerWeek; j++)
			{
				int k;
				tmp = 0;
				for (k = 0; k < r.nHoursPerDay; k++)
					if (GlobalMembersTimeconstraint.subgroupsMatrix[i][j][k] > 0)
					{
						Debug.Assert(!GlobalMembersGenerate_pre.breakDayHour[j][k] && !GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[i][j][k]);
						break;
					}
				for (; k < r.nHoursPerDay; k++)
					if (!GlobalMembersGenerate_pre.breakDayHour[j][k] && !GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[i][j][k])
					{
					if (GlobalMembersTimeconstraint.subgroupsMatrix[i][j][k] > 0)
					{
						nGaps += tmp;
						tmp = 0;
					}
					else
						tmp++;
					}
			}

			int illegalGaps = nGaps - this.maxGaps;
			if (illegalGaps < 0)
				illegalGaps = 0;

			if (illegalGaps > 0 && conflictsString != null)
			{
				QString s = tr("Time constraint students max gaps per week broken for subgroup: %1, it has %2 extra gaps, conflicts increase=%3").arg(r.internalSubgroupsList[i].name).arg(illegalGaps).arg(CustomFETString.number(illegalGaps * weightPercentage / 100));

				dl.append(s);
				cl.append(illegalGaps * weightPercentage / 100);

				conflictsString += s + "\n";
			}

			tIllegalGaps += illegalGaps;
		}

		if (c.nPlacedActivities == r.nInternalActivities)
			if (weightPercentage == 100) //for partial solutions it might be broken
				Debug.Assert(tIllegalGaps == 0);
		return weightPercentage / 100 * tIllegalGaps;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return true;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxGaps > r.nDaysPerWeek * r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxGaps > r.nDaysPerWeek * r.nHoursPerDay)
			maxGaps = r.nDaysPerWeek * r.nHoursPerDay;

		return true;
	}
}

/**
This is a constraint. It adds, to the fitness of
the solution, a conflicts factor computed from the gaps
existing in the timetable (regarding the specified students set).
*/
public abstract class ConstraintStudentsSetMaxGapsPerWeek: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintStudentsSetMaxGapsPerWeek) public: int maxGaps;

	/**
	The name of the students set for this constraint
	*/
	private QString students = new QString();

	//internal redundant data

	/**
	The number of subgroups
	*/
	//int nSubgroups;

	/**
	The subgroups
	*/
	private QList<int> iSubgroupsList = new QList<int>();


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintStudentsSetMaxGapsPerWeek() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_GAPS_PER_WEEK;
	}

	private ConstraintStudentsSetMaxGapsPerWeek(double wp, int mg, QString st) : base(wp)
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_GAPS_PER_WEEK;
		this.maxGaps = mg;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->students = st;
		this.students.CopyFrom(st);
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		StudentsSet ss = r.searchAugmentedStudentsSet(this.students);

		if (ss == null)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint students set max gaps per week is wrong because it refers to inexistent students set." + " Please correct it (removing it might be a solution). Please report potential bug. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}

		Debug.Assert(ss);

		this.iSubgroupsList.clear();
		if (ss.type == GlobalMembersStudentsset.STUDENTS_SUBGROUP)
		{
			int tmp;
			tmp = ((StudentsSubgroup)ss).indexInInternalSubgroupsList;
			Debug.Assert(tmp >= 0);
			Debug.Assert(tmp < r.nInternalSubgroups);
			if (!this.iSubgroupsList.contains(tmp))
				this.iSubgroupsList.append(tmp);
		}
		else if (ss.type == GlobalMembersStudentsset.STUDENTS_GROUP)
		{
			StudentsGroup stg = (StudentsGroup)ss;
			for (int i = 0; i < stg.subgroupsList.size(); i++)
			{
				StudentsSubgroup sts = stg.subgroupsList[i];
				int tmp;
				tmp = sts.indexInInternalSubgroupsList;
				Debug.Assert(tmp >= 0);
				Debug.Assert(tmp < r.nInternalSubgroups);
				if (!this.iSubgroupsList.contains(tmp))
					this.iSubgroupsList.append(tmp);
			}
		}
		else if (ss.type == GlobalMembersStudentsset.STUDENTS_YEAR)
		{
			StudentsYear sty = (StudentsYear)ss;
			for (int i = 0; i < sty.groupsList.size(); i++)
			{
				StudentsGroup stg = sty.groupsList[i];
				for (int j = 0; j < stg.subgroupsList.size(); j++)
				{
					StudentsSubgroup sts = stg.subgroupsList[j];
					int tmp;
					tmp = sts.indexInInternalSubgroupsList;
					Debug.Assert(tmp >= 0);
					Debug.Assert(tmp < r.nInternalSubgroups);
					if (!this.iSubgroupsList.contains(tmp))
						this.iSubgroupsList.append(tmp);
				}
			}
		}
		else
			Debug.Assert(0);

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintStudentsSetMaxGapsPerWeek>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Max_Gaps>" + CustomFETString.number(this.maxGaps) + "</Max_Gaps>\n";
		s += "	<Students>";
		s += GlobalMembersTimetable_defs.protect(this.students);
		s += "</Students>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintStudentsSetMaxGapsPerWeek>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Students set max gaps per week");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("MG:%1", "Max gaps (per week)").arg(this.maxGaps);
		s += ", ";
		s += tr("St:%1", "Students").arg(this.students);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("A students set must respect the maximum number of gaps per week");
		s += "\n";
		s += tr("(breaks and students set not available not counted)");
		s += "\n";
		s += tr("Weight (percentage)=%1").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Maximum gaps per week=%1").arg(this.maxGaps);
		s += "\n";
		s += tr("Students=%1").arg(this.students);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//OLD COMMENT
		//returns a number equal to the number of gaps of the subgroups (in hours)

		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nGaps;
		int tmp;

		int tIllegalGaps = 0;

		for (int sg = 0; sg < this.iSubgroupsList.count(); sg++)
		{
			nGaps = 0;
			int i = this.iSubgroupsList.at(sg);
			for (int j = 0; j < r.nDaysPerWeek; j++)
			{
				int k;
				tmp = 0;
				for (k = 0; k < r.nHoursPerDay; k++)
					if (GlobalMembersTimeconstraint.subgroupsMatrix[i][j][k] > 0)
					{
						Debug.Assert(!GlobalMembersGenerate_pre.breakDayHour[j][k] && !GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[i][j][k]);
						break;
					}
				for (; k < r.nHoursPerDay; k++)
					if (!GlobalMembersGenerate_pre.breakDayHour[j][k] && !GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[i][j][k])
					{
					if (GlobalMembersTimeconstraint.subgroupsMatrix[i][j][k] > 0)
					{
						nGaps += tmp;
						tmp = 0;
					}
					else
						tmp++;
					}
			}

			int illegalGaps = nGaps - this.maxGaps;
			if (illegalGaps < 0)
				illegalGaps = 0;

			if (illegalGaps > 0 && conflictsString != null)
			{
				QString s = tr("Time constraint students set max gaps per week broken for subgroup: %1, extra gaps=%2, conflicts increase=%3").arg(r.internalSubgroupsList[i].name).arg(illegalGaps).arg(CustomFETString.number(weightPercentage / 100 * illegalGaps));

				dl.append(s);
				cl.append(weightPercentage / 100 * illegalGaps);

				conflictsString += s + "\n";
			}

			tIllegalGaps += illegalGaps;
		}

		if (c.nPlacedActivities == r.nInternalActivities)
			if (weightPercentage == 100) //for partial solutions it might be broken
				Debug.Assert(tIllegalGaps == 0);
		return weightPercentage / 100 * tIllegalGaps;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		return r.setsShareStudents(this.students, s.name);
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxGaps > r.nDaysPerWeek * r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxGaps > r.nDaysPerWeek * r.nHoursPerDay)
			maxGaps = r.nDaysPerWeek * r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintTeachersMaxGapsPerWeek: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTeachersMaxGapsPerWeek) public: int maxGaps;


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintTeachersMaxGapsPerWeek() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHERS_MAX_GAPS_PER_WEEK;
	}

	private ConstraintTeachersMaxGapsPerWeek(double wp, int mg) : base(wp)
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHERS_MAX_GAPS_PER_WEEK;
		this.maxGaps = mg;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);
		Q_UNUSED(r);

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintTeachersMaxGapsPerWeek>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Max_Gaps>" + CustomFETString.number(this.maxGaps) + "</Max_Gaps>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTeachersMaxGapsPerWeek>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Teachers max gaps per week");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("MG:%1", "Max gaps (per week)").arg(this.maxGaps);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("All teachers must respect the maximum number of gaps per week");
		s += "\n";
		s += tr("(breaks and teacher not available not counted)");
		s += "\n";
		s += tr("Maximum gaps per week=%1").arg(this.maxGaps);
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int tg;
		int i;
		int j;
		int k;
		int totalGaps;

		totalGaps = 0;
		for (i = 0; i < r.nInternalTeachers; i++)
		{
			tg = 0;
			for (j = 0; j < r.nDaysPerWeek; j++)
			{
				for (k = 0; k < r.nHoursPerDay; k++)
					if (GlobalMembersTimeconstraint.teachersMatrix[i][j][k] > 0)
					{
						Debug.Assert(!GlobalMembersGenerate_pre.breakDayHour[j][k] && !GlobalMembersGenerate_pre.teacherNotAvailableDayHour[i][j][k]);
						break;
					}

				int cnt = 0;
				for (; k < r.nHoursPerDay; k++)
					if (!GlobalMembersGenerate_pre.breakDayHour[j][k] && !GlobalMembersGenerate_pre.teacherNotAvailableDayHour[i][j][k])
					{
					if (GlobalMembersTimeconstraint.teachersMatrix[i][j][k] > 0)
					{
						tg += cnt;
						cnt = 0;
					}
					else
						cnt++;
					}
			}
			if (tg > this.maxGaps)
			{
				totalGaps += tg - maxGaps;
				//assert(this->weightPercentage<100); partial solutions might break this rule
				if (conflictsString != null)
				{
					QString s = tr("Time constraint teachers max gaps per week broken for teacher: %1, conflicts factor increase=%2").arg(r.internalTeachersList[i].name).arg(CustomFETString.number((tg - maxGaps) * weightPercentage / 100));

					conflictsString += s + "\n";

					dl.append(s);
					cl.append((tg - maxGaps) * weightPercentage / 100);
				}
			}
		}

		if (c.nPlacedActivities == r.nInternalActivities)
			if (weightPercentage == 100)
			{
				Debug.Assert(totalGaps == 0); //for partial solutions this rule might be broken
			}

		return weightPercentage / 100 * totalGaps;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return true;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxGaps > r.nDaysPerWeek * r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxGaps > r.nDaysPerWeek * r.nHoursPerDay)
			maxGaps = r.nDaysPerWeek * r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintTeacherMaxGapsPerWeek: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTeacherMaxGapsPerWeek) public: int maxGaps;

	private QString teacherName = new QString();

	private int teacherIndex;


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintTeacherMaxGapsPerWeek() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_MAX_GAPS_PER_WEEK;
	}

	private ConstraintTeacherMaxGapsPerWeek(double wp, QString tn, int mg) : base(wp)
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_MAX_GAPS_PER_WEEK;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->teacherName=tn;
		this.teacherName.CopyFrom(tn);
		this.maxGaps = mg;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);

		this.teacherIndex = r.searchTeacher(this.teacherName);
		Debug.Assert(this.teacherIndex >= 0);
		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintTeacherMaxGapsPerWeek>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Teacher_Name>" + GlobalMembersTimetable_defs.protect(this.teacherName) + "</Teacher_Name>\n";
		s += "	<Max_Gaps>" + CustomFETString.number(this.maxGaps) + "</Max_Gaps>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTeacherMaxGapsPerWeek>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Teacher max gaps per week");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("T:%1", "Teacher").arg(this.teacherName);
		s += ", ";
		s += tr("MG:%1", "Max gaps (per week").arg(this.maxGaps);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("A teacher must respect the maximum number of gaps per week");
		s += "\n";
		s += tr("(breaks and teacher not available not counted)");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Teacher=%1").arg(this.teacherName);
		s += "\n";
		s += tr("Maximum gaps per week=%1").arg(this.maxGaps);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int tg;
		int i;
		int j;
		int k;
		int totalGaps;

		totalGaps = 0;

		i = this.teacherIndex;

		tg = 0;
		for (j = 0; j < r.nDaysPerWeek; j++)
		{
			for (k = 0; k < r.nHoursPerDay; k++)
				if (GlobalMembersTimeconstraint.teachersMatrix[i][j][k] > 0)
				{
					Debug.Assert(!GlobalMembersGenerate_pre.breakDayHour[j][k] && !GlobalMembersGenerate_pre.teacherNotAvailableDayHour[i][j][k]);
					break;
				}

			int cnt = 0;
			for (; k < r.nHoursPerDay; k++)
				if (!GlobalMembersGenerate_pre.breakDayHour[j][k] && !GlobalMembersGenerate_pre.teacherNotAvailableDayHour[i][j][k])
				{
				if (GlobalMembersTimeconstraint.teachersMatrix[i][j][k] > 0)
				{
					tg += cnt;
					cnt = 0;
				}
				else
					cnt++;
				}
		}
		if (tg > this.maxGaps)
		{
			totalGaps += tg - maxGaps;
			//assert(this->weightPercentage<100); partial solutions might break this rule
			if (conflictsString != null)
			{
				QString s = tr("Time constraint teacher max gaps per week broken for teacher: %1, conflicts factor increase=%2").arg(r.internalTeachersList[i].name).arg(CustomFETString.number((tg - maxGaps) * weightPercentage / 100));

				conflictsString += s + "\n";

				dl.append(s);
				cl.append((tg - maxGaps) * weightPercentage / 100);
			}
		}

		if (c.nPlacedActivities == r.nInternalActivities)
			if (weightPercentage == 100)
				Debug.Assert(totalGaps == 0); //for partial solutions this rule might be broken
		return weightPercentage / 100 * totalGaps;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		if (this.teacherName == t.name)
			return true;
		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxGaps > r.nDaysPerWeek * r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxGaps > r.nDaysPerWeek * r.nHoursPerDay)
			maxGaps = r.nDaysPerWeek * r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintTeachersMaxGapsPerDay: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTeachersMaxGapsPerDay) public: int maxGaps;


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintTeachersMaxGapsPerDay() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHERS_MAX_GAPS_PER_DAY;
	}

	private ConstraintTeachersMaxGapsPerDay(double wp, int mg) : base(wp)
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHERS_MAX_GAPS_PER_DAY;
		this.maxGaps = mg;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);
		Q_UNUSED(r);

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintTeachersMaxGapsPerDay>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Max_Gaps>" + CustomFETString.number(this.maxGaps) + "</Max_Gaps>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTeachersMaxGapsPerDay>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Teachers max gaps per day");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("MG:%1", "Max gaps (per day)").arg(this.maxGaps);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("All teachers must respect the maximum gaps per day");
		s += "\n";
		s += tr("(breaks and teacher not available not counted)");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Maximum gaps per day=%1").arg(this.maxGaps);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int tg;
		int i;
		int j;
		int k;
		int totalGaps;

		totalGaps = 0;
		for (i = 0; i < r.nInternalTeachers; i++)
		{
			for (j = 0; j < r.nDaysPerWeek; j++)
			{
				tg = 0;
				for (k = 0; k < r.nHoursPerDay; k++)
					if (GlobalMembersTimeconstraint.teachersMatrix[i][j][k] > 0)
					{
						Debug.Assert(!GlobalMembersGenerate_pre.breakDayHour[j][k] && !GlobalMembersGenerate_pre.teacherNotAvailableDayHour[i][j][k]);
						break;
					}

				int cnt = 0;
				for (; k < r.nHoursPerDay; k++)
					if (!GlobalMembersGenerate_pre.breakDayHour[j][k] && !GlobalMembersGenerate_pre.teacherNotAvailableDayHour[i][j][k])
					{
					if (GlobalMembersTimeconstraint.teachersMatrix[i][j][k] > 0)
					{
						tg += cnt;
						cnt = 0;
					}
					else
						cnt++;
					}
				if (tg > this.maxGaps)
				{
					totalGaps += tg - maxGaps;
					//assert(this->weightPercentage<100); partial solutions might break this rule
					if (conflictsString != null)
					{
						QString s = tr("Time constraint teachers max gaps per day broken for teacher: %1, day: %2, conflicts factor increase=%3").arg(r.internalTeachersList[i].name).arg(r.daysOfTheWeek[j]).arg(CustomFETString.number((tg - maxGaps) * weightPercentage / 100));

						conflictsString += s + "\n";

						dl.append(s);
						cl.append((tg - maxGaps) * weightPercentage / 100);
					}
				}
			}
		}

		if (c.nPlacedActivities == r.nInternalActivities)
			if (weightPercentage == 100)
				Debug.Assert(totalGaps == 0); //for partial solutions this rule might be broken
		return weightPercentage / 100 * totalGaps;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return true;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxGaps > r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxGaps > r.nHoursPerDay)
			maxGaps = r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintTeacherMaxGapsPerDay: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTeacherMaxGapsPerDay) public: int maxGaps;

	private QString teacherName = new QString();

	private int teacherIndex;


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintTeacherMaxGapsPerDay() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_MAX_GAPS_PER_DAY;
	}

	private ConstraintTeacherMaxGapsPerDay(double wp, QString tn, int mg) : base(wp)
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_MAX_GAPS_PER_DAY;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->teacherName=tn;
		this.teacherName.CopyFrom(tn);
		this.maxGaps = mg;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);

		this.teacherIndex = r.searchTeacher(this.teacherName);
		Debug.Assert(this.teacherIndex >= 0);
		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintTeacherMaxGapsPerDay>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Teacher_Name>" + GlobalMembersTimetable_defs.protect(this.teacherName) + "</Teacher_Name>\n";
		s += "	<Max_Gaps>" + CustomFETString.number(this.maxGaps) + "</Max_Gaps>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTeacherMaxGapsPerDay>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Teacher max gaps per day");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("T:%1", "Teacher").arg(this.teacherName);
		s += ", ";
		s += tr("MG:%1", "Max gaps (per day)").arg(this.maxGaps);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("A teacher must respect the maximum number of gaps per day");
		s += "\n";
		s += tr("(breaks and teacher not available not counted)");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Teacher=%1").arg(this.teacherName);
		s += "\n";
		s += tr("Maximum gaps per day=%1").arg(this.maxGaps);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int tg;
		int i;
		int j;
		int k;
		int totalGaps;

		totalGaps = 0;

		i = this.teacherIndex;

		for (j = 0; j < r.nDaysPerWeek; j++)
		{
			tg = 0;
			for (k = 0; k < r.nHoursPerDay; k++)
				if (GlobalMembersTimeconstraint.teachersMatrix[i][j][k] > 0)
				{
					Debug.Assert(!GlobalMembersGenerate_pre.breakDayHour[j][k] && !GlobalMembersGenerate_pre.teacherNotAvailableDayHour[i][j][k]);
					break;
				}

			int cnt = 0;
			for (; k < r.nHoursPerDay; k++)
				if (!GlobalMembersGenerate_pre.breakDayHour[j][k] && !GlobalMembersGenerate_pre.teacherNotAvailableDayHour[i][j][k])
				{
				if (GlobalMembersTimeconstraint.teachersMatrix[i][j][k] > 0)
				{
					tg += cnt;
					cnt = 0;
				}
				else
					cnt++;
				}
			if (tg > this.maxGaps)
			{
				totalGaps += tg - maxGaps;
				//assert(this->weightPercentage<100); partial solutions might break this rule
				if (conflictsString != null)
				{
					QString s = tr("Time constraint teacher max gaps per day broken for teacher: %1, day: %2, conflicts factor increase=%3").arg(r.internalTeachersList[i].name).arg(r.daysOfTheWeek[j]).arg(CustomFETString.number((tg - maxGaps) * weightPercentage / 100));

					conflictsString += s + "\n";

					dl.append(s);
					cl.append((tg - maxGaps) * weightPercentage / 100);
				}
			}
		}

		if (c.nPlacedActivities == r.nInternalActivities)
			if (weightPercentage == 100)
				Debug.Assert(totalGaps == 0); //for partial solutions this rule might be broken
		return weightPercentage / 100 * totalGaps;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		if (this.teacherName == t.name)
			return true;
		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxGaps > r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxGaps > r.nHoursPerDay)
			maxGaps = r.nHoursPerDay;

		return true;
	}
}

/**
This is a constraint. It adds, to the fitness of
the solution, a fitness factor that is related to how early
the students begin their courses. The result is a timetable
having more activities scheduled at the beginning of the day.
IMPORTANT: fortnightly activities are treated as weekly ones,
for speed and because in normal situations this does not matter.
*/
public abstract class ConstraintStudentsEarlyMaxBeginningsAtSecondHour: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintStudentsEarlyMaxBeginningsAtSecondHour) public: int maxBeginningsAtSecondHour;


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintStudentsEarlyMaxBeginningsAtSecondHour() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_EARLY_MAX_BEGINNINGS_AT_SECOND_HOUR;
	}

	private ConstraintStudentsEarlyMaxBeginningsAtSecondHour(double wp, int mBSH) : base(wp)
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_EARLY_MAX_BEGINNINGS_AT_SECOND_HOUR;
		this.maxBeginningsAtSecondHour = mBSH;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);
		Q_UNUSED(r);

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintStudentsEarlyMaxBeginningsAtSecondHour>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Max_Beginnings_At_Second_Hour>" + CustomFETString.number(this.maxBeginningsAtSecondHour) + "</Max_Beginnings_At_Second_Hour>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintStudentsEarlyMaxBeginningsAtSecondHour>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Students must arrive early, respecting maximum %1 arrivals at second hour").arg(this.maxBeginningsAtSecondHour);
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("All students must begin their courses early, respecting maximum %1 later arrivals, at second hour").arg(this.maxBeginningsAtSecondHour);
		s += "\n";
		s += tr("(breaks and students set not available not counted)");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//considers the condition that the hours of subgroups begin as early as possible

		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int conflTotal = 0;

		for (int i = 0; i < r.nInternalSubgroups; i++)
		{
			int nGapsFirstHour = 0;
			for (int j = 0; j < r.nDaysPerWeek; j++)
			{
				int k;
				for (k = 0; k < r.nHoursPerDay; k++)
					if (!GlobalMembersGenerate_pre.breakDayHour[j][k] && !GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[i][j][k])
						break;

				bool firstHourOccupied = false;
				if (k<r.nHoursPerDay && GlobalMembersTimeconstraint.subgroupsMatrix[i][j][k]>0)
					firstHourOccupied = true;

				bool dayOccupied = firstHourOccupied;

				bool illegalGap = false;

				for (k++; k < r.nHoursPerDay && !dayOccupied; k++)
					if (!GlobalMembersGenerate_pre.breakDayHour[j][k] && !GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[i][j][k])
					{
						if (GlobalMembersTimeconstraint.subgroupsMatrix[i][j][k] > 0)
							dayOccupied = true;
						else
							illegalGap = true;
					}

				if (dayOccupied && illegalGap)
				{
					if (conflictsString != null)
					{
						QString s = tr("Constraint students early max %1 beginnings at second hour broken for subgroup %2, on day %3," + " because students have an illegal gap, increases conflicts total by %4").arg(this.maxBeginningsAtSecondHour).arg(r.internalSubgroupsList[i].name).arg(r.daysOfTheWeek[j]).arg(CustomFETString.number(1 * weightPercentage / 100));

						dl.append(s);
						cl.append(1 * weightPercentage / 100);

						conflictsString += s + "\n";

						conflTotal += 1;
					}

					if (c.nPlacedActivities == r.nInternalActivities)
					{
						Debug.Assert(0);
					}
				}

				if (dayOccupied && !firstHourOccupied)
					nGapsFirstHour++;
			}

			if (nGapsFirstHour > this.maxBeginningsAtSecondHour)
			{
				if (conflictsString != null)
				{
					QString s = tr("Constraint students early max %1 beginnings at second hour broken for subgroup %2," + " because students have too many arrivals at second hour, increases conflicts total by %3").arg(this.maxBeginningsAtSecondHour).arg(r.internalSubgroupsList[i].name).arg(CustomFETString.number((nGapsFirstHour - this.maxBeginningsAtSecondHour) * weightPercentage / 100));

					dl.append(s);
					cl.append((nGapsFirstHour - this.maxBeginningsAtSecondHour) * weightPercentage / 100);

					conflictsString += s + "\n";

					conflTotal += (nGapsFirstHour - this.maxBeginningsAtSecondHour);
				}

				if (c.nPlacedActivities == r.nInternalActivities)
				{
					Debug.Assert(0);
				}
			}
		}

		if (c.nPlacedActivities == r.nInternalActivities)
			if (weightPercentage == 100) //might be broken for partial solutions
				Debug.Assert(conflTotal == 0);
		return weightPercentage / 100 * conflTotal;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return true;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxBeginningsAtSecondHour > r.nDaysPerWeek)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxBeginningsAtSecondHour > r.nDaysPerWeek)
			maxBeginningsAtSecondHour = r.nDaysPerWeek;

		return true;
	}
}

public abstract class ConstraintStudentsSetEarlyMaxBeginningsAtSecondHour: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintStudentsSetEarlyMaxBeginningsAtSecondHour) public: int maxBeginningsAtSecondHour;

	/**
	The name of the students
	*/
	private QString students = new QString();

	/**
	The number of subgroups involved in this restriction
	*/
	//int nSubgroups;

	/**
	The subgroups involved in this restriction
	*/
	//int subgroups[MAX_SUBGROUPS_PER_CONSTRAINT];
	private QList<int> iSubgroupsList = new QList<int>();


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintStudentsSetEarlyMaxBeginningsAtSecondHour() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_EARLY_MAX_BEGINNINGS_AT_SECOND_HOUR;
	}

	private ConstraintStudentsSetEarlyMaxBeginningsAtSecondHour(double wp, int mBSH, QString students) : base(wp)
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_EARLY_MAX_BEGINNINGS_AT_SECOND_HOUR;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->students=students;
		this.students.CopyFrom(students);
		this.maxBeginningsAtSecondHour = mBSH;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		StudentsSet ss = r.searchAugmentedStudentsSet(this.students);

		if (ss == null)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint students set early is wrong because it refers to inexistent students set." + " Please correct it (removing it might be a solution). Please report potential bug. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}

		Debug.Assert(ss);

		this.iSubgroupsList.clear();
		if (ss.type == GlobalMembersStudentsset.STUDENTS_SUBGROUP)
		{
			int tmp;
			tmp = ((StudentsSubgroup)ss).indexInInternalSubgroupsList;
			Debug.Assert(tmp >= 0);
			Debug.Assert(tmp < r.nInternalSubgroups);
			if (!this.iSubgroupsList.contains(tmp))
				this.iSubgroupsList.append(tmp);
		}
		else if (ss.type == GlobalMembersStudentsset.STUDENTS_GROUP)
		{
			StudentsGroup stg = (StudentsGroup)ss;
			for (int i = 0; i < stg.subgroupsList.size(); i++)
			{
				StudentsSubgroup sts = stg.subgroupsList[i];
				int tmp;
				tmp = sts.indexInInternalSubgroupsList;
				Debug.Assert(tmp >= 0);
				Debug.Assert(tmp < r.nInternalSubgroups);
				if (!this.iSubgroupsList.contains(tmp))
					this.iSubgroupsList.append(tmp);
			}
		}
		else if (ss.type == GlobalMembersStudentsset.STUDENTS_YEAR)
		{
			StudentsYear sty = (StudentsYear)ss;
			for (int i = 0; i < sty.groupsList.size(); i++)
			{
				StudentsGroup stg = sty.groupsList[i];
				for (int j = 0; j < stg.subgroupsList.size(); j++)
				{
					StudentsSubgroup sts = stg.subgroupsList[j];
					int tmp;
					tmp = sts.indexInInternalSubgroupsList;
					Debug.Assert(tmp >= 0);
					Debug.Assert(tmp < r.nInternalSubgroups);
					if (!this.iSubgroupsList.contains(tmp))
						this.iSubgroupsList.append(tmp);
				}
			}
		}
		else
			Debug.Assert(0);
		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintStudentsSetEarlyMaxBeginningsAtSecondHour>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Max_Beginnings_At_Second_Hour>" + CustomFETString.number(this.maxBeginningsAtSecondHour) + "</Max_Beginnings_At_Second_Hour>\n";
		s += "	<Students>" + GlobalMembersTimetable_defs.protect(this.students) + "</Students>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintStudentsSetEarlyMaxBeginningsAtSecondHour>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();

		s += tr("Students set must arrive early, respecting maximum %1 arrivals at second hour").arg(this.maxBeginningsAtSecondHour);
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("St:%1", "Students set").arg(this.students);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";

		s += tr("A students set must begin its courses early, respecting a maximum number of later arrivals, at second hour");
		s += "\n";
		s += tr("(breaks and students set not available not counted)");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Students set=%1").arg(this.students);
		s += "\n";
		s += tr("Maximum number of arrivals at the second hour=%1").arg(this.maxBeginningsAtSecondHour);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//considers the condition that the hours of subgroups begin as early as possible

		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int conflTotal = 0;

		foreach (int i, this.iSubgroupsList)
		{
			int nGapsFirstHour = 0;
			for (int j = 0; j < r.nDaysPerWeek; j++)
			{
				int k;
				for (k = 0; k < r.nHoursPerDay; k++)
					if (!GlobalMembersGenerate_pre.breakDayHour[j][k] && !GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[i][j][k])
						break;

				bool firstHourOccupied = false;
				if (k<r.nHoursPerDay && GlobalMembersTimeconstraint.subgroupsMatrix[i][j][k]>0)
					firstHourOccupied = true;

				bool dayOccupied = firstHourOccupied;

				bool illegalGap = false;

				for (k++; k < r.nHoursPerDay && !dayOccupied; k++)
					if (!GlobalMembersGenerate_pre.breakDayHour[j][k] && !GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[i][j][k])
					{
						if (GlobalMembersTimeconstraint.subgroupsMatrix[i][j][k] > 0)
							dayOccupied = true;
						else
							illegalGap = true;
					}

				if (dayOccupied && illegalGap)
				{
					if (conflictsString != null)
					{
						QString s = tr("Constraint students set early max %1 beginnings at second hour broken for subgroup %2, on day %3," + " because students have an illegal gap, increases conflicts total by %4").arg(this.maxBeginningsAtSecondHour).arg(r.internalSubgroupsList[i].name).arg(r.daysOfTheWeek[j]).arg(CustomFETString.number(1 * weightPercentage / 100));

						dl.append(s);
						cl.append(1 * weightPercentage / 100);

						conflictsString += s + "\n";

						conflTotal += 1;
					}

					if (c.nPlacedActivities == r.nInternalActivities)
						Debug.Assert(0);
				}

				if (dayOccupied && !firstHourOccupied)
					nGapsFirstHour++;
			}

			if (nGapsFirstHour > this.maxBeginningsAtSecondHour)
			{
				if (conflictsString != null)
				{
					QString s = tr("Constraint students set early max %1 beginnings at second hour broken for subgroup %2," + " because students have too many arrivals at second hour, increases conflicts total by %3").arg(this.maxBeginningsAtSecondHour).arg(r.internalSubgroupsList[i].name).arg(CustomFETString.number((nGapsFirstHour - this.maxBeginningsAtSecondHour) * weightPercentage / 100));

					dl.append(s);
					cl.append((nGapsFirstHour - this.maxBeginningsAtSecondHour) * weightPercentage / 100);

					conflictsString += s + "\n";

					conflTotal += (nGapsFirstHour - this.maxBeginningsAtSecondHour);
				}

				if (c.nPlacedActivities == r.nInternalActivities)
					Debug.Assert(0);
			}
		}

		if (c.nPlacedActivities == r.nInternalActivities)
			if (weightPercentage == 100) //might be broken for partial solutions
				Debug.Assert(conflTotal == 0);
		return weightPercentage / 100 * conflTotal;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		return r.setsShareStudents(this.students, s.name);
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxBeginningsAtSecondHour > r.nDaysPerWeek)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxBeginningsAtSecondHour > r.nDaysPerWeek)
			maxBeginningsAtSecondHour = r.nDaysPerWeek;

		return true;
	}
}

public abstract class ConstraintStudentsMaxHoursDaily: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintStudentsMaxHoursDaily) public: int maxHoursDaily;


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintStudentsMaxHoursDaily() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_MAX_HOURS_DAILY;
		this.maxHoursDaily = -1;
	}

	private ConstraintStudentsMaxHoursDaily(double wp, int maxnh) : base(wp)
	{
		this.maxHoursDaily = maxnh;
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_MAX_HOURS_DAILY;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);
		Q_UNUSED(r);

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintStudentsMaxHoursDaily>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		if (this.maxHoursDaily >= 0)
			s += "	<Maximum_Hours_Daily>" + CustomFETString.number(this.maxHoursDaily) + "</Maximum_Hours_Daily>\n";
		else
			Debug.Assert(0);
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintStudentsMaxHoursDaily>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Students max hours daily");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("MH:%1", "Max hours (daily)").arg(this.maxHoursDaily);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("All students must respect the maximum number of hours daily");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Maximum hours daily=%1").arg(this.maxHoursDaily);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int tmp;
		int too_much;

		Debug.Assert(this.maxHoursDaily >= 0);

		if (true)
		{
			too_much = 0;
			for (int i = 0; i < r.nInternalSubgroups; i++)
				for (int j = 0; j < r.nDaysPerWeek; j++)
				{
					tmp = 0;
					for (int k = 0; k < r.nHoursPerDay; k++)
					{
						//OLD COMMENT
						//Here we want to see if we have a weekly activity or a 2 weeks activity
						//We don't do tmp+=subgroupsMatrix[i][j][k] because we already counted this as a hard hitness
						if (GlobalMembersTimeconstraint.subgroupsMatrix[i][j][k] >= 1)
							tmp++;
					}
					if (this.maxHoursDaily >= 0 && tmp > this.maxHoursDaily) //we would like no more than maxHoursDaily hours per day.
					{
						too_much += 1; //tmp - this->maxHoursDaily;

						if (conflictsString != null)
						{
							QString s = tr("Time constraint students max hours daily broken for subgroup: %1, day: %2, lenght=%3, conflict increase=%4").arg(r.internalSubgroupsList[i].name).arg(r.daysOfTheWeek[j]).arg(CustomFETString.number(tmp)).arg(CustomFETString.number(weightPercentage / 100 * 1));

							dl.append(s);
							cl.append(weightPercentage / 100 * 1);

							conflictsString += s + "\n";
						}
					}
				}
		}

		Debug.Assert(too_much >= 0);
		if (weightPercentage == 100)
			Debug.Assert(too_much == 0);
		return too_much * weightPercentage / 100;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return true;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxHoursDaily > r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxHoursDaily > r.nHoursPerDay)
			maxHoursDaily = r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintStudentsSetMaxHoursDaily: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintStudentsSetMaxHoursDaily) public: int maxHoursDaily;

	/**
	The students set name
	*/
	private QString students = new QString();

	//internal variables

	/**
	The number of subgroups
	*/
	//int nSubgroups;

	/**
	The subgroups
	*/
	//int subgroups[MAX_SUBGROUPS_PER_CONSTRAINT];
	private QList<int> iSubgroupsList = new QList<int>();


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintStudentsSetMaxHoursDaily() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_HOURS_DAILY;
		this.maxHoursDaily = -1;
	}

	private ConstraintStudentsSetMaxHoursDaily(double wp, int maxnh, QString s) : base(wp)
	{
		this.maxHoursDaily = maxnh;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->students = s;
		this.students.CopyFrom(s);
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_HOURS_DAILY;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		StudentsSet ss = r.searchAugmentedStudentsSet(this.students);

		if (ss == null)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint students set max hours daily is wrong because it refers to inexistent students set." + " Please correct it (removing it might be a solution). Please report potential bug. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}

		Debug.Assert(ss);

		this.iSubgroupsList.clear();
		if (ss.type == GlobalMembersStudentsset.STUDENTS_SUBGROUP)
		{
			int tmp;
			tmp = ((StudentsSubgroup)ss).indexInInternalSubgroupsList;
			Debug.Assert(tmp >= 0);
			Debug.Assert(tmp < r.nInternalSubgroups);
			if (!this.iSubgroupsList.contains(tmp))
				this.iSubgroupsList.append(tmp);
		}
		else if (ss.type == GlobalMembersStudentsset.STUDENTS_GROUP)
		{
			StudentsGroup stg = (StudentsGroup)ss;
			for (int i = 0; i < stg.subgroupsList.size(); i++)
			{
				StudentsSubgroup sts = stg.subgroupsList[i];
				int tmp;
				tmp = sts.indexInInternalSubgroupsList;
				Debug.Assert(tmp >= 0);
				Debug.Assert(tmp < r.nInternalSubgroups);
				if (!this.iSubgroupsList.contains(tmp))
					this.iSubgroupsList.append(tmp);
			}
		}
		else if (ss.type == GlobalMembersStudentsset.STUDENTS_YEAR)
		{
			StudentsYear sty = (StudentsYear)ss;
			for (int i = 0; i < sty.groupsList.size(); i++)
			{
				StudentsGroup stg = sty.groupsList[i];
				for (int j = 0; j < stg.subgroupsList.size(); j++)
				{
					StudentsSubgroup sts = stg.subgroupsList[j];
					int tmp;
					tmp = sts.indexInInternalSubgroupsList;
					Debug.Assert(tmp >= 0);
					Debug.Assert(tmp < r.nInternalSubgroups);
					if (!this.iSubgroupsList.contains(tmp))
						this.iSubgroupsList.append(tmp);
				}
			}
		}
		else
			Debug.Assert(0);

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintStudentsSetMaxHoursDaily>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Maximum_Hours_Daily>" + CustomFETString.number(this.maxHoursDaily) + "</Maximum_Hours_Daily>\n";
		s += "	<Students>" + GlobalMembersTimetable_defs.protect(this.students) + "</Students>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintStudentsSetMaxHoursDaily>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Students set max hours daily");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("St:%1", "Students (set)").arg(this.students);
		s += ", ";
		s += tr("MH:%1", "Max hours (daily)").arg(this.maxHoursDaily);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("A students set must respect the maximum number of hours daily");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Students set=%1").arg(this.students);
		s += "\n";
		s += tr("Maximum hours daily=%1").arg(this.maxHoursDaily);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int tmp;
		int too_much;

		Debug.Assert(this.maxHoursDaily >= 0);

		if (true)
		{
			too_much = 0;
			for (int sg = 0; sg < this.iSubgroupsList.count(); sg++)
			{
				int i = iSubgroupsList.at(sg);
				for (int j = 0; j < r.nDaysPerWeek; j++)
				{
					tmp = 0;
					for (int k = 0; k < r.nHoursPerDay; k++)
					{
						//Here we want to see if we have a weekly activity or a 2 weeks activity
						//We don't do tmp+=subgroupsMatrix[i][j][k] because we already counted this as a hard hitness
						if (GlobalMembersTimeconstraint.subgroupsMatrix[i][j][k] >= 1)
							tmp++;
					}
					if (this.maxHoursDaily >= 0 && tmp > this.maxHoursDaily) //we would like no more than max_hours_daily hours per day.
					{
						too_much += 1; //tmp - this->maxHoursDaily;

						if (conflictsString != null)
						{
							QString s = tr("Time constraint students set max hours daily broken for subgroup: %1, day: %2, lenght=%3, conflicts increase=%4").arg(r.internalSubgroupsList[i].name).arg(r.daysOfTheWeek[j]).arg(CustomFETString.number(tmp)).arg(CustomFETString.number(1 * weightPercentage / 100));

							dl.append(s);
							cl.append(1 * weightPercentage / 100);

							conflictsString += s + "\n";
						}
					}
				}
			}
		}

		Debug.Assert(too_much >= 0);
		if (weightPercentage == 100)
			Debug.Assert(too_much == 0);
		return too_much * weightPercentage / 100.0;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		return r.setsShareStudents(this.students, s.name);
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxHoursDaily > r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxHoursDaily > r.nHoursPerDay)
			maxHoursDaily = r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintStudentsMaxHoursContinuously: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintStudentsMaxHoursContinuously) public: int maxHoursContinuously;


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintStudentsMaxHoursContinuously() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_MAX_HOURS_CONTINUOUSLY;
		this.maxHoursContinuously = -1;
	}

	private ConstraintStudentsMaxHoursContinuously(double wp, int maxnh) : base(wp)
	{
		this.maxHoursContinuously = maxnh;
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_MAX_HOURS_CONTINUOUSLY;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);
		Q_UNUSED(r);

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintStudentsMaxHoursContinuously>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		if (this.maxHoursContinuously >= 0)
			s += "	<Maximum_Hours_Continuously>" + CustomFETString.number(this.maxHoursContinuously) + "</Maximum_Hours_Continuously>\n";
		else
			Debug.Assert(0);
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintStudentsMaxHoursContinuously>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Students max hours continuously");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("MH:%1", "Max hours (continuously)").arg(this.maxHoursContinuously);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("All students must respect the maximum number of hours continuously");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Maximum hours continuously=%1").arg(this.maxHoursContinuously);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		nbroken = 0;
		for (int i = 0; i < r.nInternalSubgroups; i++)
		{
			for (int d = 0; d < r.nDaysPerWeek; d++)
			{
				int nc = 0;
				for (int h = 0; h < r.nHoursPerDay; h++)
				{
					if (GlobalMembersTimeconstraint.subgroupsMatrix[i][d][h] > 0)
						nc++;
					else
					{
						if (nc > this.maxHoursContinuously)
						{
							nbroken++;

							if (conflictsString != null)
							{
								QString s = (tr("Time constraint students max %1 hours continuously broken for subgroup %2, on day %3, length=%4.").arg(CustomFETString.number(this.maxHoursContinuously)).arg(r.internalSubgroupsList[i].name).arg(r.daysOfTheWeek[d]).arg(nc)) + " " + (tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100)));

								dl.append(s);
								cl.append(weightPercentage / 100);

								conflictsString += s + "\n";
							}
						}

						nc = 0;
					}
				}

				if (nc > this.maxHoursContinuously)
				{
					nbroken++;

					if (conflictsString != null)
					{
						QString s = (tr("Time constraint students max %1 hours continuously broken for subgroup %2, on day %3, length=%4.").arg(CustomFETString.number(this.maxHoursContinuously)).arg(r.internalSubgroupsList[i].name).arg(r.daysOfTheWeek[d]).arg(nc)) + " " + (tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100)));

						dl.append(s);
						cl.append(weightPercentage / 100);

						conflictsString += s + "\n";
					}
				}
			}
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return true;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxHoursContinuously > r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxHoursContinuously > r.nHoursPerDay)
			maxHoursContinuously = r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintStudentsSetMaxHoursContinuously: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintStudentsSetMaxHoursContinuously) public: int maxHoursContinuously;

	/**
	The students set name
	*/
	private QString students = new QString();

	//internal variables

	/**
	The number of subgroups
	*/
	//int nSubgroups;

	/**
	The subgroups
	*/
	//int subgroups[MAX_SUBGROUPS_PER_CONSTRAINT];
	private QList<int> iSubgroupsList = new QList<int>();


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintStudentsSetMaxHoursContinuously() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_HOURS_CONTINUOUSLY;
		this.maxHoursContinuously = -1;
	}

	private ConstraintStudentsSetMaxHoursContinuously(double wp, int maxnh, QString s) : base(wp)
	{
		this.maxHoursContinuously = maxnh;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->students = s;
		this.students.CopyFrom(s);
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_HOURS_CONTINUOUSLY;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		StudentsSet ss = r.searchAugmentedStudentsSet(this.students);

		if (ss == null)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint students set max hours continuously is wrong because it refers to inexistent students set." + " Please correct it (removing it might be a solution). Please report potential bug. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}

		Debug.Assert(ss);

		this.iSubgroupsList.clear();
		if (ss.type == GlobalMembersStudentsset.STUDENTS_SUBGROUP)
		{
			int tmp;
			tmp = ((StudentsSubgroup)ss).indexInInternalSubgroupsList;
			Debug.Assert(tmp >= 0);
			Debug.Assert(tmp < r.nInternalSubgroups);
			if (!this.iSubgroupsList.contains(tmp))
				this.iSubgroupsList.append(tmp);
		}
		else if (ss.type == GlobalMembersStudentsset.STUDENTS_GROUP)
		{
			StudentsGroup stg = (StudentsGroup)ss;
			for (int i = 0; i < stg.subgroupsList.size(); i++)
			{
				StudentsSubgroup sts = stg.subgroupsList[i];
				int tmp;
				tmp = sts.indexInInternalSubgroupsList;
				Debug.Assert(tmp >= 0);
				Debug.Assert(tmp < r.nInternalSubgroups);
				if (!this.iSubgroupsList.contains(tmp))
					this.iSubgroupsList.append(tmp);
			}
		}
		else if (ss.type == GlobalMembersStudentsset.STUDENTS_YEAR)
		{
			StudentsYear sty = (StudentsYear)ss;
			for (int i = 0; i < sty.groupsList.size(); i++)
			{
				StudentsGroup stg = sty.groupsList[i];
				for (int j = 0; j < stg.subgroupsList.size(); j++)
				{
					StudentsSubgroup sts = stg.subgroupsList[j];
					int tmp;
					tmp = sts.indexInInternalSubgroupsList;
					Debug.Assert(tmp >= 0);
					Debug.Assert(tmp < r.nInternalSubgroups);
					if (!this.iSubgroupsList.contains(tmp))
						this.iSubgroupsList.append(tmp);
				}
			}
		}
		else
			Debug.Assert(0);

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintStudentsSetMaxHoursContinuously>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Maximum_Hours_Continuously>" + CustomFETString.number(this.maxHoursContinuously) + "</Maximum_Hours_Continuously>\n";
		s += "	<Students>" + GlobalMembersTimetable_defs.protect(this.students) + "</Students>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintStudentsSetMaxHoursContinuously>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Students set max hours continuously");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("St:%1", "Students (set)").arg(this.students);
		s += ", ";
		s += tr("MH:%1", "Max hours (continuously)").arg(this.maxHoursContinuously);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("A students set must respect the maximum number of hours continuously");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Students set=%1").arg(this.students);
		s += "\n";
		s += tr("Maximum hours continuously=%1").arg(this.maxHoursContinuously);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		nbroken = 0;
		foreach (int i, this.iSubgroupsList)
		{
			for (int d = 0; d < r.nDaysPerWeek; d++)
			{
				int nc = 0;
				for (int h = 0; h < r.nHoursPerDay; h++)
				{
					if (GlobalMembersTimeconstraint.subgroupsMatrix[i][d][h] > 0)
						nc++;
					else
					{
						if (nc > this.maxHoursContinuously)
						{
							nbroken++;

							if (conflictsString != null)
							{
								QString s = (tr("Time constraint students set max %1 hours continuously broken for subgroup %2, on day %3, length=%4.").arg(CustomFETString.number(this.maxHoursContinuously)).arg(r.internalSubgroupsList[i].name).arg(r.daysOfTheWeek[d]).arg(nc)) + " " + (tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100)));

								dl.append(s);
								cl.append(weightPercentage / 100);

								conflictsString += s + "\n";
							}
						}

						nc = 0;
					}
				}

				if (nc > this.maxHoursContinuously)
				{
					nbroken++;

					if (conflictsString != null)
					{
						QString s = (tr("Time constraint students set max %1 hours continuously broken for subgroup %2, on day %3, length=%4.").arg(CustomFETString.number(this.maxHoursContinuously)).arg(r.internalSubgroupsList[i].name).arg(r.daysOfTheWeek[d]).arg(nc)) + " " + (tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100)));

						dl.append(s);
						cl.append(weightPercentage / 100);

						conflictsString += s + "\n";
					}
				}
			}
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		return r.setsShareStudents(this.students, s.name);
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxHoursContinuously > r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxHoursContinuously > r.nHoursPerDay)
			maxHoursContinuously = r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintStudentsActivityTagMaxHoursContinuously: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintStudentsActivityTagMaxHoursContinuously) public: int maxHoursContinuously;

	private QString activityTagName = new QString();

	private int activityTagIndex;

	private QList<int> canonicalSubgroupsList = new QList<int>();


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintStudentsActivityTagMaxHoursContinuously() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_ACTIVITY_TAG_MAX_HOURS_CONTINUOUSLY;
		this.maxHoursContinuously = -1;
	}

	private ConstraintStudentsActivityTagMaxHoursContinuously(double wp, int maxnh, QString activityTag) : base(wp)
	{
		this.maxHoursContinuously = maxnh;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->activityTagName=activityTag;
		this.activityTagName.CopyFrom(activityTag);
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_ACTIVITY_TAG_MAX_HOURS_CONTINUOUSLY;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);

		this.activityTagIndex = r.searchActivityTag(this.activityTagName);
		Debug.Assert(this.activityTagIndex >= 0);

		this.canonicalSubgroupsList.clear();
		for (int i = 0; i < r.nInternalSubgroups; i++)
		{
			bool found = false;

			StudentsSubgroup sbg = r.internalSubgroupsList[i];
			foreach (int actIndex, sbg.activitiesForSubgroup)
			{
				if (r.internalActivitiesList[actIndex].iActivityTagsSet.contains(this.activityTagIndex))
				{
					found = true;
					break;
				}
			}

			if (found)
				this.canonicalSubgroupsList.append(i);
		}

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintStudentsActivityTagMaxHoursContinuously>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";

		s += "	<Activity_Tag>" + GlobalMembersTimetable_defs.protect(this.activityTagName) + "</Activity_Tag>\n";

		if (this.maxHoursContinuously >= 0)
			s += "	<Maximum_Hours_Continuously>" + CustomFETString.number(this.maxHoursContinuously) + "</Maximum_Hours_Continuously>\n";
		else
			Debug.Assert(0);
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintStudentsActivityTagMaxHoursContinuously>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Students for activity tag %1 have max %2 hours continuously").arg(this.activityTagName).arg(this.maxHoursContinuously);
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("All students, for an activity tag, must respect the maximum number of hours continuously");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Activity tag=%1").arg(this.activityTagName);
		s += "\n";
		s += tr("Maximum hours continuously=%1").arg(this.maxHoursContinuously);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		nbroken = 0;

		foreach (int i, this.canonicalSubgroupsList)
		{
			StudentsSubgroup sbg = r.internalSubgroupsList[i];
			int[,] crtSubgroupTimetableActivityTag = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK, GlobalMembersTimetable_defs.MAX_HOURS_PER_DAY];
			for (int d = 0; d < r.nDaysPerWeek; d++)
				for (int h = 0; h < r.nHoursPerDay; h++)
					crtSubgroupTimetableActivityTag[d, h] = -1;
			foreach (int ai, sbg.activitiesForSubgroup)if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
				int d = c.times[ai] % r.nDaysPerWeek;
				int h = c.times[ai] / r.nDaysPerWeek;
				for (int dur = 0; dur < r.internalActivitiesList[ai].duration; dur++)
				{
					Debug.Assert(h + dur < r.nHoursPerDay);
					Debug.Assert(crtSubgroupTimetableActivityTag[d, h + dur] == -1);
					if (r.internalActivitiesList[ai].iActivityTagsSet.contains(this.activityTagIndex))
						crtSubgroupTimetableActivityTag[d, h + dur] = this.activityTagIndex;
				}
			}

			for (int d = 0; d < r.nDaysPerWeek; d++)
			{
				int nc = 0;
				for (int h = 0; h < r.nHoursPerDay; h++)
				{
					bool inc = false;

					if (crtSubgroupTimetableActivityTag[d, h] == this.activityTagIndex)
						inc = true;

					if (inc)
						nc++;
					else
					{
						if (nc > this.maxHoursContinuously)
						{
							nbroken++;

							if (conflictsString != null)
							{
								QString s = (tr("Time constraint students, activity tag %1, max %2 hours continuously, broken for subgroup %3, on day %4, length=%5.").arg(this.activityTagName).arg(CustomFETString.number(this.maxHoursContinuously)).arg(r.internalSubgroupsList[i].name).arg(r.daysOfTheWeek[d]).arg(nc)) + " " + (tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100)));

								dl.append(s);
								cl.append(weightPercentage / 100);

								conflictsString += s + "\n";
							}
						}

						nc = 0;
					}
				}

				if (nc > this.maxHoursContinuously)
				{
					nbroken++;

					if (conflictsString != null)
					{
						QString s = (tr("Time constraint students, activity tag %1, max %2 hours continuously, broken for subgroup %3, on day %4, length=%5.").arg(this.activityTagName).arg(CustomFETString.number(this.maxHoursContinuously)).arg(r.internalSubgroupsList[i].name).arg(r.daysOfTheWeek[d]).arg(nc)) + " " + (tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100)));

						dl.append(s);
						cl.append(weightPercentage / 100);

						conflictsString += s + "\n";
					}
				}
			}
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		return s.name == this.activityTagName;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return true;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxHoursContinuously > r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxHoursContinuously > r.nHoursPerDay)
			maxHoursContinuously = r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintStudentsSetActivityTagMaxHoursContinuously: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintStudentsSetActivityTagMaxHoursContinuously) public: int maxHoursContinuously;

	/**
	The students set name
	*/
	private QString students = new QString();

	private QString activityTagName = new QString();

	//internal variables

	private int activityTagIndex;

	/**
	The number of subgroups
	*/
	//int nSubgroups;

	/**
	The subgroups
	*/
	//int subgroups[MAX_SUBGROUPS_PER_CONSTRAINT];
	private QList<int> iSubgroupsList = new QList<int>();

	private QList<int> canonicalSubgroupsList = new QList<int>();


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintStudentsSetActivityTagMaxHoursContinuously() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_ACTIVITY_TAG_MAX_HOURS_CONTINUOUSLY;
		this.maxHoursContinuously = -1;
	}

	private ConstraintStudentsSetActivityTagMaxHoursContinuously(double wp, int maxnh, QString s, QString activityTag) : base(wp)
	{
		this.maxHoursContinuously = maxnh;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->students = s;
		this.students.CopyFrom(s);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->activityTagName=activityTag;
		this.activityTagName.CopyFrom(activityTag);
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_ACTIVITY_TAG_MAX_HOURS_CONTINUOUSLY;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		this.activityTagIndex = r.searchActivityTag(this.activityTagName);
		Debug.Assert(this.activityTagIndex >= 0);

		StudentsSet ss = r.searchAugmentedStudentsSet(this.students);

		if (ss == null)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint students set max hours continuously is wrong because it refers to inexistent students set." + " Please correct it (removing it might be a solution). Please report potential bug. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}

		Debug.Assert(ss);

		this.iSubgroupsList.clear();
		if (ss.type == GlobalMembersStudentsset.STUDENTS_SUBGROUP)
		{
			int tmp;
			tmp = ((StudentsSubgroup)ss).indexInInternalSubgroupsList;
			Debug.Assert(tmp >= 0);
			Debug.Assert(tmp < r.nInternalSubgroups);
			if (!this.iSubgroupsList.contains(tmp))
				this.iSubgroupsList.append(tmp);
		}
		else if (ss.type == GlobalMembersStudentsset.STUDENTS_GROUP)
		{
			StudentsGroup stg = (StudentsGroup)ss;
			for (int i = 0; i < stg.subgroupsList.size(); i++)
			{
				StudentsSubgroup sts = stg.subgroupsList[i];
				int tmp;
				tmp = sts.indexInInternalSubgroupsList;
				Debug.Assert(tmp >= 0);
				Debug.Assert(tmp < r.nInternalSubgroups);
				if (!this.iSubgroupsList.contains(tmp))
					this.iSubgroupsList.append(tmp);
			}
		}
		else if (ss.type == GlobalMembersStudentsset.STUDENTS_YEAR)
		{
			StudentsYear sty = (StudentsYear)ss;
			for (int i = 0; i < sty.groupsList.size(); i++)
			{
				StudentsGroup stg = sty.groupsList[i];
				for (int j = 0; j < stg.subgroupsList.size(); j++)
				{
					StudentsSubgroup sts = stg.subgroupsList[j];
					int tmp;
					tmp = sts.indexInInternalSubgroupsList;
					Debug.Assert(tmp >= 0);
					Debug.Assert(tmp < r.nInternalSubgroups);
					if (!this.iSubgroupsList.contains(tmp))
						this.iSubgroupsList.append(tmp);
				}
			}
		}
		else
			Debug.Assert(0);

		/////////////
		this.canonicalSubgroupsList.clear();
		foreach (int i, this.iSubgroupsList)
		{
			bool found = false;

			StudentsSubgroup sbg = r.internalSubgroupsList[i];
			foreach (int actIndex, sbg.activitiesForSubgroup)
			{
				if (r.internalActivitiesList[actIndex].iActivityTagsSet.contains(this.activityTagIndex))
				{
					found = true;
					break;
				}
			}

			if (found)
				this.canonicalSubgroupsList.append(i);
		}


		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintStudentsSetActivityTagMaxHoursContinuously>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Maximum_Hours_Continuously>" + CustomFETString.number(this.maxHoursContinuously) + "</Maximum_Hours_Continuously>\n";
		s += "	<Students>" + GlobalMembersTimetable_defs.protect(this.students) + "</Students>\n";
		s += "	<Activity_Tag>" + GlobalMembersTimetable_defs.protect(this.activityTagName) + "</Activity_Tag>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintStudentsSetActivityTagMaxHoursContinuously>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Students set %1 for activity tag %2 has max %3 hours continuously").arg(this.students).arg(this.activityTagName).arg(this.maxHoursContinuously);
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("A students set, for an activity tag, must respect the maximum number of hours continuously");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Students set=%1").arg(this.students);
		s += "\n";
		s += tr("Activity tag=%1").arg(this.activityTagName);
		s += "\n";
		s += tr("Maximum hours continuously=%1").arg(this.maxHoursContinuously);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		nbroken = 0;

		foreach (int i, this.canonicalSubgroupsList)
		{
			StudentsSubgroup sbg = r.internalSubgroupsList[i];
			int[,] crtSubgroupTimetableActivityTag = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK, GlobalMembersTimetable_defs.MAX_HOURS_PER_DAY];
			for (int d = 0; d < r.nDaysPerWeek; d++)
				for (int h = 0; h < r.nHoursPerDay; h++)
					crtSubgroupTimetableActivityTag[d, h] = -1;
			foreach (int ai, sbg.activitiesForSubgroup)if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
				int d = c.times[ai] % r.nDaysPerWeek;
				int h = c.times[ai] / r.nDaysPerWeek;
				for (int dur = 0; dur < r.internalActivitiesList[ai].duration; dur++)
				{
					Debug.Assert(h + dur < r.nHoursPerDay);
					Debug.Assert(crtSubgroupTimetableActivityTag[d, h + dur] == -1);
					if (r.internalActivitiesList[ai].iActivityTagsSet.contains(this.activityTagIndex))
						crtSubgroupTimetableActivityTag[d, h + dur] = this.activityTagIndex;
				}
			}

			for (int d = 0; d < r.nDaysPerWeek; d++)
			{
				int nc = 0;
				for (int h = 0; h < r.nHoursPerDay; h++)
				{
					bool inc = false;

					if (crtSubgroupTimetableActivityTag[d, h] == this.activityTagIndex)
						inc = true;

					if (inc)
						nc++;
					else
					{
						if (nc > this.maxHoursContinuously)
						{
							nbroken++;

							if (conflictsString != null)
							{
								QString s = (tr("Time constraint students set max %1 hours continuously broken for subgroup %2, on day %3, length=%4.").arg(CustomFETString.number(this.maxHoursContinuously)).arg(r.internalSubgroupsList[i].name).arg(r.daysOfTheWeek[d]).arg(nc)) + " " + (tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100)));

								dl.append(s);
								cl.append(weightPercentage / 100);

								conflictsString += s + "\n";
							}
						}

						nc = 0;
					}
				}

				if (nc > this.maxHoursContinuously)
				{
					nbroken++;

					if (conflictsString != null)
					{
						QString s = (tr("Time constraint students set max %1 hours continuously broken for subgroup %2, on day %3, length=%4.").arg(CustomFETString.number(this.maxHoursContinuously)).arg(r.internalSubgroupsList[i].name).arg(r.daysOfTheWeek[d]).arg(nc)) + " " + (tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100)));

						dl.append(s);
						cl.append(weightPercentage / 100);

						conflictsString += s + "\n";
					}
				}
			}
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		return r.setsShareStudents(this.students, s.name);
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxHoursContinuously > r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxHoursContinuously > r.nHoursPerDay)
			maxHoursContinuously = r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintStudentsMinHoursDaily: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintStudentsMinHoursDaily) public: int minHoursDaily;

	private bool allowEmptyDays;


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintStudentsMinHoursDaily() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_MIN_HOURS_DAILY;
		this.minHoursDaily = -1;

		this.allowEmptyDays = false;
	}

	private ConstraintStudentsMinHoursDaily(double wp, int minnh, bool _allowEmptyDays) : base(wp)
	{
		this.minHoursDaily = minnh;
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_MIN_HOURS_DAILY;

		this.allowEmptyDays = _allowEmptyDays;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);
		Q_UNUSED(r);

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintStudentsMinHoursDaily>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		if (this.minHoursDaily >= 0)
			s += "	<Minimum_Hours_Daily>" + CustomFETString.number(this.minHoursDaily) + "</Minimum_Hours_Daily>\n";
		else
			Debug.Assert(0);
		if (this.allowEmptyDays)
			s += "	<Allow_Empty_Days>true</Allow_Empty_Days>\n";
		else
			s += "	<Allow_Empty_Days>false</Allow_Empty_Days>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintStudentsMinHoursDaily>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();

		if (this.allowEmptyDays)
			s += "! ";
		s += tr("Students min hours daily");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("mH:%1", "Min hours (daily)").arg(this.minHoursDaily);
		s += ", ";
		s += tr("AED:%1", "Allow empty days").arg(GlobalMembersSpaceconstraint.yesNoTranslated(this.allowEmptyDays));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		if (this.allowEmptyDays == true)
		{
			s += tr("(nonstandard, students may have empty days)");
			s += "\n";
		}
		s += tr("All students must respect the minimum number of hours daily");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Minimum hours daily=%1").arg(this.minHoursDaily);
		s += "\n";
		s += tr("Allow empty days=%1").arg(GlobalMembersSpaceconstraint.yesNoTranslated(this.allowEmptyDays));
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int tmp;
		int too_little;

		Debug.Assert(this.minHoursDaily >= 0);

		too_little = 0;
		for (int i = 0; i < r.nInternalSubgroups; i++)
			for (int j = 0; j < r.nDaysPerWeek; j++)
			{
				tmp = 0;
				for (int k = 0; k < r.nHoursPerDay; k++)
				{
					if (GlobalMembersTimeconstraint.subgroupsMatrix[i][j][k] >= 1)
						tmp++;
				}

				bool searchDay;
				if (this.allowEmptyDays == true)
					searchDay = (tmp > 0);
				else
					searchDay = true;

				if (searchDay && this.minHoursDaily >= 0 && tmp < this.minHoursDaily) //we would like no less than minHoursDaily hours per day. - tmp>0
				{
					too_little += - tmp + this.minHoursDaily;

					if (conflictsString != null)
					{
						QString s = tr("Time constraint students min hours daily broken for subgroup: %1, day: %2, lenght=%3, conflict increase=%4").arg(r.internalSubgroupsList[i].name).arg(r.daysOfTheWeek[j]).arg(CustomFETString.number(tmp)).arg(CustomFETString.number(weightPercentage / 100 * (-tmp + this.minHoursDaily)));

						dl.append(s);
						cl.append(weightPercentage / 100 * (-tmp + this.minHoursDaily));

						conflictsString += s + "\n";
					}
				}
			}

		//should not consider for empty days

		Debug.Assert(too_little >= 0);

		if (c.nPlacedActivities == r.nInternalActivities)
			if (weightPercentage == 100) //does not work for partial solutions
				Debug.Assert(too_little == 0);

		return too_little * weightPercentage / 100;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return true;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (minHoursDaily > r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (minHoursDaily > r.nHoursPerDay)
			minHoursDaily = r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintStudentsSetMinHoursDaily: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintStudentsSetMinHoursDaily) public: int minHoursDaily;

	/**
	The students set name
	*/
	private QString students = new QString();

	private bool allowEmptyDays;

	//internal variables

	/**
	The number of subgroups
	*/
	//int nSubgroups;

	/**
	The subgroups
	*/
	//int subgroups[MAX_SUBGROUPS_PER_CONSTRAINT];
	private QList<int> iSubgroupsList = new QList<int>();


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintStudentsSetMinHoursDaily() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MIN_HOURS_DAILY;
		this.minHoursDaily = -1;

		this.allowEmptyDays = false;
	}

	private ConstraintStudentsSetMinHoursDaily(double wp, int minnh, QString s, bool _allowEmptyDays) : base(wp)
	{
		this.minHoursDaily = minnh;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->students = s;
		this.students.CopyFrom(s);
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MIN_HOURS_DAILY;

		this.allowEmptyDays = _allowEmptyDays;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		StudentsSet ss = r.searchAugmentedStudentsSet(this.students);

		if (ss == null)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint students set min hours daily is wrong because it refers to inexistent students set." + " Please correct it (removing it might be a solution). Please report potential bug. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}

		Debug.Assert(ss);

		this.iSubgroupsList.clear();
		if (ss.type == GlobalMembersStudentsset.STUDENTS_SUBGROUP)
		{
			int tmp;
			tmp = ((StudentsSubgroup)ss).indexInInternalSubgroupsList;
			Debug.Assert(tmp >= 0);
			Debug.Assert(tmp < r.nInternalSubgroups);
			if (!this.iSubgroupsList.contains(tmp))
				this.iSubgroupsList.append(tmp);
		}
		else if (ss.type == GlobalMembersStudentsset.STUDENTS_GROUP)
		{
			StudentsGroup stg = (StudentsGroup)ss;
			for (int i = 0; i < stg.subgroupsList.size(); i++)
			{
				StudentsSubgroup sts = stg.subgroupsList[i];
				int tmp;
				tmp = sts.indexInInternalSubgroupsList;
				Debug.Assert(tmp >= 0);
				Debug.Assert(tmp < r.nInternalSubgroups);
				if (!this.iSubgroupsList.contains(tmp))
					this.iSubgroupsList.append(tmp);
			}
		}
		else if (ss.type == GlobalMembersStudentsset.STUDENTS_YEAR)
		{
			StudentsYear sty = (StudentsYear)ss;
			for (int i = 0; i < sty.groupsList.size(); i++)
			{
				StudentsGroup stg = sty.groupsList[i];
				for (int j = 0; j < stg.subgroupsList.size(); j++)
				{
					StudentsSubgroup sts = stg.subgroupsList[j];
					int tmp;
					tmp = sts.indexInInternalSubgroupsList;
					Debug.Assert(tmp >= 0);
					Debug.Assert(tmp < r.nInternalSubgroups);
					if (!this.iSubgroupsList.contains(tmp))
						this.iSubgroupsList.append(tmp);
				}
			}
		}
		else
			Debug.Assert(0);

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintStudentsSetMinHoursDaily>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Minimum_Hours_Daily>" + CustomFETString.number(this.minHoursDaily) + "</Minimum_Hours_Daily>\n";
		s += "	<Students>" + GlobalMembersTimetable_defs.protect(this.students) + "</Students>\n";
		if (this.allowEmptyDays)
			s += "	<Allow_Empty_Days>true</Allow_Empty_Days>\n";
		else
			s += "	<Allow_Empty_Days>false</Allow_Empty_Days>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintStudentsSetMinHoursDaily>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();

		if (this.allowEmptyDays)
			s += "! ";
		s += tr("Students set min hours daily");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("St:%1", "Students (set)").arg(this.students);
		s += ", ";
		s += tr("mH:%1", "Min hours (daily)").arg(this.minHoursDaily);
		s += ", ";
		s += tr("AED:%1", "Allow empty days").arg(GlobalMembersSpaceconstraint.yesNoTranslated(this.allowEmptyDays));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		if (this.allowEmptyDays == true)
		{
			s += tr("(nonstandard, students may have empty days)");
			s += "\n";
		}
		s += tr("A students set must respect the minimum number of hours daily");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Students set=%1").arg(this.students);
		s += "\n";
		s += tr("Minimum hours daily=%1").arg(this.minHoursDaily);
		s += "\n";
		s += tr("Allow empty days=%1").arg(GlobalMembersSpaceconstraint.yesNoTranslated(this.allowEmptyDays));
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int tmp;
		int too_little;

		Debug.Assert(this.minHoursDaily >= 0);

		too_little = 0;
		for (int sg = 0; sg < this.iSubgroupsList.count(); sg++)
		{
			int i = iSubgroupsList.at(sg);
			for (int j = 0; j < r.nDaysPerWeek; j++)
			{
				tmp = 0;
				for (int k = 0; k < r.nHoursPerDay; k++)
				{
					if (GlobalMembersTimeconstraint.subgroupsMatrix[i][j][k] >= 1)
						tmp++;
				}

				bool searchDay;
				if (this.allowEmptyDays == true)
					searchDay = (tmp > 0);
				else
					searchDay = true;

				if (searchDay && this.minHoursDaily >= 0 && tmp < this.minHoursDaily) //tmp>0
				{
					too_little += - tmp + this.minHoursDaily;

					if (conflictsString != null)
					{
						QString s = tr("Time constraint students set min hours daily broken for subgroup: %1, day: %2, lenght=%3, conflicts increase=%4").arg(r.internalSubgroupsList[i].name).arg(r.daysOfTheWeek[j]).arg(CustomFETString.number(tmp)).arg(CustomFETString.number((-tmp + this.minHoursDaily) * weightPercentage / 100));

						dl.append(s);
						cl.append((-tmp + this.minHoursDaily) * weightPercentage / 100);

						conflictsString += s + "\n";
					}
				}
			}
		}

		Debug.Assert(too_little >= 0);

		if (c.nPlacedActivities == r.nInternalActivities)
			if (weightPercentage == 100) //does not work for partial solutions
				Debug.Assert(too_little == 0);

		return too_little * weightPercentage / 100.0;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		return r.setsShareStudents(this.students, s.name);
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (minHoursDaily > r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (minHoursDaily > r.nHoursPerDay)
			minHoursDaily = r.nHoursPerDay;

		return true;
	}
}

/**
This is a constraint.
It adds, to the fitness of the solution, a fitness factor that
grows as the activity is scheduled farther from the wanted time
For the moment, fitness factor increases with one unit for every hour
and one unit for every day.
*/
public abstract class ConstraintActivityPreferredStartingTime: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintActivityPreferredStartingTime) public: int activityId;
	/**
	Activity id
	*/

	/**
	The preferred day. If -1, then the user does not care about the day.
	*/
	private int day;

	/**
	The preferred hour. If -1, then the user does not care about the hour.
	*/
	private int hour;

	private bool permanentlyLocked; //if this is true, then this activity cannot be unlocked from the timetable view form

	//internal variables
	/**
	The index of the activity in the rules (from 0 to rules.nActivities-1) - it is not the id of the activity
	*/
	private int activityIndex;


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintActivityPreferredStartingTime() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITY_PREFERRED_STARTING_TIME;
	}

	private ConstraintActivityPreferredStartingTime(double wp, int actId, int d, int h, bool perm) : base(wp)
	{
		this.activityId = actId;
		this.day = d;
		this.hour = h;
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITY_PREFERRED_STARTING_TIME;
		this.permanentlyLocked = perm;
	}

	/**
	Comparison operator - to be sure that we do not introduce duplicates
	*/
	private static bool operator == (ConstraintActivityPreferredStartingTime ImpliedObject, ref ConstraintActivityPreferredStartingTime c)
	{
		if (ImpliedObject.day != c.day)
			return false;
		if (ImpliedObject.hour != c.hour)
			return false;
		if (ImpliedObject.activityId != c.activityId)
			return false;
		if (ImpliedObject.weightPercentage != c.weightPercentage)
			return false;
		if (ImpliedObject.active != c.active)
			return false;
		//no need to care about permanently locked
		return true;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Activity act;
		int i;
		for (i = 0; i < r.nInternalActivities; i++)
		{
			act = r.internalActivitiesList[i];
			if (act.id == this.activityId)
				break;
		}

		if (i == r.nInternalActivities)
		{
			//assert(0);
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (because it refers to invalid activity id. Please correct (maybe removing it is a solution)):\n%1").arg(this.getDetailedDescription(ref r)));
			return false;
		}

		if (this.day >= r.nDaysPerWeek)
		{
			TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint activity preferred time is wrong because it refers to removed day. Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}
		if (this.hour == r.nHoursPerDay)
		{
			TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint activity preferred time is wrong because preferred hour is too late (after the last acceptable slot). Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}
		if (this.hour > r.nHoursPerDay)
		{
			TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint activity preferred time is wrong because it refers to removed hour. Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}

		this.activityIndex = i;
		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		if (r.inactiveActivities.contains(this.activityId))
			return true;
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintActivityPreferredStartingTime>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Activity_Id>" + CustomFETString.number(this.activityId) + "</Activity_Id>\n";
		if (this.day >= 0)
			s += "	<Preferred_Day>" + GlobalMembersTimetable_defs.protect(r.daysOfTheWeek[this.day]) + "</Preferred_Day>\n";
		if (this.hour >= 0)
			s += "	<Preferred_Hour>" + GlobalMembersTimetable_defs.protect(r.hoursOfTheDay[this.hour]) + "</Preferred_Hour>\n";
		s += "	<Permanently_Locked>";
		s += GlobalMembersSpaceconstraint.trueFalse(this.permanentlyLocked);
		s += "</Permanently_Locked>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintActivityPreferredStartingTime>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Act. id: %1 (%2) has a preferred starting time: %3", "%1 is the id, %2 is the detailed description of the activity. %3 is time (day and hour)").arg(this.activityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activityId)).arg(r.daysOfTheWeek[this.day] + " " + r.hoursOfTheDay[this.hour]);

		s += ", ";

		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("PL:%1", "Abbreviation for permanently locked").arg(GlobalMembersSpaceconstraint.yesNoTranslated(this.permanentlyLocked));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		QString s = tr("Time constraint");
		s += "\n";
		s += tr("Activity with id=%1 (%2)", "%1 is the id, %2 is the detailed description of the activity").arg(this.activityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activityId));
		s += "\n";

		s += tr("has a preferred starting time:");
		s += "\n";
		s += tr("Day=%1").arg(r.daysOfTheWeek[this.day]);
		s += "\n";
		s += tr("Hour=%1").arg(r.hoursOfTheDay[this.hour]);
		s += "\n";

		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		if (this.permanentlyLocked)
		{
			s += tr("This activity is permanently locked, which means you cannot unlock it from the 'Timetable' menu" + " (you can unlock this activity by removing the constraint from the constraints dialog or by setting the 'permanently" + " locked' attribute false when editing this constraint)");
		}
		else
		{
			s += tr("This activity is not permanently locked, which means you can unlock it from the 'Timetable' menu");
		}
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		Debug.Assert(r.internalStructureComputed);

		nbroken = 0;
		if (c.times[this.activityIndex] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
		{
			int d = c.times[this.activityIndex] % r.nDaysPerWeek; //the day when this activity was scheduled
			int h = c.times[this.activityIndex] / r.nDaysPerWeek; //the hour
			if (this.day >= 0)
				nbroken += Math.Abs(this.day - d);
			if (this.hour >= 0)
				nbroken += Math.Abs(this.hour - h);
		}
		if (nbroken > 0)
			nbroken = 1;

		if (conflictsString != null && nbroken > 0)
		{
			QString s = tr("Time constraint activity preferred starting time broken for activity with id=%1 (%2), increases conflicts total by %3", "%1 is the id, %2 is the detailed description of the activity").arg(this.activityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activityId)).arg(CustomFETString.number(weightPercentage / 100 * nbroken));

			dl.append(s);
			cl.append(weightPercentage / 100 * nbroken);

			conflictsString += s + "\n";
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return nbroken * weightPercentage / 100;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);

		if (this.activityId == a.id)
			return true;
		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (day<0 || day >= r.nDaysPerWeek || hour<0 || hour >= r.nHoursPerDay)
			return true;
		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return false;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return false;
	}
}

/**
This is a constraint.
It returns conflicts if the activity is scheduled in another interval
than the preferred set of times.
*/
public abstract class ConstraintActivityPreferredTimeSlots: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintActivityPreferredTimeSlots) public: int p_activityId;
	/**
	Activity id
	*/

	/**
	The number of preferred times
	*/
	private int p_nPreferredTimeSlots_L;

	/**
	The preferred days. If -1, then the user does not care about the day.
	*/
	//int p_days[MAX_N_CONSTRAINT_ACTIVITY_PREFERRED_TIME_SLOTS];
	private QList<int> p_days_L = new QList<int>();

	/**
	The preferred hour. If -1, then the user does not care about the hour.
	*/
	//int p_hours[MAX_N_CONSTRAINT_ACTIVITY_PREFERRED_TIME_SLOTS];
	private QList<int> p_hours_L = new QList<int>();

	//internal variables
	/**
	The index of the activity in the rules (from 0 to rules.nActivities-1) - it is not the id of the activity
	*/
	private int p_activityIndex;


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintActivityPreferredTimeSlots() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITY_PREFERRED_TIME_SLOTS;
	}

	//ConstraintActivityPreferredTimeSlots(double wp, int actId, int nPT, int d[], int h[]);
	private ConstraintActivityPreferredTimeSlots(double wp, int actId, int nPT_L, QList<int> d_L, QList<int> h_L) : base(wp)
	{
		Debug.Assert(d_L.count() == nPT_L);
		Debug.Assert(h_L.count() == nPT_L);

		this.p_activityId = actId;
		this.p_nPreferredTimeSlots_L = nPT_L;
		this.p_days_L = d_L;
		this.p_hours_L = h_L;
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITY_PREFERRED_TIME_SLOTS;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Activity act;
		int i;
		for (i = 0; i < r.nInternalActivities; i++)
		{
			act = r.internalActivitiesList[i];
			if (act.id == this.p_activityId)
				break;
		}

		if (i == r.nInternalActivities)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (because it refers to invalid activity id. Please correct it (maybe removing it is a solution)):\n%1").arg(this.getDetailedDescription(ref r)));
			//assert(0);
			return false;
		}

		for (int k = 0; k < p_nPreferredTimeSlots_L; k++)
		{
			if (this.p_days_L[k] >= r.nDaysPerWeek)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint activity preferred time slots is wrong because it refers to removed day. Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
			if (this.p_hours_L[k] == r.nHoursPerDay)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint activity preferred time slots is wrong because a preferred hour is too late (after the last acceptable slot). Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
			if (this.p_hours_L[k] > r.nHoursPerDay)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint activity preferred time slots is wrong because it refers to removed hour. Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}

			if (this.p_hours_L[k] < 0 || this.p_days_L[k] < 0)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint activity preferred time slots is wrong because it has hour or day not specified for a slot (-1). Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
		}

		this.p_activityIndex = i;
		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		if (r.inactiveActivities.contains(this.p_activityId))
			return true;
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		QString s = "<ConstraintActivityPreferredTimeSlots>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Activity_Id>" + CustomFETString.number(this.p_activityId) + "</Activity_Id>\n";
		s += "	<Number_of_Preferred_Time_Slots>" + CustomFETString.number(this.p_nPreferredTimeSlots_L) + "</Number_of_Preferred_Time_Slots>\n";
		for (int i = 0; i < p_nPreferredTimeSlots_L; i++)
		{
			s += "	<Preferred_Time_Slot>\n";
			if (this.p_days_L[i] >= 0)
				s += "		<Preferred_Day>" + GlobalMembersTimetable_defs.protect(r.daysOfTheWeek[this.p_days_L[i]]) + "</Preferred_Day>\n";
			if (this.p_hours_L[i] >= 0)
				s += "		<Preferred_Hour>" + GlobalMembersTimetable_defs.protect(r.hoursOfTheDay[this.p_hours_L[i]]) + "</Preferred_Hour>\n";
			s += "	</Preferred_Time_Slot>\n";
		}
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintActivityPreferredTimeSlots>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Act. id: %1 (%2)", "%1 is the id, %2 is the detailed description of the activity").arg(this.p_activityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.p_activityId));
		s += " ";

		s += tr("has a set of preferred time slots:");
		s += " ";
		for (int i = 0; i < this.p_nPreferredTimeSlots_L; i++)
		{
			if (this.p_days_L[i] >= 0)
			{
				s += r.daysOfTheWeek[this.p_days_L[i]];
				s += " ";
			}
			if (this.p_hours_L[i] >= 0)
			{
				s += r.hoursOfTheDay[this.p_hours_L[i]];
			}
			if (i < this.p_nPreferredTimeSlots_L - 1)
				s += "; ";
		}
		s += ", ";

		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		QString s = tr("Time constraint");
		s += "\n";
		s += tr("Activity with id=%1 (%2)", "%1 is the id, %2 is the detailed description of the activity").arg(this.p_activityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.p_activityId));
		s += "\n";

		s += tr("has a set of preferred time slots (all hours of the activity must be in the allowed slots):");
		s += "\n";
		for (int i = 0; i < this.p_nPreferredTimeSlots_L; i++)
		{
			if (this.p_days_L[i] >= 0)
			{
				s += r.daysOfTheWeek[this.p_days_L[i]];
				s += " ";
			}
			if (this.p_hours_L[i] >= 0)
			{
				s += r.hoursOfTheDay[this.p_hours_L[i]];
			}
			if (i < this.p_nPreferredTimeSlots_L - 1)
				s += ";  ";
		}
		s += "\n";

		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		Debug.Assert(r.internalStructureComputed);

		Matrix2D<bool> allowed = new Matrix2D<bool>();
		allowed.resize(r.nDaysPerWeek, r.nHoursPerDay);
		//bool allowed[MAX_DAYS_PER_WEEK][MAX_HOURS_PER_DAY];
		for (int d = 0; d < r.nDaysPerWeek; d++)
			for (int h = 0; h < r.nHoursPerDay; h++)
				allowed[d][h] = false;
		for (int i = 0; i < this.p_nPreferredTimeSlots_L; i++)
		{
			if (this.p_days_L[i] >= 0 && this.p_hours_L[i] >= 0)
				allowed[this.p_days_L[i]][this.p_hours_L[i]] = true;
			else
				Debug.Assert(0);
		}

		nbroken = 0;
		if (c.times[this.p_activityIndex] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
		{
			int d = c.times[this.p_activityIndex] % r.nDaysPerWeek; //the day when this activity was scheduled
			int h = c.times[this.p_activityIndex] / r.nDaysPerWeek; //the hour
			for (int dur = 0; dur < r.internalActivitiesList[this.p_activityIndex].duration; dur++)
				if (!allowed[d][h + dur])
					nbroken++;
		}

		if (conflictsString != null && nbroken > 0)
		{
			QString s = tr("Time constraint activity preferred time slots broken for activity with id=%1 (%2) on %3 hours, increases conflicts total by %4", "%1 is the id, %2 is the detailed description of the activity.").arg(this.p_activityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.p_activityId)).arg(nbroken).arg(CustomFETString.number(weightPercentage / 100 * nbroken));

			dl.append(s);
			cl.append(weightPercentage / 100 * nbroken);

			conflictsString += s + "\n";
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return nbroken * weightPercentage / 100;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);

		if (this.p_activityId == a.id)
			return true;
		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(p_nPreferredTimeSlots_L == p_days_L.count());
		Debug.Assert(p_nPreferredTimeSlots_L == p_hours_L.count());

		for (int i = 0; i < p_nPreferredTimeSlots_L; i++)
			if (p_days_L.at(i)<0 || p_days_L.at(i) >= r.nDaysPerWeek || p_hours_L.at(i)<0 || p_hours_L.at(i) >= r.nHoursPerDay)
				return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		Debug.Assert(p_nPreferredTimeSlots_L == p_days_L.count());
		Debug.Assert(p_nPreferredTimeSlots_L == p_hours_L.count());

		QList<int> newDays = new QList<int>();
		QList<int> newHours = new QList<int>();
		int newNPref = 0;

		for (int i = 0; i < p_nPreferredTimeSlots_L; i++)
			if (p_days_L.at(i) >= 0 && p_days_L.at(i)<r.nDaysPerWeek && p_hours_L.at(i) >= 0 && p_hours_L.at(i) < r.nHoursPerDay)
			{
				newDays.append(p_days_L.at(i));
				newHours.append(p_hours_L.at(i));
				newNPref++;
			}

		p_nPreferredTimeSlots_L = newNPref;
		p_days_L = newDays;
		p_hours_L = newHours;

		r.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(r);

		return true;
	}
}

public abstract class ConstraintActivityPreferredStartingTimes: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintActivityPreferredStartingTimes) public: int activityId;
	/**
	Activity id
	*/

	/**
	The number of preferred times
	*/
	private int nPreferredStartingTimes_L;

	/**
	The preferred days. If -1, then the user does not care about the day.
	*/
	//int days[MAX_N_CONSTRAINT_ACTIVITY_PREFERRED_STARTING_TIMES];
	private QList<int> days_L = new QList<int>();

	/**
	The preferred hour. If -1, then the user does not care about the hour.
	*/
	//int hours[MAX_N_CONSTRAINT_ACTIVITY_PREFERRED_STARTING_TIMES];
	private QList<int> hours_L = new QList<int>();

	//internal variables
	/**
	The index of the activity in the rules (from 0 to rules.nActivities-1) - it is not the id of the activity
	*/
	private int activityIndex;


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintActivityPreferredStartingTimes() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITY_PREFERRED_STARTING_TIMES;
	}

	//ConstraintActivityPreferredStartingTimes(double wp, int actId, int nPT, int d[], int h[]);
	private ConstraintActivityPreferredStartingTimes(double wp, int actId, int nPT_L, QList<int> d_L, QList<int> h_L) : base(wp)
	{
		Debug.Assert(d_L.count() == nPT_L);
		Debug.Assert(h_L.count() == nPT_L);

		this.activityId = actId;
		this.nPreferredStartingTimes_L = nPT_L;
		this.days_L = d_L;
		this.hours_L = h_L;
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITY_PREFERRED_STARTING_TIMES;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Activity act;
		int i;
		for (i = 0; i < r.nInternalActivities; i++)
		{
			act = r.internalActivitiesList[i];
			if (act.id == this.activityId)
				break;
		}

		if (i == r.nInternalActivities)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (because it refers to invalid activity id. Please correct it (maybe removing it is a solution)):\n%1").arg(this.getDetailedDescription(ref r)));
			return false;
		}

		for (int k = 0; k < nPreferredStartingTimes_L; k++)
		{
			if (this.days_L[k] >= r.nDaysPerWeek)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint activity preferred starting times is wrong because it refers to removed day. Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
			if (this.hours_L[k] == r.nHoursPerDay)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint activity preferred starting times is wrong because a preferred hour is too late (after the last acceptable slot). Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
			if (this.hours_L[k] > r.nHoursPerDay)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint activity preferred starting times is wrong because it refers to removed hour. Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
		}

		this.activityIndex = i;
		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		if (r.inactiveActivities.contains(this.activityId))
			return true;
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		QString s = "<ConstraintActivityPreferredStartingTimes>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Activity_Id>" + CustomFETString.number(this.activityId) + "</Activity_Id>\n";
		s += "	<Number_of_Preferred_Starting_Times>" + CustomFETString.number(this.nPreferredStartingTimes_L) + "</Number_of_Preferred_Starting_Times>\n";
		for (int i = 0; i < nPreferredStartingTimes_L; i++)
		{
			s += "	<Preferred_Starting_Time>\n";
			if (this.days_L[i] >= 0)
				s += "		<Preferred_Starting_Day>" + GlobalMembersTimetable_defs.protect(r.daysOfTheWeek[this.days_L[i]]) + "</Preferred_Starting_Day>\n";
			if (this.hours_L[i] >= 0)
				s += "		<Preferred_Starting_Hour>" + GlobalMembersTimetable_defs.protect(r.hoursOfTheDay[this.hours_L[i]]) + "</Preferred_Starting_Hour>\n";
			s += "	</Preferred_Starting_Time>\n";
		}
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintActivityPreferredStartingTimes>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Act. id: %1 (%2)", "%1 is the id, %2 is the detailed description of the activity.").arg(this.activityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activityId));

		s += " ";
		s += tr("has a set of preferred starting times:");
		s += " ";
		for (int i = 0; i < this.nPreferredStartingTimes_L; i++)
		{
			if (this.days_L[i] >= 0)
			{
				s += r.daysOfTheWeek[this.days_L[i]];
				s += " ";
			}
			if (this.hours_L[i] >= 0)
			{
				s += r.hoursOfTheDay[this.hours_L[i]];
			}
			if (i < nPreferredStartingTimes_L - 1)
				s += "; ";
		}
		s += ", ";

		s += tr("WP:%1%", "Weight Percentage").arg(CustomFETString.number(this.weightPercentage));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		QString s = tr("Time constraint");
		s += "\n";
		s += tr("Activity with id=%1 (%2)", "%1 is the id, %2 is the detailed description of the activity").arg(this.activityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activityId));

		s += "\n";
		s += tr("has a set of preferred starting times:");
		s += "\n";
		for (int i = 0; i < this.nPreferredStartingTimes_L; i++)
		{
			if (this.days_L[i] >= 0)
			{
				s += r.daysOfTheWeek[this.days_L[i]];
				s += " ";
			}
			if (this.hours_L[i] >= 0)
			{
				s += r.hoursOfTheDay[this.hours_L[i]];
			}
			if (i < this.nPreferredStartingTimes_L - 1)
				s += ";  ";
		}
		s += "\n";

		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		Debug.Assert(r.internalStructureComputed);

		nbroken = 0;
		if (c.times[this.activityIndex] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
		{
			int d = c.times[this.activityIndex] % r.nDaysPerWeek; //the day when this activity was scheduled
			int h = c.times[this.activityIndex] / r.nDaysPerWeek; //the hour
			int i;
			for (i = 0; i < this.nPreferredStartingTimes_L; i++)
			{
				if (this.days_L[i] >= 0 && this.days_L[i] != d)
					continue;
				if (this.hours_L[i] >= 0 && this.hours_L[i] != h)
					continue;
				break;
			}
			if (i == this.nPreferredStartingTimes_L)
			{
				nbroken = 1;
			}
		}

		if (conflictsString != null && nbroken > 0)
		{
			QString s = tr("Time constraint activity preferred starting times broken for activity with id=%1 (%2), increases conflicts total by %3", "%1 is the id, %2 is the detailed description of the activity").arg(this.activityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activityId)).arg(CustomFETString.number(weightPercentage / 100 * nbroken));

			dl.append(s);
			cl.append(weightPercentage / 100 * nbroken);

			conflictsString += s + "\n";
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return nbroken * weightPercentage / 100;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);

		if (this.activityId == a.id)
			return true;
		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(nPreferredStartingTimes_L == days_L.count());
		Debug.Assert(nPreferredStartingTimes_L == hours_L.count());

		for (int i = 0; i < nPreferredStartingTimes_L; i++)
			if (days_L.at(i)<0 || days_L.at(i) >= r.nDaysPerWeek || hours_L.at(i)<0 || hours_L.at(i) >= r.nHoursPerDay)
				return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		Debug.Assert(nPreferredStartingTimes_L == days_L.count());
		Debug.Assert(nPreferredStartingTimes_L == hours_L.count());

		QList<int> newDays = new QList<int>();
		QList<int> newHours = new QList<int>();
		int newNPref = 0;

		for (int i = 0; i < nPreferredStartingTimes_L; i++)
			if (days_L.at(i) >= 0 && days_L.at(i)<r.nDaysPerWeek && hours_L.at(i) >= 0 && hours_L.at(i) < r.nHoursPerDay)
			{
				newDays.append(days_L.at(i));
				newHours.append(hours_L.at(i));
				newNPref++;
			}

		nPreferredStartingTimes_L = newNPref;
		days_L = newDays;
		hours_L = newHours;

		r.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(r);

		return true;
	}
}

/**
This is a constraint.
It returns conflicts if a set of activities is scheduled in another interval
than the preferred set of times.
The set of activities is specified by a subject, teacher, students or a combination
of these.
*/
public abstract class ConstraintActivitiesPreferredTimeSlots: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintActivitiesPreferredTimeSlots) public: QString p_teacherName;
	/**
	The teacher. If void, all teachers.
	*/

	/**
	The students. If void, all students.
	*/
	private QString p_studentsName = new QString();

	/**
	The subject. If void, all subjects.
	*/
	private QString p_subjectName = new QString();

	/**
	The activity tag. If void, all activity tags.
	*/
	private QString p_activityTagName = new QString();

	/**
	The number of preferred times
	*/
	private int p_nPreferredTimeSlots_L;

	/**
	The preferred days. If -1, then the user does not care about the day.
	*/
	//int p_days[MAX_N_CONSTRAINT_ACTIVITIES_PREFERRED_TIME_SLOTS];
	private QList<int> p_days_L = new QList<int>();

	/**
	The preferred hours. If -1, then the user does not care about the hour.
	*/
	//int p_hours[MAX_N_CONSTRAINT_ACTIVITIES_PREFERRED_TIME_SLOTS];
	private QList<int> p_hours_L = new QList<int>();

	//internal variables

	/**
	The number of activities which are represented by the subject, teacher and students requirements.
	*/
	private int p_nActivities;

	/**
	The indices of the activities in the rules (from 0 to rules.nActivities-1)
	These are indices in the internal list -> Rules::internalActivitiesList
	*/
	//int p_activitiesIndices[MAX_ACTIVITIES];
	private QList<int> p_activitiesIndices = new QList<int>();


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintActivitiesPreferredTimeSlots() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_PREFERRED_TIME_SLOTS;
	}

	//ConstraintActivitiesPreferredTimeSlots(double wp, QString te,
	//	QString st, QString su, QString sut, int nPT, int d[], int h[]);
	private ConstraintActivitiesPreferredTimeSlots(double wp, QString te, QString st, QString su, QString sut, int nPT_L, QList<int> d_L, QList<int> h_L) : base(wp)
	{
		Debug.Assert(d_L.count() == nPT_L);
		Debug.Assert(h_L.count() == nPT_L);

		this.p_teacherName = te;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->p_subjectName=su;
		this.p_subjectName.CopyFrom(su);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->p_activityTagName=sut;
		this.p_activityTagName.CopyFrom(sut);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->p_studentsName=st;
		this.p_studentsName.CopyFrom(st);
		this.p_nPreferredTimeSlots_L = nPT_L;
		this.p_days_L = d_L;
		this.p_hours_L = h_L;
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_PREFERRED_TIME_SLOTS;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		this.p_nActivities = 0;
		this.p_activitiesIndices.clear();

		int it;
		Activity act;
		int i;
		for (i = 0; i < r.nInternalActivities; i++)
		{
			act = r.internalActivitiesList[i];

			//check if this activity has the corresponding teacher
			if (this.p_teacherName != "")
			{
				it = act.teachersNames.indexOf(this.p_teacherName);
				if (it == -1)
					continue;
			}
			//check if this activity has the corresponding students
			if (this.p_studentsName != "")
			{
				bool commonStudents = false;
				foreach (QString st, act.studentsNames) if (r.setsShareStudents(st, p_studentsName))
				{
						commonStudents = true;
						break;
				}

				if (!commonStudents)
					continue;
			}
			//check if this activity has the corresponding subject
			if (this.p_subjectName != "" && act.subjectName != this.p_subjectName)
			{
				continue;
			}
			//check if this activity has the corresponding activity tag
			if (this.p_activityTagName != "" && !act.activityTagsNames.contains(this.p_activityTagName))
			{
				continue;
			}

			Debug.Assert(this.p_nActivities < GlobalMembersTimetable_defs.MAX_ACTIVITIES);
			this.p_nActivities++;
			this.p_activitiesIndices.append(i);
		}

		Debug.Assert(this.p_nActivities == this.p_activitiesIndices.count());

		//////////////////////
		for (int k = 0; k < p_nPreferredTimeSlots_L; k++)
		{
			if (this.p_days_L[k] >= r.nDaysPerWeek)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint activities preferred time slots is wrong because it refers to removed day. Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
			if (this.p_hours_L[k] == r.nHoursPerDay)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint activities preferred time slots is wrong because a preferred hour is too late (after the last acceptable slot). Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
			if (this.p_hours_L[k] > r.nHoursPerDay)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint activities preferred time slots is wrong because it refers to removed hour. Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
			if (this.p_hours_L[k] < 0 || this.p_days_L[k] < 0)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint activities preferred time slots is wrong because hour or day is not specified for a slot (-1). Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
		}
		///////////////////////

		if (this.p_nActivities > 0)
			return true;
		else
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (refers to no activities). Please correct it:\n%1").arg(this.getDetailedDescription(ref r)));
			return false;
		}
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		QList<int> localActiveActs = new QList<int>();
		QList<int> localAllActs = new QList<int>();

		//returns true if all activities are inactive
		int it;
		Activity act;
		int i;
		for (i = 0; i < r.activitiesList.count(); i++)
		{
			act = r.activitiesList.at(i);

			//check if this activity has the corresponding teacher
			if (this.p_teacherName != "")
			{
				it = act.teachersNames.indexOf(this.p_teacherName);
				if (it == -1)
					continue;
			}
			//check if this activity has the corresponding students
			if (this.p_studentsName != "")
			{
				bool commonStudents = false;
				foreach (QString st, act.studentsNames) if (r.setsShareStudents(st, p_studentsName))
				{
						commonStudents = true;
						break;
				}

				if (!commonStudents)
					continue;
			}
			//check if this activity has the corresponding subject
			if (this.p_subjectName != "" && act.subjectName != this.p_subjectName)
			{
					continue;
			}
			//check if this activity has the corresponding activity tag
			if (this.p_activityTagName != "" && !act.activityTagsNames.contains(this.p_activityTagName))
			{
					continue;
			}

			if (!r.inactiveActivities.contains(act.id))
				localActiveActs.append(act.id);

			localAllActs.append(act.id);
		}

		if (localActiveActs.count() == 0 && localAllActs.count() > 0)
		//because if this constraint does not refer to any activity,
		//it should be reported as incorrect
			return true;
		else
			return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		QString s = "<ConstraintActivitiesPreferredTimeSlots>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Teacher_Name>" + GlobalMembersTimetable_defs.protect(this.p_teacherName) + "</Teacher_Name>\n";
		s += "	<Students_Name>" + GlobalMembersTimetable_defs.protect(this.p_studentsName) + "</Students_Name>\n";
		s += "	<Subject_Name>" + GlobalMembersTimetable_defs.protect(this.p_subjectName) + "</Subject_Name>\n";
		s += "	<Activity_Tag_Name>" + GlobalMembersTimetable_defs.protect(this.p_activityTagName) + "</Activity_Tag_Name>\n";
		s += "	<Number_of_Preferred_Time_Slots>" + CustomFETString.number(this.p_nPreferredTimeSlots_L) + "</Number_of_Preferred_Time_Slots>\n";
		for (int i = 0; i < p_nPreferredTimeSlots_L; i++)
		{
			s += "	<Preferred_Time_Slot>\n";
			if (this.p_days_L[i] >= 0)
				s += "		<Preferred_Day>" + GlobalMembersTimetable_defs.protect(r.daysOfTheWeek[this.p_days_L[i]]) + "</Preferred_Day>\n";
			if (this.p_hours_L[i] >= 0)
				s += "		<Preferred_Hour>" + GlobalMembersTimetable_defs.protect(r.hoursOfTheDay[this.p_hours_L[i]]) + "</Preferred_Hour>\n";
			s += "	</Preferred_Time_Slot>\n";
		}
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintActivitiesPreferredTimeSlots>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();

		QString tc = new QString();
		QString st = new QString();
		QString su = new QString();
		QString at = new QString();

		if (this.p_teacherName != "")
			tc = tr("teacher=%1").arg(this.p_teacherName);
		else
			tc = tr("all teachers");

		if (this.p_studentsName != "")
			st = tr("students=%1").arg(this.p_studentsName);
		else
			st = tr("all students");

		if (this.p_subjectName != "")
			su = tr("subject=%1").arg(this.p_subjectName);
		else
			su = tr("all subjects");

		if (this.p_activityTagName != "")
			at += tr("activity tag=%1").arg(this.p_activityTagName);
		else
			at += tr("all activity tags");

		s += tr("Activities with %1, %2, %3, %4, have a set of preferred time slots:", "%1...%4 are conditions for the activities").arg(tc).arg(st).arg(su).arg(at);
		s += " ";
		for (int i = 0; i < this.p_nPreferredTimeSlots_L; i++)
		{
			if (this.p_days_L[i] >= 0)
			{
				s += r.daysOfTheWeek[this.p_days_L[i]];
				s += " ";
			}
			if (this.p_hours_L[i] >= 0)
			{
				s += r.hoursOfTheDay[this.p_hours_L[i]];
			}
			if (i < this.p_nPreferredTimeSlots_L - 1)
				s += "; ";
		}
		s += ", ";

		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		QString s = tr("Time constraint");
		s += "\n";
		s += tr("Activities with:");
		s += "\n";

		if (this.p_teacherName != "")
			s += tr("Teacher=%1").arg(this.p_teacherName);
		else
			s += tr("All teachers");
		s += "\n";
		if (this.p_studentsName != "")
			s += tr("Students=%1").arg(this.p_studentsName);
		else
			s += tr("All students");
		s += "\n";
		if (this.p_subjectName != "")
			s += tr("Subject=%1").arg(this.p_subjectName);
		else
			s += tr("All subjects");
		s += "\n";
		if (this.p_activityTagName != "")
			s += tr("Activity tag=%1").arg(this.p_activityTagName);
		else
			s += tr("All activity tags");
		s += "\n";

		s += tr("have a set of preferred time slots (all hours of each affected activity must be in the allowed slots):");
		s += "\n";
		for (int i = 0; i < this.p_nPreferredTimeSlots_L; i++)
		{
			if (this.p_days_L[i] >= 0)
			{
				s += r.daysOfTheWeek[this.p_days_L[i]];
				s += " ";
			}
			if (this.p_hours_L[i] >= 0)
			{
				s += r.hoursOfTheDay[this.p_hours_L[i]];
			}
			if (i < this.p_nPreferredTimeSlots_L - 1)
				s += ";  ";
		}
		s += "\n";

		s += tr("Weight (percentage)=%1").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		Debug.Assert(r.internalStructureComputed);

	///////////////////
		Matrix2D<bool> allowed = new Matrix2D<bool>();
		allowed.resize(r.nDaysPerWeek, r.nHoursPerDay);
		//bool allowed[MAX_DAYS_PER_WEEK][MAX_HOURS_PER_DAY];
		for (int d = 0; d < r.nDaysPerWeek; d++)
			for (int h = 0; h < r.nHoursPerDay; h++)
				allowed[d][h] = false;
		for (int i = 0; i < this.p_nPreferredTimeSlots_L; i++)
		{
			if (this.p_days_L[i] >= 0 && this.p_hours_L[i] >= 0)
				allowed[this.p_days_L[i]][this.p_hours_L[i]] = true;
			else
				Debug.Assert(0);
		}
	////////////////////

		nbroken = 0;
		int tmp;

		for (int i = 0; i < this.p_nActivities; i++)
		{
			tmp = 0;
			int ai = this.p_activitiesIndices[i];
			if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
				int d = c.times[ai] % r.nDaysPerWeek; //the day when this activity was scheduled
				int h = c.times[ai] / r.nDaysPerWeek; //the hour

				for (int dur = 0; dur < r.internalActivitiesList[ai].duration; dur++)
					if (!allowed[d][h + dur])
						tmp++;
			}
			nbroken += tmp;
			if (conflictsString != null && tmp > 0)
			{
				QString s = tr("Time constraint activities preferred time slots broken" + " for activity with id=%1 (%2) on %3 hours," + " increases conflicts total by %4", "%1 is the id, %2 is the detailed description of the activity.").arg(r.internalActivitiesList[ai].id).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, r.internalActivitiesList[ai].id)).arg(tmp).arg(CustomFETString.number(weightPercentage / 100 * tmp));

				dl.append(s);
				cl.append(weightPercentage / 100 * tmp);

				conflictsString += s + "\n";
			}
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return nbroken * weightPercentage / 100.0;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		int it;

		//check if this activity has the corresponding teacher
		if (this.p_teacherName != "")
		{
			it = a.teachersNames.indexOf(this.p_teacherName);
			if (it == -1)
				return false;
		}
		//check if this activity has the corresponding students
		if (this.p_studentsName != "")
		{
			bool commonStudents = false;
			foreach (QString st, a.studentsNames)
			{
				if (r.setsShareStudents(st, this.p_studentsName))
				{
					commonStudents = true;
					break;
				}
			}
			if (!commonStudents)
				return false;
		}
		//check if this activity has the corresponding subject
		if (this.p_subjectName != "" && a.subjectName != this.p_subjectName)
			return false;
		//check if this activity has the corresponding activity tag
		if (this.p_activityTagName != "" && !a.activityTagsNames.contains(this.p_activityTagName))
			return false;

		return true;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(p_nPreferredTimeSlots_L == p_days_L.count());
		Debug.Assert(p_nPreferredTimeSlots_L == p_hours_L.count());

		for (int i = 0; i < p_nPreferredTimeSlots_L; i++)
			if (p_days_L.at(i)<0 || p_days_L.at(i) >= r.nDaysPerWeek || p_hours_L.at(i)<0 || p_hours_L.at(i) >= r.nHoursPerDay)
				return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		Debug.Assert(p_nPreferredTimeSlots_L == p_days_L.count());
		Debug.Assert(p_nPreferredTimeSlots_L == p_hours_L.count());

		QList<int> newDays = new QList<int>();
		QList<int> newHours = new QList<int>();
		int newNPref = 0;

		for (int i = 0; i < p_nPreferredTimeSlots_L; i++)
			if (p_days_L.at(i) >= 0 && p_days_L.at(i)<r.nDaysPerWeek && p_hours_L.at(i) >= 0 && p_hours_L.at(i) < r.nHoursPerDay)
			{
				newDays.append(p_days_L.at(i));
				newHours.append(p_hours_L.at(i));
				newNPref++;
			}

		p_nPreferredTimeSlots_L = newNPref;
		p_days_L = newDays;
		p_hours_L = newHours;

		r.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(r);

		return true;
	}
}

public abstract class ConstraintSubactivitiesPreferredTimeSlots: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintSubactivitiesPreferredTimeSlots) public: int componentNumber;

	/**
	The teacher. If void, all teachers.
	*/
	private QString p_teacherName = new QString();

	/**
	The students. If void, all students.
	*/
	private QString p_studentsName = new QString();

	/**
	The subject. If void, all subjects.
	*/
	private QString p_subjectName = new QString();

	/**
	The activity tag. If void, all activity tags.
	*/
	private QString p_activityTagName = new QString();

	/**
	The number of preferred times
	*/
	private int p_nPreferredTimeSlots_L;

	/**
	The preferred days. If -1, then the user does not care about the day.
	*/
	//int p_days[MAX_N_CONSTRAINT_ACTIVITIES_PREFERRED_TIME_SLOTS];
	private QList<int> p_days_L = new QList<int>();

	/**
	The preferred hours. If -1, then the user does not care about the hour.
	*/
	//int p_hours[MAX_N_CONSTRAINT_ACTIVITIES_PREFERRED_TIME_SLOTS];
	private QList<int> p_hours_L = new QList<int>();

	//internal variables

	/**
	The number of activities which are represented by the subject, teacher and students requirements.
	*/
	private int p_nActivities;

	/**
	The indices of the activities in the rules (from 0 to rules.nActivities-1)
	These are indices in the internal list -> Rules::internalActivitiesList
	*/
	//int p_activitiesIndices[MAX_ACTIVITIES];
	private QList<int> p_activitiesIndices = new QList<int>();


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintSubactivitiesPreferredTimeSlots() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_SUBACTIVITIES_PREFERRED_TIME_SLOTS;
	}

	//ConstraintSubactivitiesPreferredTimeSlots(double wp, int compNo, QString te,
	//	QString st, QString su, QString sut, int nPT, int d[], int h[]);
	private ConstraintSubactivitiesPreferredTimeSlots(double wp, int compNo, QString te, QString st, QString su, QString sut, int nPT_L, QList<int> d_L, QList<int> h_L) : base(wp)
	{
		Debug.Assert(d_L.count() == nPT_L);
		Debug.Assert(h_L.count() == nPT_L);

		this.componentNumber = compNo;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->p_teacherName=te;
		this.p_teacherName.CopyFrom(te);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->p_subjectName=su;
		this.p_subjectName.CopyFrom(su);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->p_activityTagName=sut;
		this.p_activityTagName.CopyFrom(sut);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->p_studentsName=st;
		this.p_studentsName.CopyFrom(st);
		this.p_nPreferredTimeSlots_L = nPT_L;
		this.p_days_L = d_L;
		this.p_hours_L = h_L;
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_SUBACTIVITIES_PREFERRED_TIME_SLOTS;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		this.p_nActivities = 0;
		this.p_activitiesIndices.clear();

		int it;
		Activity act;
		int i;
		for (i = 0; i < r.nInternalActivities; i++)
		{
			act = r.internalActivitiesList[i];

			if (!act.representsComponentNumber(this.componentNumber))
				continue;

			//check if this activity has the corresponding teacher
			if (this.p_teacherName != "")
			{
				it = act.teachersNames.indexOf(this.p_teacherName);
				if (it == -1)
					continue;
			}
			//check if this activity has the corresponding students
			if (this.p_studentsName != "")
			{
				bool commonStudents = false;
				foreach (QString st, act.studentsNames) if (r.setsShareStudents(st, p_studentsName))
				{
						commonStudents = true;
						break;
				}

				if (!commonStudents)
					continue;
			}
			//check if this activity has the corresponding subject
			if (this.p_subjectName != "" && act.subjectName != this.p_subjectName)
			{
				continue;
			}
			//check if this activity has the corresponding activity tag
			if (this.p_activityTagName != "" && !act.activityTagsNames.contains(this.p_activityTagName))
			{
				continue;
			}

			Debug.Assert(this.p_nActivities < GlobalMembersTimetable_defs.MAX_ACTIVITIES);
			this.p_nActivities++;
			this.p_activitiesIndices.append(i);
		}

		Debug.Assert(this.p_nActivities == this.p_activitiesIndices.count());

		//////////////////////
		for (int k = 0; k < p_nPreferredTimeSlots_L; k++)
		{
			if (this.p_days_L[k] >= r.nDaysPerWeek)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint subactivities preferred time slots is wrong because it refers to removed day. Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
			if (this.p_hours_L[k] == r.nHoursPerDay)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint subactivities preferred time slots is wrong because a preferred hour is too late (after the last acceptable slot). Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
			if (this.p_hours_L[k] > r.nHoursPerDay)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint subactivities preferred time slots is wrong because it refers to removed hour. Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
			if (this.p_hours_L[k] < 0 || this.p_days_L[k] < 0)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint subactivities preferred time slots is wrong because hour or day is not specified for a slot (-1). Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
		}
		///////////////////////

		if (this.p_nActivities > 0)
			return true;
		else
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (refers to no activities). Please correct it:\n%1").arg(this.getDetailedDescription(ref r)));
			return false;
		}
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		QList<int> localActiveActs = new QList<int>();
		QList<int> localAllActs = new QList<int>();

		//returns true if all activities are inactive
		int it;
		Activity act;
		int i;
		for (i = 0; i < r.activitiesList.count(); i++)
		{
			act = r.activitiesList.at(i);

			if (!act.representsComponentNumber(this.componentNumber))
				continue;

			//check if this activity has the corresponding teacher
			if (this.p_teacherName != "")
			{
				it = act.teachersNames.indexOf(this.p_teacherName);
				if (it == -1)
					continue;
			}
			//check if this activity has the corresponding students
			if (this.p_studentsName != "")
			{
				bool commonStudents = false;
				foreach (QString st, act.studentsNames) if (r.setsShareStudents(st, p_studentsName))
				{
						commonStudents = true;
						break;
				}

				if (!commonStudents)
					continue;
			}
			//check if this activity has the corresponding subject
			if (this.p_subjectName != "" && act.subjectName != this.p_subjectName)
			{
					continue;
			}
			//check if this activity has the corresponding activity tag
			if (this.p_activityTagName != "" && !act.activityTagsNames.contains(this.p_activityTagName))
			{
					continue;
			}

			if (!r.inactiveActivities.contains(act.id))
				localActiveActs.append(act.id);

			localAllActs.append(act.id);
		}

		if (localActiveActs.count() == 0 && localAllActs.count() > 0)
			return true;
		else
			return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		QString s = "<ConstraintSubactivitiesPreferredTimeSlots>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Component_Number>" + CustomFETString.number(this.componentNumber) + "</Component_Number>\n";
		s += "	<Teacher_Name>" + GlobalMembersTimetable_defs.protect(this.p_teacherName) + "</Teacher_Name>\n";
		s += "	<Students_Name>" + GlobalMembersTimetable_defs.protect(this.p_studentsName) + "</Students_Name>\n";
		s += "	<Subject_Name>" + GlobalMembersTimetable_defs.protect(this.p_subjectName) + "</Subject_Name>\n";
		s += "	<Activity_Tag_Name>" + GlobalMembersTimetable_defs.protect(this.p_activityTagName) + "</Activity_Tag_Name>\n";
		s += "	<Number_of_Preferred_Time_Slots>" + CustomFETString.number(this.p_nPreferredTimeSlots_L) + "</Number_of_Preferred_Time_Slots>\n";
		for (int i = 0; i < p_nPreferredTimeSlots_L; i++)
		{
			s += "	<Preferred_Time_Slot>\n";
			if (this.p_days_L[i] >= 0)
				s += "		<Preferred_Day>" + GlobalMembersTimetable_defs.protect(r.daysOfTheWeek[this.p_days_L[i]]) + "</Preferred_Day>\n";
			if (this.p_hours_L[i] >= 0)
				s += "		<Preferred_Hour>" + GlobalMembersTimetable_defs.protect(r.hoursOfTheDay[this.p_hours_L[i]]) + "</Preferred_Hour>\n";
			s += "	</Preferred_Time_Slot>\n";
		}
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintSubactivitiesPreferredTimeSlots>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();

		QString tc = new QString();
		QString st = new QString();
		QString su = new QString();
		QString at = new QString();

		if (this.p_teacherName != "")
			tc = tr("teacher=%1").arg(this.p_teacherName);
		else
			tc = tr("all teachers");

		if (this.p_studentsName != "")
			st = tr("students=%1").arg(this.p_studentsName);
		else
			st = tr("all students");

		if (this.p_subjectName != "")
			su = tr("subject=%1").arg(this.p_subjectName);
		else
			su = tr("all subjects");

		if (this.p_activityTagName != "")
			at += tr("activity tag=%1").arg(this.p_activityTagName);
		else
			at += tr("all activity tags");

		s += tr("Subactivities with %1, %2, %3, %4, %5, have a set of preferred time slots:", "%1...%5 are conditions for the subactivities").arg(tr("component number=%1").arg(this.componentNumber)).arg(tc).arg(st).arg(su).arg(at);

		s += " ";

		for (int i = 0; i < this.p_nPreferredTimeSlots_L; i++)
		{
			if (this.p_days_L[i] >= 0)
			{
				s += r.daysOfTheWeek[this.p_days_L[i]];
				s += " ";
			}
			if (this.p_hours_L[i] >= 0)
			{
				s += r.hoursOfTheDay[this.p_hours_L[i]];
			}
			if (i < this.p_nPreferredTimeSlots_L - 1)
				s += "; ";
		}
		s += ", ";

		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		QString s = tr("Time constraint");
		s += "\n";
		s += tr("Subactivities with:");
		s += "\n";

		s += tr("Component number=%1").arg(this.componentNumber);
		s += "\n";

		if (this.p_teacherName != "")
			s += tr("Teacher=%1").arg(this.p_teacherName);
		else
			s += tr("All teachers");
		s += "\n";

		if (this.p_studentsName != "")
			s += tr("Students=%1").arg(this.p_studentsName);
		else
			s += tr("All students");
		s += "\n";

		if (this.p_subjectName != "")
			s += tr("Subject=%1").arg(this.p_subjectName);
		else
			s += tr("All subjects");
		s += "\n";

		if (this.p_activityTagName != "")
			s += tr("Activity tag=%1").arg(this.p_activityTagName);
		else
			s += tr("All activity tags");
		s += "\n";

		s += tr("have a set of preferred time slots (all hours of each affected subactivity must be in the allowed slots):");
		s += "\n";
		for (int i = 0; i < this.p_nPreferredTimeSlots_L; i++)
		{
			if (this.p_days_L[i] >= 0)
			{
				s += r.daysOfTheWeek[this.p_days_L[i]];
				s += " ";
			}
			if (this.p_hours_L[i] >= 0)
			{
				s += r.hoursOfTheDay[this.p_hours_L[i]];
			}
			if (i < this.p_nPreferredTimeSlots_L - 1)
				s += ";  ";
		}
		s += "\n";

		s += tr("Weight (percentage)=%1").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		Debug.Assert(r.internalStructureComputed);

	///////////////////
		Matrix2D<bool> allowed = new Matrix2D<bool>();
		allowed.resize(r.nDaysPerWeek, r.nHoursPerDay);
		//bool allowed[MAX_DAYS_PER_WEEK][MAX_HOURS_PER_DAY];
		for (int d = 0; d < r.nDaysPerWeek; d++)
			for (int h = 0; h < r.nHoursPerDay; h++)
				allowed[d][h] = false;
		for (int i = 0; i < this.p_nPreferredTimeSlots_L; i++)
		{
			if (this.p_days_L[i] >= 0 && this.p_hours_L[i] >= 0)
				allowed[this.p_days_L[i]][this.p_hours_L[i]] = true;
			else
				Debug.Assert(0);
		}
	////////////////////

		nbroken = 0;
		int tmp;

		for (int i = 0; i < this.p_nActivities; i++)
		{
			tmp = 0;
			int ai = this.p_activitiesIndices[i];
			if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
				int d = c.times[ai] % r.nDaysPerWeek; //the day when this activity was scheduled
				int h = c.times[ai] / r.nDaysPerWeek; //the hour

				for (int dur = 0; dur < r.internalActivitiesList[ai].duration; dur++)
					if (!allowed[d][h + dur])
						tmp++;
			}
			nbroken += tmp;
			if (conflictsString != null && tmp > 0)
			{
				QString s = tr("Time constraint subactivities preferred time slots broken" + " for activity with id=%1 (%2), component number %3, on %4 hours," + " increases conflicts total by %5", "%1 is the id, %2 is the detailed description of the activity.").arg(r.internalActivitiesList[ai].id).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, r.internalActivitiesList[ai].id)).arg(componentNumber).arg(tmp).arg(CustomFETString.number(weightPercentage / 100 * tmp));

				dl.append(s);
				cl.append(weightPercentage / 100 * tmp);

				conflictsString += s + "\n";
			}
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return nbroken * weightPercentage / 100.0;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		if (!a.representsComponentNumber(this.componentNumber))
			return false;

		int it;

		//check if this activity has the corresponding teacher
		if (this.p_teacherName != "")
		{
			it = a.teachersNames.indexOf(this.p_teacherName);
			if (it == -1)
				return false;
		}
		//check if this activity has the corresponding students
		if (this.p_studentsName != "")
		{
			bool commonStudents = false;
			foreach (QString st, a.studentsNames)
			{
				if (r.setsShareStudents(st, this.p_studentsName))
				{
					commonStudents = true;
					break;
				}
			}
			if (!commonStudents)
				return false;
		}
		//check if this activity has the corresponding subject
		if (this.p_subjectName != "" && a.subjectName != this.p_subjectName)
			return false;
		//check if this activity has the corresponding activity tag
		if (this.p_activityTagName != "" && !a.activityTagsNames.contains(this.p_activityTagName))
			return false;

		return true;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(p_nPreferredTimeSlots_L == p_days_L.count());
		Debug.Assert(p_nPreferredTimeSlots_L == p_hours_L.count());

		for (int i = 0; i < p_nPreferredTimeSlots_L; i++)
			if (p_days_L.at(i)<0 || p_days_L.at(i) >= r.nDaysPerWeek || p_hours_L.at(i)<0 || p_hours_L.at(i) >= r.nHoursPerDay)
				return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		Debug.Assert(p_nPreferredTimeSlots_L == p_days_L.count());
		Debug.Assert(p_nPreferredTimeSlots_L == p_hours_L.count());

		QList<int> newDays = new QList<int>();
		QList<int> newHours = new QList<int>();
		int newNPref = 0;

		for (int i = 0; i < p_nPreferredTimeSlots_L; i++)
			if (p_days_L.at(i) >= 0 && p_days_L.at(i)<r.nDaysPerWeek && p_hours_L.at(i) >= 0 && p_hours_L.at(i) < r.nHoursPerDay)
			{
				newDays.append(p_days_L.at(i));
				newHours.append(p_hours_L.at(i));
				newNPref++;
			}

		p_nPreferredTimeSlots_L = newNPref;
		p_days_L = newDays;
		p_hours_L = newHours;

		r.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(r);

		return true;
	}
}

public abstract class ConstraintActivitiesPreferredStartingTimes: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintActivitiesPreferredStartingTimes) public: QString teacherName;
	/**
	The teacher. If void, all teachers.
	*/

	/**
	The students. If void, all students.
	*/
	private QString studentsName = new QString();

	/**
	The subject. If void, all subjects.
	*/
	private QString subjectName = new QString();

	/**
	The activity tag. If void, all activity tags.
	*/
	private QString activityTagName = new QString();

	/**
	The number of preferred times
	*/
	private int nPreferredStartingTimes_L;

	/**
	The preferred days. If -1, then the user does not care about the day.
	*/
	//int days[MAX_N_CONSTRAINT_ACTIVITIES_PREFERRED_STARTING_TIMES];
	private QList<int> days_L = new QList<int>();

	/**
	The preferred hours. If -1, then the user does not care about the hour.
	*/
	//int hours[MAX_N_CONSTRAINT_ACTIVITIES_PREFERRED_STARTING_TIMES];
	private QList<int> hours_L = new QList<int>();

	//internal variables

	/**
	The number of activities which are represented by the subject, teacher and students requirements.
	*/
	private int nActivities;

	/**
	The indices of the activities in the rules (from 0 to rules.nActivities-1)
	These are indices in the internal list -> Rules::internalActivitiesList
	*/
	//int activitiesIndices[MAX_ACTIVITIES];
	private QList<int> activitiesIndices = new QList<int>();


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintActivitiesPreferredStartingTimes() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_PREFERRED_STARTING_TIMES;
	}

	//ConstraintActivitiesPreferredStartingTimes(double wp, QString te,
	//	QString st, QString su, QString sut, int nPT, int d[], int h[]);
	private ConstraintActivitiesPreferredStartingTimes(double wp, QString te, QString st, QString su, QString sut, int nPT_L, QList<int> d_L, QList<int> h_L) : base(wp)
	{
		Debug.Assert(d_L.count() == nPT_L);
		Debug.Assert(h_L.count() == nPT_L);

		this.teacherName = te;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->subjectName=su;
		this.subjectName.CopyFrom(su);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->activityTagName=sut;
		this.activityTagName.CopyFrom(sut);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->studentsName=st;
		this.studentsName.CopyFrom(st);
		this.nPreferredStartingTimes_L = nPT_L;
		this.days_L = d_L;
		this.hours_L = h_L;
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_PREFERRED_STARTING_TIMES;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		this.nActivities = 0;
		this.activitiesIndices.clear();

		int it;
		Activity act;
		int i;
		for (i = 0; i < r.nInternalActivities; i++)
		{
			act = r.internalActivitiesList[i];

			//check if this activity has the corresponding teacher
			if (this.teacherName != "")
			{
				it = act.teachersNames.indexOf(this.teacherName);
				if (it == -1)
					continue;
			}
			//check if this activity has the corresponding students
			if (this.studentsName != "")
			{
				bool commonStudents = false;
				foreach (QString st, act.studentsNames) if (r.setsShareStudents(st, studentsName))
				{
						commonStudents = true;
						break;
				}

				if (!commonStudents)
					continue;
			}
			//check if this activity has the corresponding subject
			if (this.subjectName != "" && act.subjectName != this.subjectName)
			{
					continue;
			}
			//check if this activity has the corresponding activity tag
			if (this.activityTagName != "" && !act.activityTagsNames.contains(this.activityTagName))
			{
					continue;
			}

			Debug.Assert(this.nActivities < GlobalMembersTimetable_defs.MAX_ACTIVITIES);
			//this->activitiesIndices[this->nActivities++]=i;
			this.activitiesIndices.append(i);
			this.nActivities++;
		}

		Debug.Assert(this.activitiesIndices.count() == this.nActivities);

		//////////////////////
		for (int k = 0; k < nPreferredStartingTimes_L; k++)
		{
			if (this.days_L[k] >= r.nDaysPerWeek)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint activities preferred starting times is wrong because it refers to removed day. Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
			if (this.hours_L[k] == r.nHoursPerDay)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint activities preferred starting times is wrong because a preferred hour is too late (after the last acceptable slot). Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
			if (this.hours_L[k] > r.nHoursPerDay)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint activities preferred starting times is wrong because it refers to removed hour. Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
		}
		///////////////////////

		if (this.nActivities > 0)
			return true;
		else
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (refers to no activities). Please correct it:\n%1").arg(this.getDetailedDescription(ref r)));
			return false;
		}
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		QList<int> localActiveActs = new QList<int>();
		QList<int> localAllActs = new QList<int>();

		//returns true if all activities are inactive
		int it;
		Activity act;
		int i;
		for (i = 0; i < r.activitiesList.count(); i++)
		{
			act = r.activitiesList.at(i);

			//check if this activity has the corresponding teacher
			if (this.teacherName != "")
			{
				it = act.teachersNames.indexOf(this.teacherName);
				if (it == -1)
					continue;
			}
			//check if this activity has the corresponding students
			if (this.studentsName != "")
			{
				bool commonStudents = false;
				foreach (QString st, act.studentsNames) if (r.setsShareStudents(st, studentsName))
				{
						commonStudents = true;
						break;
				}

				if (!commonStudents)
					continue;
			}
			//check if this activity has the corresponding subject
			if (this.subjectName != "" && act.subjectName != this.subjectName)
			{
					continue;
			}
			//check if this activity has the corresponding activity tag
			if (this.activityTagName != "" && !act.activityTagsNames.contains(this.activityTagName))
			{
					continue;
			}

			if (!r.inactiveActivities.contains(act.id))
				localActiveActs.append(act.id);

			localAllActs.append(act.id);
		}

		if (localActiveActs.count() == 0 && localAllActs.count() > 0)
			return true;
		else
			return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		QString s = "<ConstraintActivitiesPreferredStartingTimes>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Teacher_Name>" + GlobalMembersTimetable_defs.protect(this.teacherName) + "</Teacher_Name>\n";
		s += "	<Students_Name>" + GlobalMembersTimetable_defs.protect(this.studentsName) + "</Students_Name>\n";
		s += "	<Subject_Name>" + GlobalMembersTimetable_defs.protect(this.subjectName) + "</Subject_Name>\n";
		s += "	<Activity_Tag_Name>" + GlobalMembersTimetable_defs.protect(this.activityTagName) + "</Activity_Tag_Name>\n";
		s += "	<Number_of_Preferred_Starting_Times>" + CustomFETString.number(this.nPreferredStartingTimes_L) + "</Number_of_Preferred_Starting_Times>\n";
		for (int i = 0; i < nPreferredStartingTimes_L; i++)
		{
			s += "	<Preferred_Starting_Time>\n";
			if (this.days_L[i] >= 0)
				s += "		<Preferred_Starting_Day>" + GlobalMembersTimetable_defs.protect(r.daysOfTheWeek[this.days_L[i]]) + "</Preferred_Starting_Day>\n";
			if (this.hours_L[i] >= 0)
				s += "		<Preferred_Starting_Hour>" + GlobalMembersTimetable_defs.protect(r.hoursOfTheDay[this.hours_L[i]]) + "</Preferred_Starting_Hour>\n";
			s += "	</Preferred_Starting_Time>\n";
		}
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintActivitiesPreferredStartingTimes>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();

		QString tc = new QString();
		QString st = new QString();
		QString su = new QString();
		QString at = new QString();

		if (this.teacherName != "")
			tc = tr("teacher=%1").arg(this.teacherName);
		else
			tc = tr("all teachers");

		if (this.studentsName != "")
			st = tr("students=%1").arg(this.studentsName);
		else
			st = tr("all students");

		if (this.subjectName != "")
			su = tr("subject=%1").arg(this.subjectName);
		else
			su = tr("all subjects");

		if (this.activityTagName != "")
			at += tr("activity tag=%1").arg(this.activityTagName);
		else
			at += tr("all activity tags");

		s += tr("Activities with %1, %2, %3, %4, have a set of preferred starting times:", "%1...%4 are conditions for the activities").arg(tc).arg(st).arg(su).arg(at);
		s += " ";

		for (int i = 0; i < this.nPreferredStartingTimes_L; i++)
		{
			if (this.days_L[i] >= 0)
			{
				s += r.daysOfTheWeek[this.days_L[i]];
				s += " ";
			}
			if (this.hours_L[i] >= 0)
			{
				s += r.hoursOfTheDay[this.hours_L[i]];
			}
			if (i < this.nPreferredStartingTimes_L - 1)
				s += "; ";
		}
		s += ", ";

		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		QString s = tr("Time constraint");
		s += "\n";
		s += tr("Activities with:");
		s += "\n";

		if (this.teacherName != "")
			s += tr("Teacher=%1").arg(this.teacherName);
		else
			s += tr("All teachers");
		s += "\n";

		if (this.studentsName != "")
			s += tr("Students=%1").arg(this.studentsName);
		else
			s += tr("All students");
		s += "\n";

		if (this.subjectName != "")
			s += tr("Subject=%1").arg(this.subjectName);
		else
			s += tr("All subjects");
		s += "\n";

		if (this.activityTagName != "")
			s += tr("Activity tag=%1").arg(this.activityTagName);
		else
			s += tr("All activity tags");
		s += "\n";

		s += tr("have a set of preferred starting times:");
		s += "\n";
		for (int i = 0; i < this.nPreferredStartingTimes_L; i++)
		{
			if (this.days_L[i] >= 0)
			{
				s += r.daysOfTheWeek[this.days_L[i]];
				s += " ";
			}
			if (this.hours_L[i] >= 0)
			{
				s += r.hoursOfTheDay[this.hours_L[i]];
			}
			if (i < this.nPreferredStartingTimes_L - 1)
				s += ";  ";
		}
		s += "\n";

		s += tr("Weight (percentage)=%1").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		Debug.Assert(r.internalStructureComputed);

		nbroken = 0;
		int tmp;

		for (int i = 0; i < this.nActivities; i++)
		{
			tmp = 0;
			int ai = this.activitiesIndices[i];
			if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
				int d = c.times[ai] % r.nDaysPerWeek; //the day when this activity was scheduled
				int h = c.times[ai] / r.nDaysPerWeek; //the hour
				int i;
				for (i = 0; i < this.nPreferredStartingTimes_L; i++)
				{
					if (this.days_L[i] >= 0 && this.days_L[i] != d)
						continue;
					if (this.hours_L[i] >= 0 && this.hours_L[i] != h)
						continue;
					break;
				}
				if (i == this.nPreferredStartingTimes_L)
				{
					tmp = 1;
				}
			}
			nbroken += tmp;
			if (conflictsString != null && tmp > 0)
			{
				QString s = tr("Time constraint activities preferred starting times broken" + " for activity with id=%1 (%2)," + " increases conflicts total by %3", "%1 is the id, %2 is the detailed description of the activity").arg(r.internalActivitiesList[ai].id).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, r.internalActivitiesList[ai].id)).arg(CustomFETString.number(weightPercentage / 100 * tmp));

				dl.append(s);
				cl.append(weightPercentage / 100 * tmp);

				conflictsString += s + "\n";
			}
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return nbroken * weightPercentage / 100.0;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		int it;

		//check if this activity has the corresponding teacher
		if (this.teacherName != "")
		{
			it = a.teachersNames.indexOf(this.teacherName);
			if (it == -1)
				return false;
		}
		//check if this activity has the corresponding students
		if (this.studentsName != "")
		{
			bool commonStudents = false;
			foreach (QString st, a.studentsNames)
			{
				if (r.setsShareStudents(st, this.studentsName))
				{
					commonStudents = true;
					break;
				}
			}
			if (!commonStudents)
				return false;
		}
		//check if this activity has the corresponding subject
		if (this.subjectName != "" && a.subjectName != this.subjectName)
			return false;
		//check if this activity has the corresponding activity tag
		if (this.activityTagName != "" && !a.activityTagsNames.contains(this.activityTagName))
			return false;

		return true;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(nPreferredStartingTimes_L == days_L.count());
		Debug.Assert(nPreferredStartingTimes_L == hours_L.count());

		for (int i = 0; i < nPreferredStartingTimes_L; i++)
			if (days_L.at(i)<0 || days_L.at(i) >= r.nDaysPerWeek || hours_L.at(i)<0 || hours_L.at(i) >= r.nHoursPerDay)
				return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		Debug.Assert(nPreferredStartingTimes_L == days_L.count());
		Debug.Assert(nPreferredStartingTimes_L == hours_L.count());

		QList<int> newDays = new QList<int>();
		QList<int> newHours = new QList<int>();
		int newNPref = 0;

		for (int i = 0; i < nPreferredStartingTimes_L; i++)
			if (days_L.at(i) >= 0 && days_L.at(i)<r.nDaysPerWeek && hours_L.at(i) >= 0 && hours_L.at(i) < r.nHoursPerDay)
			{
				newDays.append(days_L.at(i));
				newHours.append(hours_L.at(i));
				newNPref++;
			}

		nPreferredStartingTimes_L = newNPref;
		days_L = newDays;
		hours_L = newHours;

		r.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(r);

		return true;
	}
}

public abstract class ConstraintSubactivitiesPreferredStartingTimes: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintSubactivitiesPreferredStartingTimes) public: int componentNumber;

	/**
	The teacher. If void, all teachers.
	*/
	private QString teacherName = new QString();

	/**
	The students. If void, all students.
	*/
	private QString studentsName = new QString();

	/**
	The subject. If void, all subjects.
	*/
	private QString subjectName = new QString();

	/**
	The activity tag. If void, all activity tags.
	*/
	private QString activityTagName = new QString();

	/**
	The number of preferred times
	*/
	private int nPreferredStartingTimes_L;

	/**
	The preferred days. If -1, then the user does not care about the day.
	*/
	//int days[MAX_N_CONSTRAINT_SUBACTIVITIES_PREFERRED_STARTING_TIMES];
	private QList<int> days_L = new QList<int>();

	/**
	The preferred hours. If -1, then the user does not care about the hour.
	*/
	//int hours[MAX_N_CONSTRAINT_SUBACTIVITIES_PREFERRED_STARTING_TIMES];
	private QList<int> hours_L = new QList<int>();

	//internal variables

	/**
	The number of activities which are represented by the subject, teacher and students requirements.
	*/
	private int nActivities;

	/**
	The indices of the activities in the rules (from 0 to rules.nActivities-1)
	These are indices in the internal list -> Rules::internalActivitiesList
	*/
	//int activitiesIndices[MAX_ACTIVITIES];
	private QList<int> activitiesIndices = new QList<int>();


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintSubactivitiesPreferredStartingTimes() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_SUBACTIVITIES_PREFERRED_STARTING_TIMES;
	}

	private ConstraintSubactivitiesPreferredStartingTimes(double wp, int compNo, QString te, QString st, QString su, QString sut, int nPT_L, QList<int> d_L, QList<int> h_L) : base(wp)
	{
		Debug.Assert(d_L.count() == nPT_L);
		Debug.Assert(h_L.count() == nPT_L);

		this.componentNumber = compNo;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->teacherName=te;
		this.teacherName.CopyFrom(te);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->subjectName=su;
		this.subjectName.CopyFrom(su);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->activityTagName=sut;
		this.activityTagName.CopyFrom(sut);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->studentsName=st;
		this.studentsName.CopyFrom(st);
		this.nPreferredStartingTimes_L = nPT_L;
		this.days_L = d_L;
		this.hours_L = h_L;
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_SUBACTIVITIES_PREFERRED_STARTING_TIMES;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		this.nActivities = 0;
		this.activitiesIndices.clear();

		int it;
		Activity act;
		int i;
		for (i = 0; i < r.nInternalActivities; i++)
		{
			act = r.internalActivitiesList[i];

			if (!act.representsComponentNumber(this.componentNumber))
				continue;

			//check if this activity has the corresponding teacher
			if (this.teacherName != "")
			{
				it = act.teachersNames.indexOf(this.teacherName);
				if (it == -1)
					continue;
			}
			//check if this activity has the corresponding students
			if (this.studentsName != "")
			{
				bool commonStudents = false;
				foreach (QString st, act.studentsNames) if (r.setsShareStudents(st, studentsName))
				{
						commonStudents = true;
						break;
				}

				if (!commonStudents)
					continue;
			}
			//check if this activity has the corresponding subject
			if (this.subjectName != "" && act.subjectName != this.subjectName)
			{
					continue;
			}
			//check if this activity has the corresponding activity tag
			if (this.activityTagName != "" && !act.activityTagsNames.contains(this.activityTagName))
			{
					continue;
			}

			Debug.Assert(this.nActivities < GlobalMembersTimetable_defs.MAX_ACTIVITIES);
			//this->activitiesIndices[this->nActivities++]=i;
			this.nActivities++;
			this.activitiesIndices.append(i);
		}

		Debug.Assert(this.activitiesIndices.count() == this.nActivities);

		//////////////////////
		for (int k = 0; k < nPreferredStartingTimes_L; k++)
		{
			if (this.days_L[k] >= r.nDaysPerWeek)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint subactivities preferred starting times is wrong because it refers to removed day. Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
			if (this.hours_L[k] == r.nHoursPerDay)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint subactivities preferred starting times is wrong because a preferred hour is too late (after the last acceptable slot). Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
			if (this.hours_L[k] > r.nHoursPerDay)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint subactivities preferred starting times is wrong because it refers to removed hour. Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
		}
		///////////////////////

		if (this.nActivities > 0)
			return true;
		else
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (refers to no activities). Please correct it:\n%1").arg(this.getDetailedDescription(ref r)));
			return false;
		}
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		QList<int> localActiveActs = new QList<int>();
		QList<int> localAllActs = new QList<int>();

		//returns true if all activities are inactive
		int it;
		Activity act;
		int i;
		for (i = 0; i < r.activitiesList.count(); i++)
		{
			act = r.activitiesList.at(i);

			if (!act.representsComponentNumber(this.componentNumber))
				continue;

			//check if this activity has the corresponding teacher
			if (this.teacherName != "")
			{
				it = act.teachersNames.indexOf(this.teacherName);
				if (it == -1)
					continue;
			}
			//check if this activity has the corresponding students
			if (this.studentsName != "")
			{
				bool commonStudents = false;
				foreach (QString st, act.studentsNames) if (r.setsShareStudents(st, studentsName))
				{
						commonStudents = true;
						break;
				}

				if (!commonStudents)
					continue;
			}
			//check if this activity has the corresponding subject
			if (this.subjectName != "" && act.subjectName != this.subjectName)
			{
					continue;
			}
			//check if this activity has the corresponding activity tag
			if (this.activityTagName != "" && !act.activityTagsNames.contains(this.activityTagName))
			{
					continue;
			}

			if (!r.inactiveActivities.contains(act.id))
				localActiveActs.append(act.id);

			localAllActs.append(act.id);
		}

		if (localActiveActs.count() == 0 && localAllActs.count() > 0)
			return true;
		else
			return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		QString s = "<ConstraintSubactivitiesPreferredStartingTimes>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Component_Number>" + CustomFETString.number(this.componentNumber) + "</Component_Number>\n";
		s += "	<Teacher_Name>" + GlobalMembersTimetable_defs.protect(this.teacherName) + "</Teacher_Name>\n";
		s += "	<Students_Name>" + GlobalMembersTimetable_defs.protect(this.studentsName) + "</Students_Name>\n";
		s += "	<Subject_Name>" + GlobalMembersTimetable_defs.protect(this.subjectName) + "</Subject_Name>\n";
		s += "	<Activity_Tag_Name>" + GlobalMembersTimetable_defs.protect(this.activityTagName) + "</Activity_Tag_Name>\n";
		s += "	<Number_of_Preferred_Starting_Times>" + CustomFETString.number(this.nPreferredStartingTimes_L) + "</Number_of_Preferred_Starting_Times>\n";
		for (int i = 0; i < nPreferredStartingTimes_L; i++)
		{
			s += "	<Preferred_Starting_Time>\n";
			if (this.days_L[i] >= 0)
				s += "		<Preferred_Starting_Day>" + GlobalMembersTimetable_defs.protect(r.daysOfTheWeek[this.days_L[i]]) + "</Preferred_Starting_Day>\n";
			if (this.hours_L[i] >= 0)
				s += "		<Preferred_Starting_Hour>" + GlobalMembersTimetable_defs.protect(r.hoursOfTheDay[this.hours_L[i]]) + "</Preferred_Starting_Hour>\n";
			s += "	</Preferred_Starting_Time>\n";
		}
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintSubactivitiesPreferredStartingTimes>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString tc = new QString();
		QString st = new QString();
		QString su = new QString();
		QString at = new QString();

		if (this.teacherName != "")
			tc = tr("teacher=%1").arg(this.teacherName);
		else
			tc = tr("all teachers");

		if (this.studentsName != "")
			st = tr("students=%1").arg(this.studentsName);
		else
			st = tr("all students");

		if (this.subjectName != "")
			su = tr("subject=%1").arg(this.subjectName);
		else
			su = tr("all subjects");

		if (this.activityTagName != "")
			at += tr("activity tag=%1").arg(this.activityTagName);
		else
			at += tr("all activity tags");

		QString s = new QString();

		s += tr("Subactivities with %1, %2, %3, %4, %5, have a set of preferred starting times:", "%1...%5 are conditions for the subactivities").arg(tr("component number=%1").arg(this.componentNumber)).arg(tc).arg(st).arg(su).arg(at);
		s += " ";

		for (int i = 0; i < this.nPreferredStartingTimes_L; i++)
		{
			if (this.days_L[i] >= 0)
			{
				s += r.daysOfTheWeek[this.days_L[i]];
				s += " ";
			}
			if (this.hours_L[i] >= 0)
			{
				s += r.hoursOfTheDay[this.hours_L[i]];
			}
			if (i < this.nPreferredStartingTimes_L - 1)
				s += "; ";
		}
		s += ", ";

		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		QString s = tr("Time constraint");
		s += "\n";
		s += tr("Subactivities with:");
		s += "\n";

		s += tr("Component number=%1").arg(this.componentNumber);
		s += "\n";

		if (this.teacherName != "")
			s += tr("Teacher=%1").arg(this.teacherName);
		else
			s += tr("All teachers");
		s += "\n";

		if (this.studentsName != "")
			s += tr("Students=%1").arg(this.studentsName);
		else
			s += tr("All students");
		s += "\n";

		if (this.subjectName != "")
			s += tr("Subject=%1").arg(this.subjectName);
		else
			s += tr("All subjects");
		s += "\n";

		if (this.activityTagName != "")
			s += tr("Activity tag=%1").arg(this.activityTagName);
		else
			s += tr("All activity tags");
		s += "\n";

		s += tr("have a set of preferred starting times:");
		s += "\n";
		for (int i = 0; i < this.nPreferredStartingTimes_L; i++)
		{
			if (this.days_L[i] >= 0)
			{
				s += r.daysOfTheWeek[this.days_L[i]];
				s += " ";
			}
			if (this.hours_L[i] >= 0)
			{
				s += r.hoursOfTheDay[this.hours_L[i]];
			}
			if (i < this.nPreferredStartingTimes_L - 1)
				s += ";  ";
		}
		s += "\n";

		s += tr("Weight (percentage)=%1").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		Debug.Assert(r.internalStructureComputed);

		nbroken = 0;
		int tmp;

		for (int i = 0; i < this.nActivities; i++)
		{
			tmp = 0;
			int ai = this.activitiesIndices[i];
			if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
				int d = c.times[ai] % r.nDaysPerWeek; //the day when this activity was scheduled
				int h = c.times[ai] / r.nDaysPerWeek; //the hour
				int i;
				for (i = 0; i < this.nPreferredStartingTimes_L; i++)
				{
					if (this.days_L[i] >= 0 && this.days_L[i] != d)
						continue;
					if (this.hours_L[i] >= 0 && this.hours_L[i] != h)
						continue;
					break;
				}
				if (i == this.nPreferredStartingTimes_L)
				{
					tmp = 1;
				}
			}
			nbroken += tmp;
			if (conflictsString != null && tmp > 0)
			{
				QString s = tr("Time constraint subactivities preferred starting times broken" + " for activity with id=%1 (%2), component number %3," + " increases conflicts total by %4", "%1 is the id, %2 is the detailed description of the activity").arg(r.internalActivitiesList[ai].id).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, r.internalActivitiesList[ai].id)).arg(this.componentNumber).arg(CustomFETString.number(weightPercentage / 100 * tmp));

				dl.append(s);
				cl.append(weightPercentage / 100 * tmp);

				conflictsString += s + "\n";
			}
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return nbroken * weightPercentage / 100.0;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		if (!a.representsComponentNumber(this.componentNumber))
			return false;

		int it;

		//check if this activity has the corresponding teacher
		if (this.teacherName != "")
		{
			it = a.teachersNames.indexOf(this.teacherName);
			if (it == -1)
				return false;
		}
		//check if this activity has the corresponding students
		if (this.studentsName != "")
		{
			bool commonStudents = false;
			foreach (QString st, a.studentsNames)
			{
				if (r.setsShareStudents(st, this.studentsName))
				{
					commonStudents = true;
					break;
				}
			}
			if (!commonStudents)
				return false;
		}
		//check if this activity has the corresponding subject
		if (this.subjectName != "" && a.subjectName != this.subjectName)
			return false;
		//check if this activity has the corresponding activity tag
		if (this.activityTagName != "" && !a.activityTagsNames.contains(this.activityTagName))
			return false;

		return true;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(nPreferredStartingTimes_L == days_L.count());
		Debug.Assert(nPreferredStartingTimes_L == hours_L.count());

		for (int i = 0; i < nPreferredStartingTimes_L; i++)
			if (days_L.at(i)<0 || days_L.at(i) >= r.nDaysPerWeek || hours_L.at(i)<0 || hours_L.at(i) >= r.nHoursPerDay)
				return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		Debug.Assert(nPreferredStartingTimes_L == days_L.count());
		Debug.Assert(nPreferredStartingTimes_L == hours_L.count());

		QList<int> newDays = new QList<int>();
		QList<int> newHours = new QList<int>();
		int newNPref = 0;

		for (int i = 0; i < nPreferredStartingTimes_L; i++)
			if (days_L.at(i) >= 0 && days_L.at(i)<r.nDaysPerWeek && hours_L.at(i) >= 0 && hours_L.at(i) < r.nHoursPerDay)
			{
				newDays.append(days_L.at(i));
				newHours.append(hours_L.at(i));
				newNPref++;
			}

		nPreferredStartingTimes_L = newNPref;
		days_L = newDays;
		hours_L = newHours;

		r.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(r);

		return true;
	}
}

public abstract class ConstraintActivitiesSameStartingHour: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintActivitiesSameStartingHour) public: int n_activities;
	/**
	The number of activities involved in this constraint
	*/

	/**
	The activities involved in this constraint (id)
	*/
	private QList<int> activitiesId = new QList<int>();
	//int activitiesId[MAX_CONSTRAINT_ACTIVITIES_SAME_STARTING_HOUR];

	/**
	The number of activities involved in this constraint - internal structure
	*/
	private int _n_activities;

	/**
	The activities involved in this constraint (index in the rules) - internal structure
	*/
	private QList<int> _activities = new QList<int>();
	//int _activities[MAX_CONSTRAINT_ACTIVITIES_SAME_STARTING_HOUR];


	/////////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintActivitiesSameStartingHour() : base()
	{
		type = GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_SAME_STARTING_HOUR;
	}

	/**
	Constructor, using:
	the weight, the number of activities and the list of activities' id-s.
	*/
	//ConstraintActivitiesSameStartingHour(double wp, int n_act, const int act[]);
	private ConstraintActivitiesSameStartingHour(double wp, int nact, QList<int> act) : base(wp)
	{
		Debug.Assert(nact >= 2);
		Debug.Assert(act.count() == nact);
		this.n_activities = nact;
		this.activitiesId.clear();
		for (int i = 0; i < nact; i++)
			this.activitiesId.append(act.at(i));

		this.type = GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_SAME_STARTING_HOUR;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		//compute the indices of the activities,
		//based on their unique ID

		Debug.Assert(this.n_activities == this.activitiesId.count());

		this._activities.clear();
		for (int i = 0; i < this.n_activities; i++)
		{
			int j;
			Activity act;
			for (j = 0; j < r.nInternalActivities; j++)
			{
				act = r.internalActivitiesList[j];
				if (act.id == this.activitiesId[i])
				{
					this._activities.append(j);
					break;
				}
			}
		}
		this._n_activities = this._activities.count();

		if (this._n_activities <= 1)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (because you need 2 or more activities. Please correct it):\n%1").arg(this.getDetailedDescription(ref r)));
			//assert(0);
			return false;
		}

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		int count = 0;

		for (int i = 0; i < this.n_activities; i++)
			if (r.inactiveActivities.contains(this.activitiesId[i]))
				count++;

		if (this.n_activities - count <= 1)
			return true;
		else
			return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintActivitiesSameStartingHour>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Number_of_Activities>" + CustomFETString.number(this.n_activities) + "</Number_of_Activities>\n";
		for (int i = 0; i < this.n_activities; i++)
			s += "	<Activity_Id>" + CustomFETString.number(this.activitiesId[i]) + "</Activity_Id>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintActivitiesSameStartingHour>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Activities same starting hour");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("NA:%1", "Number of activities").arg(this.n_activities);
		s += ", ";
		for (int i = 0; i < this.n_activities; i++)
		{
			s += tr("Id:%1", "Id of activity").arg(this.activitiesId[i]);
			if (i < this.n_activities - 1)
				s += ", ";
		}

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		QString s = new QString();

		s = tr("Time constraint");
		s += "\n";
		s += tr("Activities must have the same starting hour");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Number of activities=%1").arg(this.n_activities);
		s += "\n";
		for (int i = 0; i < this.n_activities; i++)
		{
			s += tr("Activity with id=%1 (%2)", "%1 is the id, %2 is the detailed description of the activity.").arg(this.activitiesId[i]).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activitiesId[i]));
			s += "\n";
		}

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		Debug.Assert(r.internalStructureComputed);

		int nbroken;

		//We do not use the matrices 'subgroupsMatrix' nor 'teachersMatrix'.

		//sum the differences in the scheduled hour for all pairs of activities.

		//without logging
		if (conflictsString == null)
		{
			nbroken = 0;
			for (int i = 1; i < this._n_activities; i++)
			{
				int t1 = c.times[this._activities[i]];
				if (t1 != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
					//int day1=t1%r.nDaysPerWeek;
					int hour1 = t1 / r.nDaysPerWeek;
					for (int j = 0; j < i; j++)
					{
						int t2 = c.times[this._activities[j]];
						if (t2 != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
						{
							//int day2=t2%r.nDaysPerWeek;
							int hour2 = t2 / r.nDaysPerWeek;
							int tmp = 0;

							//	tmp = abs(hour1-hour2);
							if (hour1 != hour2)
								tmp = 1;

							nbroken += tmp;
						}
					}
				}
			}
		}
		//with logging
		else
		{
			nbroken = 0;
			for (int i = 1; i < this._n_activities; i++)
			{
				int t1 = c.times[this._activities[i]];
				if (t1 != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
					//int day1=t1%r.nDaysPerWeek;
					int hour1 = t1 / r.nDaysPerWeek;
					for (int j = 0; j < i; j++)
					{
						int t2 = c.times[this._activities[j]];
						if (t2 != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
						{
							//int day2=t2%r.nDaysPerWeek;
							int hour2 = t2 / r.nDaysPerWeek;
							int tmp = 0;

							//	tmp = abs(hour1-hour2);
							if (hour1 != hour2)
								tmp = 1;

							nbroken += tmp;

							if (tmp > 0 && conflictsString != null)
							{
								QString s = tr("Time constraint activities same starting hour broken, because activity with id=%1 (%2) is not at the same hour with activity with id=%3 (%4)", "%1 is the id, %2 is the detailed description of the activity, %3 id, %4 det. descr.").arg(this.activitiesId[i]).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activitiesId[i])).arg(this.activitiesId[j]).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activitiesId[j]));
								s += ". ";
								s += tr("Conflicts factor increase=%1").arg(CustomFETString.number(tmp * weightPercentage / 100));

								dl.append(s);
								cl.append(tmp * weightPercentage / 100);

								conflictsString += s + "\n";
							}
						}
					}
				}
			}
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100 * nbroken;
	}

	private void removeUseless(ref Rules r)
	{
		//remove the activitiesId which no longer exist (used after the deletion of an activity)

		Debug.Assert(this.n_activities == this.activitiesId.count());

		QList<int> tmpList = new QList<int>();

		for (int i = 0; i < this.n_activities; i++)
		{
			for (int k = 0; k < r.activitiesList.size(); k++)
			{
				Activity act = r.activitiesList[k];
				if (act.id == this.activitiesId[i])
				{
					tmpList.append(act.id);
					break;
				}
			}
		}

		this.activitiesId = tmpList;
		this.n_activities = this.activitiesId.count();

		r.internalStructureComputed = false;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);

		for (int i = 0; i < this.n_activities; i++)
			if (this.activitiesId[i] == a.id)
				return true;
		return false;
	}


	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0);

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0); //should check hasWrongDayOrHour, firstly

		return true;
	}
}

public abstract class ConstraintActivitiesSameStartingDay: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintActivitiesSameStartingDay) public: int n_activities;
	/**
	The number of activities involved in this constraint
	*/

	/**
	The activities involved in this constraint (id)
	*/
	private QList<int> activitiesId = new QList<int>();
	//int activitiesId[MAX_CONSTRAINT_ACTIVITIES_SAME_STARTING_DAY];

	/**
	The number of activities involved in this constraint - internal structure
	*/
	private int _n_activities;

	/**
	The activities involved in this constraint (index in the rules) - internal structure
	*/
	//int _activities[MAX_CONSTRAINT_ACTIVITIES_SAME_STARTING_DAY];
	private QList<int> _activities = new QList<int>();


	/////////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintActivitiesSameStartingDay() : base()
	{
		type = GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_SAME_STARTING_DAY;
	}

	/**
	Constructor, using:
	the weight, the number of activities and the list of activities' id-s.
	*/
	//ConstraintActivitiesSameStartingDay(double wp, int n_act, const int act[]);
	private ConstraintActivitiesSameStartingDay(double wp, int nact, QList<int> act) : base(wp)
	{
		Debug.Assert(nact >= 2);
		Debug.Assert(act.count() == nact);
		this.n_activities = nact;
		this.activitiesId.clear();
		for (int i = 0; i < nact; i++)
			this.activitiesId.append(act.at(i));

		this.type = GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_SAME_STARTING_DAY;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		//compute the indices of the activities,
		//based on their unique ID

		Debug.Assert(this.n_activities == this.activitiesId.count());

		this._activities.clear();
		for (int i = 0; i < this.n_activities; i++)
		{
			int j;
			Activity act;
			for (j = 0; j < r.nInternalActivities; j++)
			{
				act = r.internalActivitiesList[j];
				if (act.id == this.activitiesId[i])
				{
					this._activities.append(j);
					break;
				}
			}
		}
		this._n_activities = this._activities.count();

		if (this._n_activities <= 1)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (because you need 2 or more activities. Please correct it):\n%1").arg(this.getDetailedDescription(ref r)));
			//assert(0);
			return false;
		}

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		int count = 0;

		for (int i = 0; i < this.n_activities; i++)
			if (r.inactiveActivities.contains(this.activitiesId[i]))
				count++;

		if (this.n_activities - count <= 1)
			return true;
		else
			return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintActivitiesSameStartingDay>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Number_of_Activities>" + CustomFETString.number(this.n_activities) + "</Number_of_Activities>\n";
		for (int i = 0; i < this.n_activities; i++)
			s += "	<Activity_Id>" + CustomFETString.number(this.activitiesId[i]) + "</Activity_Id>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintActivitiesSameStartingDay>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Activities same starting day");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("NA:%1", "Number of activities").arg(this.n_activities);
		s += ", ";
		for (int i = 0; i < this.n_activities; i++)
		{
			s += tr("Id:%1", "Id of activity").arg(this.activitiesId[i]);
			if (i < this.n_activities - 1)
				s += ", ";
		}

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		QString s = new QString();

		s = tr("Time constraint");
		s += "\n";
		s += tr("Activities must have the same starting day");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Number of activities=%1").arg(this.n_activities);
		s += "\n";
		for (int i = 0; i < this.n_activities; i++)
		{
			s += tr("Activity with id=%1 (%2)", "%1 is the id, %2 is the detailed description of the activity.").arg(this.activitiesId[i]).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activitiesId[i]));
			s += "\n";
		}

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		Debug.Assert(r.internalStructureComputed);

		int nbroken;

		//We do not use the matrices 'subgroupsMatrix' nor 'teachersMatrix'.

		//sum the differences in the scheduled hour for all pairs of activities.

		//without logging
		if (conflictsString == null)
		{
			nbroken = 0;
			for (int i = 1; i < this._n_activities; i++)
			{
				int t1 = c.times[this._activities[i]];
				if (t1 != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
					int day1 = t1 % r.nDaysPerWeek;
					//int hour1=t1/r.nDaysPerWeek;
					for (int j = 0; j < i; j++)
					{
						int t2 = c.times[this._activities[j]];
						if (t2 != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
						{
							int day2 = t2 % r.nDaysPerWeek;
							//int hour2=t2/r.nDaysPerWeek;
							int tmp = 0;

							if (day1 != day2)
								tmp = 1;

							nbroken += tmp;
						}
					}
				}
			}
		}
		//with logging
		else
		{
			nbroken = 0;
			for (int i = 1; i < this._n_activities; i++)
			{
				int t1 = c.times[this._activities[i]];
				if (t1 != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
					int day1 = t1 % r.nDaysPerWeek;
					//int hour1=t1/r.nDaysPerWeek;
					for (int j = 0; j < i; j++)
					{
						int t2 = c.times[this._activities[j]];
						if (t2 != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
						{
							int day2 = t2 % r.nDaysPerWeek;
							//int hour2=t2/r.nDaysPerWeek;
							int tmp = 0;

							if (day1 != day2)
								tmp = 1;

							nbroken += tmp;

							if (tmp > 0 && conflictsString != null)
							{
								QString s = tr("Time constraint activities same starting day broken, because activity with id=%1 (%2) is not in the same day with activity with id=%3 (%4)", "%1 is the id, %2 is the detailed description of the activity, %3 id, %4 det. descr.").arg(this.activitiesId[i]).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activitiesId[i])).arg(this.activitiesId[j]).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activitiesId[j]));
								s += ". ";
								s += tr("Conflicts factor increase=%1").arg(CustomFETString.number(tmp * weightPercentage / 100));

								dl.append(s);
								cl.append(tmp * weightPercentage / 100);

								conflictsString += s + "\n";
							}
						}
					}
				}
			}
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100 * nbroken;
	}

	private void removeUseless(ref Rules r)
	{
		//remove the activitiesId which no longer exist (used after the deletion of an activity)

		Debug.Assert(this.n_activities == this.activitiesId.count());

		QList<int> tmpList = new QList<int>();

		for (int i = 0; i < this.n_activities; i++)
		{
			for (int k = 0; k < r.activitiesList.size(); k++)
			{
				Activity act = r.activitiesList[k];
				if (act.id == this.activitiesId[i])
				{
					tmpList.append(act.id);
					break;
				}
			}
		}

		this.activitiesId = tmpList;
		this.n_activities = this.activitiesId.count();

		r.internalStructureComputed = false;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);

		for (int i = 0; i < this.n_activities; i++)
			if (this.activitiesId[i] == a.id)
				return true;
		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0);

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0); //should check hasWrongDayOrHour, firstly

		return true;
	}
}

public abstract class ConstraintTwoActivitiesConsecutive: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTwoActivitiesConsecutive) public: int firstActivityId;
	/**
	First activity id
	*/

	/**
	Second activity id
	*/
	private int secondActivityId;

	//internal variables
	/**
	The index of the first activity in the rules (from 0 to rules.nActivities-1) - it is not the id of the activity
	*/
	private int firstActivityIndex;

	/**
	The index of the second activity in the rules (from 0 to rules.nActivities-1) - it is not the id of the activity
	*/
	private int secondActivityIndex;


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintTwoActivitiesConsecutive() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TWO_ACTIVITIES_CONSECUTIVE;
	}

	private ConstraintTwoActivitiesConsecutive(double wp, int firstActId, int secondActId) : base(wp)
	{
		this.firstActivityId = firstActId;
		this.secondActivityId = secondActId;
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TWO_ACTIVITIES_CONSECUTIVE;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Activity act;
		int i;
		for (i = 0; i < r.nInternalActivities; i++)
		{
			act = r.internalActivitiesList[i];
			if (act.id == this.firstActivityId)
				break;
		}

		if (i == r.nInternalActivities)
		{
			//assert(0);
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (refers to inexistent activity ids):\n%1").arg(this.getDetailedDescription(ref r)));
			return false;
		}

		this.firstActivityIndex = i;

		////////

		for (i = 0; i < r.nInternalActivities; i++)
		{
			act = r.internalActivitiesList[i];
			if (act.id == this.secondActivityId)
				break;
		}

		if (i == r.nInternalActivities)
		{
			//assert(0);
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (refers to inexistent activity ids):\n%1").arg(this.getDetailedDescription(ref r)));
			return false;
		}

		this.secondActivityIndex = i;

		if (firstActivityIndex == secondActivityIndex)
		{
			//assert(0);
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (refers to same activities):\n%1").arg(this.getDetailedDescription(ref r)));
			return false;
		}
		Debug.Assert(firstActivityIndex != secondActivityIndex);

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		if (r.inactiveActivities.contains(this.firstActivityId))
			return true;
		if (r.inactiveActivities.contains(this.secondActivityId))
			return true;
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintTwoActivitiesConsecutive>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<First_Activity_Id>" + CustomFETString.number(this.firstActivityId) + "</First_Activity_Id>\n";
		s += "	<Second_Activity_Id>" + CustomFETString.number(this.secondActivityId) + "</Second_Activity_Id>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTwoActivitiesConsecutive>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();

		s = tr("Constraint two activities consecutive:");
		s += " ";

		s += tr("first act. id: %1", "act.=activity").arg(this.firstActivityId);
		s += ", ";
		s += tr("second act. id: %1", "act.=activity").arg(this.secondActivityId);
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		QString s = tr("Time constraint");
		s += "\n";
		s += tr("Constraint two activities consecutive (second activity must be placed immediately after the first" + " activity, in the same day, possibly separated by breaks)");
		s += "\n";

		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		s += tr("First activity id=%1 (%2)", "%1 is the id, %2 is the detailed description of the activity.").arg(this.firstActivityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.firstActivityId));
		s += "\n";

		s += tr("Second activity id=%1 (%2)", "%1 is the id, %2 is the detailed description of the activity.").arg(this.secondActivityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.secondActivityId));
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		Debug.Assert(r.internalStructureComputed);

		nbroken = 0;
		if (c.times[this.firstActivityIndex] != GlobalMembersTimetable_defs.UNALLOCATED_TIME && c.times[this.secondActivityIndex] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
		{
			int fd = c.times[this.firstActivityIndex] % r.nDaysPerWeek; //the day when first activity was scheduled
			int fh = c.times[this.firstActivityIndex] / r.nDaysPerWeek; //the hour
			int sd = c.times[this.secondActivityIndex] % r.nDaysPerWeek; //the day when second activity was scheduled
			int sh = c.times[this.secondActivityIndex] / r.nDaysPerWeek; //the hour

			if (fd != sd)
				nbroken = 1;
			else if (fh + r.internalActivitiesList[this.firstActivityIndex].duration > sh)
				nbroken = 1;
			else if (fd == sd)
			{
				int h;
				int d = fd;
				Debug.Assert(d == sd);
				for (h = fh + r.internalActivitiesList[this.firstActivityIndex].duration; h < r.nHoursPerDay; h++)
					if (!GlobalMembersGenerate_pre.breakDayHour[d][h])
						break;

				Debug.Assert(h <= sh);

				if (h != sh)
					nbroken = 1;
			}
		}

		Debug.Assert(nbroken == 0 || nbroken == 1);

		if (conflictsString != null && nbroken > 0)
		{
			QString s = tr("Time constraint two activities consecutive broken for first activity with id=%1 (%2) and " + "second activity with id=%3 (%4), increases conflicts total by %5", "%1 is the id, %2 is the detailed description of the activity, %3 id, %4 det. descr.").arg(this.firstActivityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.firstActivityId)).arg(this.secondActivityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.secondActivityId)).arg(CustomFETString.number(weightPercentage / 100 * nbroken));

			dl.append(s);
			cl.append(weightPercentage / 100 * nbroken);

			conflictsString += s + "\n";
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return nbroken * weightPercentage / 100;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);

		if (this.firstActivityId == a.id)
			return true;
		if (this.secondActivityId == a.id)
			return true;
		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0);

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0); //should check hasWrongDayOrHour, firstly

		return true;
	}
}

public abstract class ConstraintTwoActivitiesGrouped: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTwoActivitiesGrouped) public: int firstActivityId;
	/**
	First activity id
	*/

	/**
	Second activity id
	*/
	private int secondActivityId;

	//internal variables
	/**
	The index of the first activity in the rules (from 0 to rules.nActivities-1) - it is not the id of the activity
	*/
	private int firstActivityIndex;

	/**
	The index of the second activity in the rules (from 0 to rules.nActivities-1) - it is not the id of the activity
	*/
	private int secondActivityIndex;


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintTwoActivitiesGrouped() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TWO_ACTIVITIES_GROUPED;
	}

	private ConstraintTwoActivitiesGrouped(double wp, int firstActId, int secondActId) : base(wp)
	{
		this.firstActivityId = firstActId;
		this.secondActivityId = secondActId;
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TWO_ACTIVITIES_GROUPED;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Activity act;
		int i;
		for (i = 0; i < r.nInternalActivities; i++)
		{
			act = r.internalActivitiesList[i];
			if (act.id == this.firstActivityId)
				break;
		}

		if (i == r.nInternalActivities)
		{
			//assert(0);
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (refers to inexistent activity ids):\n%1").arg(this.getDetailedDescription(ref r)));
			return false;
		}

		this.firstActivityIndex = i;

		////////

		for (i = 0; i < r.nInternalActivities; i++)
		{
			act = r.internalActivitiesList[i];
			if (act.id == this.secondActivityId)
				break;
		}

		if (i == r.nInternalActivities)
		{
			//assert(0);
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (refers to inexistent activity ids):\n%1").arg(this.getDetailedDescription(ref r)));
			return false;
		}

		this.secondActivityIndex = i;

		if (firstActivityIndex == secondActivityIndex)
		{
			//assert(0);
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (refers to same activities):\n%1").arg(this.getDetailedDescription(ref r)));
			return false;
		}
		Debug.Assert(firstActivityIndex != secondActivityIndex);

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		if (r.inactiveActivities.contains(this.firstActivityId))
			return true;
		if (r.inactiveActivities.contains(this.secondActivityId))
			return true;
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintTwoActivitiesGrouped>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<First_Activity_Id>" + CustomFETString.number(this.firstActivityId) + "</First_Activity_Id>\n";
		s += "	<Second_Activity_Id>" + CustomFETString.number(this.secondActivityId) + "</Second_Activity_Id>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTwoActivitiesGrouped>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();

		s = tr("Constraint two activities grouped:");
		s += " ";

		s += tr("first act. id: %1", "act.=activity").arg(this.firstActivityId);
		s += ", ";
		s += tr("second act. id: %1", "act.=activity").arg(this.secondActivityId);
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		QString s = tr("Time constraint");
		s += "\n";
		s += tr("Constraint two activities grouped (the activities must be placed in the same day, " + "one immediately following the other, in any order, possibly separated by breaks)");
		s += "\n";

		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		s += tr("First activity id=%1 (%2)", "%1 is the id, %2 is the detailed description of the activity.").arg(this.firstActivityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.firstActivityId));
		s += "\n";

		s += tr("Second activity id=%1 (%2)", "%1 is the id, %2 is the detailed description of the activity.").arg(this.secondActivityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.secondActivityId));
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		Debug.Assert(r.internalStructureComputed);

		nbroken = 0;
		if (c.times[this.firstActivityIndex] != GlobalMembersTimetable_defs.UNALLOCATED_TIME && c.times[this.secondActivityIndex] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
		{
			int fd = c.times[this.firstActivityIndex] % r.nDaysPerWeek; //the day when first activity was scheduled
			int fh = c.times[this.firstActivityIndex] / r.nDaysPerWeek; //the hour
			int sd = c.times[this.secondActivityIndex] % r.nDaysPerWeek; //the day when second activity was scheduled
			int sh = c.times[this.secondActivityIndex] / r.nDaysPerWeek; //the hour

			if (fd != sd)
				nbroken = 1;
			else if (fd == sd && fh + r.internalActivitiesList[this.firstActivityIndex].duration <= sh)
			{
				int h;
				int d = fd;
				Debug.Assert(d == sd);
				for (h = fh + r.internalActivitiesList[this.firstActivityIndex].duration; h < r.nHoursPerDay; h++)
					if (!GlobalMembersGenerate_pre.breakDayHour[d][h])
						break;

				Debug.Assert(h <= sh);

				if (h != sh)
					nbroken = 1;
			}
			else if (fd == sd && sh + r.internalActivitiesList[this.secondActivityIndex].duration <= fh)
			{
				int h;
				int d = sd;
				Debug.Assert(d == fd);
				for (h = sh + r.internalActivitiesList[this.secondActivityIndex].duration; h < r.nHoursPerDay; h++)
					if (!GlobalMembersGenerate_pre.breakDayHour[d][h])
						break;

				Debug.Assert(h <= fh);

				if (h != fh)
					nbroken = 1;
			}
			else
				nbroken = 1;
		}

		Debug.Assert(nbroken == 0 || nbroken == 1);

		if (conflictsString != null && nbroken > 0)
		{
			QString s = tr("Time constraint two activities grouped broken for first activity with id=%1 (%2) and " + "second activity with id=%3 (%4), increases conflicts total by %5", "%1 is the id, %2 is the detailed description of the activity, %3 id, %4 det. descr.").arg(this.firstActivityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.firstActivityId)).arg(this.secondActivityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.secondActivityId)).arg(CustomFETString.number(weightPercentage / 100 * nbroken));

			dl.append(s);
			cl.append(weightPercentage / 100 * nbroken);

			conflictsString += s + "\n";
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return nbroken * weightPercentage / 100;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);

		if (this.firstActivityId == a.id)
			return true;
		if (this.secondActivityId == a.id)
			return true;
		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0);

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0); //should check hasWrongDayOrHour, firstly

		return true;
	}
}

public abstract class ConstraintThreeActivitiesGrouped: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintThreeActivitiesGrouped) public: int firstActivityId;
	/**
	First activity id
	*/

	/**
	Second activity id
	*/
	private int secondActivityId;

	private int thirdActivityId;

	//internal variables
	/**
	The index of the first activity in the rules (from 0 to rules.nActivities-1) - it is not the id of the activity
	*/
	private int firstActivityIndex;

	/**
	The index of the second activity in the rules (from 0 to rules.nActivities-1) - it is not the id of the activity
	*/
	private int secondActivityIndex;

	private int thirdActivityIndex;


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintThreeActivitiesGrouped() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_THREE_ACTIVITIES_GROUPED;
	}

	private ConstraintThreeActivitiesGrouped(double wp, int firstActId, int secondActId, int thirdActId) : base(wp)
	{
		this.firstActivityId = firstActId;
		this.secondActivityId = secondActId;
		this.thirdActivityId = thirdActId;
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_THREE_ACTIVITIES_GROUPED;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Activity act;
		int i;
		for (i = 0; i < r.nInternalActivities; i++)
		{
			act = r.internalActivitiesList[i];
			if (act.id == this.firstActivityId)
				break;
		}

		if (i == r.nInternalActivities)
		{
			//assert(0);
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (refers to inexistent activity ids):\n%1").arg(this.getDetailedDescription(ref r)));
			return false;
		}

		this.firstActivityIndex = i;

		////////

		for (i = 0; i < r.nInternalActivities; i++)
		{
			act = r.internalActivitiesList[i];
			if (act.id == this.secondActivityId)
				break;
		}

		if (i == r.nInternalActivities)
		{
			//assert(0);
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (refers to inexistent activity ids):\n%1").arg(this.getDetailedDescription(ref r)));
			return false;
		}

		this.secondActivityIndex = i;

		////////

		for (i = 0; i < r.nInternalActivities; i++)
		{
			act = r.internalActivitiesList[i];
			if (act.id == this.thirdActivityId)
				break;
		}

		if (i == r.nInternalActivities)
		{
			//assert(0);
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (refers to inexistent activity ids):\n%1").arg(this.getDetailedDescription(ref r)));
			return false;
		}

		this.thirdActivityIndex = i;

		if (firstActivityIndex == secondActivityIndex || firstActivityIndex == thirdActivityIndex || secondActivityIndex == thirdActivityIndex)
		{
			//assert(0);
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (refers to same activities):\n%1").arg(this.getDetailedDescription(ref r)));
			return false;
		}
		Debug.Assert(firstActivityIndex != secondActivityIndex && firstActivityIndex != thirdActivityIndex && secondActivityIndex != thirdActivityIndex);

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		if (r.inactiveActivities.contains(this.firstActivityId))
			return true;
		if (r.inactiveActivities.contains(this.secondActivityId))
			return true;
		if (r.inactiveActivities.contains(this.thirdActivityId))
			return true;
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintThreeActivitiesGrouped>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<First_Activity_Id>" + CustomFETString.number(this.firstActivityId) + "</First_Activity_Id>\n";
		s += "	<Second_Activity_Id>" + CustomFETString.number(this.secondActivityId) + "</Second_Activity_Id>\n";
		s += "	<Third_Activity_Id>" + CustomFETString.number(this.thirdActivityId) + "</Third_Activity_Id>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintThreeActivitiesGrouped>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();

		s = tr("Constraint three activities grouped:");
		s += " ";

		s += tr("first act. id: %1", "act.=activity").arg(this.firstActivityId);
		s += ", ";
		s += tr("second act. id: %1", "act.=activity").arg(this.secondActivityId);
		s += ", ";
		s += tr("third act. id: %1", "act.=activity").arg(this.thirdActivityId);
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		QString s = tr("Time constraint");
		s += "\n";
		s += tr("Constraint three activities grouped (the activities must be placed in the same day, " + "one immediately following the other, as a block of three activities, in any order, possibly separated by breaks)");
		s += "\n";

		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		s += tr("First activity id=%1 (%2)", "%1 is the id, %2 is the detailed description of the activity.").arg(this.firstActivityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.firstActivityId));
		s += "\n";

		s += tr("Second activity id=%1 (%2)", "%1 is the id, %2 is the detailed description of the activity.").arg(this.secondActivityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.secondActivityId));
		s += "\n";

		s += tr("Third activity id=%1 (%2)", "%1 is the id, %2 is the detailed description of the activity.").arg(this.thirdActivityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.thirdActivityId));
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		Debug.Assert(r.internalStructureComputed);

		nbroken = 0;
		if (c.times[this.firstActivityIndex] != GlobalMembersTimetable_defs.UNALLOCATED_TIME && c.times[this.secondActivityIndex] != GlobalMembersTimetable_defs.UNALLOCATED_TIME && c.times[this.thirdActivityIndex] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
		{
			int fd = c.times[this.firstActivityIndex] % r.nDaysPerWeek; //the day when first activity was scheduled
			int fh = c.times[this.firstActivityIndex] / r.nDaysPerWeek; //the hour
			int sd = c.times[this.secondActivityIndex] % r.nDaysPerWeek; //the day when second activity was scheduled
			int sh = c.times[this.secondActivityIndex] / r.nDaysPerWeek; //the hour
			int td = c.times[this.thirdActivityIndex] % r.nDaysPerWeek; //the day when third activity was scheduled
			int th = c.times[this.thirdActivityIndex] / r.nDaysPerWeek; //the hour

			if (!(fd == sd && fd == td))
				nbroken = 1;
			else
			{
				Debug.Assert(fd == sd && fd == td && sd == td);
				int a1 = -1;
				int a2 = -1;
				int a3 = -1;
				if (fh >= sh && fh >= th && sh >= th)
				{
					a1 = thirdActivityIndex;
					a2 = secondActivityIndex;
					a3 = firstActivityIndex;
					//out<<"321"<<endl;
				}
				else if (fh >= sh && fh >= th && th >= sh)
				{
					a1 = secondActivityIndex;
					a2 = thirdActivityIndex;
					a3 = firstActivityIndex;
					//out<<"231"<<endl;
				}
				else if (sh >= fh && sh >= th && fh >= th)
				{
					a1 = thirdActivityIndex;
					a2 = firstActivityIndex;
					a3 = secondActivityIndex;
					//out<<"312"<<endl;
				}
				else if (sh >= fh && sh >= th && th >= fh)
				{
					a1 = firstActivityIndex;
					a2 = thirdActivityIndex;
					a3 = secondActivityIndex;
					//out<<"132"<<endl;
				}
				else if (th >= fh && th >= sh && fh >= sh)
				{
					a1 = secondActivityIndex;
					a2 = firstActivityIndex;
					a3 = thirdActivityIndex;
					//out<<"213"<<endl;
				}
				else if (th >= fh && th >= sh && sh >= fh)
				{
					a1 = firstActivityIndex;
					a2 = secondActivityIndex;
					a3 = thirdActivityIndex;
					//out<<"123"<<endl;
				}
				else
					Debug.Assert(0);

				int a1d = c.times[a1] % r.nDaysPerWeek; //the day for a1
				int a1h = c.times[a1] / r.nDaysPerWeek; //the day for a1
				int a1dur = r.internalActivitiesList[a1].duration;

				int a2d = c.times[a2] % r.nDaysPerWeek; //the day for a2
				int a2h = c.times[a2] / r.nDaysPerWeek; //the day for a2
				int a2dur = r.internalActivitiesList[a2].duration;

				int a3d = c.times[a3] % r.nDaysPerWeek; //the day for a3
				int a3h = c.times[a3] / r.nDaysPerWeek; //the day for a3
				//int a3dur=r.internalActivitiesList[a3].duration;

				int hoursBetweenThem = -1;

				Debug.Assert(a1d == a2d && a1d == a3d);

				if (a1h + a1dur <= a2h && a2h + a2dur <= a3h)
				{
					hoursBetweenThem = 0;
					for (int hh = a1h + a1dur; hh < a2h; hh++)
						if (!GlobalMembersGenerate_pre.breakDayHour[a1d][hh])
							hoursBetweenThem++;

					for (int hh = a2h + a2dur; hh < a3h; hh++)
						if (!GlobalMembersGenerate_pre.breakDayHour[a2d][hh])
							hoursBetweenThem++;
				}

				if (hoursBetweenThem == 0)
					nbroken = 0;
				else
					nbroken = 1;
			}
		}

		Debug.Assert(nbroken == 0 || nbroken == 1);

		if (conflictsString != null && nbroken > 0)
		{
			QString s = tr("Time constraint three activities grouped broken for first activity with id=%1 (%2), " + "second activity with id=%3 (%4) and third activity with id=%5 (%6), increases conflicts total by %7", "%1 is the id, %2 is the detailed description of the activity, %3 id, %4 det. descr., %5 id, %6 det. descr.").arg(this.firstActivityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.firstActivityId)).arg(this.secondActivityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.secondActivityId)).arg(this.thirdActivityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.thirdActivityId)).arg(CustomFETString.number(weightPercentage / 100 * nbroken));

			dl.append(s);
			cl.append(weightPercentage / 100 * nbroken);

			conflictsString += s + "\n";
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return nbroken * weightPercentage / 100;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);

		if (this.firstActivityId == a.id)
			return true;
		if (this.secondActivityId == a.id)
			return true;
		if (this.thirdActivityId == a.id)
			return true;
		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0);

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0); //should check hasWrongDayOrHour, firstly

		return true;
	}
}

public abstract class ConstraintTwoActivitiesOrdered: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTwoActivitiesOrdered) public: int firstActivityId;
	/**
	First activity id
	*/

	/**
	Second activity id
	*/
	private int secondActivityId;

	//internal variables
	/**
	The index of the first activity in the rules (from 0 to rules.nActivities-1) - it is not the id of the activity
	*/
	private int firstActivityIndex;

	/**
	The index of the second activity in the rules (from 0 to rules.nActivities-1) - it is not the id of the activity
	*/
	private int secondActivityIndex;


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintTwoActivitiesOrdered() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TWO_ACTIVITIES_ORDERED;
	}

	private ConstraintTwoActivitiesOrdered(double wp, int firstActId, int secondActId) : base(wp)
	{
		this.firstActivityId = firstActId;
		this.secondActivityId = secondActId;
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TWO_ACTIVITIES_ORDERED;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Activity act;
		int i;
		for (i = 0; i < r.nInternalActivities; i++)
		{
			act = r.internalActivitiesList[i];
			if (act.id == this.firstActivityId)
				break;
		}

		if (i == r.nInternalActivities)
		{
			//assert(0);
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (refers to inexistent activity ids):\n%1").arg(this.getDetailedDescription(ref r)));
			return false;
		}

		this.firstActivityIndex = i;

		////////

		for (i = 0; i < r.nInternalActivities; i++)
		{
			act = r.internalActivitiesList[i];
			if (act.id == this.secondActivityId)
				break;
		}

		if (i == r.nInternalActivities)
		{
			//assert(0);
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (refers to inexistent activity ids):\n%1").arg(this.getDetailedDescription(ref r)));
			return false;
		}

		this.secondActivityIndex = i;

		if (firstActivityIndex == secondActivityIndex)
		{
			//assert(0);
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (refers to same activities):\n%1").arg(this.getDetailedDescription(ref r)));
			return false;
		}
		Debug.Assert(firstActivityIndex != secondActivityIndex);

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		if (r.inactiveActivities.contains(this.firstActivityId))
			return true;
		if (r.inactiveActivities.contains(this.secondActivityId))
			return true;
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintTwoActivitiesOrdered>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<First_Activity_Id>" + CustomFETString.number(this.firstActivityId) + "</First_Activity_Id>\n";
		s += "	<Second_Activity_Id>" + CustomFETString.number(this.secondActivityId) + "</Second_Activity_Id>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTwoActivitiesOrdered>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();

		s = tr("Constraint two activities ordered:");
		s += " ";

		s += tr("first act. id: %1", "act.=activity").arg(this.firstActivityId);
		s += ", ";
		s += tr("second act. id: %1", "act.=activity").arg(this.secondActivityId);
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		QString s = tr("Time constraint");
		s += "\n";
		s += tr("Constraint two activities ordered (second activity must be placed at any time in the week after the first" + " activity)");
		s += "\n";

		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		s += tr("First activity id=%1 (%2)", "%1 is the id, %2 is the detailed description of the activity.").arg(this.firstActivityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.firstActivityId));
		s += "\n";

		s += tr("Second activity id=%1 (%2)", "%1 is the id, %2 is the detailed description of the activity.").arg(this.secondActivityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.secondActivityId));
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		Debug.Assert(r.internalStructureComputed);

		nbroken = 0;
		if (c.times[this.firstActivityIndex] != GlobalMembersTimetable_defs.UNALLOCATED_TIME && c.times[this.secondActivityIndex] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
		{
			int fd = c.times[this.firstActivityIndex] % r.nDaysPerWeek; //the day when first activity was scheduled
			int fh = c.times[this.firstActivityIndex] / r.nDaysPerWeek + r.internalActivitiesList[this.firstActivityIndex].duration - 1; //the end hour of first activity
			int sd = c.times[this.secondActivityIndex] % r.nDaysPerWeek; //the day when second activity was scheduled
			int sh = c.times[this.secondActivityIndex] / r.nDaysPerWeek; //the start hour of second activity

			if (!(fd < sd || (fd == sd && fh < sh)))
				nbroken = 1;
		}

		Debug.Assert(nbroken == 0 || nbroken == 1);

		if (conflictsString != null && nbroken > 0)
		{
			QString s = tr("Time constraint two activities ordered broken for first activity with id=%1 (%2) and " + "second activity with id=%3 (%4), increases conflicts total by %5", "%1 is the id, %2 is the detailed description of the activity, %3 id, %4 det. descr.").arg(this.firstActivityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.firstActivityId)).arg(this.secondActivityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.secondActivityId)).arg(CustomFETString.number(weightPercentage / 100 * nbroken));

			dl.append(s);
			cl.append(weightPercentage / 100 * nbroken);

			conflictsString += s + "\n";
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return nbroken * weightPercentage / 100;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);

		if (this.firstActivityId == a.id)
			return true;
		if (this.secondActivityId == a.id)
			return true;
		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0);

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0); //should check hasWrongDayOrHour, firstly

		return true;
	}
}

public abstract class ConstraintActivityEndsStudentsDay: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintActivityEndsStudentsDay) public: int activityId;
	/**
	Activity id
	*/

	//internal variables
	/**
	The index of the activity in the rules (from 0 to rules.nActivities-1) - it is not the id of the activity
	*/
	private int activityIndex;


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintActivityEndsStudentsDay() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITY_ENDS_STUDENTS_DAY;
	}

	private ConstraintActivityEndsStudentsDay(double wp, int actId) : base(wp)
	{
		this.activityId = actId;
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITY_ENDS_STUDENTS_DAY;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Activity act;
		int i;
		for (i = 0; i < r.nInternalActivities; i++)
		{
			act = r.internalActivitiesList[i];
			if (act.id == this.activityId)
				break;
		}

		if (i == r.nInternalActivities)
		{
			//assert(0);
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (because it refers to invalid activity id. Please correct (maybe removing it is a solution)):\n%1").arg(this.getDetailedDescription(ref r)));
			return false;
		}

		this.activityIndex = i;
		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		if (r.inactiveActivities.contains(this.activityId))
			return true;
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintActivityEndsStudentsDay>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Activity_Id>" + CustomFETString.number(this.activityId) + "</Activity_Id>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintActivityEndsStudentsDay>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Act. id: %1 (%2) must end students' day", "%1 is the id, %2 is the detailed description of the activity.").arg(this.activityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activityId));
		s += ", ";

		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		QString s = tr("Time constraint");
		s += "\n";
		s += tr("Activity must end students' day");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Activity id=%1 (%2)", "%1 is the id, %2 is the detailed description of the activity.").arg(this.activityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activityId));
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		Debug.Assert(r.internalStructureComputed);

		nbroken = 0;
		if (c.times[this.activityIndex] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
		{
			int d = c.times[this.activityIndex] % r.nDaysPerWeek; //the day when this activity was scheduled
			int h = c.times[this.activityIndex] / r.nDaysPerWeek; //the hour

			int i = this.activityIndex;
			for (int j = 0; j < r.internalActivitiesList[i].iSubgroupsList.count(); j++)
			{
				int sb = r.internalActivitiesList[i].iSubgroupsList.at(j);
				for (int hh = h + r.internalActivitiesList[i].duration; hh < r.nHoursPerDay; hh++)
					if (GlobalMembersTimeconstraint.subgroupsMatrix[sb][d][hh] > 0)
					{
						nbroken = 1;
						break;
					}
				if (nbroken != 0)
					break;
			}
		}

		if (conflictsString != null && nbroken > 0)
		{
			QString s = tr("Time constraint activity ends students' day broken for activity with id=%1 (%2), increases conflicts total by %3", "%1 is the id, %2 is the detailed description of the activity").arg(this.activityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activityId)).arg(CustomFETString.number(weightPercentage / 100 * nbroken));

			dl.append(s);
			cl.append(weightPercentage / 100 * nbroken);

			conflictsString += s + "\n";
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return nbroken * weightPercentage / 100;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);

		if (this.activityId == a.id)
			return true;
		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0);

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0); //should check hasWrongDayOrHour, firstly

		return true;
	}
}

public abstract class ConstraintTeachersMinHoursDaily: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTeachersMinHoursDaily) public: int minHoursDaily;
	/**
	The minimum hours daily
	*/

	private bool allowEmptyDays;


	///////////////////////////////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintTeachersMinHoursDaily() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHERS_MIN_HOURS_DAILY;

		this.allowEmptyDays = true;
	}

	private ConstraintTeachersMinHoursDaily(double wp, int minhours, bool _allowEmptyDays) : base(wp)
	{
		Debug.Assert(minhours > 0);
		this.minHoursDaily = minhours;

		this.allowEmptyDays = _allowEmptyDays;

		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHERS_MIN_HOURS_DAILY;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintTeachersMinHoursDaily>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Minimum_Hours_Daily>" + CustomFETString.number(this.minHoursDaily) + "</Minimum_Hours_Daily>\n";
		if (this.allowEmptyDays)
			s += "	<Allow_Empty_Days>true</Allow_Empty_Days>\n";
		else
			s += "	<Allow_Empty_Days>false</Allow_Empty_Days>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTeachersMinHoursDaily>\n";
		return s;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(r);

		if (allowEmptyDays == false)
		{
			QString s = tr("Cannot generate a timetable with a constraint teachers min hours daily with allow empty days=false. Please modify it," + " so that it allows empty days. If you need a facility like that, please use constraint teachers min days per week");
			s += "\n\n";
			s += tr("Constraint is:") + "\n" + this.getDetailedDescription(ref r);
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), s);

			return false;
		}

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Teachers min hours daily");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("mH:%1", "Min hours (daily)").arg(this.minHoursDaily);
		s += ", ";
		s += tr("AED:%1", "Allow empty days").arg(GlobalMembersSpaceconstraint.yesNoTranslated(this.allowEmptyDays));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("All teachers must respect the minimum number of hours daily");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Minimum hours daily=%1").arg(this.minHoursDaily);
		s += "\n";
		s += tr("Allow empty days=%1").arg(GlobalMembersSpaceconstraint.yesNoTranslated(this.allowEmptyDays));
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		Debug.Assert(this.allowEmptyDays == true);

		int nbroken;

		//without logging
		if (conflictsString == null)
		{
			nbroken = 0;
			for (int i = 0; i < r.nInternalTeachers; i++)
			{
				for (int d = 0; d < r.nDaysPerWeek; d++)
				{
					int n_hours_daily = 0;
					for (int h = 0; h < r.nHoursPerDay; h++)
						if (GlobalMembersTimeconstraint.teachersMatrix[i][d][h] > 0)
							n_hours_daily++;

					if (n_hours_daily > 0 && n_hours_daily < this.minHoursDaily)
					{
						nbroken++;
					}
				}
			}
		}
		//with logging
		else
		{
			nbroken = 0;
			for (int i = 0; i < r.nInternalTeachers; i++)
			{
				for (int d = 0; d < r.nDaysPerWeek; d++)
				{
					int n_hours_daily = 0;
					for (int h = 0; h < r.nHoursPerDay; h++)
						if (GlobalMembersTimeconstraint.teachersMatrix[i][d][h] > 0)
							n_hours_daily++;

					if (n_hours_daily > 0 && n_hours_daily < this.minHoursDaily)
					{
						nbroken++;

						if (conflictsString != null)
						{
							QString s = (tr("Time constraint teachers min %1 hours daily broken for teacher %2, on day %3, length=%4.").arg(CustomFETString.number(this.minHoursDaily)).arg(r.internalTeachersList[i].name).arg(r.daysOfTheWeek[d]).arg(n_hours_daily)) + " " + (tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100)));

							dl.append(s);
							cl.append(weightPercentage / 100);

							conflictsString += s + "\n";
						}
					}
				}
			}
		}

		if (c.nPlacedActivities == r.nInternalActivities)
			if (weightPercentage == 100)
				Debug.Assert(nbroken == 0);
		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(a);
		Q_UNUSED(r);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return true;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (minHoursDaily > r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (minHoursDaily > r.nHoursPerDay)
			minHoursDaily = r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintTeacherMinHoursDaily: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTeacherMinHoursDaily) public: int minHoursDaily;
	/**
	The minimum hours daily
	*/

	private QString teacherName = new QString();

	private int teacher_ID;

	private bool allowEmptyDays;


	///////////////////////////////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintTeacherMinHoursDaily() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_MIN_HOURS_DAILY;

		this.allowEmptyDays = true;
	}

	private ConstraintTeacherMinHoursDaily(double wp, int minhours, QString teacher, bool _allowEmptyDays) : base(wp)
	{
		Debug.Assert(minhours > 0);
		this.minHoursDaily = minhours;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->teacherName=teacher;
		this.teacherName.CopyFrom(teacher);

		this.allowEmptyDays = _allowEmptyDays;

		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_MIN_HOURS_DAILY;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintTeacherMinHoursDaily>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Teacher_Name>" + GlobalMembersTimetable_defs.protect(this.teacherName) + "</Teacher_Name>\n";
		s += "	<Minimum_Hours_Daily>" + CustomFETString.number(this.minHoursDaily) + "</Minimum_Hours_Daily>\n";
		if (this.allowEmptyDays)
			s += "	<Allow_Empty_Days>true</Allow_Empty_Days>\n";
		else
			s += "	<Allow_Empty_Days>false</Allow_Empty_Days>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTeacherMinHoursDaily>\n";
		return s;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		this.teacher_ID = r.searchTeacher(this.teacherName);
		Debug.Assert(this.teacher_ID >= 0);

		if (allowEmptyDays == false)
		{
			QString s = tr("Cannot generate a timetable with a constraint teacher min hours daily with allow empty days=false. Please modify it," + " so that it allows empty days. If you need a facility like that, please use constraint teacher min days per week");
			s += "\n\n";
			s += tr("Constraint is:") + "\n" + this.getDetailedDescription(ref r);
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), s);

			return false;
		}

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += tr("Teacher min hours daily");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("T:%1", "Teacher").arg(this.teacherName);
		s += ", ";
		s += tr("mH:%1", "Minimum hours (daily)").arg(this.minHoursDaily);
		s += ", ";
		s += tr("AED:%1", "Allow empty days").arg(GlobalMembersSpaceconstraint.yesNoTranslated(this.allowEmptyDays));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("A teacher must respect the minimum number of hours daily");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Teacher=%1").arg(this.teacherName);
		s += "\n";
		s += tr("Minimum hours daily=%1").arg(this.minHoursDaily);
		s += "\n";
		s += tr("Allow empty days=%1").arg(GlobalMembersSpaceconstraint.yesNoTranslated(this.allowEmptyDays));
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		Debug.Assert(this.allowEmptyDays == true);

		int nbroken;

		//without logging
		if (conflictsString == null)
		{
			nbroken = 0;
			int i = this.teacher_ID;
			for (int d = 0; d < r.nDaysPerWeek; d++)
			{
				int n_hours_daily = 0;
				for (int h = 0; h < r.nHoursPerDay; h++)
					if (GlobalMembersTimeconstraint.teachersMatrix[i][d][h] > 0)
						n_hours_daily++;

				if (n_hours_daily > 0 && n_hours_daily < this.minHoursDaily)
				{
					nbroken++;
				}
			}
		}
		//with logging
		else
		{
			nbroken = 0;
			int i = this.teacher_ID;
			for (int d = 0; d < r.nDaysPerWeek; d++)
			{
				int n_hours_daily = 0;
				for (int h = 0; h < r.nHoursPerDay; h++)
					if (GlobalMembersTimeconstraint.teachersMatrix[i][d][h] > 0)
						n_hours_daily++;

				if (n_hours_daily > 0 && n_hours_daily < this.minHoursDaily)
				{
					nbroken++;

					if (conflictsString != null)
					{
						QString s = (tr("Time constraint teacher min %1 hours daily broken for teacher %2, on day %3, length=%4.").arg(CustomFETString.number(this.minHoursDaily)).arg(r.internalTeachersList[i].name).arg(r.daysOfTheWeek[d]).arg(n_hours_daily)) + " " + tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100));

						dl.append(s);
						cl.append(weightPercentage / 100);

						conflictsString += s + "\n";
					}
				}
			}
		}

		if (c.nPlacedActivities == r.nInternalActivities)
			if (weightPercentage == 100)
				Debug.Assert(nbroken == 0);

		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		if (this.teacherName == t.name)
			return true;
		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (minHoursDaily > r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (minHoursDaily > r.nHoursPerDay)
			minHoursDaily = r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintTeacherIntervalMaxDaysPerWeek: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTeacherIntervalMaxDaysPerWeek) public: int maxDaysPerWeek;
	/**
	The number of maximum allowed working days per week
	*/

	private int startHour;

	private int endHour; //might be = to gt.rules.nHoursPerDay

	/**
	The teacher's name
	*/
	private QString teacherName = new QString();

	/**
	The teacher's id, or index in the rules
	*/
	private int teacher_ID;


	///////////////////////////////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintTeacherIntervalMaxDaysPerWeek() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_INTERVAL_MAX_DAYS_PER_WEEK;
	}

	private ConstraintTeacherIntervalMaxDaysPerWeek(double wp, int maxnd, QString tn, int sh, int eh) : base(wp)
	{
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->teacherName = tn;
		this.teacherName.CopyFrom(tn);
		this.maxDaysPerWeek = maxnd;
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_INTERVAL_MAX_DAYS_PER_WEEK;
		this.startHour = sh;
		this.endHour = eh;
		Debug.Assert(sh < eh);
		Debug.Assert(sh >= 0);
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		this.teacher_ID = r.searchTeacher(this.teacherName);
		Debug.Assert(this.teacher_ID >= 0);
		if (this.startHour >= this.endHour)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint teacher interval max days per week is wrong because start hour >= end hour." + " Please correct it. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}
		if (this.startHour < 0)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint teacher interval max days per week is wrong because start hour < first hour or the day." + " Please correct it. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}
		if (this.endHour > r.nHoursPerDay)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint teacher interval max days per week is wrong because end hour > number of hours per day." + " Please correct it. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}
		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintTeacherIntervalMaxDaysPerWeek>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Teacher_Name>" + GlobalMembersTimetable_defs.protect(this.teacherName) + "</Teacher_Name>\n";
		s += "	<Interval_Start_Hour>" + GlobalMembersTimetable_defs.protect(r.hoursOfTheDay[this.startHour]) + "</Interval_Start_Hour>\n";
		if (this.endHour < r.nHoursPerDay)
		{
			s += "	<Interval_End_Hour>" + GlobalMembersTimetable_defs.protect(r.hoursOfTheDay[this.endHour]) + "</Interval_End_Hour>\n";
		}
		else
		{
			s += "	<Interval_End_Hour></Interval_End_Hour>\n";
			s += "	<!-- Interval_End_Hour void means the end of the day (which has no name) -->\n";
		}
		s += "	<Max_Days_Per_Week>" + CustomFETString.number(this.maxDaysPerWeek) + "</Max_Days_Per_Week>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTeacherIntervalMaxDaysPerWeek>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = tr("Teacher interval max days per week");
		s += ", ";
		s += tr("WP:%1%", "Abbreviation for weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("T:%1", "Abbreviation for teacher").arg(this.teacherName);
		s += ", ";
		s += tr("ISH:%1", "Abbreviation for interval start hour").arg(r.hoursOfTheDay[this.startHour]);
		s += ", ";
		if (this.endHour < r.nHoursPerDay)
			s += tr("IEH:%1", "Abbreviation for interval end hour").arg(r.hoursOfTheDay[this.endHour]);
		else
			s += tr("IEH:%1", "Abbreviation for interval end hour").arg(tr("End of the day"));
		s += ", ";
		s += tr("MD:%1", "Abbreviation for max days").arg(this.maxDaysPerWeek);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("A teacher respects working in an hourly interval a maximum number of days per week");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Teacher=%1").arg(this.teacherName);
		s += "\n";
		s += tr("Interval start hour=%1").arg(r.hoursOfTheDay[this.startHour]);
		s += "\n";

		if (this.endHour < r.nHoursPerDay)
			s += tr("Interval end hour=%1").arg(r.hoursOfTheDay[this.endHour]);
		else
			s += tr("Interval end hour=%1").arg(tr("End of the day"));
		s += "\n";

		s += tr("Maximum days per week=%1").arg(this.maxDaysPerWeek);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString *conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		int t = this.teacher_ID;

		nbroken = 0;
		bool[] ocDay = new bool[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK];
		for (int d = 0; d < r.nDaysPerWeek; d++)
		{
			ocDay[d] = false;
			for (int h = startHour; h < endHour; h++)
			{
				if (GlobalMembersTimeconstraint.teachersMatrix[t][d][h] > 0)
				{
					ocDay[d] = true;
				}
			}
		}
		int nOcDays = 0;
		for (int d = 0; d < r.nDaysPerWeek; d++)
			if (ocDay[d])
				nOcDays++;
		if (nOcDays > this.maxDaysPerWeek)
		{
			nbroken += nOcDays - this.maxDaysPerWeek;

			if (nbroken > 0)
			{
				QString s = tr("Time constraint teacher interval max days per week broken for teacher: %1, allowed %2 days, required %3 days.").arg(r.internalTeachersList[t].name).arg(this.maxDaysPerWeek).arg(nOcDays);
				s += " ";
				s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(nbroken * weightPercentage / 100));

				dl.append(s);
				cl.append(nbroken * weightPercentage / 100);

				conflictsString += s + "\n";
			}
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		if (this.teacherName == t.name)
			return true;
		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (this.startHour >= r.nHoursPerDay)
			return true;
		if (this.endHour > r.nHoursPerDay)
			return true;
		if (this.maxDaysPerWeek > r.nDaysPerWeek)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (this.startHour < r.nHoursPerDay && this.endHour <= r.nHoursPerDay)
			return true;

		return false;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		Debug.Assert(this.startHour < r.nHoursPerDay && this.endHour <= r.nHoursPerDay);

		if (this.maxDaysPerWeek > r.nDaysPerWeek)
			this.maxDaysPerWeek = r.nDaysPerWeek;

		return true;
	}
}

public abstract class ConstraintTeachersIntervalMaxDaysPerWeek: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTeachersIntervalMaxDaysPerWeek) public: int maxDaysPerWeek;
	/**
	The number of maximum allowed working days per week
	*/

	private int startHour;

	private int endHour; //might be = to gt.rules.nHoursPerDay



	///////////////////////////////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintTeachersIntervalMaxDaysPerWeek() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHERS_INTERVAL_MAX_DAYS_PER_WEEK;
	}

	private ConstraintTeachersIntervalMaxDaysPerWeek(double wp, int maxnd, int sh, int eh) : base(wp)
	{
		this.maxDaysPerWeek = maxnd;
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHERS_INTERVAL_MAX_DAYS_PER_WEEK;
		this.startHour = sh;
		this.endHour = eh;
		Debug.Assert(sh < eh);
		Debug.Assert(sh >= 0);
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		if (this.startHour >= this.endHour)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint teacher interval max days per week is wrong because start hour >= end hour." + " Please correct it. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}
		if (this.startHour < 0)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint teacher interval max days per week is wrong because start hour < first hour or the day." + " Please correct it. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}
		if (this.endHour > r.nHoursPerDay)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint teacher interval max days per week is wrong because end hour > number of hours per day." + " Please correct it. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}
		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintTeachersIntervalMaxDaysPerWeek>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Interval_Start_Hour>" + GlobalMembersTimetable_defs.protect(r.hoursOfTheDay[this.startHour]) + "</Interval_Start_Hour>\n";
		if (this.endHour < r.nHoursPerDay)
		{
			s += "	<Interval_End_Hour>" + GlobalMembersTimetable_defs.protect(r.hoursOfTheDay[this.endHour]) + "</Interval_End_Hour>\n";
		}
		else
		{
			s += "	<Interval_End_Hour></Interval_End_Hour>\n";
			s += "	<!-- Interval_End_Hour void means the end of the day (which has no name) -->\n";
		}
		s += "	<Max_Days_Per_Week>" + CustomFETString.number(this.maxDaysPerWeek) + "</Max_Days_Per_Week>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTeachersIntervalMaxDaysPerWeek>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = tr("Teachers interval max days per week");
		s += ", ";
		s += tr("WP:%1%", "Abbreviation for weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("ISH:%1", "Abbreviation for interval start hour").arg(r.hoursOfTheDay[this.startHour]);
		s += ", ";
		if (this.endHour < r.nHoursPerDay)
			s += tr("IEH:%1", "Abbreviation for interval end hour").arg(r.hoursOfTheDay[this.endHour]);
		else
			s += tr("IEH:%1", "Abbreviation for interval end hour").arg(tr("End of the day"));
		s += ", ";
		s += tr("MD:%1", "Abbreviation for max days").arg(this.maxDaysPerWeek);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("All teachers respect working in an hourly interval a maximum number of days per week");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Interval start hour=%1").arg(r.hoursOfTheDay[this.startHour]);
		s += "\n";

		if (this.endHour < r.nHoursPerDay)
			s += tr("Interval end hour=%1").arg(r.hoursOfTheDay[this.endHour]);
		else
			s += tr("Interval end hour=%1").arg(tr("End of the day"));
		s += "\n";

		s += tr("Maximum days per week=%1").arg(this.maxDaysPerWeek);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString *conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken = 0;

		for (int t = 0; t < r.nInternalTeachers; t++)
		{
			bool[] ocDay = new bool[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK];
			for (int d = 0; d < r.nDaysPerWeek; d++)
			{
				ocDay[d] = false;
				for (int h = startHour; h < endHour; h++)
				{
					if (GlobalMembersTimeconstraint.teachersMatrix[t][d][h] > 0)
					{
						ocDay[d] = true;
					}
				}
			}
			int nOcDays = 0;
			for (int d = 0; d < r.nDaysPerWeek; d++)
				if (ocDay[d])
					nOcDays++;
			if (nOcDays > this.maxDaysPerWeek)
			{
				nbroken += nOcDays - this.maxDaysPerWeek;

				if (nOcDays - this.maxDaysPerWeek > 0)
				{
					QString s = tr("Time constraint teachers interval max days per week broken for teacher: %1, allowed %2 days, required %3 days.").arg(r.internalTeachersList[t].name).arg(this.maxDaysPerWeek).arg(nOcDays);
					s += " ";
					s += tr("This increases the conflicts total by %1").arg(CustomFETString.number((nOcDays - this.maxDaysPerWeek) * weightPercentage / 100));

					dl.append(s);
					cl.append((nOcDays - this.maxDaysPerWeek) * weightPercentage / 100);

					conflictsString += s + "\n";
				}
			}
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return true;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (this.startHour >= r.nHoursPerDay)
			return true;
		if (this.endHour > r.nHoursPerDay)
			return true;
		if (this.maxDaysPerWeek > r.nDaysPerWeek)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (this.startHour < r.nHoursPerDay && this.endHour <= r.nHoursPerDay)
			return true;

		return false;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		Debug.Assert(this.startHour < r.nHoursPerDay && this.endHour <= r.nHoursPerDay);

		if (this.maxDaysPerWeek > r.nDaysPerWeek)
			this.maxDaysPerWeek = r.nDaysPerWeek;

		return true;
	}
}

public abstract class ConstraintStudentsSetIntervalMaxDaysPerWeek: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintStudentsSetIntervalMaxDaysPerWeek) public: int maxDaysPerWeek;
	/**
	The number of maximum allowed working days per week
	*/

	private int startHour;

	private int endHour; //might be = to gt.rules.nHoursPerDay

	/**
	The name of the students set for this constraint
	*/
	private QString students = new QString();

	//internal redundant data

	/**
	The number of subgroups
	*/
	//int nSubgroups;

	/**
	The subgroups
	*/
	private QList<int> iSubgroupsList = new QList<int>();


	///////////////////////////////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintStudentsSetIntervalMaxDaysPerWeek() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_INTERVAL_MAX_DAYS_PER_WEEK;
	}

	private ConstraintStudentsSetIntervalMaxDaysPerWeek(double wp, int maxnd, QString sn, int sh, int eh) : base(wp)
	{
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->students = sn;
		this.students.CopyFrom(sn);
		this.maxDaysPerWeek = maxnd;
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_INTERVAL_MAX_DAYS_PER_WEEK;
		this.startHour = sh;
		this.endHour = eh;
		Debug.Assert(sh < eh);
		Debug.Assert(sh >= 0);
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		if (this.startHour >= this.endHour)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint teacher interval max days per week is wrong because start hour >= end hour." + " Please correct it. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}
		if (this.startHour < 0)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint teacher interval max days per week is wrong because start hour < first hour or the day." + " Please correct it. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}
		if (this.endHour > r.nHoursPerDay)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint teacher interval max days per week is wrong because end hour > number of hours per day." + " Please correct it. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}

		/////////
		StudentsSet ss = r.searchAugmentedStudentsSet(this.students);

		if (ss == null)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint students set interval max days per week is wrong because it refers to inexistent students set." + " Please correct it (removing it might be a solution). Please report potential bug. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}

		Debug.Assert(ss);

		this.iSubgroupsList.clear();
		if (ss.type == GlobalMembersStudentsset.STUDENTS_SUBGROUP)
		{
			int tmp;
			tmp = ((StudentsSubgroup)ss).indexInInternalSubgroupsList;
			Debug.Assert(tmp >= 0);
			Debug.Assert(tmp < r.nInternalSubgroups);
			if (!this.iSubgroupsList.contains(tmp))
				this.iSubgroupsList.append(tmp);
		}
		else if (ss.type == GlobalMembersStudentsset.STUDENTS_GROUP)
		{
			StudentsGroup stg = (StudentsGroup)ss;
			for (int i = 0; i < stg.subgroupsList.size(); i++)
			{
				StudentsSubgroup sts = stg.subgroupsList[i];
				int tmp;
				tmp = sts.indexInInternalSubgroupsList;
				Debug.Assert(tmp >= 0);
				Debug.Assert(tmp < r.nInternalSubgroups);
				if (!this.iSubgroupsList.contains(tmp))
					this.iSubgroupsList.append(tmp);
			}
		}
		else if (ss.type == GlobalMembersStudentsset.STUDENTS_YEAR)
		{
			StudentsYear sty = (StudentsYear)ss;
			for (int i = 0; i < sty.groupsList.size(); i++)
			{
				StudentsGroup stg = sty.groupsList[i];
				for (int j = 0; j < stg.subgroupsList.size(); j++)
				{
					StudentsSubgroup sts = stg.subgroupsList[j];
					int tmp;
					tmp = sts.indexInInternalSubgroupsList;
					Debug.Assert(tmp >= 0);
					Debug.Assert(tmp < r.nInternalSubgroups);
					if (!this.iSubgroupsList.contains(tmp))
						this.iSubgroupsList.append(tmp);
				}
			}
		}
		else
			Debug.Assert(0);

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintStudentsSetIntervalMaxDaysPerWeek>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Students>" + GlobalMembersTimetable_defs.protect(this.students) + "</Students>\n";
		s += "	<Interval_Start_Hour>" + GlobalMembersTimetable_defs.protect(r.hoursOfTheDay[this.startHour]) + "</Interval_Start_Hour>\n";
		if (this.endHour < r.nHoursPerDay)
		{
			s += "	<Interval_End_Hour>" + GlobalMembersTimetable_defs.protect(r.hoursOfTheDay[this.endHour]) + "</Interval_End_Hour>\n";
		}
		else
		{
			s += "	<Interval_End_Hour></Interval_End_Hour>\n";
			s += "	<!-- Interval_End_Hour void means the end of the day (which has no name) -->\n";
		}
		s += "	<Max_Days_Per_Week>" + CustomFETString.number(this.maxDaysPerWeek) + "</Max_Days_Per_Week>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintStudentsSetIntervalMaxDaysPerWeek>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = tr("Students set interval max days per week");
		s += ", ";
		s += tr("WP:%1%", "Abbreviation for weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("St:%1", "Abbreviation for students (sets)").arg(this.students);
		s += ", ";
		s += tr("ISH:%1", "Abbreviation for interval start hour").arg(r.hoursOfTheDay[this.startHour]);
		s += ", ";
		if (this.endHour < r.nHoursPerDay)
			s += tr("IEH:%1", "Abbreviation for interval end hour").arg(r.hoursOfTheDay[this.endHour]);
		else
			s += tr("IEH:%1", "Abbreviation for interval end hour").arg(tr("End of the day"));
		s += ", ";
		s += tr("MD:%1", "Abbreviation for max days").arg(this.maxDaysPerWeek);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("A students set respects working in an hourly interval a maximum number of days per week");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Students set=%1").arg(this.students);
		s += "\n";
		s += tr("Interval start hour=%1").arg(r.hoursOfTheDay[this.startHour]);
		s += "\n";

		if (this.endHour < r.nHoursPerDay)
			s += tr("Interval end hour=%1").arg(r.hoursOfTheDay[this.endHour]);
		else
			s += tr("Interval end hour=%1").arg(tr("End of the day"));
		s += "\n";

		s += tr("Maximum days per week=%1").arg(this.maxDaysPerWeek);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString *conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		nbroken = 0;

		foreach (int sbg, this.iSubgroupsList)
		{
			bool[] ocDay = new bool[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK];
			for (int d = 0; d < r.nDaysPerWeek; d++)
			{
				ocDay[d] = false;
				for (int h = startHour; h < endHour; h++)
				{
					if (GlobalMembersTimeconstraint.subgroupsMatrix[sbg][d][h] > 0)
					{
						ocDay[d] = true;
					}
				}
			}
			int nOcDays = 0;
			for (int d = 0; d < r.nDaysPerWeek; d++)
				if (ocDay[d])
					nOcDays++;
			if (nOcDays > this.maxDaysPerWeek)
			{
				nbroken += nOcDays - this.maxDaysPerWeek;

				if ((nOcDays - this.maxDaysPerWeek) > 0)
				{
					QString s = tr("Time constraint students set interval max days per week broken for subgroup: %1, allowed %2 days, required %3 days.").arg(r.internalSubgroupsList[sbg].name).arg(this.maxDaysPerWeek).arg(nOcDays);
					s += " ";
					s += tr("This increases the conflicts total by %1").arg(CustomFETString.number((nOcDays - this.maxDaysPerWeek) * weightPercentage / 100));

					dl.append(s);
					cl.append((nOcDays - this.maxDaysPerWeek) * weightPercentage / 100);

					conflictsString += s + "\n";
				}
			}
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);
		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		return r.setsShareStudents(this.students, s.name);
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (this.startHour >= r.nHoursPerDay)
			return true;
		if (this.endHour > r.nHoursPerDay)
			return true;
		if (this.maxDaysPerWeek > r.nDaysPerWeek)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (this.startHour < r.nHoursPerDay && this.endHour <= r.nHoursPerDay)
			return true;

		return false;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		Debug.Assert(this.startHour < r.nHoursPerDay && this.endHour <= r.nHoursPerDay);

		if (this.maxDaysPerWeek > r.nDaysPerWeek)
			this.maxDaysPerWeek = r.nDaysPerWeek;

		return true;
	}
}

public abstract class ConstraintStudentsIntervalMaxDaysPerWeek: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintStudentsIntervalMaxDaysPerWeek) public: int maxDaysPerWeek;
	/**
	The number of maximum allowed working days per week
	*/

	private int startHour;

	private int endHour; //might be = to gt.rules.nHoursPerDay



	///////////////////////////////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintStudentsIntervalMaxDaysPerWeek() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_INTERVAL_MAX_DAYS_PER_WEEK;
	}

	private ConstraintStudentsIntervalMaxDaysPerWeek(double wp, int maxnd, int sh, int eh) : base(wp)
	{
		this.maxDaysPerWeek = maxnd;
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_INTERVAL_MAX_DAYS_PER_WEEK;
		this.startHour = sh;
		this.endHour = eh;
		Debug.Assert(sh < eh);
		Debug.Assert(sh >= 0);
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		if (this.startHour >= this.endHour)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint teacher interval max days per week is wrong because start hour >= end hour." + " Please correct it. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}
		if (this.startHour < 0)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint teacher interval max days per week is wrong because start hour < first hour or the day." + " Please correct it. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}
		if (this.endHour > r.nHoursPerDay)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint teacher interval max days per week is wrong because end hour > number of hours per day." + " Please correct it. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintStudentsIntervalMaxDaysPerWeek>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Interval_Start_Hour>" + GlobalMembersTimetable_defs.protect(r.hoursOfTheDay[this.startHour]) + "</Interval_Start_Hour>\n";
		if (this.endHour < r.nHoursPerDay)
		{
			s += "	<Interval_End_Hour>" + GlobalMembersTimetable_defs.protect(r.hoursOfTheDay[this.endHour]) + "</Interval_End_Hour>\n";
		}
		else
		{
			s += "	<Interval_End_Hour></Interval_End_Hour>\n";
			s += "	<!-- Interval_End_Hour void means the end of the day (which has no name) -->\n";
		}
		s += "	<Max_Days_Per_Week>" + CustomFETString.number(this.maxDaysPerWeek) + "</Max_Days_Per_Week>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintStudentsIntervalMaxDaysPerWeek>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = tr("Students interval max days per week");
		s += ", ";
		s += tr("WP:%1%", "Abbreviation for weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("ISH:%1", "Abbreviation for interval start hour").arg(r.hoursOfTheDay[this.startHour]);
		s += ", ";
		if (this.endHour < r.nHoursPerDay)
			s += tr("IEH:%1", "Abbreviation for interval end hour").arg(r.hoursOfTheDay[this.endHour]);
		else
			s += tr("IEH:%1", "Abbreviation for interval end hour").arg(tr("End of the day"));
		s += ", ";
		s += tr("MD:%1", "Abbreviation for max days").arg(this.maxDaysPerWeek);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("All students respect working in an hourly interval a maximum number of days per week");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Interval start hour=%1").arg(r.hoursOfTheDay[this.startHour]);
		s += "\n";

		if (this.endHour < r.nHoursPerDay)
			s += tr("Interval end hour=%1").arg(r.hoursOfTheDay[this.endHour]);
		else
			s += tr("Interval end hour=%1").arg(tr("End of the day"));
		s += "\n";

		s += tr("Maximum days per week=%1").arg(this.maxDaysPerWeek);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString *conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		nbroken = 0;

		for (int sbg = 0; sbg < r.nInternalSubgroups; sbg++)
		{
			bool[] ocDay = new bool[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK];
			for (int d = 0; d < r.nDaysPerWeek; d++)
			{
				ocDay[d] = false;
				for (int h = startHour; h < endHour; h++)
				{
					if (GlobalMembersTimeconstraint.subgroupsMatrix[sbg][d][h] > 0)
					{
						ocDay[d] = true;
					}
				}
			}
			int nOcDays = 0;
			for (int d = 0; d < r.nDaysPerWeek; d++)
				if (ocDay[d])
					nOcDays++;
			if (nOcDays > this.maxDaysPerWeek)
			{
				nbroken += nOcDays - this.maxDaysPerWeek;

				if ((nOcDays - this.maxDaysPerWeek) > 0)
				{
					QString s = tr("Time constraint students interval max days per week broken for subgroup: %1, allowed %2 days, required %3 days.").arg(r.internalSubgroupsList[sbg].name).arg(this.maxDaysPerWeek).arg(nOcDays);
					s += " ";
					s += tr("This increases the conflicts total by %1").arg(CustomFETString.number((nOcDays - this.maxDaysPerWeek) * weightPercentage / 100));

					dl.append(s);
					cl.append((nOcDays - this.maxDaysPerWeek) * weightPercentage / 100);

					conflictsString += s + "\n";
				}
			}
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);
		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);
		return true;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (this.startHour >= r.nHoursPerDay)
			return true;
		if (this.endHour > r.nHoursPerDay)
			return true;
		if (this.maxDaysPerWeek > r.nDaysPerWeek)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (this.startHour < r.nHoursPerDay && this.endHour <= r.nHoursPerDay)
			return true;

		return false;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		Debug.Assert(this.startHour < r.nHoursPerDay && this.endHour <= r.nHoursPerDay);

		if (this.maxDaysPerWeek > r.nDaysPerWeek)
			this.maxDaysPerWeek = r.nDaysPerWeek;

		return true;
	}
}

public abstract class ConstraintActivitiesEndStudentsDay: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintActivitiesEndStudentsDay) public: QString teacherName;
	/**
	The teacher. If void, all teachers.
	*/

	/**
	The students. If void, all students.
	*/
	private QString studentsName = new QString();

	/**
	The subject. If void, all subjects.
	*/
	private QString subjectName = new QString();

	/**
	The activity tag. If void, all activity tags.
	*/
	private QString activityTagName = new QString();


	//internal data

	/**
	The number of activities which are represented by the subject, teacher and students requirements.
	*/
	private int nActivities;

	/**
	The indices of the activities in the rules (from 0 to rules.nActivities-1)
	These are indices in the internal list -> Rules::internalActivitiesList
	*/
	//int activitiesIndices[MAX_ACTIVITIES];
	private QList<int> activitiesIndices = new QList<int>();


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintActivitiesEndStudentsDay() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_END_STUDENTS_DAY;
	}

	private ConstraintActivitiesEndStudentsDay(double wp, QString te, QString st, QString su, QString sut) : base(wp)
	{
		this.teacherName = te;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->subjectName=su;
		this.subjectName.CopyFrom(su);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->activityTagName=sut;
		this.activityTagName.CopyFrom(sut);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->studentsName=st;
		this.studentsName.CopyFrom(st);
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_END_STUDENTS_DAY;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		this.nActivities = 0;
		this.activitiesIndices.clear();

		int it;
		Activity act;
		int i;
		for (i = 0; i < r.nInternalActivities; i++)
		{
			act = r.internalActivitiesList[i];

			//check if this activity has the corresponding teacher
			if (this.teacherName != "")
			{
				it = act.teachersNames.indexOf(this.teacherName);
				if (it == -1)
					continue;
			}
			//check if this activity has the corresponding students
			if (this.studentsName != "")
			{
				bool commonStudents = false;
				foreach (QString st, act.studentsNames) if (r.setsShareStudents(st, studentsName))
				{
						commonStudents = true;
						break;
				}

				if (!commonStudents)
					continue;
			}
			//check if this activity has the corresponding subject
			if (this.subjectName != "" && act.subjectName != this.subjectName)
			{
					continue;
			}
			//check if this activity has the corresponding activity tag
			if (this.activityTagName != "" && !act.activityTagsNames.contains(this.activityTagName))
			{
					continue;
			}

			Debug.Assert(this.nActivities < GlobalMembersTimetable_defs.MAX_ACTIVITIES);
			this.nActivities++;
			this.activitiesIndices.append(i);
		}

		Debug.Assert(this.activitiesIndices.count() == this.nActivities);

		if (this.nActivities > 0)
			return true;
		else
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (refers to no activities). Please correct it:\n%1").arg(this.getDetailedDescription(ref r)));
			return false;
		}
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintActivitiesEndStudentsDay>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Teacher_Name>" + GlobalMembersTimetable_defs.protect(this.teacherName) + "</Teacher_Name>\n";
		s += "	<Students_Name>" + GlobalMembersTimetable_defs.protect(this.studentsName) + "</Students_Name>\n";
		s += "	<Subject_Name>" + GlobalMembersTimetable_defs.protect(this.subjectName) + "</Subject_Name>\n";
		s += "	<Activity_Tag_Name>" + GlobalMembersTimetable_defs.protect(this.activityTagName) + "</Activity_Tag_Name>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintActivitiesEndStudentsDay>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString tc = new QString();
		QString st = new QString();
		QString su = new QString();
		QString at = new QString();

		if (this.teacherName != "")
			tc = tr("teacher=%1").arg(this.teacherName);
		else
			tc = tr("all teachers");

		if (this.studentsName != "")
			st = tr("students=%1").arg(this.studentsName);
		else
			st = tr("all students");

		if (this.subjectName != "")
			su = tr("subject=%1").arg(this.subjectName);
		else
			su = tr("all subjects");

		if (this.activityTagName != "")
			at += tr("activity tag=%1").arg(this.activityTagName);
		else
			at += tr("all activity tags");

		QString s = new QString();
		s += tr("Activities with %1, %2, %3, %4, must end students' day", "%1...%4 are conditions for the activities").arg(tc).arg(st).arg(su).arg(at);

		s += ", ";

		s += tr("WP:%1%", "Abbreviation for Weight Percentage").arg(CustomFETString.number(this.weightPercentage));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("Activities with:");
		s += "\n";

		if (this.teacherName != "")
			s += tr("Teacher=%1").arg(this.teacherName);
		else
			s += tr("All teachers");
		s += "\n";

		if (this.studentsName != "")
			s += tr("Students=%1").arg(this.studentsName);
		else
			s += tr("All students");
		s += "\n";

		if (this.subjectName != "")
			s += tr("Subject=%1").arg(this.subjectName);
		else
			s += tr("All subjects");
		s += "\n";

		if (this.activityTagName != "")
			s += tr("Activity tag=%1").arg(this.activityTagName);
		else
			s += tr("All activity tags");
		s += "\n";

		s += tr("must end students' day");
		s += "\n";

		s += tr("Weight (percentage)=%1").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken = 0;

		Debug.Assert(r.internalStructureComputed);

		for (int kk = 0; kk < this.nActivities; kk++)
		{
			int tmp = 0;
			int ai = this.activitiesIndices[kk];

			if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
				int d = c.times[ai] % r.nDaysPerWeek; //the day when this activity was scheduled
				int h = c.times[ai] / r.nDaysPerWeek; //the hour

				for (int j = 0; j < r.internalActivitiesList[ai].iSubgroupsList.count(); j++)
				{
					int sb = r.internalActivitiesList[ai].iSubgroupsList.at(j);
					for (int hh = h + r.internalActivitiesList[ai].duration; hh < r.nHoursPerDay; hh++)
						if (GlobalMembersTimeconstraint.subgroupsMatrix[sb][d][hh] > 0)
						{
							nbroken++;
							tmp = 1;
							break;
						}
					if (tmp > 0)
						break;
				}

				if (conflictsString != null && tmp > 0)
				{
					QString s = tr("Time constraint activities end students' day broken for activity with id=%1 (%2), increases conflicts total by %3", "%1 is the id, %2 is the detailed description of the activity").arg(r.internalActivitiesList[ai].id).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, r.internalActivitiesList[ai].id)).arg(CustomFETString.number(weightPercentage / 100 * tmp));

					dl.append(s);
					cl.append(weightPercentage / 100 * tmp);

					conflictsString += s + "\n";
				}
			}
		}

		if (weightPercentage == 100)
			Debug.Assert(nbroken == 0);
		return nbroken * weightPercentage / 100;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		int it;

		//check if this activity has the corresponding teacher
		if (this.teacherName != "")
		{
			it = a.teachersNames.indexOf(this.teacherName);
			if (it == -1)
				return false;
		}
		//check if this activity has the corresponding students
		if (this.studentsName != "")
		{
			bool commonStudents = false;
			foreach (QString st, a.studentsNames)
			{
				if (r.setsShareStudents(st, this.studentsName))
				{
					commonStudents = true;
					break;
				}
			}
			if (!commonStudents)
				return false;
		}
		//check if this activity has the corresponding subject
		if (this.subjectName != "" && a.subjectName != this.subjectName)
			return false;
		//check if this activity has the corresponding activity tag
		if (this.activityTagName != "" && !a.activityTagsNames.contains(this.activityTagName))
			return false;

		return true;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0);

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0); //should check hasWrongDayOrHour, firstly

		return true;
	}
}

public abstract class ConstraintTeachersActivityTagMaxHoursDaily: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTeachersActivityTagMaxHoursDaily) public: int maxHoursDaily;
	/**
	The maximum hours daily
	*/

	private QString activityTagName = new QString();

	private int activityTagIndex;

	private QList<int> canonicalTeachersList = new QList<int>();


	///////////////////////////////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintTeachersActivityTagMaxHoursDaily() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHERS_ACTIVITY_TAG_MAX_HOURS_DAILY;
	}

	private ConstraintTeachersActivityTagMaxHoursDaily(double wp, int maxhours, QString activityTag) : base(wp)
	{
		Debug.Assert(maxhours > 0);
		this.maxHoursDaily = maxhours;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->activityTagName=activityTag;
		this.activityTagName.CopyFrom(activityTag);

		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHERS_ACTIVITY_TAG_MAX_HOURS_DAILY;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintTeachersActivityTagMaxHoursDaily>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Activity_Tag_Name>" + GlobalMembersTimetable_defs.protect(this.activityTagName) + "</Activity_Tag_Name>\n";
		s += "	<Maximum_Hours_Daily>" + CustomFETString.number(this.maxHoursDaily) + "</Maximum_Hours_Daily>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTeachersActivityTagMaxHoursDaily>\n";
		return s;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);

		this.activityTagIndex = r.searchActivityTag(this.activityTagName);
		Debug.Assert(this.activityTagIndex >= 0);

		this.canonicalTeachersList.clear();
		for (int i = 0; i < r.nInternalTeachers; i++)
		{
			bool found = false;

			Teacher tch = r.internalTeachersList[i];
			foreach (int actIndex, tch.activitiesForTeacher)
			{
				if (r.internalActivitiesList[actIndex].iActivityTagsSet.contains(this.activityTagIndex))
				{
					found = true;
					break;
				}
			}

			if (found)
				this.canonicalTeachersList.append(i);
		}

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += "! ";
		s += tr("Teachers for activity tag %1 have max %2 hours daily").arg(this.activityTagName).arg(this.maxHoursDaily);
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("(not perfect)", "It refers to a not perfect constraint");
		s += "\n";
		s += tr("All teachers, for an activity tag, must respect the maximum number of hours daily");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Activity tag=%1").arg(this.activityTagName);
		s += "\n";
		s += tr("Maximum hours daily=%1").arg(this.maxHoursDaily);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		nbroken = 0;
		foreach (int i, this.canonicalTeachersList)
		{
			Teacher tch = r.internalTeachersList[i];
			int[,] crtTeacherTimetableActivityTag = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK, GlobalMembersTimetable_defs.MAX_HOURS_PER_DAY];
			for (int d = 0; d < r.nDaysPerWeek; d++)
				for (int h = 0; h < r.nHoursPerDay; h++)
					crtTeacherTimetableActivityTag[d, h] = -1;

			foreach (int ai, tch.activitiesForTeacher)if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
				int d = c.times[ai] % r.nDaysPerWeek;
				int h = c.times[ai] / r.nDaysPerWeek;
				for (int dur = 0; dur < r.internalActivitiesList[ai].duration; dur++)
				{
					Debug.Assert(h + dur < r.nHoursPerDay);
					Debug.Assert(crtTeacherTimetableActivityTag[d, h + dur] == -1);
					if (r.internalActivitiesList[ai].iActivityTagsSet.contains(this.activityTagIndex))
						crtTeacherTimetableActivityTag[d, h + dur] = this.activityTagIndex;
				}
			}

			for (int d = 0; d < r.nDaysPerWeek; d++)
			{
				int nd = 0;
				for (int h = 0; h < r.nHoursPerDay; h++)
					if (crtTeacherTimetableActivityTag[d, h] == this.activityTagIndex)
						nd++;

				if (nd > this.maxHoursDaily)
				{
					nbroken++;

					if (conflictsString != null)
					{
						QString s = (tr("Time constraint teachers activity tag %1 max %2 hours daily broken for teacher %3, on day %4, length=%5.").arg(this.activityTagName).arg(CustomFETString.number(this.maxHoursDaily)).arg(r.internalTeachersList[i].name).arg(r.daysOfTheWeek[d]).arg(nd)) + " " + (tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100.0)));

						dl.append(s);
						cl.append(weightPercentage / 100.0);

						conflictsString += s + "\n";
					}
				}
			}
		}

		if (weightPercentage == 100.0)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100.0 * nbroken;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return true;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		return s.name == this.activityTagName;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxHoursDaily > r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxHoursDaily > r.nHoursPerDay)
			maxHoursDaily = r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintTeacherActivityTagMaxHoursDaily: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTeacherActivityTagMaxHoursDaily) public: int maxHoursDaily;
	/**
	The maximum hours daily
	*/

	private QString teacherName = new QString();

	private QString activityTagName = new QString();

	private int teacher_ID;

	private int activityTagIndex;

	private QList<int> canonicalTeachersList = new QList<int>();


	///////////////////////////////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintTeacherActivityTagMaxHoursDaily() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_ACTIVITY_TAG_MAX_HOURS_DAILY;
	}

	private ConstraintTeacherActivityTagMaxHoursDaily(double wp, int maxhours, QString teacher, QString activityTag) : base(wp)
	{
		Debug.Assert(maxhours > 0);
		this.maxHoursDaily = maxhours;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->teacherName=teacher;
		this.teacherName.CopyFrom(teacher);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->activityTagName=activityTag;
		this.activityTagName.CopyFrom(activityTag);

		this.type = GlobalMembersTimeconstraint.CONSTRAINT_TEACHER_ACTIVITY_TAG_MAX_HOURS_DAILY;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintTeacherActivityTagMaxHoursDaily>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Teacher_Name>" + GlobalMembersTimetable_defs.protect(this.teacherName) + "</Teacher_Name>\n";
		s += "	<Activity_Tag_Name>" + GlobalMembersTimetable_defs.protect(this.activityTagName) + "</Activity_Tag_Name>\n";
		s += "	<Maximum_Hours_Daily>" + CustomFETString.number(this.maxHoursDaily) + "</Maximum_Hours_Daily>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTeacherActivityTagMaxHoursDaily>\n";
		return s;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);

		this.teacher_ID = r.searchTeacher(this.teacherName);
		Debug.Assert(this.teacher_ID >= 0);

		this.activityTagIndex = r.searchActivityTag(this.activityTagName);
		Debug.Assert(this.activityTagIndex >= 0);

		this.canonicalTeachersList.clear();
		int i = this.teacher_ID;
		bool found = false;

		Teacher tch = r.internalTeachersList[i];
		foreach (int actIndex, tch.activitiesForTeacher)
		{
			if (r.internalActivitiesList[actIndex].iActivityTagsSet.contains(this.activityTagIndex))
			{
				found = true;
				break;
			}
		}

		if (found)
			this.canonicalTeachersList.append(i);

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += "! ";
		s += tr("Teacher %1 for activity tag %2 has max %3 hours daily").arg(this.teacherName).arg(this.activityTagName).arg(this.maxHoursDaily);
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("(not perfect)", "It refers to a not perfect constraint");
		s += "\n";
		s += tr("A teacher for an activity tag must respect the maximum number of hours daily");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Teacher=%1").arg(this.teacherName);
		s += "\n";
		s += tr("Activity tag=%1").arg(this.activityTagName);
		s += "\n";
		s += tr("Maximum hours daily=%1").arg(this.maxHoursDaily);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		nbroken = 0;
		foreach (int i, this.canonicalTeachersList)
		{
			Teacher tch = r.internalTeachersList[i];
			int[,] crtTeacherTimetableActivityTag = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK, GlobalMembersTimetable_defs.MAX_HOURS_PER_DAY];
			for (int d = 0; d < r.nDaysPerWeek; d++)
				for (int h = 0; h < r.nHoursPerDay; h++)
					crtTeacherTimetableActivityTag[d, h] = -1;

			foreach (int ai, tch.activitiesForTeacher)if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
				int d = c.times[ai] % r.nDaysPerWeek;
				int h = c.times[ai] / r.nDaysPerWeek;
				for (int dur = 0; dur < r.internalActivitiesList[ai].duration; dur++)
				{
					Debug.Assert(h + dur < r.nHoursPerDay);
					Debug.Assert(crtTeacherTimetableActivityTag[d, h + dur] == -1);
					if (r.internalActivitiesList[ai].iActivityTagsSet.contains(this.activityTagIndex))
						crtTeacherTimetableActivityTag[d, h + dur] = this.activityTagIndex;
				}
			}

			for (int d = 0; d < r.nDaysPerWeek; d++)
			{
				int nd = 0;
				for (int h = 0; h < r.nHoursPerDay; h++)
					if (crtTeacherTimetableActivityTag[d, h] == this.activityTagIndex)
						nd++;

				if (nd > this.maxHoursDaily)
				{
					nbroken++;

					if (conflictsString != null)
					{
						QString s = (tr("Time constraint teacher activity tag %1 max %2 hours daily broken for teacher %3, on day %4, length=%5.").arg(this.activityTagName).arg(CustomFETString.number(this.maxHoursDaily)).arg(r.internalTeachersList[i].name).arg(r.daysOfTheWeek[d]).arg(nd)) + " " + (tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100.0)));

						dl.append(s);
						cl.append(weightPercentage / 100.0);

						conflictsString += s + "\n";
					}
				}
			}
		}

		if (weightPercentage == 100.0)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100.0 * nbroken;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		if (this.teacherName == t.name)
			return true;
		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		return this.activityTagName == s.name;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxHoursDaily > r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxHoursDaily > r.nHoursPerDay)
			maxHoursDaily = r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintStudentsActivityTagMaxHoursDaily: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintStudentsActivityTagMaxHoursDaily) public: int maxHoursDaily;

	private QString activityTagName = new QString();

	private int activityTagIndex;

	private QList<int> canonicalSubgroupsList = new QList<int>();


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintStudentsActivityTagMaxHoursDaily() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_ACTIVITY_TAG_MAX_HOURS_DAILY;
		this.maxHoursDaily = -1;
	}

	private ConstraintStudentsActivityTagMaxHoursDaily(double wp, int maxnh, QString activityTag) : base(wp)
	{
		this.maxHoursDaily = maxnh;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->activityTagName=activityTag;
		this.activityTagName.CopyFrom(activityTag);
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_ACTIVITY_TAG_MAX_HOURS_DAILY;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);

		this.activityTagIndex = r.searchActivityTag(this.activityTagName);
		Debug.Assert(this.activityTagIndex >= 0);

		this.canonicalSubgroupsList.clear();
		for (int i = 0; i < r.nInternalSubgroups; i++)
		{
			bool found = false;

			StudentsSubgroup sbg = r.internalSubgroupsList[i];
			foreach (int actIndex, sbg.activitiesForSubgroup)
			{
				if (r.internalActivitiesList[actIndex].iActivityTagsSet.contains(this.activityTagIndex))
				{
					found = true;
					break;
				}
			}

			if (found)
				this.canonicalSubgroupsList.append(i);
		}

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintStudentsActivityTagMaxHoursDaily>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";

		s += "	<Activity_Tag>" + GlobalMembersTimetable_defs.protect(this.activityTagName) + "</Activity_Tag>\n";

		if (this.maxHoursDaily >= 0)
			s += "	<Maximum_Hours_Daily>" + CustomFETString.number(this.maxHoursDaily) + "</Maximum_Hours_Daily>\n";
		else
			Debug.Assert(0);
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintStudentsActivityTagMaxHoursDaily>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += "! ";
		s += tr("Students for activity tag %1 have max %2 hours daily").arg(this.activityTagName).arg(this.maxHoursDaily);
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("(not perfect)", "It refers to a not perfect constraint");
		s += "\n";
		s += tr("All students, for an activity tag, must respect the maximum number of hours daily");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Activity tag=%1").arg(this.activityTagName);
		s += "\n";
		s += tr("Maximum hours daily=%1").arg(this.maxHoursDaily);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		nbroken = 0;

		foreach (int i, this.canonicalSubgroupsList)
		{
			StudentsSubgroup sbg = r.internalSubgroupsList[i];
			int[,] crtSubgroupTimetableActivityTag = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK, GlobalMembersTimetable_defs.MAX_HOURS_PER_DAY];
			for (int d = 0; d < r.nDaysPerWeek; d++)
				for (int h = 0; h < r.nHoursPerDay; h++)
					crtSubgroupTimetableActivityTag[d, h] = -1;
			foreach (int ai, sbg.activitiesForSubgroup)if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
				int d = c.times[ai] % r.nDaysPerWeek;
				int h = c.times[ai] / r.nDaysPerWeek;
				for (int dur = 0; dur < r.internalActivitiesList[ai].duration; dur++)
				{
					Debug.Assert(h + dur < r.nHoursPerDay);
					Debug.Assert(crtSubgroupTimetableActivityTag[d, h + dur] == -1);
					if (r.internalActivitiesList[ai].iActivityTagsSet.contains(this.activityTagIndex))
						crtSubgroupTimetableActivityTag[d, h + dur] = this.activityTagIndex;
				}
			}

			for (int d = 0; d < r.nDaysPerWeek; d++)
			{
				int nd = 0;
				for (int h = 0; h < r.nHoursPerDay; h++)
					if (crtSubgroupTimetableActivityTag[d, h] == this.activityTagIndex)
						nd++;

				if (nd > this.maxHoursDaily)
				{
					nbroken++;

					if (conflictsString != null)
					{
						QString s = (tr("Time constraint students, activity tag %1, max %2 hours daily, broken for subgroup %3, on day %4, length=%5.").arg(this.activityTagName).arg(CustomFETString.number(this.maxHoursDaily)).arg(r.internalSubgroupsList[i].name).arg(r.daysOfTheWeek[d]).arg(nd)) + " " + (tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100.0)));

						dl.append(s);
						cl.append(weightPercentage / 100);

						conflictsString += s + "\n";
					}
				}
			}
		}

		if (weightPercentage == 100.0)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100.0 * nbroken;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		return s.name == this.activityTagName;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return true;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxHoursDaily > r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxHoursDaily > r.nHoursPerDay)
			maxHoursDaily = r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintStudentsSetActivityTagMaxHoursDaily: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintStudentsSetActivityTagMaxHoursDaily) public: int maxHoursDaily;

	/**
	The students set name
	*/
	private QString students = new QString();

	private QString activityTagName = new QString();

	//internal variables

	private int activityTagIndex;

	/**
	The number of subgroups
	*/
	//int nSubgroups;

	/**
	The subgroups
	*/
	//int subgroups[MAX_SUBGROUPS_PER_CONSTRAINT];
	private QList<int> iSubgroupsList = new QList<int>();

	private QList<int> canonicalSubgroupsList = new QList<int>();


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintStudentsSetActivityTagMaxHoursDaily() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_ACTIVITY_TAG_MAX_HOURS_DAILY;
		this.maxHoursDaily = -1;
	}

	private ConstraintStudentsSetActivityTagMaxHoursDaily(double wp, int maxnh, QString s, QString activityTag) : base(wp)
	{
		this.maxHoursDaily = maxnh;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->students = s;
		this.students.CopyFrom(s);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->activityTagName=activityTag;
		this.activityTagName.CopyFrom(activityTag);
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_ACTIVITY_TAG_MAX_HOURS_DAILY;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		this.activityTagIndex = r.searchActivityTag(this.activityTagName);
		Debug.Assert(this.activityTagIndex >= 0);

		StudentsSet ss = r.searchAugmentedStudentsSet(this.students);

		if (ss == null)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint students set max hours daily is wrong because it refers to inexistent students set." + " Please correct it (removing it might be a solution). Please report potential bug. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}

		Debug.Assert(ss);

		this.iSubgroupsList.clear();
		if (ss.type == GlobalMembersStudentsset.STUDENTS_SUBGROUP)
		{
			int tmp;
			tmp = ((StudentsSubgroup)ss).indexInInternalSubgroupsList;
			Debug.Assert(tmp >= 0);
			Debug.Assert(tmp < r.nInternalSubgroups);
			if (!this.iSubgroupsList.contains(tmp))
				this.iSubgroupsList.append(tmp);
		}
		else if (ss.type == GlobalMembersStudentsset.STUDENTS_GROUP)
		{
			StudentsGroup stg = (StudentsGroup)ss;
			for (int i = 0; i < stg.subgroupsList.size(); i++)
			{
				StudentsSubgroup sts = stg.subgroupsList[i];
				int tmp;
				tmp = sts.indexInInternalSubgroupsList;
				Debug.Assert(tmp >= 0);
				Debug.Assert(tmp < r.nInternalSubgroups);
				if (!this.iSubgroupsList.contains(tmp))
					this.iSubgroupsList.append(tmp);
			}
		}
		else if (ss.type == GlobalMembersStudentsset.STUDENTS_YEAR)
		{
			StudentsYear sty = (StudentsYear)ss;
			for (int i = 0; i < sty.groupsList.size(); i++)
			{
				StudentsGroup stg = sty.groupsList[i];
				for (int j = 0; j < stg.subgroupsList.size(); j++)
				{
					StudentsSubgroup sts = stg.subgroupsList[j];
					int tmp;
					tmp = sts.indexInInternalSubgroupsList;
					Debug.Assert(tmp >= 0);
					Debug.Assert(tmp < r.nInternalSubgroups);
					if (!this.iSubgroupsList.contains(tmp))
						this.iSubgroupsList.append(tmp);
				}
			}
		}
		else
			Debug.Assert(0);

		/////////////
		this.canonicalSubgroupsList.clear();
		foreach (int i, this.iSubgroupsList)
		{
			bool found = false;

			StudentsSubgroup sbg = r.internalSubgroupsList[i];
			foreach (int actIndex, sbg.activitiesForSubgroup)
			{
				if (r.internalActivitiesList[actIndex].iActivityTagsSet.contains(this.activityTagIndex))
				{
					found = true;
					break;
				}
			}

			if (found)
				this.canonicalSubgroupsList.append(i);
		}


		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintStudentsSetActivityTagMaxHoursDaily>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Maximum_Hours_Daily>" + CustomFETString.number(this.maxHoursDaily) + "</Maximum_Hours_Daily>\n";
		s += "	<Students>" + GlobalMembersTimetable_defs.protect(this.students) + "</Students>\n";
		s += "	<Activity_Tag>" + GlobalMembersTimetable_defs.protect(this.activityTagName) + "</Activity_Tag>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintStudentsSetActivityTagMaxHoursDaily>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += "! ";
		s += tr("Students set %1 for activity tag %2 has max %3 hours daily").arg(this.students).arg(this.activityTagName).arg(this.maxHoursDaily);
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("(not perfect)", "It refers to a not perfect constraint");
		s += "\n";
		s += tr("A students set, for an activity tag, must respect the maximum number of hours daily");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Students set=%1").arg(this.students);
		s += "\n";
		s += tr("Activity tag=%1").arg(this.activityTagName);
		s += "\n";
		s += tr("Maximum hours daily=%1").arg(this.maxHoursDaily);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		nbroken = 0;

		foreach (int i, this.canonicalSubgroupsList)
		{
			StudentsSubgroup sbg = r.internalSubgroupsList[i];
			int[,] crtSubgroupTimetableActivityTag = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK, GlobalMembersTimetable_defs.MAX_HOURS_PER_DAY];
			for (int d = 0; d < r.nDaysPerWeek; d++)
				for (int h = 0; h < r.nHoursPerDay; h++)
					crtSubgroupTimetableActivityTag[d, h] = -1;
			foreach (int ai, sbg.activitiesForSubgroup)if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
				int d = c.times[ai] % r.nDaysPerWeek;
				int h = c.times[ai] / r.nDaysPerWeek;
				for (int dur = 0; dur < r.internalActivitiesList[ai].duration; dur++)
				{
					Debug.Assert(h + dur < r.nHoursPerDay);
					Debug.Assert(crtSubgroupTimetableActivityTag[d, h + dur] == -1);
					if (r.internalActivitiesList[ai].iActivityTagsSet.contains(this.activityTagIndex))
						crtSubgroupTimetableActivityTag[d, h + dur] = this.activityTagIndex;
				}
			}

			for (int d = 0; d < r.nDaysPerWeek; d++)
			{
				int nd = 0;
				for (int h = 0; h < r.nHoursPerDay; h++)
					if (crtSubgroupTimetableActivityTag[d, h] == this.activityTagIndex)
						nd++;

				if (nd > this.maxHoursDaily)
				{
					nbroken++;

					if (conflictsString != null)
					{
						QString s = (tr("Time constraint students set, activity tag %1, max %2 hours daily, broken for subgroup %3, on day %4, length=%5.").arg(this.activityTagName).arg(CustomFETString.number(this.maxHoursDaily)).arg(r.internalSubgroupsList[i].name).arg(r.daysOfTheWeek[d]).arg(nd)) + " " + (tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100.0)));

						dl.append(s);
						cl.append(weightPercentage / 100);

						conflictsString += s + "\n";
					}
				}
			}
		}

		if (weightPercentage == 100.0)
			Debug.Assert(nbroken == 0);
		return weightPercentage / 100.0 * nbroken;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		return r.setsShareStudents(this.students, s.name);
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxHoursDaily > r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxHoursDaily > r.nHoursPerDay)
			maxHoursDaily = r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintStudentsMaxGapsPerDay: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintStudentsMaxGapsPerDay) public: int maxGaps;


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintStudentsMaxGapsPerDay() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_MAX_GAPS_PER_DAY;
	}

	private ConstraintStudentsMaxGapsPerDay(double wp, int mg) : base(wp)
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_MAX_GAPS_PER_DAY;
		this.maxGaps = mg;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);
		Q_UNUSED(r);

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintStudentsMaxGapsPerDay>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Max_Gaps>" + CustomFETString.number(this.maxGaps) + "</Max_Gaps>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintStudentsMaxGapsPerDay>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += "! ";
		s += tr("Students max gaps per day");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("MG:%1", "Max gaps (per day)").arg(this.maxGaps);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("(not perfect)", "It refers to a not perfect constraint");
		s += "\n";
		s += tr("All students must respect the maximum number of gaps per day");
		s += "\n";
		s += tr("(breaks and students set not available not counted)");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Maximum gaps per day=%1").arg(this.maxGaps);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//returns a number equal to the number of gaps of the subgroups (in hours)

		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nGaps;
		int tmp;
		int i;

		int tIllegalGaps = 0;

		for (i = 0; i < r.nInternalSubgroups; i++)
		{
			for (int j = 0; j < r.nDaysPerWeek; j++)
			{
				nGaps = 0;

				int k;
				tmp = 0;
				for (k = 0; k < r.nHoursPerDay; k++)
					if (GlobalMembersTimeconstraint.subgroupsMatrix[i][j][k] > 0)
					{
						Debug.Assert(!GlobalMembersGenerate_pre.breakDayHour[j][k] && !GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[i][j][k]);
						break;
					}
				for (; k < r.nHoursPerDay; k++)
					if (!GlobalMembersGenerate_pre.breakDayHour[j][k] && !GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[i][j][k])
					{
					if (GlobalMembersTimeconstraint.subgroupsMatrix[i][j][k] > 0)
					{
						nGaps += tmp;
						tmp = 0;
					}
					else
						tmp++;
					}

				int illegalGaps = nGaps - this.maxGaps;
				if (illegalGaps < 0)
					illegalGaps = 0;

				if (illegalGaps > 0 && conflictsString != null)
				{
					QString s = tr("Time constraint students max gaps per day broken for subgroup: %1, it has %2 extra gaps, on day %3, conflicts increase=%4").arg(r.internalSubgroupsList[i].name).arg(illegalGaps).arg(r.daysOfTheWeek[j]).arg(CustomFETString.number(illegalGaps * weightPercentage / 100));

					dl.append(s);
					cl.append(illegalGaps * weightPercentage / 100);

					conflictsString += s + "\n";
				}

				tIllegalGaps += illegalGaps;
			}
		}

		if (c.nPlacedActivities == r.nInternalActivities)
			if (weightPercentage == 100) //for partial solutions it might be broken
				Debug.Assert(tIllegalGaps == 0);
		return weightPercentage / 100 * tIllegalGaps;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return true;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxGaps > r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxGaps > r.nHoursPerDay)
			maxGaps = r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintStudentsSetMaxGapsPerDay: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintStudentsSetMaxGapsPerDay) public: int maxGaps;

	/**
	The name of the students set for this constraint
	*/
	private QString students = new QString();

	//internal redundant data

	/**
	The number of subgroups
	*/
	//int nSubgroups;

	/**
	The subgroups
	*/
	private QList<int> iSubgroupsList = new QList<int>();


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintStudentsSetMaxGapsPerDay() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_GAPS_PER_DAY;
	}

	private ConstraintStudentsSetMaxGapsPerDay(double wp, int mg, QString st) : base(wp)
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_STUDENTS_SET_MAX_GAPS_PER_DAY;
		this.maxGaps = mg;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->students = st;
		this.students.CopyFrom(st);
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		StudentsSet ss = r.searchAugmentedStudentsSet(this.students);

		if (ss == null)
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint students set max gaps per day is wrong because it refers to inexistent students set." + " Please correct it (removing it might be a solution). Please report potential bug. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}

		Debug.Assert(ss);

		this.iSubgroupsList.clear();
		if (ss.type == GlobalMembersStudentsset.STUDENTS_SUBGROUP)
		{
			int tmp;
			tmp = ((StudentsSubgroup)ss).indexInInternalSubgroupsList;
			Debug.Assert(tmp >= 0);
			Debug.Assert(tmp < r.nInternalSubgroups);
			if (!this.iSubgroupsList.contains(tmp))
				this.iSubgroupsList.append(tmp);
		}
		else if (ss.type == GlobalMembersStudentsset.STUDENTS_GROUP)
		{
			StudentsGroup stg = (StudentsGroup)ss;
			for (int i = 0; i < stg.subgroupsList.size(); i++)
			{
				StudentsSubgroup sts = stg.subgroupsList[i];
				int tmp;
				tmp = sts.indexInInternalSubgroupsList;
				Debug.Assert(tmp >= 0);
				Debug.Assert(tmp < r.nInternalSubgroups);
				if (!this.iSubgroupsList.contains(tmp))
					this.iSubgroupsList.append(tmp);
			}
		}
		else if (ss.type == GlobalMembersStudentsset.STUDENTS_YEAR)
		{
			StudentsYear sty = (StudentsYear)ss;
			for (int i = 0; i < sty.groupsList.size(); i++)
			{
				StudentsGroup stg = sty.groupsList[i];
				for (int j = 0; j < stg.subgroupsList.size(); j++)
				{
					StudentsSubgroup sts = stg.subgroupsList[j];
					int tmp;
					tmp = sts.indexInInternalSubgroupsList;
					Debug.Assert(tmp >= 0);
					Debug.Assert(tmp < r.nInternalSubgroups);
					if (!this.iSubgroupsList.contains(tmp))
						this.iSubgroupsList.append(tmp);
				}
			}
		}
		else
			Debug.Assert(0);

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintStudentsSetMaxGapsPerDay>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Max_Gaps>" + CustomFETString.number(this.maxGaps) + "</Max_Gaps>\n";
		s += "	<Students>";
		s += GlobalMembersTimetable_defs.protect(this.students);
		s += "</Students>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintStudentsSetMaxGapsPerDay>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = new QString();
		s += "! ";
		s += tr("Students set max gaps per day");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("MG:%1", "Max gaps (per day)").arg(this.maxGaps);
		s += ", ";
		s += tr("St:%1", "Students").arg(this.students);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("(not perfect)", "It refers to a not perfect constraint");
		s += "\n";
		s += tr("A students set must respect the maximum number of gaps per day");
		s += "\n";
		s += tr("(breaks and students set not available not counted)");
		s += "\n";
		s += tr("Weight (percentage)=%1").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Maximum gaps per day=%1").arg(this.maxGaps);
		s += "\n";
		s += tr("Students=%1").arg(this.students);
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//OLD COMMENT
		//returns a number equal to the number of gaps of the subgroups (in hours)

		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nGaps;
		int tmp;

		int tIllegalGaps = 0;

		for (int sg = 0; sg < this.iSubgroupsList.count(); sg++)
		{
			int i = this.iSubgroupsList.at(sg);
			for (int j = 0; j < r.nDaysPerWeek; j++)
			{
				nGaps = 0;

				int k;
				tmp = 0;
				for (k = 0; k < r.nHoursPerDay; k++)
					if (GlobalMembersTimeconstraint.subgroupsMatrix[i][j][k] > 0)
					{
						Debug.Assert(!GlobalMembersGenerate_pre.breakDayHour[j][k] && !GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[i][j][k]);
						break;
					}
				for (; k < r.nHoursPerDay; k++)
					if (!GlobalMembersGenerate_pre.breakDayHour[j][k] && !GlobalMembersGenerate_pre.subgroupNotAvailableDayHour[i][j][k])
					{
					if (GlobalMembersTimeconstraint.subgroupsMatrix[i][j][k] > 0)
					{
						nGaps += tmp;
						tmp = 0;
					}
					else
						tmp++;
					}

				int illegalGaps = nGaps - this.maxGaps;
				if (illegalGaps < 0)
					illegalGaps = 0;

				if (illegalGaps > 0 && conflictsString != null)
				{
					QString s = tr("Time constraint students set max gaps per day broken for subgroup: %1, extra gaps=%2, on day %3, conflicts increase=%4").arg(r.internalSubgroupsList[i].name).arg(illegalGaps).arg(r.daysOfTheWeek[j]).arg(CustomFETString.number(weightPercentage / 100 * illegalGaps));

					dl.append(s);
					cl.append(weightPercentage / 100 * illegalGaps);

					conflictsString += s + "\n";
				}

				tIllegalGaps += illegalGaps;
			}
		}

		if (c.nPlacedActivities == r.nInternalActivities)
			if (weightPercentage == 100) //for partial solutions it might be broken
				Debug.Assert(tIllegalGaps == 0);
		return weightPercentage / 100 * tIllegalGaps;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);
		Q_UNUSED(a);

		return false;
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		return r.setsShareStudents(this.students, s.name);
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxGaps > r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxGaps > r.nHoursPerDay)
			maxGaps = r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintActivitiesOccupyMaxTimeSlotsFromSelection: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintActivitiesOccupyMaxTimeSlotsFromSelection) public: QList<int> activitiesIds;

	private QList<int> selectedDays = new QList<int>();
	private QList<int> selectedHours = new QList<int>();

	private int maxOccupiedTimeSlots;

	//internal variables
	private QList<int> _activitiesIndices = new QList<int>();


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintActivitiesOccupyMaxTimeSlotsFromSelection() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_OCCUPY_MAX_TIME_SLOTS_FROM_SELECTION;
	}

	private ConstraintActivitiesOccupyMaxTimeSlotsFromSelection(double wp, QList<int> a_L, QList<int> d_L, QList<int> h_L, int max_slots) : base(wp)
	{
		Debug.Assert(d_L.count() == h_L.count());

		this.activitiesIds = a_L;
		this.selectedDays = d_L;
		this.selectedHours = h_L;
		this.maxOccupiedTimeSlots = max_slots;

		this.type = GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_OCCUPY_MAX_TIME_SLOTS_FROM_SELECTION;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		this._activitiesIndices.clear();

		QSet<int> req = this.activitiesIds.toSet();
		Debug.Assert(req.count() == this.activitiesIds.count());

		//this cares about inactive activities, also, so do not assert this->_actIndices.count()==this->actIds.count()
		int i;
		for (i = 0; i < r.nInternalActivities; i++)
			if (req.contains(r.internalActivitiesList[i].id))
				this._activitiesIndices.append(i);

		//////////////////////
		Debug.Assert(this.selectedDays.count() == this.selectedHours.count());

		for (int k = 0; k < this.selectedDays.count(); k++)
		{
			if (this.selectedDays.at(k) >= r.nDaysPerWeek)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint activities occupy max time slots from selection is wrong because it refers to removed day. Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
			if (this.selectedHours.at(k) == r.nHoursPerDay)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint activities occupy max time slots from selection is wrong because a preferred hour is too late (after the last acceptable slot). Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
			if (this.selectedHours.at(k) > r.nHoursPerDay)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint activities occupy max time slots from selection is wrong because it refers to removed hour. Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
			if (this.selectedDays.at(k) < 0 || this.selectedHours.at(k) < 0)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint activities occupy max time slots from selection is wrong because hour or day is not specified for a slot (-1). Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
		}
		///////////////////////

		if (this._activitiesIndices.count() > 0)
			return true;
		else
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (refers to no activities). Please correct it:\n%1").arg(this.getDetailedDescription(ref r)));
			return false;
		}
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		//returns true if all activities are inactive

		foreach (int aid, this.activitiesIds) if (!r.inactiveActivities.contains(aid)) return false;

		return true;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Debug.Assert(this.selectedDays.count() == this.selectedHours.count());

		QString s = "<ConstraintActivitiesOccupyMaxTimeSlotsFromSelection>\n";

		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";

		s += "	<Number_of_Activities>" + CustomFETString.number(this.activitiesIds.count()) + "</Number_of_Activities>\n";
		foreach (int aid, this.activitiesIds) s += "	<Activity_Id>" + CustomFETString.number(aid) + "</Activity_Id>\n";

		s += "	<Number_of_Selected_Time_Slots>" + CustomFETString.number(this.selectedDays.count()) + "</Number_of_Selected_Time_Slots>\n";
		for (int i = 0; i < this.selectedDays.count(); i++)
		{
			s += "	<Selected_Time_Slot>\n";
			s += "		<Selected_Day>" + GlobalMembersTimetable_defs.protect(r.daysOfTheWeek[this.selectedDays.at(i)]) + "</Selected_Day>\n";
			s += "		<Selected_Hour>" + GlobalMembersTimetable_defs.protect(r.hoursOfTheDay[this.selectedHours.at(i)]) + "</Selected_Hour>\n";
			s += "	</Selected_Time_Slot>\n";
		}
		s += "	<Max_Number_of_Occupied_Time_Slots>" + CustomFETString.number(this.maxOccupiedTimeSlots) + "</Max_Number_of_Occupied_Time_Slots>\n";

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintActivitiesOccupyMaxTimeSlotsFromSelection>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		Debug.Assert(this.selectedDays.count() == this.selectedHours.count());

		QString actids = new QString("");
		foreach (int aid, this.activitiesIds) actids += CustomFETString.number(aid) + new QString(", ");
		actids.chop(2);

		QString timeslots = new QString("");
		for (int i = 0; i < this.selectedDays.count(); i++)
			timeslots += r.daysOfTheWeek[selectedDays.at(i)] + new QString(" ") + r.hoursOfTheDay[selectedHours.at(i)] + new QString(", ");
		timeslots.chop(2);

		QString s = tr("Activities occupy max time slots from selection, WP:%1, NA:%2, A: %3, STS: %4, MTS:%5", "Constraint description. WP means weight percentage, " + "NA means the number of activities, A means activities list, STS means selected time slots, MTS means max time slots").arg(CustomFETString.number(this.weightPercentage)).arg(CustomFETString.number(this.activitiesIds.count())).arg(actids).arg(timeslots).arg(CustomFETString.number(this.maxOccupiedTimeSlots));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Debug.Assert(this.selectedDays.count() == this.selectedHours.count());

		QString actids = new QString("");
		foreach (int aid, this.activitiesIds) actids += CustomFETString.number(aid) + new QString(", ");
		actids.chop(2);

		QString timeslots = new QString("");
		for (int i = 0; i < this.selectedDays.count(); i++)
			timeslots += r.daysOfTheWeek[selectedDays.at(i)] + new QString(" ") + r.hoursOfTheDay[selectedHours.at(i)] + new QString(", ");
		timeslots.chop(2);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("Activities occupy max time slots from selection");
		s += "\n";
		s += tr("Weight (percentage)=%1").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Number of activities=%1").arg(CustomFETString.number(this.activitiesIds.count()));
		s += "\n";
		foreach (int id, this.activitiesIds)
		{
			s += tr("Activity with id=%1 (%2)", "%1 is the id, %2 is the detailed description of the activity").arg(id).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, id));
			s += "\n";
		}
		s += tr("Selected time slots: %1").arg(timeslots);
		s += "\n";
		s += tr("Maximum number of occupied slots from selection=%1").arg(CustomFETString.number(this.maxOccupiedTimeSlots));
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		Debug.Assert(r.internalStructureComputed);

		///////////////////
		Matrix2D<bool> used = new Matrix2D<bool>();
		used.resize(r.nDaysPerWeek, r.nHoursPerDay);
		for (int d = 0; d < r.nDaysPerWeek; d++)
			for (int h = 0; h < r.nHoursPerDay; h++)
				used[d][h] = false;

		foreach (int ai, this._activitiesIndices)
		{
			if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
				Activity act = r.internalActivitiesList[ai];
				int d = c.times[ai] % r.nDaysPerWeek;
				int h = c.times[ai] / r.nDaysPerWeek;
				for (int dur = 0; dur < act.duration; dur++)
				{
					Debug.Assert(h + dur < r.nHoursPerDay);
					used[d][h + dur] = true;
				}
			}
		}

		int cnt = 0;
		Debug.Assert(this.selectedDays.count() == this.selectedHours.count());
		for (int t = 0; t < this.selectedDays.count(); t++)
		{
			int d = this.selectedDays.at(t);
			int h = this.selectedHours.at(t);

			if (used[d][h])
				cnt++;
		}

		nbroken = 0;

		if (cnt > this.maxOccupiedTimeSlots)
		{
			nbroken = 1;

			if (conflictsString != null)
			{
				QString s = tr("Time constraint %1 broken - this should not happen, as this kind of constraint should " + "have only 100.0% weight. Please report error!").arg(this.getDescription(ref r));

				dl.append(s);
				cl.append(weightPercentage / 100.0);

				conflictsString += s + "\n";
			}
		}

		if (weightPercentage == 100.0)
			Debug.Assert(nbroken == 0);
		return nbroken * weightPercentage / 100.0;
	}

	private void removeUseless(ref Rules r)
	{
		QSet<int> validActs = new QSet<int>();

		foreach (Activity * act, r.activitiesList) validActs.insert(act.id);

		QList<int> newActs = new QList<int>();

		foreach (int aid, activitiesIds) if (validActs.contains(aid)) newActs.append(aid);

		activitiesIds = newActs;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);

		return this.activitiesIds.contains(a.id);
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(selectedDays.count() == selectedHours.count());

		for (int i = 0; i < selectedDays.count(); i++)
			if (selectedDays.at(i)<0 || selectedDays.at(i) >= r.nDaysPerWeek || selectedHours.at(i)<0 || selectedHours.at(i) >= r.nHoursPerDay)
				return true;

		if (maxOccupiedTimeSlots > r.nDaysPerWeek * r.nHoursPerDay)
			return true;

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		Debug.Assert(selectedDays.count() == selectedHours.count());

		QList<int> newDays = new QList<int>();
		QList<int> newHours = new QList<int>();

		for (int i = 0; i < selectedDays.count(); i++)
			if (selectedDays.at(i) >= 0 && selectedDays.at(i)<r.nDaysPerWeek && selectedHours.at(i) >= 0 && selectedHours.at(i) < r.nHoursPerDay)
			{
				newDays.append(selectedDays.at(i));
				newHours.append(selectedHours.at(i));
			}

		selectedDays = newDays;
		selectedHours = newHours;

		if (maxOccupiedTimeSlots > r.nDaysPerWeek * r.nHoursPerDay)
			maxOccupiedTimeSlots = r.nDaysPerWeek * r.nHoursPerDay;

		r.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(r);

		return true;
	}
}

public abstract class ConstraintActivitiesMaxSimultaneousInSelectedTimeSlots: TimeConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintActivitiesMaxSimultaneousInSelectedTimeSlots) public: QList<int> activitiesIds;

	private QList<int> selectedDays = new QList<int>();
	private QList<int> selectedHours = new QList<int>();

	private int maxSimultaneous;

	//internal variables
	private QList<int> _activitiesIndices = new QList<int>();


	////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintActivitiesMaxSimultaneousInSelectedTimeSlots() : base()
	{
		this.type = GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_MAX_SIMULTANEOUS_IN_SELECTED_TIME_SLOTS;
	}

	private ConstraintActivitiesMaxSimultaneousInSelectedTimeSlots(double wp, QList<int> a_L, QList<int> d_L, QList<int> h_L, int max_simultaneous) : base(wp)
	{
		Debug.Assert(d_L.count() == h_L.count());

		this.activitiesIds = a_L;
		this.selectedDays = d_L;
		this.selectedHours = h_L;
		this.maxSimultaneous = max_simultaneous;

		this.type = GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITIES_MAX_SIMULTANEOUS_IN_SELECTED_TIME_SLOTS;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		this._activitiesIndices.clear();

		QSet<int> req = this.activitiesIds.toSet();
		Debug.Assert(req.count() == this.activitiesIds.count());

		//this cares about inactive activities, also, so do not assert this->_actIndices.count()==this->actIds.count()
		int i;
		for (i = 0; i < r.nInternalActivities; i++)
			if (req.contains(r.internalActivitiesList[i].id))
				this._activitiesIndices.append(i);

		//////////////////////
		Debug.Assert(this.selectedDays.count() == this.selectedHours.count());

		for (int k = 0; k < this.selectedDays.count(); k++)
		{
			if (this.selectedDays.at(k) >= r.nDaysPerWeek)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint activities max simultaneous in selected time slots is wrong because it refers to removed day. Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
			if (this.selectedHours.at(k) == r.nHoursPerDay)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint activities max simultaneous in selected time slots is wrong because a preferred hour is too late (after the last acceptable slot). Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
			if (this.selectedHours.at(k) > r.nHoursPerDay)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint activities max simultaneous in selected time slots is wrong because it refers to removed hour. Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
			if (this.selectedDays.at(k) < 0 || this.selectedHours.at(k) < 0)
			{
				TimeConstraintIrreconcilableMessage.information(parent, tr("FET information"), tr("Constraint activities max simultaneous in selected time slots is wrong because hour or day is not specified for a slot (-1). Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
		}
		///////////////////////

		if (this._activitiesIndices.count() > 0)
			return true;
		else
		{
			TimeConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (refers to no activities). Please correct it:\n%1").arg(this.getDetailedDescription(ref r)));
			return false;
		}
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		//returns true if all activities are inactive

		foreach (int aid, this.activitiesIds) if (!r.inactiveActivities.contains(aid)) return false;

		return true;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Debug.Assert(this.selectedDays.count() == this.selectedHours.count());

		QString s = "<ConstraintActivitiesMaxSimultaneousInSelectedTimeSlots>\n";

		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";

		s += "	<Number_of_Activities>" + CustomFETString.number(this.activitiesIds.count()) + "</Number_of_Activities>\n";
		foreach (int aid, this.activitiesIds) s += "	<Activity_Id>" + CustomFETString.number(aid) + "</Activity_Id>\n";

		s += "	<Number_of_Selected_Time_Slots>" + CustomFETString.number(this.selectedDays.count()) + "</Number_of_Selected_Time_Slots>\n";
		for (int i = 0; i < this.selectedDays.count(); i++)
		{
			s += "	<Selected_Time_Slot>\n";
			s += "		<Selected_Day>" + GlobalMembersTimetable_defs.protect(r.daysOfTheWeek[this.selectedDays.at(i)]) + "</Selected_Day>\n";
			s += "		<Selected_Hour>" + GlobalMembersTimetable_defs.protect(r.hoursOfTheDay[this.selectedHours.at(i)]) + "</Selected_Hour>\n";
			s += "	</Selected_Time_Slot>\n";
		}
		s += "	<Max_Number_of_Simultaneous_Activities>" + CustomFETString.number(this.maxSimultaneous) + "</Max_Number_of_Simultaneous_Activities>\n";

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintActivitiesMaxSimultaneousInSelectedTimeSlots>\n";
		return s;
	}

	private QString getDescription(ref Rules r)
	{
		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		Debug.Assert(this.selectedDays.count() == this.selectedHours.count());

		QString actids = new QString("");
		foreach (int aid, this.activitiesIds) actids += CustomFETString.number(aid) + new QString(", ");
		actids.chop(2);

		QString timeslots = new QString("");
		for (int i = 0; i < this.selectedDays.count(); i++)
			timeslots += r.daysOfTheWeek[selectedDays.at(i)] + new QString(" ") + r.hoursOfTheDay[selectedHours.at(i)] + new QString(", ");
		timeslots.chop(2);

		QString s = tr("Activities max simultaneous in selected time slots, WP:%1, NA:%2, A: %3, STS: %4, MS:%5", "Constraint description. WP means weight percentage, " + "NA means the number of activities, A means activities list, STS means selected time slots, MS means max simultaneous (number of activities in each selected time slot)").arg(CustomFETString.number(this.weightPercentage)).arg(CustomFETString.number(this.activitiesIds.count())).arg(actids).arg(timeslots).arg(CustomFETString.number(this.maxSimultaneous));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Debug.Assert(this.selectedDays.count() == this.selectedHours.count());

		QString actids = new QString("");
		foreach (int aid, this.activitiesIds) actids += CustomFETString.number(aid) + new QString(", ");
		actids.chop(2);

		QString timeslots = new QString("");
		for (int i = 0; i < this.selectedDays.count(); i++)
			timeslots += r.daysOfTheWeek[selectedDays.at(i)] + new QString(" ") + r.hoursOfTheDay[selectedHours.at(i)] + new QString(", ");
		timeslots.chop(2);

		QString s = tr("Time constraint");
		s += "\n";
		s += tr("Activities max simultaneous in selected time slots");
		s += "\n";
		s += tr("Weight (percentage)=%1").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Number of activities=%1").arg(CustomFETString.number(this.activitiesIds.count()));
		s += "\n";
		foreach (int id, this.activitiesIds)
		{
			s += tr("Activity with id=%1 (%2)", "%1 is the id, %2 is the detailed description of the activity").arg(id).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, id));
			s += "\n";
		}
		s += tr("Selected time slots: %1").arg(timeslots);
		s += "\n";
		s += tr("Maximum number of simultaneous activities in each selected time slot=%1").arg(CustomFETString.number(this.maxSimultaneous));
		s += "\n";

		if (!active)
		{
			s += tr("Active=%1", "Refers to a constraint").arg(GlobalMembersSpaceconstraint.yesNoTranslated(active));
			s += "\n";
		}
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>&dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices subgroupsMatrix and teachersMatrix are already calculated, do not calculate them again!
		if (!c.teachersMatrixReady || !c.subgroupsMatrixReady)
		{
			c.teachersMatrixReady = true;
			c.subgroupsMatrixReady = true;
			GlobalMembersTimeconstraint.subgroups_conflicts = c.getSubgroupsMatrix(ref r, ref GlobalMembersTimeconstraint.subgroupsMatrix);
			GlobalMembersTimeconstraint.teachers_conflicts = c.getTeachersMatrix(ref r, ref GlobalMembersTimeconstraint.teachersMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken;

		Debug.Assert(r.internalStructureComputed);

	///////////////////

		Matrix2D<int> count = new Matrix2D<int>();
		count.resize(r.nDaysPerWeek, r.nHoursPerDay);
		for (int d = 0; d < r.nDaysPerWeek; d++)
			for (int h = 0; h < r.nHoursPerDay; h++)
				count[d][h] = 0;

		foreach (int ai, this._activitiesIndices)
		{
			if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
				Activity act = r.internalActivitiesList[ai];
				int d = c.times[ai] % r.nDaysPerWeek;
				int h = c.times[ai] / r.nDaysPerWeek;
				for (int dur = 0; dur < act.duration; dur++)
				{
					Debug.Assert(h + dur < r.nHoursPerDay);
					count[d][h + dur]++;
				}
			}
		}

		nbroken = 0;

		Debug.Assert(this.selectedDays.count() == this.selectedHours.count());
		for (int t = 0; t < this.selectedDays.count(); t++)
		{
			int d = this.selectedDays.at(t);
			int h = this.selectedHours.at(t);

			if (count[d][h] > this.maxSimultaneous)
				nbroken++;
		}

		if (nbroken > 0)
		{
			if (conflictsString != null)
			{
				QString s = tr("Time constraint %1 broken - this should not happen, as this kind of constraint should " + "have only 100.0% weight. Please report error!").arg(this.getDescription(ref r));

				dl.append(s);
				cl.append(weightPercentage / 100.0);

				conflictsString += s + "\n";
			}
		}

		if (weightPercentage == 100.0)
			Debug.Assert(nbroken == 0);
		return nbroken * weightPercentage / 100.0;
	}

	private void removeUseless(ref Rules r)
	{
		QSet<int> validActs = new QSet<int>();

		foreach (Activity * act, r.activitiesList) validActs.insert(act.id);

		QList<int> newActs = new QList<int>();

		foreach (int aid, activitiesIds) if (validActs.contains(aid)) newActs.append(aid);

		activitiesIds = newActs;
	}

	private bool isRelatedToActivity(ref Rules r, Activity a)
	{
		Q_UNUSED(r);

		return this.activitiesIds.contains(a.id);
	}

	private bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	private bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	private bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(selectedDays.count() == selectedHours.count());

		for (int i = 0; i < selectedDays.count(); i++)
			if (selectedDays.at(i)<0 || selectedDays.at(i) >= r.nDaysPerWeek || selectedHours.at(i)<0 || selectedHours.at(i) >= r.nHoursPerDay)
				return true;

		//Do not care about maxSimultaneous, which can be as high as MAX_ACTIVITIES

		return false;
	}
	private bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	private bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		Debug.Assert(selectedDays.count() == selectedHours.count());

		QList<int> newDays = new QList<int>();
		QList<int> newHours = new QList<int>();

		for (int i = 0; i < selectedDays.count(); i++)
			if (selectedDays.at(i) >= 0 && selectedDays.at(i)<r.nDaysPerWeek && selectedHours.at(i) >= 0 && selectedHours.at(i) < r.nHoursPerDay)
			{
				newDays.append(selectedDays.at(i));
				newHours.append(selectedHours.at(i));
			}

		selectedDays = newDays;
		selectedHours = newHours;

		//Do not modify maxSimultaneous, which can be as high as MAX_ACTIVITIES

		r.internalStructureComputed = false;
		setRulesModifiedAndOtherThings(r);

		return true;
	}
}

//C++ TO C# CONVERTER WARNING: The declaration of the following method implementation was not found:
//ORIGINAL LINE: TimeConstraint::TimeConstraint()

//C++ TO C# CONVERTER WARNING: The declaration of the following method implementation was not found:
//ORIGINAL LINE: TimeConstraint::~TimeConstraint()

//C++ TO C# CONVERTER WARNING: The declaration of the following method implementation was not found:
//ORIGINAL LINE: TimeConstraint::TimeConstraint(double wp)

/////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////

//C++ TO C# CONVERTER WARNING: The declaration of the following method implementation was not found:
//ORIGINAL LINE: ConstraintBasicCompulsoryTime::ConstraintBasicCompulsoryTime(): TimeConstraint()

///////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////


public partial class TimeConstraint
{
	public TimeConstraint()
	{
		type = CONSTRAINT_GENERIC_TIME;
    
		active = true;
		comments = new QString("");
	}
	public void Dispose()
	{
	}
	public TimeConstraint(double wp)
	{
		type = CONSTRAINT_GENERIC_TIME;
    
		weightPercentage = wp;
		Debug.Assert(wp <= 100 && wp >= 0);
    
		active = true;
		comments = new QString("");
	}
}

public partial class ConstraintBasicCompulsoryTime
{
	public ConstraintBasicCompulsoryTime()
	{
		TimeConstraint = new <type missing>();
		this.type = CONSTRAINT_BASIC_COMPULSORY_TIME;
		this.weightPercentage = 100;
	}
}