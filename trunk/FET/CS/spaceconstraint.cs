using System.Diagnostics;

public static class GlobalMembersSpaceconstraint
{


	public const int CONSTRAINT_GENERIC_SPACE = 1000; //time constraints are beginning from 1

	public const int CONSTRAINT_BASIC_COMPULSORY_SPACE = 1001; //space constraints from 1001
	public const int CONSTRAINT_ROOM_NOT_AVAILABLE_TIMES = 1002;

	public const int CONSTRAINT_ACTIVITY_PREFERRED_ROOM = 1003;
	public const int CONSTRAINT_ACTIVITY_PREFERRED_ROOMS = 1004;

	public const int CONSTRAINT_STUDENTS_SET_HOME_ROOM = 1005;
	public const int CONSTRAINT_STUDENTS_SET_HOME_ROOMS = 1006;

	public const int CONSTRAINT_TEACHER_HOME_ROOM = 1007;
	public const int CONSTRAINT_TEACHER_HOME_ROOMS = 1008;

	public const int CONSTRAINT_SUBJECT_PREFERRED_ROOM = 1009;
	public const int CONSTRAINT_SUBJECT_PREFERRED_ROOMS = 1010;
	public const int CONSTRAINT_SUBJECT_ACTIVITY_TAG_PREFERRED_ROOM = 1011;
	public const int CONSTRAINT_SUBJECT_ACTIVITY_TAG_PREFERRED_ROOMS = 1012;

	public const int CONSTRAINT_STUDENTS_MAX_BUILDING_CHANGES_PER_DAY = 1013;
	public const int CONSTRAINT_STUDENTS_SET_MAX_BUILDING_CHANGES_PER_DAY = 1014;
	public const int CONSTRAINT_STUDENTS_MAX_BUILDING_CHANGES_PER_WEEK = 1015;
	public const int CONSTRAINT_STUDENTS_SET_MAX_BUILDING_CHANGES_PER_WEEK = 1016;
	public const int CONSTRAINT_STUDENTS_MIN_GAPS_BETWEEN_BUILDING_CHANGES = 1017;
	public const int CONSTRAINT_STUDENTS_SET_MIN_GAPS_BETWEEN_BUILDING_CHANGES = 1018;

	public const int CONSTRAINT_TEACHERS_MAX_BUILDING_CHANGES_PER_DAY = 1019;
	public const int CONSTRAINT_TEACHER_MAX_BUILDING_CHANGES_PER_DAY = 1020;
	public const int CONSTRAINT_TEACHERS_MAX_BUILDING_CHANGES_PER_WEEK = 1021;
	public const int CONSTRAINT_TEACHER_MAX_BUILDING_CHANGES_PER_WEEK = 1022;
	public const int CONSTRAINT_TEACHERS_MIN_GAPS_BETWEEN_BUILDING_CHANGES = 1023;
	public const int CONSTRAINT_TEACHER_MIN_GAPS_BETWEEN_BUILDING_CHANGES = 1024;

	public const int CONSTRAINT_ACTIVITY_TAG_PREFERRED_ROOM = 1025;
	public const int CONSTRAINT_ACTIVITY_TAG_PREFERRED_ROOMS = 1026;

	public const int CONSTRAINT_ACTIVITIES_OCCUPY_MAX_DIFFERENT_ROOMS = 1027;






	#if ! FET_COMMAND_LINE
	#else
	#endif
	#if FET_COMMAND_LINE
	#else
	#endif
	#if FET_COMMAND_LINE
	#endif

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
			return QCoreApplication.translate("SpaceConstraint", "no", "no - meaning negation");
		else
			return QCoreApplication.translate("SpaceConstraint", "yes", "yes - meaning affirmative");
	}

	//static qint8 roomsMatrix[MAX_ROOMS][MAX_DAYS_PER_WEEK][MAX_HOURS_PER_DAY];
	internal static Matrix3D<qint8> roomsMatrix = new Matrix3D<qint8>();

	internal static int rooms_conflicts = -1;

	//extern QList<int> activitiesPreferredRoomsPreferredRooms[MAX_ACTIVITIES];

	//static qint8 subgroupsBuildingsTimetable[MAX_TOTAL_SUBGROUPS][MAX_DAYS_PER_WEEK][MAX_HOURS_PER_DAY];
	//static qint8 teachersBuildingsTimetable[MAX_TEACHERS][MAX_DAYS_PER_WEEK][MAX_HOURS_PER_DAY];

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//QString getActivityDetailedDescription(ref Rules r, int id);
}

/*
File spaceconstraint.cpp
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
File spaceconstraint.h
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
//class SpaceConstraint;
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
//class Equipment;
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class Building;
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class Room;
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class Solution;

//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class QWidget;

/**
This class represents a space constraint
*/
public interface SpaceConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(SpaceConstraint) public: double weightPercentage;
	/**
	The weight (percentage) of this constraint
	*/

	private bool active;

	private QString comments = new QString();

	/**
	Specifies the type of this constraint (using the above constants).
	*/
	private int type;

	/**
	Dummy constructor - needed for the static array of constraints.
	Use of this function must be avoided.
	*/
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	SpaceConstraint();

	public virtual void Dispose()

	/**
	Constructor - please note that the maximum allowed weight is 100.0
	The reason: unallocated activities must have very big conflict weight,
	and any other restrictions must have much more lower weight,
	so that the timetable can evolve when starting with uninitialized activities
	*/
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	SpaceConstraint(double wp);

	/**
	The function that calculates the fitness of a solution, according to this
	constraint. We need the rules to compute this fitness factor.
	We need also the allocation of the activities on days and hours.
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
	Computes the internal structure for this constraint
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
	bool isRelatedToActivity(Activity a);

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

	/**
	Returns true if this constraint is related to this room
	*/
	bool isRelatedToRoom(Room r);

	bool hasWrongDayOrHour(ref Rules r);
	bool canRepairWrongDayOrHour(ref Rules r);
	bool repairWrongDayOrHour(ref Rules r);
}

/**
This class comprises all the basic compulsory constraints (constraints
which must be fulfilled for any timetable) - the space allocation part
*/
public abstract partial class ConstraintBasicCompulsorySpace: SpaceConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintBasicCompulsorySpace) public: ConstraintBasicCompulsorySpace();

	private ConstraintBasicCompulsorySpace(double wp) : base(wp)
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_BASIC_COMPULSORY_SPACE;
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

		QString s = "<ConstraintBasicCompulsorySpace>\n";
		Debug.Assert(this.weightPercentage == 100.0);
		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintBasicCompulsorySpace>\n";
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

		QString s = tr("Basic compulsory constraints (space)");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("These are the basic compulsory constraints (referring to rooms allocation) for any timetable");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		s += tr("The basic space constraints try to avoid:");
		s += "\n";
		s += new QString("- ");
		s += tr("rooms assigned to more than one activity simultaneously");
		s += "\n";
		s += new QString("- ");
		s += tr("activities with more students than the capacity of the room");
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
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>& dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{

		Debug.Assert(r.internalStructureComputed);

		int roomsConflicts;

		//This constraint fitness calculation routine is called firstly,
		//so we can compute the rooms conflicts faster this way.
		if (!c.roomsMatrixReady)
		{
			c.roomsMatrixReady = true;
			GlobalMembersSpaceconstraint.rooms_conflicts = roomsConflicts = c.getRoomsMatrix(ref r, ref GlobalMembersSpaceconstraint.roomsMatrix);

			c.changedForMatrixCalculation = false;
		}
		else
		{
			Debug.Assert(GlobalMembersSpaceconstraint.rooms_conflicts >= 0);
			roomsConflicts = GlobalMembersSpaceconstraint.rooms_conflicts;
		}

		int i;

		int unallocated; //unallocated activities
		int nre; //number of room exhaustions
		int nor; //number of overwhelmed rooms

		//part without logging....................................................................
		if (conflictsString == null)
		{
			//Unallocated activities
			unallocated = 0;
			nor = 0;
			for (i = 0; i < r.nInternalActivities; i++)
				if (c.rooms[i] == GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
				{
					//Firstly, we consider a big clash each unallocated activity.
					//Needs to be very a large constant, bigger than any other broken constraint.
					unallocated += 10000; //r.internalActivitiesList[i].duration * r.internalActivitiesList[i].nSubgroups *
					//(an unallocated activity for a year is more important than an unallocated activity for a subgroup)
				}
				else if (c.rooms[i] != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM)
				{
					//The capacity of each room must be respected
					//(the number of students must be less than the capacity)
					int rm = c.rooms[i];
					if (r.internalActivitiesList[i].nTotalStudents > r.internalRoomsList[rm].capacity)
					{
						int tmp;
						//if(r.internalActivitiesList[i].parity==PARITY_WEEKLY)
						//	tmp=2;
						//else
							tmp = 1;

						nor += tmp;
					}
				}

			//Calculates the number of rooms exhaustion (when a room is occupied
			//for more than one activity at the same time)
			/*nre=0;
			for(i=0; i<r.nInternalRooms; i++)
				for(int j=0; j<r.nDaysPerWeek; j++)
					for(int k=0; k<r.nHoursPerDay; k++){
						int tmp=roomsMatrix[i][j][k]-1;
						if(tmp>0){
							if(conflictsString!=NULL){
								QString s=tr("Space constraint basic compulsory: room with name %1 has more than one allocated activity on day %2, hour %3.")
									.arg(r.internalRoomsList[i]->name)
									.arg(r.daysOfTheWeek[j])
									.arg(r.hoursOfTheDay[k]);
								s+=" ";
								s+=tr("This increases the conflicts total by %1").arg(tmp*weightPercentage/100);
			
								dl.append(s);
								cl.append(tmp*weightPercentage/100);
			
								*conflictsString += s+"\n";
							}
							nre+=tmp;
						}
					}
			*/
			nre = roomsConflicts;
		}
		//part with logging....................................................................
		else
		{
			//Unallocated activities
			unallocated = 0;
			nor = 0;
			for (i = 0; i < r.nInternalActivities; i++)
				if (c.rooms[i] == GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
				{
					//Firstly, we consider a big clash each unallocated activity.
					//Needs to be very a large constant, bigger than any other broken constraint.
					unallocated += 10000; //r.internalActivitiesList[i].duration * r.internalActivitiesList[i].nSubgroups *
					//(an unallocated activity for a year is more important than an unallocated activity for a subgroup)
					if (conflictsString != null)
					{
						QString s = tr("Space constraint basic compulsory broken: unallocated activity with id=%1 (%2)", "%2 is the detailed description of the activity").arg(r.internalActivitiesList[i].id).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, r.internalActivitiesList[i].id));
						s += new QString(" - ");
						s += tr("this increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100 * 10000));

						dl.append(s);
						cl.append(weightPercentage / 100 * 10000);

						conflictsString += s + "\n";

						/*(*conflictsString) += tr("Space constraint basic compulsory: unallocated activity with id=%1").arg(r.internalActivitiesList[i].id);
						(*conflictsString) += tr(" - this increases the conflicts total by %1")
							.arg(weight*10000);
						(*conflictsString) += "\n";*/
					}
				}
				else if (c.rooms[i] != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM)
				{
					//The capacity of each room must be respected
					//(the number of students must be less than the capacity)
					int rm = c.rooms[i];
					if (r.internalActivitiesList[i].nTotalStudents > r.internalRoomsList[rm].capacity)
					{
						int tmp;
						//if(r.internalActivitiesList[i].parity==PARITY_WEEKLY)
						//	tmp=2;
						//else
							tmp = 1;

						nor += tmp;

						if (conflictsString != null)
						{
							QString s = new QString();
							s = tr("Space constraint basic compulsory: room %1 has allocated activity with id %2 (%3) and the capacity of the room is overloaded", "%2 is act id, %3 is detailed description of activity").arg(r.internalRoomsList[rm].name).arg(r.internalActivitiesList[i].id).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, r.internalActivitiesList[i].id));
							s += ". ";
							s += tr("This increases conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100));

							dl.append(s);
							cl.append(weightPercentage / 100);

							conflictsString += s + "\n";
						}
					}
				}

			//Calculates the number of rooms exhaustion (when a room is occupied
			//for more than one activity at the same time)
			nre = 0;
			for (i = 0; i < r.nInternalRooms; i++)
				for (int j = 0; j < r.nDaysPerWeek; j++)
					for (int k = 0; k < r.nHoursPerDay; k++)
					{
						int tmp = GlobalMembersSpaceconstraint.roomsMatrix[i][j][k] - 1;
						if (tmp > 0)
						{
							if (conflictsString != null)
							{
								QString s = tr("Space constraint basic compulsory: room with name %1 has more than one allocated activity on day %2, hour %3.").arg(r.internalRoomsList[i].name).arg(r.daysOfTheWeek[j]).arg(r.hoursOfTheDay[k]);
								s += " ";
								s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(tmp * weightPercentage / 100));

								dl.append(s);
								cl.append(tmp * weightPercentage / 100);

								conflictsString += s + "\n";
								/*(*conflictsString)+=tr("Space constraint basic compulsory: room with name %1 has more than one allocated activity on day %2, hour %3.")
									.arg(r.internalRoomsList[i]->name)
									.arg(r.daysOfTheWeek[j])
									.arg(r.hoursOfTheDay[k]);
								(*conflictsString)+=" ";
								(*conflictsString)+=tr("This increases the conflicts total by %1").arg(tmp*weight);
								(*conflictsString)+="\n";*/
							}
							nre += tmp;
						}
					}
		}
		/*if(roomsConflicts!=-1)
			assert(nre==roomsConflicts);*/	 //just a check, works only on logged fitness calculation

		if (this.weightPercentage == 100)
		{
			//assert(unallocated==0);
			Debug.Assert(nre == 0);
			Debug.Assert(nor == 0);
		}

		return weightPercentage / 100 * (unallocated + nre + nor); //fitness factor
	}

	private bool isRelatedToActivity(Activity a)
	{
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

	private bool isRelatedToRoom(Room r)
	{
		Q_UNUSED(r);

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

public abstract class ConstraintRoomNotAvailableTimes: SpaceConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintRoomNotAvailableTimes) public: QList<int> days;
	private QList<int> hours = new QList<int>();

	/**
	The room's name
	*/
	private QString room = new QString();

	/**
	The room's id, or index in the rules
	*/
	private int room_ID;


	/////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintRoomNotAvailableTimes() : base()
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_ROOM_NOT_AVAILABLE_TIMES;
	}

	private ConstraintRoomNotAvailableTimes(double wp, QString rn, QList<int> d, QList<int> h) : base(wp)
	{
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->room=rn;
		this.room.CopyFrom(rn);
		this.days = d;
		this.hours = h;
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_ROOM_NOT_AVAILABLE_TIMES;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		this.room_ID = r.searchRoom(this.room);

		if (this.room_ID < 0)
		{
			SpaceConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint room not available times is wrong because it refers to inexistent room." + " Please correct it (removing it might be a solution). Please report potential bug. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}

		Debug.Assert(days.count() == hours.count());
		for (int k = 0; k < days.count(); k++)
		{
			if (this.days.at(k) >= r.nDaysPerWeek)
			{
				SpaceConstraintIrreconcilableMessage.warning(parent, tr("FET information"), tr("Constraint room not available times is wrong because it refers to removed day. Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
			if (this.hours.at(k) >= r.nHoursPerDay)
			{
				SpaceConstraintIrreconcilableMessage.warning(parent, tr("FET information"), tr("Constraint room not available times is wrong because an hour is too late (after the last acceptable slot). Please correct" + " and try again. Correcting means editing the constraint and updating information. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
		}

		Debug.Assert(this.room_ID >= 0);

		return true;
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);

		return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		QString s = "<ConstraintRoomNotAvailableTimes>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Room>" + GlobalMembersTimetable_defs.protect(this.room) + "</Room>\n";

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
		s += "</ConstraintRoomNotAvailableTimes>\n";
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

		QString s = tr("Room not available");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("R:%1", "Room").arg(this.room);
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
		QString s = tr("Space constraint");
		s += "\n";
		s += tr("Room not available");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Room=%1").arg(this.room);
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
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>& dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrices roomsMatrix is already calculated, do not calculate it again!
		if (!c.roomsMatrixReady)
		{
			c.roomsMatrixReady = true;
			GlobalMembersSpaceconstraint.rooms_conflicts = c.getRoomsMatrix(ref r, ref GlobalMembersSpaceconstraint.roomsMatrix);

			c.changedForMatrixCalculation = false;
		}

		//Calculates the number of hours when the roomr is supposed to be occupied,
		//but it is not available
		//This function consideres all the hours, I mean if there are for example 5 weekly courses
		//scheduled on that hour (which is already a broken compulsory constraint - we only
		//are allowed 1 weekly activity for a certain room at a certain hour) we calculate
		//5 broken constraints for that function.
		//TODO: decide if it is better to consider only 2 or 10 as a return value in this particular case
		//(currently it is 10)
		int rm = this.room_ID;

		int nbroken;

		nbroken = 0;

		Debug.Assert(days.count() == hours.count());
		for (int k = 0; k < days.count(); k++)
		{
			int d = days.at(k);
			int h = hours.at(k);

			if (GlobalMembersSpaceconstraint.roomsMatrix[rm][d][h] > 0)
			{
				nbroken += GlobalMembersSpaceconstraint.roomsMatrix[rm][d][h];

				if (conflictsString != null)
				{
					QString s = tr("Space constraint room not available times broken for room: %1, on day %2, hour %3").arg(r.internalRoomsList[rm].name).arg(r.daysOfTheWeek[d]).arg(r.hoursOfTheDay[h]);
					s += ". ";
					s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(GlobalMembersSpaceconstraint.roomsMatrix[rm][d][h] * weightPercentage / 100));

					dl.append(s);
					cl.append(GlobalMembersSpaceconstraint.roomsMatrix[rm][d][h] * weightPercentage / 100);

					conflictsString += s + "\n";
				}
			}
		}

		if (this.weightPercentage == 100)
			Debug.Assert(nbroken == 0);

		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(Activity a)
	{
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

	private bool isRelatedToRoom(Room r)
	{
		return this.room == r.name;
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
This is a constraint. Its purpose: an activity must take part in
the preferred room.
*/
public abstract class ConstraintActivityPreferredRoom: SpaceConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintActivityPreferredRoom) public: int _activity;
	//The activity referred to by this constraint.
	//This is an index in the rules internal activities list.

	//The index of the room
	private int _room;

	//----------------------------------------------------------

	private int activityId;

	private QString roomName = new QString();

	private bool permanentlyLocked;


	/////////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintActivityPreferredRoom() : base()
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITY_PREFERRED_ROOM;
	}

	private ConstraintActivityPreferredRoom(double wp, int aid, QString room, bool perm) : base(wp)
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITY_PREFERRED_ROOM;
		this.activityId = aid;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->roomName=room;
		this.roomName.CopyFrom(room);
		this.permanentlyLocked = perm;
	}

	/**
	Comparison operator - to be sure we do not introduce duplicates
	*/
	private static bool operator == (ConstraintActivityPreferredRoom ImpliedObject, ref ConstraintActivityPreferredRoom c)
	{
		if (ImpliedObject.roomName != c.roomName)
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
		this._activity = -1;
		int ac;
		for (ac = 0; ac < r.nInternalActivities; ac++)
			if (r.internalActivitiesList[ac].id == this.activityId)
			{
				Debug.Assert(this._activity == -1);
				this._activity = ac;
				break;
			}
		if (ac == r.nInternalActivities)
		{
			SpaceConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}

		this._room = r.searchRoom(this.roomName);

		if (this._room < 0)
		{
			SpaceConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong:\n%1").arg(this.getDetailedDescription(ref r)));
			return false;
		}

		Debug.Assert(this._room >= 0);

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

		QString s = "<ConstraintActivityPreferredRoom>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Activity_Id>" + CustomFETString.number(this.activityId) + "</Activity_Id>\n";
		s += "	<Room>" + GlobalMembersTimetable_defs.protect(this.roomName) + "</Room>\n";

		s += "	<Permanently_Locked>";
		s += GlobalMembersSpaceconstraint.trueFalse(this.permanentlyLocked);
		s += "</Permanently_Locked>\n";

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintActivityPreferredRoom>\n";

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

		QString s = tr("Activity preferred room");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("Id:%1 (%2)", "%1 is activity id, %2 is detailed description of activity").arg(this.activityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activityId));
		s += ", ";

		s += tr("R:%1", "Room").arg(this.roomName);

		s += ", ";
		s += tr("PL:%1", "Abbreviation for permanently locked").arg(GlobalMembersSpaceconstraint.yesNoTranslated(this.permanentlyLocked));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		QString s = tr("Space constraint");
		s += "\n";
		s += tr("Activity preferred room");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		s += tr("Activity id=%1 (%2)", "%1 is activity id, %2 is detailed description of activity").arg(this.activityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activityId));
		s += "\n";

		s += tr("Room=%1").arg(this.roomName);
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

	//int fitness(Solution& c, Rules& r, const int days[/*MAX_ACTIVITIES*/], const int hours[/*MAX_ACTIVITIES*/], QString* conflictsString=NULL);
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>& dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrix roomsMatrix is already calculated, do not calculate it again!
		if (!c.roomsMatrixReady)
		{
			c.roomsMatrixReady = true;
			GlobalMembersSpaceconstraint.rooms_conflicts = c.getRoomsMatrix(ref r, ref GlobalMembersSpaceconstraint.roomsMatrix);

			c.changedForMatrixCalculation = false;
		}

		//Calculates the number of conflicts

		int nbroken;

		bool ok = true;

		nbroken = 0;

		int rm = c.rooms[this._activity];
		if (rm != this._room) //rm!=UNALLOCATED_SPACE &&
		{
			if (rm != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
			{
				ok = false;

				if (conflictsString != null)
				{
					QString s = tr("Space constraint activity preferred room broken for activity with id=%1 (%2), room=%3", "%1 is activity id, %2 is detailed description of activity").arg(this.activityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activityId)).arg(this.roomName);
						s += ". ";
					s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100 * 1));

					dl.append(s);
					cl.append(1 * weightPercentage / 100);

					conflictsString += s + "\n";
				}
				nbroken++;
			}
		}

		if (this.weightPercentage == 100)
			Debug.Assert(ok);

		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(Activity a)
	{
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

	private bool isRelatedToRoom(Room r)
	{
		return r.name == this.roomName;
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
This is a constraint. Its purpose: an activity must take part in
the preferred rooms.
*/
public abstract class ConstraintActivityPreferredRooms: SpaceConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintActivityPreferredRooms) public: int _activity;
	//The activity referred to by this constraint.
	//This is an index in the rules internal activities list.

	//The indexes of the rooms
	private QList<int> _rooms = new QList<int>();

	//----------------------------------------------------------

	private int activityId;

	private QStringList roomsNames = new QStringList();


	/////////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintActivityPreferredRooms() : base()
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITY_PREFERRED_ROOMS;
	}

	private ConstraintActivityPreferredRooms(double wp, int aid, QStringList roomsList) : base(wp)
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITY_PREFERRED_ROOMS;
		this.activityId = aid;
		this.roomsNames = roomsList;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		this._activity = -1;
		int ac;
		for (ac = 0; ac < r.nInternalActivities; ac++)
			if (r.internalActivitiesList[ac].id == this.activityId)
			{
				Debug.Assert(this._activity == -1);
				this._activity = ac;
				break;
			}

		if (ac == r.nInternalActivities)
		{
			SpaceConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}

		this._rooms.clear();
		foreach (QString rm, this.roomsNames)
		{
			int t = r.searchRoom(rm);

			if (t < 0)
			{
				SpaceConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}

			Debug.Assert(t >= 0);
			this._rooms.append(t);
		}

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

		QString s = "<ConstraintActivityPreferredRooms>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Activity_Id>" + CustomFETString.number(this.activityId) + "</Activity_Id>\n";
		s += "	<Number_of_Preferred_Rooms>" + CustomFETString.number(this.roomsNames.count()) + "</Number_of_Preferred_Rooms>\n";
		for (QStringList.Iterator it = this.roomsNames.begin(); it != this.roomsNames.end(); it++)
			s += "	<Preferred_Room>" + GlobalMembersTimetable_defs.protect(*it) + "</Preferred_Room>\n";

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintActivityPreferredRooms>\n";

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

		QString s = tr("Activity preferred rooms");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("Id:%1 (%2)", "%1 is activity id, %2 is detailed description of activity").arg(this.activityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activityId));

		for (QStringList.Iterator it = this.roomsNames.begin(); it != this.roomsNames.end(); it++)
		{
			s += ", ";
			s += tr("R:%1", "Room").arg(*it);
		}

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		QString s = tr("Space constraint");
		s += "\n";
		s += tr("Activity preferred rooms");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		s += tr("Activity id=%1 (%2)", "%1 is activity id, %2 is detailed description of activity").arg(this.activityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activityId));
		s += "\n";

		for (QStringList.Iterator it = this.roomsNames.begin(); it != this.roomsNames.end(); it++)
		{
			s += tr("Room=%1").arg(*it);
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
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>& dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrix roomsMatrix is already calculated, do not calculate it again!
		if (!c.roomsMatrixReady)
		{
			c.roomsMatrixReady = true;
			GlobalMembersSpaceconstraint.rooms_conflicts = c.getRoomsMatrix(ref r, ref GlobalMembersSpaceconstraint.roomsMatrix);

			c.changedForMatrixCalculation = false;
		}

		//Calculates the number of conflicts

		int nbroken;

		bool ok = true;

		nbroken = 0;

		int rm = c.rooms[this._activity];
		if (1 || rm != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
		{
			int i;
			for (i = 0; i < this._rooms.count(); i++)
				if (this._rooms.at(i) == rm)
					break;
			if (i == this._rooms.count())
			{
				if (rm != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
				{
					ok = false;

					if (conflictsString != null)
					{
						QString s = tr("Space constraint activity preferred rooms broken for activity with id=%1 (%2)", "%1 is activity id, %2 is detailed description of activity").arg(this.activityId).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, this.activityId));
						s += ". ";
						s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100 * 1));

						dl.append(s);
						cl.append(weightPercentage / 100 * 1);

						conflictsString += s + "\n";
					}

					nbroken++;
				}
			}
		}

		if (this.weightPercentage == 100)
			Debug.Assert(ok);

		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(Activity a)
	{
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

	private bool isRelatedToRoom(Room r)
	{
		return this.roomsNames.contains(r.name);
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

public abstract class ConstraintStudentsSetHomeRoom: SpaceConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintStudentsSetHomeRoom) public: QList<int> _activities;

	// The index of the room
	private int _room;


	public QString studentsName = new QString();

	public QString roomName = new QString();


	/////////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////////

	public ConstraintStudentsSetHomeRoom() : base()
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_HOME_ROOM;
	}

	public ConstraintStudentsSetHomeRoom(double wp, QString st, QString rm) : base(wp)
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_HOME_ROOM;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->studentsName=st;
		this.studentsName.CopyFrom(st);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->roomName=rm;
		this.roomName.CopyFrom(rm);
	}

	public bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);

		//This procedure computes the internal list of all the activities
		//which correspond to the subject of the constraint.

		QStringList.iterator it = new QStringList.iterator();
		Activity act;

		this._activities.clear();

		for (int ac = 0; ac < r.nInternalActivities; ac++)
		{
			act = r.internalActivitiesList[ac];

			//check if this activity has the corresponding students
			bool commonStudents = false;
			if (act.studentsNames.count() == 1)
				if (act.studentsNames.at(0) == studentsName)
					commonStudents = true;

			if (!commonStudents)
				continue;

			this._activities.append(ac);
		}

		this._room = r.searchRoom(this.roomName);
		Debug.Assert(this._room >= 0);

		return true;
	}

	public bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);

		return false;
	}

	public QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintStudentsSetHomeRoom>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Students>" + GlobalMembersTimetable_defs.protect(this.studentsName) + "</Students>\n";
		s += "	<Room>" + GlobalMembersTimetable_defs.protect(this.roomName) + "</Room>\n";

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintStudentsSetHomeRoom>\n";

		return s;
	}

	public QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = tr("Students set home room");
		s += ", ";

		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";

		s += tr("St:%1", "St means students").arg(this.studentsName);
		s += ", ";

		s += tr("R:%1", "R means Room").arg(this.roomName);

		return begin + s + end;
	}

	public QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Space constraint");
		s += "\n";
		s += tr("Students set home room");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		s += tr("Students=%1").arg(this.studentsName);
		s += "\n";

		s += tr("Room=%1").arg(this.roomName);
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

	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>& dl, QString* conflictsString =null)
	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrix roomsMatrix is already calculated, do not calculate it again!
		if (!c.roomsMatrixReady)
		{
			c.roomsMatrixReady = true;
			GlobalMembersSpaceconstraint.rooms_conflicts = c.getRoomsMatrix(ref r, ref GlobalMembersSpaceconstraint.roomsMatrix);

			c.changedForMatrixCalculation = false;
		}

		//Calculates the number of conflicts.
		//The fastest way seems to iterate over all activities
		//involved in this constraint (share the subject and activity tag of this constraint),
		//find the scheduled room and check to see if this
		//room is accepted or not.

		int nbroken;

		bool ok2 = true;

		nbroken = 0;
		foreach (int ac, this._activities)
		{
			int rm = c.rooms[ac];
			if (rm == GlobalMembersTimetable_defs.UNALLOCATED_SPACE) //counted as unallocated
				continue;

			bool ok = true;
			//if(rm!=this->_room)
			if (rm == GlobalMembersTimetable_defs.UNSPECIFIED_ROOM) //it may be other room, from subject (activity tag) preferred room(s), which is OK
				ok = false;
			else if (rm == this._room)
			{
			} //OK
			else //other room, from subject (activity tag) pref. room(s)
			{
				bool okk = false;
				foreach (PreferredRoomsItem it, GlobalMembersGenerate_pre.activitiesPreferredRoomsList[ac]) if (it.preferredRooms.contains(rm)) okk = true;
				Debug.Assert(okk);
				//assert(activitiesPreferredRoomsPreferredRooms[ac].contains(rm));
			}

			if (!ok)
			{
				if (rm != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
					ok2 = false;

				if (conflictsString != null)
				{
					QString s = tr("Space constraint students set home room broken for activity with id %1 (%2)", "%1 is activity id, %2 is detailed description of activity").arg(r.internalActivitiesList[ac].id).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, r.internalActivitiesList[ac].id));
					s += ". ";
					s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100 * 1));

					dl.append(s);
					cl.append(weightPercentage / 100 * 1);

					conflictsString += s + "\n";
				}

				nbroken++;
			}
		}

		if (this.weightPercentage == 100)
			Debug.Assert(ok2);

		return weightPercentage / 100 * nbroken;
	}

	public bool isRelatedToActivity(Activity a)
	{
		Q_UNUSED(a);

		return false;
	}

	public bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	public bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);

		return s.name == this.studentsName;
	}

	public bool isRelatedToRoom(Room r)
	{
		return r.name == this.roomName;
	}

	public bool hasWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}
	public bool canRepairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0);

		return true;
	}
	public bool repairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0); //should check hasWrongDayOrHour, firstly

		return true;
	}
}

public abstract class ConstraintStudentsSetHomeRooms: SpaceConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintStudentsSetHomeRooms) public: QList<int> _activities;
	//The list of activities referred to by this constraint.
	//This is a list of indices in the rules internal activities list.

	//The indexes of the rooms
	private QList<int> _rooms = new QList<int>();


	public QString studentsName = new QString();

	public QStringList roomsNames = new QStringList();


	/////////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////////

	public ConstraintStudentsSetHomeRooms() : base()
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_HOME_ROOMS;
	}

	public ConstraintStudentsSetHomeRooms(double wp, QString st, QStringList rms) : base(wp)
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_HOME_ROOMS;

//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->studentsName=st;
		this.studentsName.CopyFrom(st);

		this.roomsNames = rms;
	}

	public bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		//This procedure computes the internal list of all the activities
		//which correspond to the constraint.

		this._activities.clear();

		QStringList.iterator it = new QStringList.iterator();
		Activity act;

		for (int ac = 0; ac < r.nInternalActivities; ac++)
		{
			act = r.internalActivitiesList[ac];

			//check if this activity has the corresponding students
			bool commonStudents = false;
			if (act.studentsNames.count() == 1)
				if (act.studentsNames.at(0) == studentsName)
					commonStudents = true;

			if (!commonStudents)
				continue;

			this._activities.append(ac);
		}

		this._rooms.clear();

		foreach (QString rm, this.roomsNames)
		{
			int t = r.searchRoom(rm);
			if (t < 0)
			{
				SpaceConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
			else
			{
				Debug.Assert(t >= 0);
				this._rooms.append(t);
			}
		}

		return true;
	}

	public bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);

		return false;
	}

	public QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintStudentsSetHomeRooms>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Students>" + GlobalMembersTimetable_defs.protect(this.studentsName) + "</Students>\n";
		s += "	<Number_of_Preferred_Rooms>" + CustomFETString.number(this.roomsNames.count()) + "</Number_of_Preferred_Rooms>\n";
		for (QStringList.Iterator it = this.roomsNames.begin(); it != this.roomsNames.end(); it++)
			s += "	<Preferred_Room>" + GlobalMembersTimetable_defs.protect(*it) + "</Preferred_Room>\n";

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintStudentsSetHomeRooms>\n";

		return s;
	}

	public QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = tr("Students set home rooms");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";

		s += tr("St:%1", "St means students").arg(this.studentsName);

		for (QStringList.Iterator it = this.roomsNames.begin(); it != this.roomsNames.end(); it++)
		{
			s += ", ";
			s += tr("R:%1", "R means Room").arg(*it);
		}

		return begin + s + end;
	}

	public QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Space constraint");
		s += "\n";
		s += tr("Students set home rooms");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		s += tr("Students=%1").arg(this.studentsName);
		s += "\n";

		for (QStringList.Iterator it = this.roomsNames.begin(); it != this.roomsNames.end(); it++)
		{
			s += tr("Room=%1").arg(*it);
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

	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>& dl, QString* conflictsString =null)
	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrix roomsMatrix is already calculated, do not calculate it again!
		if (!c.roomsMatrixReady)
		{
			c.roomsMatrixReady = true;
			GlobalMembersSpaceconstraint.rooms_conflicts = c.getRoomsMatrix(ref r, ref GlobalMembersSpaceconstraint.roomsMatrix);

			c.changedForMatrixCalculation = false;
		}

		//Calculates the number of conflicts.
		//The fastest way seems to iterate over all activities
		//involved in this constraint (share the subject and activity tag of this constraint),
		//find the scheduled room and check to see if this
		//room is accepted or not.

		int nbroken;

		bool ok2 = true;

		nbroken = 0;
		foreach (int ac, this._activities)
		{
			int rm = c.rooms[ac];
			if (rm == GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
				continue;

			bool ok = true;
			int i;
			for (i = 0; i < this._rooms.count(); i++)
				if (this._rooms[i] == rm)
					break;
			if (i == this._rooms.count())
			{
				if (rm == GlobalMembersTimetable_defs.UNSPECIFIED_ROOM)
					ok = false;
				else
				{
					bool okk = false;
					foreach (PreferredRoomsItem it, GlobalMembersGenerate_pre.activitiesPreferredRoomsList[ac]) if (it.preferredRooms.contains(rm)) okk = true;
					Debug.Assert(okk);
					//assert(activitiesPreferredRoomsPreferredRooms[ac].contains(rm));
				}
			}

			if (!ok)
			{
				if (rm != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
					ok2 = false;

				if (conflictsString != null)
				{
					QString s = tr("Space constraint students set home rooms broken for activity with id %1 (%2)", "%1 is activity id, %2 is detailed description of activity").arg(r.internalActivitiesList[ac].id).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, r.internalActivitiesList[ac].id));
					s += ". ";
					s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100 * 1));

					dl.append(s);
					cl.append(weightPercentage / 100 * 1);

					conflictsString += s + "\n";
				}
				nbroken++;
			}
		}

		if (this.weightPercentage == 100)
			Debug.Assert(ok2);

		return weightPercentage / 100 * nbroken;
	}

	public bool isRelatedToActivity(Activity a)
	{
		Q_UNUSED(a);

		return false;
	}

	public bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	public bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s) return false;
	}

	public bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);

		return s.name == this.studentsName;
	}

	public bool isRelatedToRoom(Room r)
	{
		return this.roomsNames.contains(r.name);
	}

	public bool hasWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}
	public bool canRepairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0);

		return true;
	}
	public bool repairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0); //should check hasWrongDayOrHour, firstly

		return true;
	}
}

public abstract class ConstraintTeacherHomeRoom: SpaceConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTeacherHomeRoom) public: QList<int> _activities;

	// The index of the room
	private int _room;


	public QString teacherName = new QString();

	public QString roomName = new QString();


	/////////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////////

	public ConstraintTeacherHomeRoom() : base()
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_TEACHER_HOME_ROOM;
	}

	public ConstraintTeacherHomeRoom(double wp, QString tc, QString rm) : base(wp)
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_TEACHER_HOME_ROOM;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->teacherName=tc;
		this.teacherName.CopyFrom(tc);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->roomName=rm;
		this.roomName.CopyFrom(rm);
	}

	public bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);

		//This procedure computes the internal list of all the activities
		//which correspond to the subject of the constraint.

		QStringList.iterator it = new QStringList.iterator();
		Activity act;

		this._activities.clear();

		for (int ac = 0; ac < r.nInternalActivities; ac++)
		{
			act = r.internalActivitiesList[ac];

			//check if this activity has the corresponding students
			bool sameTeacher = false;
			if (act.teachersNames.count() == 1)
				if (act.teachersNames.at(0) == teacherName)
					sameTeacher = true;

			if (!sameTeacher)
				continue;

			this._activities.append(ac);
		}

		this._room = r.searchRoom(this.roomName);
		Debug.Assert(this._room >= 0);

		return true;
	}

	public bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);

		return false;
	}

	public QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintTeacherHomeRoom>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Teacher>" + GlobalMembersTimetable_defs.protect(this.teacherName) + "</Teacher>\n";
		s += "	<Room>" + GlobalMembersTimetable_defs.protect(this.roomName) + "</Room>\n";

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTeacherHomeRoom>\n";

		return s;
	}

	public QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = tr("Teacher home room");
		s += ", ";

		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";

		s += tr("T:%1", "T means teacher").arg(this.teacherName);
		s += ", ";

		s += tr("R:%1", "R means Room").arg(this.roomName);

		return begin + s + end;
	}

	public QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Space constraint");
		s += "\n";
		s += tr("Teacher home room");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		s += tr("Teacher=%1").arg(this.teacherName);
		s += "\n";

		s += tr("Room=%1").arg(this.roomName);
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

	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>& dl, QString* conflictsString =null)
	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrix roomsMatrix is already calculated, do not calculate it again!
		if (!c.roomsMatrixReady)
		{
			c.roomsMatrixReady = true;
			GlobalMembersSpaceconstraint.rooms_conflicts = c.getRoomsMatrix(ref r, ref GlobalMembersSpaceconstraint.roomsMatrix);

			c.changedForMatrixCalculation = false;
		}

		//Calculates the number of conflicts.
		//The fastest way seems to iterate over all activities
		//involved in this constraint (share the subject and activity tag of this constraint),
		//find the scheduled room and check to see if this
		//room is accepted or not.

		int nbroken;

		bool ok2 = true;

		nbroken = 0;
		foreach (int ac, this._activities)
		{
			int rm = c.rooms[ac];
			if (rm == GlobalMembersTimetable_defs.UNALLOCATED_SPACE) //counted as unallocated
				continue;

			bool ok = true;
			if (rm == GlobalMembersTimetable_defs.UNSPECIFIED_ROOM) //it may be other room, from subject (activity tag) preferred room(s), which is OK
				ok = false;
			else if (rm == this._room)
			{
			} //OK
			else //other room, from subject (activity tag) pref. room(s)
			{
				bool okk = false;
				foreach (PreferredRoomsItem it, GlobalMembersGenerate_pre.activitiesPreferredRoomsList[ac]) if (it.preferredRooms.contains(rm)) okk = true;
				Debug.Assert(okk);
				//assert(activitiesPreferredRoomsPreferredRooms[ac].contains(rm));
			}

			if (!ok)
			{
				if (rm != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
					ok2 = false;

				if (conflictsString != null)
				{
					QString s = tr("Space constraint teacher home room broken for activity with id %1 (%2)", "%1 is activity id, %2 is detailed description of activity").arg(r.internalActivitiesList[ac].id).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, r.internalActivitiesList[ac].id));
					s += ". ";
					s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100 * 1));

					dl.append(s);
					cl.append(weightPercentage / 100 * 1);

					conflictsString += s + "\n";
				}

				nbroken++;
			}
		}

		if (this.weightPercentage == 100)
			Debug.Assert(ok2);

		return weightPercentage / 100 * nbroken;
	}

	public bool isRelatedToActivity(Activity a)
	{
		Q_UNUSED(a);

		return false;
	}

	public bool isRelatedToTeacher(Teacher t)
	{
		return teacherName == t.name;
	}

	public bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToRoom(Room r)
	{
		return r.name == this.roomName;
	}

	public bool hasWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}
	public bool canRepairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0);

		return true;
	}
	public bool repairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0); //should check hasWrongDayOrHour, firstly

		return true;
	}
}

public abstract class ConstraintTeacherHomeRooms: SpaceConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTeacherHomeRooms) public: QList<int> _activities;
	//The list of activities referred to by this constraint.
	//This is a list of indices in the rules internal activities list.

	//The indexes of the rooms
	private QList<int> _rooms = new QList<int>();


	public QString teacherName = new QString();

	public QStringList roomsNames = new QStringList();


	/////////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////////

	public ConstraintTeacherHomeRooms() : base()
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_TEACHER_HOME_ROOMS;
	}

	public ConstraintTeacherHomeRooms(double wp, QString tc, QStringList rms) : base(wp)
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_TEACHER_HOME_ROOMS;

//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->teacherName=tc;
		this.teacherName.CopyFrom(tc);

		this.roomsNames = rms;
	}

	public bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		//This procedure computes the internal list of all the activities
		//which correspond to the constraint.

		this._activities.clear();

		QStringList.iterator it = new QStringList.iterator();
		Activity act;

		for (int ac = 0; ac < r.nInternalActivities; ac++)
		{
			act = r.internalActivitiesList[ac];

			//check if this activity has the corresponding students
			bool sameTeacher = false;
			if (act.teachersNames.count() == 1)
				if (act.teachersNames.at(0) == teacherName)
					sameTeacher = true;

			if (!sameTeacher)
				continue;

			this._activities.append(ac);
		}

		this._rooms.clear();

		foreach (QString rm, this.roomsNames)
		{
			int t = r.searchRoom(rm);
			if (t < 0)
			{
				SpaceConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
			else
			{
				Debug.Assert(t >= 0);
				this._rooms.append(t);
			}
		}

		return true;
	}

	public bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);

		return false;
	}

	public QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintTeacherHomeRooms>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Teacher>" + GlobalMembersTimetable_defs.protect(this.teacherName) + "</Teacher>\n";
		s += "	<Number_of_Preferred_Rooms>" + CustomFETString.number(this.roomsNames.count()) + "</Number_of_Preferred_Rooms>\n";
		for (QStringList.Iterator it = this.roomsNames.begin(); it != this.roomsNames.end(); it++)
			s += "	<Preferred_Room>" + GlobalMembersTimetable_defs.protect(*it) + "</Preferred_Room>\n";

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTeacherHomeRooms>\n";

		return s;
	}

	public QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = tr("Teacher home rooms");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";

		s += tr("T:%1", "T means teacher").arg(this.teacherName);

		for (QStringList.Iterator it = this.roomsNames.begin(); it != this.roomsNames.end(); it++)
		{
			s += ", ";
			s += tr("R:%1", "R means Room").arg(*it);
		}

		return begin + s + end;
	}

	public QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Space constraint");
		s += "\n";
		s += tr("Teacher home rooms");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		s += tr("Teacher=%1").arg(this.teacherName);
		s += "\n";

		for (QStringList.Iterator it = this.roomsNames.begin(); it != this.roomsNames.end(); it++)
		{
			s += tr("Room=%1").arg(*it);
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

	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>& dl, QString* conflictsString =null)
	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrix roomsMatrix is already calculated, do not calculate it again!
		if (!c.roomsMatrixReady)
		{
			c.roomsMatrixReady = true;
			GlobalMembersSpaceconstraint.rooms_conflicts = c.getRoomsMatrix(ref r, ref GlobalMembersSpaceconstraint.roomsMatrix);

			c.changedForMatrixCalculation = false;
		}

		//Calculates the number of conflicts.
		//The fastest way seems to iterate over all activities
		//involved in this constraint (share the subject and activity tag of this constraint),
		//find the scheduled room and check to see if this
		//room is accepted or not.

		int nbroken;

		bool ok2 = true;

		nbroken = 0;
		foreach (int ac, this._activities)
		{
			int rm = c.rooms[ac];
			if (rm == GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
				continue;

			bool ok = true;
			int i;
			for (i = 0; i < this._rooms.count(); i++)
				if (this._rooms[i] == rm)
					break;
			if (i == this._rooms.count())
			{
				if (rm == GlobalMembersTimetable_defs.UNSPECIFIED_ROOM)
					ok = false;
				else
				{
					bool okk = false;
					foreach (PreferredRoomsItem it, GlobalMembersGenerate_pre.activitiesPreferredRoomsList[ac]) if (it.preferredRooms.contains(rm)) okk = true;
					Debug.Assert(okk);
					//	assert(activitiesPreferredRoomsPreferredRooms[ac].contains(rm));
				}
			}

			if (!ok)
			{
				if (rm != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
					ok2 = false;

				if (conflictsString != null)
				{
					QString s = tr("Space constraint teacher home rooms broken for activity with id %1 (%2)", "%1 is activity id, %2 is detailed description of activity").arg(r.internalActivitiesList[ac].id).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, r.internalActivitiesList[ac].id));
					s += ". ";
					s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100 * 1));

					dl.append(s);
					cl.append(weightPercentage / 100 * 1);

					conflictsString += s + "\n";
				}
				nbroken++;
			}
		}

		if (this.weightPercentage == 100)
			Debug.Assert(ok2);

		return weightPercentage / 100 * nbroken;
	}

	public bool isRelatedToActivity(Activity a)
	{
		Q_UNUSED(a);

		return false;
	}

	public bool isRelatedToTeacher(Teacher t)
	{
		return teacherName == t.name;
	}

	public bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s) return false;
	}

	public bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);
		return false;
	}

	public bool isRelatedToRoom(Room r)
	{
		return this.roomsNames.contains(r.name);
	}

	public bool hasWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}
	public bool canRepairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0);

		return true;
	}
	public bool repairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0); //should check hasWrongDayOrHour, firstly

		return true;
	}
}

/**
This is a constraint. Its purpose: a subject must be taught in
a certain room.
*/
public abstract class ConstraintSubjectPreferredRoom: SpaceConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintSubjectPreferredRoom) public: QList<int> _activities;

	// The index of the room
	private int _room;


	public QString subjectName = new QString();

	public QString roomName = new QString();


	//////////////////////////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////////////////////////

	public ConstraintSubjectPreferredRoom() : base()
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_SUBJECT_PREFERRED_ROOM;
	}

	public ConstraintSubjectPreferredRoom(double wp, QString subj, QString rm) : base(wp)
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_SUBJECT_PREFERRED_ROOM;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->subjectName=subj;
		this.subjectName.CopyFrom(subj);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->roomName=rm;
		this.roomName.CopyFrom(rm);
	}

	public bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		//This procedure computes the internal list of all the activities
		//which correspond to the subject of the constraint.

		this._activities.clear();
		for (int ac = 0; ac < r.nInternalActivities; ac++)
			if (r.internalActivitiesList[ac].subjectName == this.subjectName)
			{
				this._activities.append(ac);
			}

		this._room = r.searchRoom(this.roomName);
		if (this._room < 0)
		{
			SpaceConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}
		Debug.Assert(this._room >= 0);

		return true;
	}

	public bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);

		return false;
	}

	public QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintSubjectPreferredRoom>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Subject>" + GlobalMembersTimetable_defs.protect(this.subjectName) + "</Subject>\n";
		s += "	<Room>" + GlobalMembersTimetable_defs.protect(this.roomName) + "</Room>\n";

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintSubjectPreferredRoom>\n";

		return s;
	}

	public QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = tr("Subject preferred room");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("S:%1", "Subject").arg(this.subjectName);
		s += ", ";
		s += tr("R:%1", "Room").arg(this.roomName);

		return begin + s + end;
	}

	public QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Space constraint");
		s += "\n";
		s += tr("Subject preferred room");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Subject=%1").arg(this.subjectName);
		s += "\n";
		s += tr("Room=%1").arg(this.roomName);
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

	//int fitness(Solution& c, Rules& r, const int days[/*MAX_ACTIVITIES*/], const int hours[/*MAX_ACTIVITIES*/], QString* conflictsString=NULL);
	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>& dl, QString* conflictsString =null)
	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrix roomsMatrix is already calculated, do not calculate it again!
		if (!c.roomsMatrixReady)
		{
			c.roomsMatrixReady = true;
			GlobalMembersSpaceconstraint.rooms_conflicts = c.getRoomsMatrix(ref r, ref GlobalMembersSpaceconstraint.roomsMatrix);

			c.changedForMatrixCalculation = false;
		}

		//Calculates the number of conflicts.
		//The fastest way seems to iterate over all activities
		//involved in this constraint (share the subject and activity tag of this constraint),
		//find the scheduled room and check to see if this
		//room is accepted or not.

		int nbroken;

		bool ok2 = true;

		nbroken = 0;
		foreach (int ac, this._activities)
		{
			int rm = c.rooms[ac];
			if (rm == GlobalMembersTimetable_defs.UNALLOCATED_SPACE) //counted as unallocated
				continue;

			bool ok = true;
			if (rm != this._room)
				ok = false;

			if (!ok)
			{
				if (rm != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
					ok2 = false;

				if (conflictsString != null)
				{
					QString s = tr("Space constraint subject preferred room broken for activity with id %1 (%2)", "%1 is activity id, %2 is detailed description of activity").arg(r.internalActivitiesList[ac].id).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, r.internalActivitiesList[ac].id));
					s += ". ";
					s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100 * 1));

					dl.append(s);
					cl.append(weightPercentage / 100 * 1);

					conflictsString += s + "\n";
				}

				nbroken++;
			}
		}

		if (this.weightPercentage == 100)
			Debug.Assert(ok2);

		return weightPercentage / 100 * nbroken;
	}

	public bool isRelatedToActivity(Activity a)
	{
		return a.subjectName == this.subjectName;
	}

	public bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	public bool isRelatedToSubject(Subject s)
	{
		if (this.subjectName == s.name)
			return true;
		return false;
	}

	public bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToRoom(Room r)
	{
		return r.name == this.roomName;
	}

	public bool hasWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}
	public bool canRepairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0);

		return true;
	}
	public bool repairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0); //should check hasWrongDayOrHour, firstly

		return true;
	}
}

/**
This is a constraint. Its purpose: a subject must be taught in
certain rooms.
*/
public abstract class ConstraintSubjectPreferredRooms: SpaceConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintSubjectPreferredRooms) public: QList<int> _activities;

	private QList<int> _rooms = new QList<int>();


	public QString subjectName = new QString();

	public QStringList roomsNames = new QStringList();


	/////////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////////

	public ConstraintSubjectPreferredRooms() : base()
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_SUBJECT_PREFERRED_ROOMS;
	}

	public ConstraintSubjectPreferredRooms(double wp, QString subj, QStringList rms) : base(wp)
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_SUBJECT_PREFERRED_ROOMS;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->subjectName=subj;
		this.subjectName.CopyFrom(subj);
		this.roomsNames = rms;
	}

	public bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		//This procedure computes the internal list of all the activities
		//which correspond to the subject of the constraint.

		this._activities.clear();
		for (int ac = 0; ac < r.nInternalActivities; ac++)
			if (r.internalActivitiesList[ac].subjectName == this.subjectName)
			{
				this._activities.append(ac);
			}

		this._rooms.clear();
		foreach (QString rm, this.roomsNames)
		{
			int t = r.searchRoom(rm);
			if (t < 0)
			{
				SpaceConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
			Debug.Assert(t >= 0);
			this._rooms.append(t);
		}

		return true;
	}

	public bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);

		return false;
	}

	public QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintSubjectPreferredRooms>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Subject>" + GlobalMembersTimetable_defs.protect(this.subjectName) + "</Subject>\n";
		s += "	<Number_of_Preferred_Rooms>" + CustomFETString.number(this.roomsNames.count()) + "</Number_of_Preferred_Rooms>\n";
		for (QStringList.Iterator it = this.roomsNames.begin(); it != this.roomsNames.end(); it++)
			s += "	<Preferred_Room>" + GlobalMembersTimetable_defs.protect(*it) + "</Preferred_Room>\n";

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintSubjectPreferredRooms>\n";

		return s;
	}

	public QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = tr("Subject preferred rooms");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("S:%1", "Subject").arg(this.subjectName);
		for (QStringList.Iterator it = this.roomsNames.begin(); it != this.roomsNames.end(); it++)
		{
			s += ", ";
			s += tr("R:%1", "Room").arg(*it);
		}

		return begin + s + end;
	}

	public QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Space constraint");
		s += "\n";
		s += tr("Subject preferred rooms");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Subject=%1").arg(this.subjectName);
		s += "\n";
		for (QStringList.Iterator it = this.roomsNames.begin(); it != this.roomsNames.end(); it++)
		{
			s += tr("Room=%1").arg(*it);
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

	//int fitness(Solution& c, Rules& r, const int days[/*MAX_ACTIVITIES*/], const int hours[/*MAX_ACTIVITIES*/], QString* conflictsString=NULL);
	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>& dl, QString* conflictsString =null)
	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrix roomsMatrix is already calculated, do not calculate it again!
		if (!c.roomsMatrixReady)
		{
			c.roomsMatrixReady = true;
			GlobalMembersSpaceconstraint.rooms_conflicts = c.getRoomsMatrix(ref r, ref GlobalMembersSpaceconstraint.roomsMatrix);

			c.changedForMatrixCalculation = false;
		}

		//Calculates the number of conflicts.
		//The fastest way seems to iterate over all activities
		//involved in this constraint (share the subject and activity tag of this constraint),
		//find the scheduled room and check to see if this
		//room is accepted or not.

		int nbroken;

		bool ok2 = true;

		nbroken = 0;
		foreach (int ac, this._activities)
		{
			int rm = c.rooms[ac];
			if (rm == GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
				continue;

			bool ok = true;
			int i;
			for (i = 0; i < this._rooms.count(); i++)
				if (this._rooms.at(i) == rm)
					break;
			if (i == this._rooms.count())
				ok = false;

			if (!ok)
			{
				if (rm != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
					ok2 = false;

				if (conflictsString != null)
				{
					QString s = tr("Space constraint subject preferred rooms broken for activity with id %1 (%2)", "%1 is activity id, %2 is detailed description of activity").arg(r.internalActivitiesList[ac].id).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, r.internalActivitiesList[ac].id));
					s += ". ";
					s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100 * 1));

					dl.append(s);
					cl.append(weightPercentage / 100 * 1);

					conflictsString += s + "\n";
				}
				nbroken++;
			}
		}

		if (this.weightPercentage == 100)
			Debug.Assert(ok2);

		return weightPercentage / 100 * nbroken;
	}

	public bool isRelatedToActivity(Activity a)
	{
		return a.subjectName == this.subjectName;
	}

	public bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	public bool isRelatedToSubject(Subject s)
	{
		if (this.subjectName == s.name)
			return true;
		return false;
	}

	public bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToRoom(Room r)
	{
		return this.roomsNames.contains(r.name);
	}

	public bool hasWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}
	public bool canRepairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0);

		return true;
	}
	public bool repairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0); //should check hasWrongDayOrHour, firstly

		return true;
	}
}

/**
This is a constraint. Its purpose: a subject+subject tag must be taught in
a certain room.
*/
public abstract class ConstraintSubjectActivityTagPreferredRoom: SpaceConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintSubjectActivityTagPreferredRoom) public: QList<int> _activities;

	// The index of the room
	private int _room;


	public QString subjectName = new QString();

	public QString activityTagName = new QString();

	public QString roomName = new QString();


	//////////////////////////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////////////////////////

	public ConstraintSubjectActivityTagPreferredRoom() : base()
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_SUBJECT_ACTIVITY_TAG_PREFERRED_ROOM;
	}

	public ConstraintSubjectActivityTagPreferredRoom(double wp, QString subj, QString subjTag, QString rm) : base(wp)
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_SUBJECT_ACTIVITY_TAG_PREFERRED_ROOM;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->subjectName=subj;
		this.subjectName.CopyFrom(subj);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->activityTagName=subjTag;
		this.activityTagName.CopyFrom(subjTag);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->roomName=rm;
		this.roomName.CopyFrom(rm);
	}

	public bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		//This procedure computes the internal list of all the activities
		//which correspond to the subject of the constraint.

		this._activities.clear();
		for (int ac = 0; ac < r.nInternalActivities; ac++)
			if (r.internalActivitiesList[ac].subjectName == this.subjectName && r.internalActivitiesList[ac].activityTagsNames.contains(this.activityTagName))
			{
				 this._activities.append(ac);
			}

		this._room = r.searchRoom(this.roomName);
		if (this._room < 0)
		{
			SpaceConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}
		Debug.Assert(this._room >= 0);

		return true;
	}

	public bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);

		return false;
	}

	public QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintSubjectActivityTagPreferredRoom>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Subject>" + GlobalMembersTimetable_defs.protect(this.subjectName) + "</Subject>\n";
		s += "	<Activity_Tag>" + GlobalMembersTimetable_defs.protect(this.activityTagName) + "</Activity_Tag>\n";
		s += "	<Room>" + GlobalMembersTimetable_defs.protect(this.roomName) + "</Room>\n";

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintSubjectActivityTagPreferredRoom>\n";

		return s;
	}

	public QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = tr("Subject activity tag preferred room");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("S:%1", "Subject").arg(this.subjectName);
		s += ", ";
		s += tr("AT:%1", "Activity tag").arg(this.activityTagName);
		s += ", ";
		s += tr("R:%1", "Room").arg(this.roomName);

		return begin + s + end;
	}

	public QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Space constraint");
		s += "\n";
		s += tr("Subject activity tag preferred room");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Subject=%1").arg(this.subjectName);
		s += "\n";
		s += tr("Activity tag=%1").arg(this.activityTagName);
		s += "\n";
		s += tr("Room=%1").arg(this.roomName);
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

	//int fitness(Solution& c, Rules& r, const int days[/*MAX_ACTIVITIES*/], const int hours[/*MAX_ACTIVITIES*/], QString* conflictsString=NULL);
	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>& dl, QString* conflictsString =null)
	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrix roomsMatrix is already calculated, do not calculate it again!
		if (!c.roomsMatrixReady)
		{
			c.roomsMatrixReady = true;
			GlobalMembersSpaceconstraint.rooms_conflicts = c.getRoomsMatrix(ref r, ref GlobalMembersSpaceconstraint.roomsMatrix);

			c.changedForMatrixCalculation = false;
		}

		//Calculates the number of conflicts.
		//The fastest way seems to iterate over all activities
		//involved in this constraint (share the subject and activity tag of this constraint),
		//find the scheduled room and check to see if this
		//room is accepted or not.

		int nbroken;

		bool ok2 = true;

		nbroken = 0;
		foreach (int ac, this._activities)
		{
			int rm = c.rooms[ac];
			if (rm == GlobalMembersTimetable_defs.UNALLOCATED_SPACE) //counted as unallocated
				continue;

			bool ok = true;
			if (rm != this._room)
				ok = false;

			if (!ok)
			{
				if (rm != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
					ok2 = false;

				if (conflictsString != null)
				{
					QString s = tr("Space constraint subject activity tag preferred room broken for activity with id %1 (%2) (activity tag of constraint=%3)", "%1 is activity id, %2 is detailed description of activity").arg(r.internalActivitiesList[ac].id).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, r.internalActivitiesList[ac].id)).arg(this.activityTagName);
					s += ". ";
					s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100 * 1));

					dl.append(s);
					cl.append(weightPercentage / 100 * 1);

					conflictsString += s + "\n";
				}

				nbroken++;
			}
		}

		if (this.weightPercentage == 100)
			Debug.Assert(ok2);

		return weightPercentage / 100 * nbroken;
	}

	public bool isRelatedToActivity(Activity a)
	{
		return this.subjectName == a.subjectName && a.activityTagsNames.contains(this.activityTagName);
	}

	public bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	public bool isRelatedToSubject(Subject s)
	{
		if (this.subjectName == s.name)
			return true;
		return false;
	}

	public bool isRelatedToActivityTag(ActivityTag s)
	{
		if (this.activityTagName == s.name)
			return true;
		return false;
	}

	public bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToRoom(Room r)
	{
		return r.name == this.roomName;
	}

	public bool hasWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}
	public bool canRepairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0);

		return true;
	}
	public bool repairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0); //should check hasWrongDayOrHour, firstly

		return true;
	}
}

/**
This is a constraint. Its purpose: a subject+subject tag must be taught in
certain rooms.
*/
public abstract class ConstraintSubjectActivityTagPreferredRooms: SpaceConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintSubjectActivityTagPreferredRooms) public: QList<int> _activities;

	private QList<int> _rooms = new QList<int>();


	public QString subjectName = new QString();

	public QString activityTagName = new QString();

	public QStringList roomsNames = new QStringList();


	/////////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////////

	public ConstraintSubjectActivityTagPreferredRooms() : base()
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_SUBJECT_ACTIVITY_TAG_PREFERRED_ROOMS;
	}

	public ConstraintSubjectActivityTagPreferredRooms(double wp, QString subj, QString subjTag, QStringList rms) : base(wp)
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_SUBJECT_ACTIVITY_TAG_PREFERRED_ROOMS;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->subjectName=subj;
		this.subjectName.CopyFrom(subj);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->activityTagName=subjTag;
		this.activityTagName.CopyFrom(subjTag);
		this.roomsNames = rms;
	}

	public bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		//This procedure computes the internal list of all the activities
		//which correspond to the subject of the constraint.

		this._activities.clear();
		for (int ac = 0; ac < r.nInternalActivities; ac++)
			if (r.internalActivitiesList[ac].subjectName == this.subjectName && r.internalActivitiesList[ac].activityTagsNames.contains(this.activityTagName))
			{
				this._activities.append(ac);
			}

		this._rooms.clear();
		foreach (QString rm, roomsNames)
		{
			int t = r.searchRoom(rm);
			if (t < 0)
			{
				SpaceConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
			Debug.Assert(t >= 0);
			this._rooms.append(t);
		}

		return true;
	}

	public bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);

		return false;
	}

	public QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintSubjectActivityTagPreferredRooms>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Subject>" + GlobalMembersTimetable_defs.protect(this.subjectName) + "</Subject>\n";
		s += "	<Activity_Tag>" + GlobalMembersTimetable_defs.protect(this.activityTagName) + "</Activity_Tag>\n";
		s += "	<Number_of_Preferred_Rooms>" + CustomFETString.number(this.roomsNames.count()) + "</Number_of_Preferred_Rooms>\n";
		for (QStringList.Iterator it = this.roomsNames.begin(); it != this.roomsNames.end(); it++)
			s += "	<Preferred_Room>" + GlobalMembersTimetable_defs.protect(*it) + "</Preferred_Room>\n";

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintSubjectActivityTagPreferredRooms>\n";

		return s;
	}

	public QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = tr("Subject activity tag preferred rooms");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("S:%1", "Subject").arg(this.subjectName);
		s += ", ";
		s += tr("AT:%1", "Activity tag").arg(this.activityTagName);
		for (QStringList.Iterator it = this.roomsNames.begin(); it != this.roomsNames.end(); it++)
		{
			s += ", ";
			s += tr("R:%1", "Room").arg(*it);
		}

		return begin + s + end;
	}

	public QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Space constraint");
		s += "\n";
		s += tr("Subject activity tag preferred rooms");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Subject=%1").arg(this.subjectName);
		s += "\n";
		s += tr("Activity tag=%1").arg(this.activityTagName);
		s += "\n";
		for (QStringList.Iterator it = this.roomsNames.begin(); it != this.roomsNames.end(); it++)
		{
			s += tr("Room=%1").arg(*it);
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

	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>& dl, QString* conflictsString =null)
	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrix roomsMatrix is already calculated, do not calculate it again!
		if (!c.roomsMatrixReady)
		{
			c.roomsMatrixReady = true;
			GlobalMembersSpaceconstraint.rooms_conflicts = c.getRoomsMatrix(ref r, ref GlobalMembersSpaceconstraint.roomsMatrix);

			c.changedForMatrixCalculation = false;
		}

		//Calculates the number of conflicts.
		//The fastest way seems to iterate over all activities
		//involved in this constraint (share the subject and activity tag of this constraint),
		//find the scheduled room and check to see if this
		//room is accepted or not.

		int nbroken;

		bool ok2 = true;

		nbroken = 0;
		foreach (int ac, this._activities)
		{
			int rm = c.rooms[ac];
			if (rm == GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
				continue;

			bool ok = true;
			int i;
			for (i = 0; i < this._rooms.count(); i++)
				if (this._rooms.at(i) == rm)
					break;
			if (i == this._rooms.count())
				ok = false;

			if (!ok)
			{
				if (rm != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
					ok2 = false;

				if (conflictsString != null)
				{
					QString s = tr("Space constraint subject activity tag preferred rooms broken for activity with id %1 (%2) (activity tag of constraint=%3)", "%1 is activity id, %2 is detailed description of activity").arg(r.internalActivitiesList[ac].id).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, r.internalActivitiesList[ac].id)).arg(this.activityTagName);
					s += ". ";
					s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100 * 1));

					dl.append(s);
					cl.append(weightPercentage / 100 * 1);

					conflictsString += s + "\n";
				}
				nbroken++;
			}
		}

		if (this.weightPercentage == 100)
			Debug.Assert(ok2);

		return weightPercentage / 100 * nbroken;
	}

	public bool isRelatedToActivity(Activity a)
	{
		return this.subjectName == a.subjectName && a.activityTagsNames.contains(this.activityTagName);
	}

	public bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	public bool isRelatedToSubject(Subject s)
	{
		if (this.subjectName == s.name)
			return true;
		return false;
	}

	public bool isRelatedToActivityTag(ActivityTag s)
	{
		if (this.activityTagName == s.name)
			return true;
		return false;
	}

	public bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToRoom(Room r)
	{
		return this.roomsNames.contains(r.name);
	}

	public bool hasWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}
	public bool canRepairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0);

		return true;
	}
	public bool repairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0); //should check hasWrongDayOrHour, firstly

		return true;
	}
}

//addded on 6 apr 2009
public abstract class ConstraintActivityTagPreferredRoom: SpaceConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintActivityTagPreferredRoom) public: QList<int> _activities;

	// The index of the room
	private int _room;


	public QString activityTagName = new QString();

	public QString roomName = new QString();


	//////////////////////////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////////////////////////

	public ConstraintActivityTagPreferredRoom() : base()
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITY_TAG_PREFERRED_ROOM;
	}

	public ConstraintActivityTagPreferredRoom(double wp, QString subjTag, QString rm) : base(wp)
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITY_TAG_PREFERRED_ROOM;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->activityTagName=subjTag;
		this.activityTagName.CopyFrom(subjTag);
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->roomName=rm;
		this.roomName.CopyFrom(rm);
	}

	public bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		//This procedure computes the internal list of all the activities
		//which correspond to the subject of the constraint.

		this._activities.clear();
		for (int ac = 0; ac < r.nInternalActivities; ac++)
			if (r.internalActivitiesList[ac].activityTagsNames.contains(this.activityTagName))
			{
				 this._activities.append(ac);
			}

		this._room = r.searchRoom(this.roomName);
		if (this._room < 0)
		{
			SpaceConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}
		Debug.Assert(this._room >= 0);

		return true;
	}

	public bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);

		return false;
	}

	public QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintActivityTagPreferredRoom>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Activity_Tag>" + GlobalMembersTimetable_defs.protect(this.activityTagName) + "</Activity_Tag>\n";
		s += "	<Room>" + GlobalMembersTimetable_defs.protect(this.roomName) + "</Room>\n";

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintActivityTagPreferredRoom>\n";

		return s;
	}

	public QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = tr("Activity tag preferred room");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("AT:%1", "Activity tag").arg(this.activityTagName);
		s += ", ";
		s += tr("R:%1", "Room").arg(this.roomName);

		return begin + s + end;
	}

	public QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Space constraint");
		s += "\n";
		s += tr("Activity tag preferred room");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Activity tag=%1").arg(this.activityTagName);
		s += "\n";
		s += tr("Room=%1").arg(this.roomName);
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

	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>& dl, QString* conflictsString =null)
	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrix roomsMatrix is already calculated, do not calculate it again!
		if (!c.roomsMatrixReady)
		{
			c.roomsMatrixReady = true;
			GlobalMembersSpaceconstraint.rooms_conflicts = c.getRoomsMatrix(ref r, ref GlobalMembersSpaceconstraint.roomsMatrix);

			c.changedForMatrixCalculation = false;
		}

		//Calculates the number of conflicts.
		//The fastest way seems to iterate over all activities
		//involved in this constraint (share the subject and activity tag of this constraint),
		//find the scheduled room and check to see if this
		//room is accepted or not.

		int nbroken;

		bool ok2 = true;

		nbroken = 0;
		foreach (int ac, this._activities)
		{
			int rm = c.rooms[ac];
			if (rm == GlobalMembersTimetable_defs.UNALLOCATED_SPACE) //counted as unallocated
				continue;

			bool ok = true;
			if (rm != this._room)
				ok = false;

			if (!ok)
			{
				if (rm != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
					ok2 = false;

				if (conflictsString != null)
				{
					QString s = tr("Space constraint activity tag preferred room broken for activity with id %1 (%2) (activity tag of constraint=%3)", "%1 is activity id, %2 is detailed description of activity").arg(r.internalActivitiesList[ac].id).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, r.internalActivitiesList[ac].id)).arg(this.activityTagName);
					s += ". ";
					s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100 * 1));

					dl.append(s);
					cl.append(weightPercentage / 100 * 1);

					conflictsString += s + "\n";
				}

				nbroken++;
			}
		}

		if (this.weightPercentage == 100)
			Debug.Assert(ok2);

		return weightPercentage / 100 * nbroken;
	}

	public bool isRelatedToActivity(Activity a)
	{
		return a.activityTagsNames.contains(this.activityTagName);
	}

	public bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	public bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToActivityTag(ActivityTag s)
	{
		if (this.activityTagName == s.name)
			return true;
		return false;
	}

	public bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToRoom(Room r)
	{
		return r.name == this.roomName;
	}

	public bool hasWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}
	public bool canRepairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0);

		return true;
	}
	public bool repairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0); //should check hasWrongDayOrHour, firstly

		return true;
	}
}

public abstract class ConstraintActivityTagPreferredRooms: SpaceConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintActivityTagPreferredRooms) public: QList<int> _activities;

	private QList<int> _rooms = new QList<int>();


	public QString activityTagName = new QString();

	public QStringList roomsNames = new QStringList();


	/////////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////////

	public ConstraintActivityTagPreferredRooms() : base()
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITY_TAG_PREFERRED_ROOMS;
	}

	public ConstraintActivityTagPreferredRooms(double wp, QString subjTag, QStringList rms) : base(wp)
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITY_TAG_PREFERRED_ROOMS;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->activityTagName=subjTag;
		this.activityTagName.CopyFrom(subjTag);
		this.roomsNames = rms;
	}

	public bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		//This procedure computes the internal list of all the activities
		//which correspond to the subject of the constraint.

		this._activities.clear();
		for (int ac = 0; ac < r.nInternalActivities; ac++)
			if (r.internalActivitiesList[ac].activityTagsNames.contains(this.activityTagName))
			{
				this._activities.append(ac);
			}

		this._rooms.clear();
		foreach (QString rm, roomsNames)
		{
			int t = r.searchRoom(rm);
			if (t < 0)
			{
				SpaceConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong:\n%1").arg(this.getDetailedDescription(ref r)));

				return false;
			}
			Debug.Assert(t >= 0);
			this._rooms.append(t);
		}

		return true;
	}

	public bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);

		return false;
	}

	public QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintActivityTagPreferredRooms>\n";
		s += "	<Weight_Percentage>" + CustomFETString.number(weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Activity_Tag>" + GlobalMembersTimetable_defs.protect(this.activityTagName) + "</Activity_Tag>\n";
		s += "	<Number_of_Preferred_Rooms>" + CustomFETString.number(this.roomsNames.count()) + "</Number_of_Preferred_Rooms>\n";
		for (QStringList.Iterator it = this.roomsNames.begin(); it != this.roomsNames.end(); it++)
			s += "	<Preferred_Room>" + GlobalMembersTimetable_defs.protect(*it) + "</Preferred_Room>\n";

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintActivityTagPreferredRooms>\n";

		return s;
	}

	public QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = tr("Activity tag preferred rooms");
		s += ", ";
		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";
		s += tr("AT:%1", "Activity tag").arg(this.activityTagName);
		for (QStringList.Iterator it = this.roomsNames.begin(); it != this.roomsNames.end(); it++)
		{
			s += ", ";
			s += tr("R:%1", "Room").arg(*it);
		}

		return begin + s + end;
	}

	public QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Space constraint");
		s += "\n";
		s += tr("Activity tag preferred rooms");
		s += "\n";
		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";
		s += tr("Activity tag=%1").arg(this.activityTagName);
		s += "\n";
		for (QStringList.Iterator it = this.roomsNames.begin(); it != this.roomsNames.end(); it++)
		{
			s += tr("Room=%1").arg(*it);
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

	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>& dl, QString* conflictsString =null)
	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrix roomsMatrix is already calculated, do not calculate it again!
		if (!c.roomsMatrixReady)
		{
			c.roomsMatrixReady = true;
			GlobalMembersSpaceconstraint.rooms_conflicts = c.getRoomsMatrix(ref r, ref GlobalMembersSpaceconstraint.roomsMatrix);

			c.changedForMatrixCalculation = false;
		}

		//Calculates the number of conflicts.
		//The fastest way seems to iterate over all activities
		//involved in this constraint (share the subject and activity tag of this constraint),
		//find the scheduled room and check to see if this
		//room is accepted or not.

		int nbroken;

		bool ok2 = true;

		nbroken = 0;
		foreach (int ac, this._activities)
		{
			int rm = c.rooms[ac];
			if (rm == GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
				continue;

			bool ok = true;
			int i;
			for (i = 0; i < this._rooms.count(); i++)
				if (this._rooms.at(i) == rm)
					break;
			if (i == this._rooms.count())
				ok = false;

			if (!ok)
			{
				if (rm != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
					ok2 = false;

				if (conflictsString != null)
				{
					QString s = tr("Space constraint activity tag preferred rooms broken for activity with id %1 (%2) (activity tag of constraint=%3)", "%1 is activity id, %2 is detailed description of activity").arg(r.internalActivitiesList[ac].id).arg(GlobalMembersTimeconstraint.getActivityDetailedDescription(ref r, r.internalActivitiesList[ac].id)).arg(this.activityTagName);
					s += ". ";
					s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100 * 1));

					dl.append(s);
					cl.append(weightPercentage / 100 * 1);

					conflictsString += s + "\n";
				}
				nbroken++;
			}
		}

		if (this.weightPercentage == 100)
			Debug.Assert(ok2);

		return weightPercentage / 100 * nbroken;
	}

	public bool isRelatedToActivity(Activity a)
	{
		return a.activityTagsNames.contains(this.activityTagName);
	}

	public bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	public bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToActivityTag(ActivityTag s)
	{
		if (this.activityTagName == s.name)
			return true;
		return false;
	}

	public bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToRoom(Room r)
	{
		return this.roomsNames.contains(r.name);
	}

	public bool hasWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		return false;
	}
	public bool canRepairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0);

		return true;
	}
	public bool repairWrongDayOrHour(ref Rules r)
	{
		Q_UNUSED(r);
		Debug.Assert(0); //should check hasWrongDayOrHour, firstly

		return true;
	}
}
///////

public abstract class ConstraintStudentsSetMaxBuildingChangesPerDay: SpaceConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintStudentsSetMaxBuildingChangesPerDay) public: QList<int> iSubgroupsList;
	//internal variables


	public int maxBuildingChangesPerDay;

	public QString studentsName = new QString();


	/////////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////////

	public ConstraintStudentsSetMaxBuildingChangesPerDay() : base()
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_MAX_BUILDING_CHANGES_PER_DAY;
	}

	public ConstraintStudentsSetMaxBuildingChangesPerDay(double wp, QString st, int mc) : base(wp)
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_MAX_BUILDING_CHANGES_PER_DAY;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->studentsName=st;
		this.studentsName.CopyFrom(st);
		this.maxBuildingChangesPerDay = mc;
	}

	public bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		this.iSubgroupsList.clear();

		StudentsSet ss = r.searchAugmentedStudentsSet(this.studentsName);

		if (ss == null)
		{
			SpaceConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint students set max building changes per day is wrong because it refers to inexistent students set." + " Please correct it (removing it might be a solution). Please report potential bug. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}

		if (ss.type == GlobalMembersStudentsset.STUDENTS_SUBGROUP)
		{
			int tmp;
			tmp = ((StudentsSubgroup)ss).indexInInternalSubgroupsList;
			Debug.Assert(tmp >= 0);
			Debug.Assert(tmp < r.nInternalSubgroups);
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
					this.iSubgroupsList.append(tmp);
				}
			}
		}
		else
			Debug.Assert(0);

		return true;
	}

	public QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintStudentsSetMaxBuildingChangesPerDay>\n";

		s += "	<Weight_Percentage>" + CustomFETString.number(weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Students>" + GlobalMembersTimetable_defs.protect(this.studentsName) + "</Students>\n";
		s += "	<Max_Building_Changes_Per_Day>" + CustomFETString.number(this.maxBuildingChangesPerDay) + "</Max_Building_Changes_Per_Day>\n";

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintStudentsSetMaxBuildingChangesPerDay>\n";

		return s;
	}

	public bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);

		return false;
	}

	public QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = tr("Students set max building changes per day");
		s += ", ";

		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";

		s += tr("St:%1", "St means students").arg(this.studentsName);
		s += ", ";

		s += tr("MC:%1", "MC means max changes").arg(this.maxBuildingChangesPerDay);

		return begin + s + end;
	}

	public QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Space constraint");
		s += "\n";

		s += tr("Students set maximum building changes per day");
		s += "\n";

		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		s += tr("Students=%1").arg(this.studentsName);
		s += "\n";

		s += tr("Maximum building changes per day=%1").arg(this.maxBuildingChangesPerDay);
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

	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>& dl, QString* conflictsString =null)
	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrix roomsMatrix is already calculated, do not calculate it again!
		if (!c.roomsMatrixReady)
		{
			c.roomsMatrixReady = true;
			GlobalMembersSpaceconstraint.rooms_conflicts = c.getRoomsMatrix(ref r, ref GlobalMembersSpaceconstraint.roomsMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken = 0;

		foreach (int sbg, this.iSubgroupsList)
		{
			//Better, less memory
			StudentsSubgroup sts = r.internalSubgroupsList[sbg];
			int[,] crtBuildingsTimetable = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK, GlobalMembersTimetable_defs.MAX_HOURS_PER_DAY];
			for (int d2 = 0; d2 < r.nDaysPerWeek; d2++)
				for (int h2 = 0; h2 < r.nHoursPerDay; h2++)
					crtBuildingsTimetable[d2, h2] = -1;

			foreach (int ai, sts.activitiesForSubgroup) if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
					int d2 = c.times[ai] % r.nDaysPerWeek;
					int h2 = c.times[ai] / r.nDaysPerWeek;

					for (int dur = 0; dur < r.internalActivitiesList[ai].duration; dur++)
					{
						Debug.Assert(h2 + dur < r.nHoursPerDay);
						Debug.Assert(crtBuildingsTimetable[d2, h2 + dur] == -1);
						if (c.rooms[ai] != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM && c.rooms[ai] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
						{
							Debug.Assert(c.rooms[ai] >= 0 && c.rooms[ai] < r.nInternalRooms);
							crtBuildingsTimetable[d2, h2 + dur] = r.internalRoomsList[c.rooms[ai]].buildingIndex;
						}
					}
			}
			/////////////

			for (int d2 = 0; d2 < r.nDaysPerWeek; d2++)
			{
				int crt_building = -1;
				int n_changes = 0;
				for (int h2 = 0; h2 < r.nHoursPerDay; h2++)
				{
					if (crtBuildingsTimetable[d2, h2] != -1)
					{
						if (crt_building != crtBuildingsTimetable[d2, h2])
						{
							if (crt_building != -1)
								n_changes++;
							crt_building = crtBuildingsTimetable[d2, h2];
						}
					}
				}

				if (n_changes > this.maxBuildingChangesPerDay)
				{
					nbroken += -this.maxBuildingChangesPerDay + n_changes;

					if (conflictsString != null)
					{
						QString s = tr("Space constraint students set max building changes per day broken for students=%1 on day %2").arg(this.studentsName).arg(r.daysOfTheWeek[d2]);
						s += ". ";
						s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100 * (-maxBuildingChangesPerDay + n_changes)));

						dl.append(s);
						cl.append(weightPercentage / 100 * (-maxBuildingChangesPerDay + n_changes));

						conflictsString += s + "\n";
					}
				}
			}
		}

		if (this.weightPercentage == 100)
			Debug.Assert(nbroken == 0);

		return weightPercentage / 100 * nbroken;
	}

	public bool isRelatedToActivity(Activity a)
	{
		Q_UNUSED(a);

		return false;
	}

	public bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	public bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		return r.setsShareStudents(s.name, this.studentsName);
	}

	public bool isRelatedToRoom(Room r)
	{
		Q_UNUSED(r);

		return false;
	}

	public bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxBuildingChangesPerDay > r.nHoursPerDay)
			return true;

		return false;
	}
	public bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	public bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxBuildingChangesPerDay > r.nHoursPerDay)
			maxBuildingChangesPerDay = r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintStudentsMaxBuildingChangesPerDay: SpaceConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintStudentsMaxBuildingChangesPerDay) public: int maxBuildingChangesPerDay;


	/////////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintStudentsMaxBuildingChangesPerDay() : base()
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_MAX_BUILDING_CHANGES_PER_DAY;
	}

	private ConstraintStudentsMaxBuildingChangesPerDay(double wp, int mc) : base(wp)
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_MAX_BUILDING_CHANGES_PER_DAY;
		this.maxBuildingChangesPerDay = mc;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);
		Q_UNUSED(r);

		return true;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintStudentsMaxBuildingChangesPerDay>\n";

		s += "	<Weight_Percentage>" + CustomFETString.number(weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Max_Building_Changes_Per_Day>" + CustomFETString.number(this.maxBuildingChangesPerDay) + "</Max_Building_Changes_Per_Day>\n";

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintStudentsMaxBuildingChangesPerDay>\n";

		return s;
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

		QString s = tr("Students max building changes per day");
		s += ", ";

		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";

		s += tr("MC:%1", "MC means max changes").arg(this.maxBuildingChangesPerDay);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Space constraint");
		s += "\n";

		s += tr("Students maximum building changes per day");
		s += "\n";

		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		s += tr("Maximum building changes per day=%1").arg(this.maxBuildingChangesPerDay);
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
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>& dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrix roomsMatrix is already calculated, do not calculate it again!
		if (!c.roomsMatrixReady)
		{
			c.roomsMatrixReady = true;
			GlobalMembersSpaceconstraint.rooms_conflicts = c.getRoomsMatrix(ref r, ref GlobalMembersSpaceconstraint.roomsMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken = 0;

		for (int sbg = 0; sbg < r.nInternalSubgroups; sbg++)
		{
			//Better, less memory
			StudentsSubgroup sts = r.internalSubgroupsList[sbg];
			int[,] crtBuildingsTimetable = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK, GlobalMembersTimetable_defs.MAX_HOURS_PER_DAY];
			for (int d2 = 0; d2 < r.nDaysPerWeek; d2++)
				for (int h2 = 0; h2 < r.nHoursPerDay; h2++)
					crtBuildingsTimetable[d2, h2] = -1;

			foreach (int ai, sts.activitiesForSubgroup) if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
					int d2 = c.times[ai] % r.nDaysPerWeek;
					int h2 = c.times[ai] / r.nDaysPerWeek;

					for (int dur = 0; dur < r.internalActivitiesList[ai].duration; dur++)
					{
						Debug.Assert(h2 + dur < r.nHoursPerDay);
						Debug.Assert(crtBuildingsTimetable[d2, h2 + dur] == -1);
						if (c.rooms[ai] != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM && c.rooms[ai] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
						{
							Debug.Assert(c.rooms[ai] >= 0 && c.rooms[ai] < r.nInternalRooms);
							crtBuildingsTimetable[d2, h2 + dur] = r.internalRoomsList[c.rooms[ai]].buildingIndex;
						}
					}
			}
			/////////////

			for (int d2 = 0; d2 < r.nDaysPerWeek; d2++)
			{
				int crt_building = -1;
				int n_changes = 0;
				for (int h2 = 0; h2 < r.nHoursPerDay; h2++)
				{
					if (crtBuildingsTimetable[d2, h2] != -1)
					{
						if (crt_building != crtBuildingsTimetable[d2, h2])
						{
							if (crt_building != -1)
								n_changes++;
							crt_building = crtBuildingsTimetable[d2, h2];
						}
					}
				}

				if (n_changes > this.maxBuildingChangesPerDay)
				{
					nbroken += -this.maxBuildingChangesPerDay + n_changes;

					if (conflictsString != null)
					{
						QString s = tr("Space constraint students max building changes per day broken for students=%1 on day %2").arg(r.internalSubgroupsList[sbg].name).arg(r.daysOfTheWeek[d2]);
						s += ". ";
						s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100 * (-maxBuildingChangesPerDay + n_changes)));

						dl.append(s);
						cl.append(weightPercentage / 100 * (-maxBuildingChangesPerDay + n_changes));

						conflictsString += s + "\n";
					}
				}
			}
		}

		if (this.weightPercentage == 100)
			Debug.Assert(nbroken == 0);

		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(Activity a)
	{
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

	private bool isRelatedToRoom(Room r)
	{
		Q_UNUSED(r);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxBuildingChangesPerDay > r.nHoursPerDay)
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

		if (maxBuildingChangesPerDay > r.nHoursPerDay)
			maxBuildingChangesPerDay = r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintStudentsSetMaxBuildingChangesPerWeek: SpaceConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintStudentsSetMaxBuildingChangesPerWeek) public: QList<int> iSubgroupsList;
	//internal variables


	public int maxBuildingChangesPerWeek;

	public QString studentsName = new QString();


	/////////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////////

	public ConstraintStudentsSetMaxBuildingChangesPerWeek() : base()
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_MAX_BUILDING_CHANGES_PER_WEEK;
	}

	public ConstraintStudentsSetMaxBuildingChangesPerWeek(double wp, QString st, int mc) : base(wp)
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_MAX_BUILDING_CHANGES_PER_WEEK;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->studentsName=st;
		this.studentsName.CopyFrom(st);
		this.maxBuildingChangesPerWeek = mc;
	}

	public bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		this.iSubgroupsList.clear();

		StudentsSet ss = r.searchAugmentedStudentsSet(this.studentsName);

		if (ss == null)
		{
			SpaceConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint students set max building changes per week is wrong because it refers to inexistent students set." + " Please correct it (removing it might be a solution). Please report potential bug. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}

		if (ss.type == GlobalMembersStudentsset.STUDENTS_SUBGROUP)
		{
			int tmp;
			tmp = ((StudentsSubgroup)ss).indexInInternalSubgroupsList;
			Debug.Assert(tmp >= 0);
			Debug.Assert(tmp < r.nInternalSubgroups);
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
					this.iSubgroupsList.append(tmp);
				}
			}
		}
		else
			Debug.Assert(0);

		return true;
	}

	public QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintStudentsSetMaxBuildingChangesPerWeek>\n";

		s += "	<Weight_Percentage>" + CustomFETString.number(weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Students>" + GlobalMembersTimetable_defs.protect(this.studentsName) + "</Students>\n";
		s += "	<Max_Building_Changes_Per_Week>" + CustomFETString.number(this.maxBuildingChangesPerWeek) + "</Max_Building_Changes_Per_Week>\n";

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintStudentsSetMaxBuildingChangesPerWeek>\n";

		return s;
	}

	public bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);

		return false;
	}

	public QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = tr("Students set max building changes per week");
		s += ", ";

		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";

		s += tr("St:%1", "St means students").arg(this.studentsName);
		s += ", ";

		s += tr("MC:%1", "MC means max changes").arg(this.maxBuildingChangesPerWeek);

		return begin + s + end;
	}

	public QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Space constraint");
		s += "\n";

		s += tr("Students set maximum building changes per week");
		s += "\n";

		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		s += tr("Students=%1").arg(this.studentsName);
		s += "\n";

		s += tr("Maximum building changes per week=%1").arg(this.maxBuildingChangesPerWeek);
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

	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>& dl, QString* conflictsString =null)
	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrix roomsMatrix is already calculated, do not calculate it again!
		if (!c.roomsMatrixReady)
		{
			c.roomsMatrixReady = true;
			GlobalMembersSpaceconstraint.rooms_conflicts = c.getRoomsMatrix(ref r, ref GlobalMembersSpaceconstraint.roomsMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken = 0;

		foreach (int sbg, this.iSubgroupsList)
		{
			//Better, less memory
			StudentsSubgroup sts = r.internalSubgroupsList[sbg];
			int[,] crtBuildingsTimetable = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK, GlobalMembersTimetable_defs.MAX_HOURS_PER_DAY];
			for (int d2 = 0; d2 < r.nDaysPerWeek; d2++)
				for (int h2 = 0; h2 < r.nHoursPerDay; h2++)
					crtBuildingsTimetable[d2, h2] = -1;

			foreach (int ai, sts.activitiesForSubgroup) if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
					int d2 = c.times[ai] % r.nDaysPerWeek;
					int h2 = c.times[ai] / r.nDaysPerWeek;

					for (int dur = 0; dur < r.internalActivitiesList[ai].duration; dur++)
					{
						Debug.Assert(h2 + dur < r.nHoursPerDay);
						Debug.Assert(crtBuildingsTimetable[d2, h2 + dur] == -1);
						if (c.rooms[ai] != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM && c.rooms[ai] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
						{
							Debug.Assert(c.rooms[ai] >= 0 && c.rooms[ai] < r.nInternalRooms);
							crtBuildingsTimetable[d2, h2 + dur] = r.internalRoomsList[c.rooms[ai]].buildingIndex;
						}
					}
			}
			/////////////

			int n_changes = 0;
			for (int d2 = 0; d2 < r.nDaysPerWeek; d2++)
			{
				int crt_building = -1;
				for (int h2 = 0; h2 < r.nHoursPerDay; h2++)
				{
					if (crtBuildingsTimetable[d2, h2] != -1)
					{
						if (crt_building != crtBuildingsTimetable[d2, h2])
						{
							if (crt_building != -1)
								n_changes++;
							crt_building = crtBuildingsTimetable[d2, h2];
						}
					}
				}
			}

			if (n_changes > this.maxBuildingChangesPerWeek)
			{
				nbroken += -this.maxBuildingChangesPerWeek + n_changes;

				if (conflictsString != null)
				{
					QString s = tr("Space constraint students set max building changes per week broken for students=%1").arg(this.studentsName);
					s += ". ";
					s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100 * (-maxBuildingChangesPerWeek + n_changes)));

					dl.append(s);
					cl.append(weightPercentage / 100 * (-maxBuildingChangesPerWeek + n_changes));

					conflictsString += s + "\n";
				}
			}
		}

		if (this.weightPercentage == 100)
			Debug.Assert(nbroken == 0);

		return weightPercentage / 100 * nbroken;
	}

	public bool isRelatedToActivity(Activity a)
	{
		Q_UNUSED(a);

		return false;
	}

	public bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	public bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		return r.setsShareStudents(s.name, this.studentsName);
	}

	public bool isRelatedToRoom(Room r)
	{
		Q_UNUSED(r);

		return false;
	}

	public bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxBuildingChangesPerWeek > r.nDaysPerWeek * r.nHoursPerDay)
			return true;

		return false;
	}
	public bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	public bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxBuildingChangesPerWeek > r.nDaysPerWeek * r.nHoursPerDay)
			maxBuildingChangesPerWeek = r.nDaysPerWeek * r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintStudentsMaxBuildingChangesPerWeek: SpaceConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintStudentsMaxBuildingChangesPerWeek) public: int maxBuildingChangesPerWeek;


	/////////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintStudentsMaxBuildingChangesPerWeek() : base()
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_MAX_BUILDING_CHANGES_PER_WEEK;
	}

	private ConstraintStudentsMaxBuildingChangesPerWeek(double wp, int mc) : base(wp)
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_MAX_BUILDING_CHANGES_PER_WEEK;
		this.maxBuildingChangesPerWeek = mc;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);

		Q_UNUSED(r);

		return true;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintStudentsMaxBuildingChangesPerWeek>\n";

		s += "	<Weight_Percentage>" + CustomFETString.number(weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Max_Building_Changes_Per_Week>" + CustomFETString.number(this.maxBuildingChangesPerWeek) + "</Max_Building_Changes_Per_Week>\n";

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintStudentsMaxBuildingChangesPerWeek>\n";

		return s;
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

		QString s = tr("Students max building changes per week");
		s += ", ";

		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";

		s += tr("MC:%1", "MC means max changes").arg(this.maxBuildingChangesPerWeek);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Space constraint");
		s += "\n";

		s += tr("Students maximum building changes per week");
		s += "\n";

		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		s += tr("Maximum building changes per week=%1").arg(this.maxBuildingChangesPerWeek);
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
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>& dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrix roomsMatrix is already calculated, do not calculate it again!
		if (!c.roomsMatrixReady)
		{
			c.roomsMatrixReady = true;
			GlobalMembersSpaceconstraint.rooms_conflicts = c.getRoomsMatrix(ref r, ref GlobalMembersSpaceconstraint.roomsMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken = 0;

		for (int sbg = 0; sbg < r.nInternalSubgroups; sbg++)
		{
			//Better, less memory
			StudentsSubgroup sts = r.internalSubgroupsList[sbg];
			int[,] crtBuildingsTimetable = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK, GlobalMembersTimetable_defs.MAX_HOURS_PER_DAY];
			for (int d2 = 0; d2 < r.nDaysPerWeek; d2++)
				for (int h2 = 0; h2 < r.nHoursPerDay; h2++)
					crtBuildingsTimetable[d2, h2] = -1;

			foreach (int ai, sts.activitiesForSubgroup) if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
					int d2 = c.times[ai] % r.nDaysPerWeek;
					int h2 = c.times[ai] / r.nDaysPerWeek;

					for (int dur = 0; dur < r.internalActivitiesList[ai].duration; dur++)
					{
						Debug.Assert(h2 + dur < r.nHoursPerDay);
						Debug.Assert(crtBuildingsTimetable[d2, h2 + dur] == -1);
						if (c.rooms[ai] != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM && c.rooms[ai] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
						{
							Debug.Assert(c.rooms[ai] >= 0 && c.rooms[ai] < r.nInternalRooms);
							crtBuildingsTimetable[d2, h2 + dur] = r.internalRoomsList[c.rooms[ai]].buildingIndex;
						}
					}
			}
			/////////////

			int n_changes = 0;
			for (int d2 = 0; d2 < r.nDaysPerWeek; d2++)
			{
				int crt_building = -1;
				for (int h2 = 0; h2 < r.nHoursPerDay; h2++)
				{
					if (crtBuildingsTimetable[d2, h2] != -1)
					{
						if (crt_building != crtBuildingsTimetable[d2, h2])
						{
							if (crt_building != -1)
								n_changes++;
							crt_building = crtBuildingsTimetable[d2, h2];
						}
					}
				}
			}

			if (n_changes > this.maxBuildingChangesPerWeek)
			{
				nbroken += -this.maxBuildingChangesPerWeek + n_changes;

				if (conflictsString != null)
				{
					QString s = tr("Space constraint students max building changes per week broken for students=%1").arg(r.internalSubgroupsList[sbg].name);
					s += ". ";
					s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100 * (-maxBuildingChangesPerWeek + n_changes)));

					dl.append(s);
					cl.append(weightPercentage / 100 * (-maxBuildingChangesPerWeek + n_changes));

					conflictsString += s + "\n";
				}
			}
		}

		if (this.weightPercentage == 100)
			Debug.Assert(nbroken == 0);

		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(Activity a)
	{
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

	private bool isRelatedToRoom(Room r)
	{
		Q_UNUSED(r);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxBuildingChangesPerWeek > r.nDaysPerWeek * r.nHoursPerDay)
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

		if (maxBuildingChangesPerWeek > r.nDaysPerWeek * r.nHoursPerDay)
			maxBuildingChangesPerWeek = r.nDaysPerWeek * r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintStudentsSetMinGapsBetweenBuildingChanges: SpaceConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintStudentsSetMinGapsBetweenBuildingChanges) public: QList<int> iSubgroupsList;
	//internal variables


	public int minGapsBetweenBuildingChanges;

	public QString studentsName = new QString();


	/////////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////////

	public ConstraintStudentsSetMinGapsBetweenBuildingChanges() : base()
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_MIN_GAPS_BETWEEN_BUILDING_CHANGES;
	}

	public ConstraintStudentsSetMinGapsBetweenBuildingChanges(double wp, QString st, int mg) : base(wp)
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_SET_MIN_GAPS_BETWEEN_BUILDING_CHANGES;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->studentsName=st;
		this.studentsName.CopyFrom(st);
		this.minGapsBetweenBuildingChanges = mg;
	}

	public bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		this.iSubgroupsList.clear();

		StudentsSet ss = r.searchAugmentedStudentsSet(this.studentsName);

		if (ss == null)
		{
			SpaceConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint students set min gaps between building changes is wrong because it refers to inexistent students set." + " Please correct it (removing it might be a solution). Please report potential bug. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}

		if (ss.type == GlobalMembersStudentsset.STUDENTS_SUBGROUP)
		{
			int tmp;
			tmp = ((StudentsSubgroup)ss).indexInInternalSubgroupsList;
			Debug.Assert(tmp >= 0);
			Debug.Assert(tmp < r.nInternalSubgroups);
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
					this.iSubgroupsList.append(tmp);
				}
			}
		}
		else
			Debug.Assert(0);

		return true;
	}

	public QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintStudentsSetMinGapsBetweenBuildingChanges>\n";

		s += "	<Weight_Percentage>" + CustomFETString.number(weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Students>" + GlobalMembersTimetable_defs.protect(this.studentsName) + "</Students>\n";
		s += "	<Min_Gaps_Between_Building_Changes>" + CustomFETString.number(this.minGapsBetweenBuildingChanges) + "</Min_Gaps_Between_Building_Changes>\n";

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintStudentsSetMinGapsBetweenBuildingChanges>\n";

		return s;
	}

	public bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);

		return false;
	}

	public QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = tr("Students set min gaps between building changes");
		s += ", ";

		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";

		s += tr("St:%1", "St means students").arg(this.studentsName);
		s += ", ";

		s += tr("mG:%1", "mG means min gaps").arg(this.minGapsBetweenBuildingChanges);

		return begin + s + end;
	}

	public QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Space constraint");
		s += "\n";

		s += tr("Students set minimum gaps between building changes");
		s += "\n";

		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		s += tr("Students=%1").arg(this.studentsName);
		s += "\n";

		s += tr("Minimum gaps between building changes=%1").arg(this.minGapsBetweenBuildingChanges);
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

	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>& dl, QString* conflictsString =null)
	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrix roomsMatrix is already calculated, do not calculate it again!
		if (!c.roomsMatrixReady)
		{
			c.roomsMatrixReady = true;
			GlobalMembersSpaceconstraint.rooms_conflicts = c.getRoomsMatrix(ref r, ref GlobalMembersSpaceconstraint.roomsMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken = 0;

		foreach (int sbg, this.iSubgroupsList)
		{
			//Better, less memory
			StudentsSubgroup sts = r.internalSubgroupsList[sbg];
			int[,] crtBuildingsTimetable = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK, GlobalMembersTimetable_defs.MAX_HOURS_PER_DAY];
			for (int d2 = 0; d2 < r.nDaysPerWeek; d2++)
				for (int h2 = 0; h2 < r.nHoursPerDay; h2++)
					crtBuildingsTimetable[d2, h2] = -1;

			foreach (int ai, sts.activitiesForSubgroup) if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
					int d2 = c.times[ai] % r.nDaysPerWeek;
					int h2 = c.times[ai] / r.nDaysPerWeek;

					for (int dur = 0; dur < r.internalActivitiesList[ai].duration; dur++)
					{
						Debug.Assert(h2 + dur < r.nHoursPerDay);
						Debug.Assert(crtBuildingsTimetable[d2, h2 + dur] == -1);
						if (c.rooms[ai] != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM && c.rooms[ai] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
						{
							Debug.Assert(c.rooms[ai] >= 0 && c.rooms[ai] < r.nInternalRooms);
							crtBuildingsTimetable[d2, h2 + dur] = r.internalRoomsList[c.rooms[ai]].buildingIndex;
						}
					}
			}
			/////////////

			for (int d2 = 0; d2 < r.nDaysPerWeek; d2++)
			{
				int h2;
				for (h2 = 0; h2 < r.nHoursPerDay; h2++)
					if (crtBuildingsTimetable[d2, h2] != -1)
						break;

				int crt_building = -1;
				if (h2 < r.nHoursPerDay)
					crt_building = crtBuildingsTimetable[d2, h2];

				int cnt_gaps = 0;

				for (h2++; h2 < r.nHoursPerDay; h2++)
				{
					if (crtBuildingsTimetable[d2, h2] != -1)
					{
						if (crtBuildingsTimetable[d2, h2] == crt_building)
							cnt_gaps = 0;
						else
						{
							if (cnt_gaps < this.minGapsBetweenBuildingChanges)
							{
								nbroken++;

								if (conflictsString != null)
								{
									QString s = tr("Space constraint students set min gaps between building changes broken for students=%1 on day %2").arg(this.studentsName).arg(r.daysOfTheWeek[d2]);
									s += ". ";
									s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100 * 1));

									dl.append(s);
									cl.append(weightPercentage / 100 * 1);

									conflictsString += s + "\n";
								}
							}

							crt_building = crtBuildingsTimetable[d2, h2];
							cnt_gaps = 0;
						}
					}
					else
						cnt_gaps++;
				}
			}
		}

		if (this.weightPercentage == 100)
			Debug.Assert(nbroken == 0);

		return weightPercentage / 100 * nbroken;
	}

	public bool isRelatedToActivity(Activity a)
	{
		Q_UNUSED(a);

		return false;
	}

	public bool isRelatedToTeacher(Teacher t)
	{
		Q_UNUSED(t);

		return false;
	}

	public bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		return r.setsShareStudents(s.name, this.studentsName);
	}

	public bool isRelatedToRoom(Room r)
	{
		Q_UNUSED(r);

		return false;
	}

	public bool hasWrongDayOrHour(ref Rules r)
	{
		if (minGapsBetweenBuildingChanges > r.nHoursPerDay)
			return true;

		return false;
	}
	public bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	public bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (minGapsBetweenBuildingChanges > r.nHoursPerDay)
			minGapsBetweenBuildingChanges = r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintStudentsMinGapsBetweenBuildingChanges: SpaceConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintStudentsMinGapsBetweenBuildingChanges) public: int minGapsBetweenBuildingChanges;


	/////////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintStudentsMinGapsBetweenBuildingChanges() : base()
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_MIN_GAPS_BETWEEN_BUILDING_CHANGES;
	}

	private ConstraintStudentsMinGapsBetweenBuildingChanges(double wp, int mg) : base(wp)
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_STUDENTS_MIN_GAPS_BETWEEN_BUILDING_CHANGES;
		this.minGapsBetweenBuildingChanges = mg;
	}

	private bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		Q_UNUSED(parent);
		Q_UNUSED(r);

		return true;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintStudentsMinGapsBetweenBuildingChanges>\n";

		s += "	<Weight_Percentage>" + CustomFETString.number(weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Min_Gaps_Between_Building_Changes>" + CustomFETString.number(this.minGapsBetweenBuildingChanges) + "</Min_Gaps_Between_Building_Changes>\n";

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintStudentsMinGapsBetweenBuildingChanges>\n";

		return s;
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

		QString s = tr("Students min gaps between building changes");
		s += ", ";

		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";

		s += tr("mG:%1", "mG means min gaps").arg(this.minGapsBetweenBuildingChanges);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Space constraint");
		s += "\n";

		s += tr("Students minimum gaps between building changes");
		s += "\n";

		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		s += tr("Minimum gaps between building changes=%1").arg(this.minGapsBetweenBuildingChanges);
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
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>& dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrix roomsMatrix is already calculated, do not calculate it again!
		if (!c.roomsMatrixReady)
		{
			c.roomsMatrixReady = true;
			GlobalMembersSpaceconstraint.rooms_conflicts = c.getRoomsMatrix(ref r, ref GlobalMembersSpaceconstraint.roomsMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken = 0;

		for (int sbg = 0; sbg < r.nInternalSubgroups; sbg++)
		{
			//Better, less memory
			StudentsSubgroup sts = r.internalSubgroupsList[sbg];
			int[,] crtBuildingsTimetable = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK, GlobalMembersTimetable_defs.MAX_HOURS_PER_DAY];
			for (int d2 = 0; d2 < r.nDaysPerWeek; d2++)
				for (int h2 = 0; h2 < r.nHoursPerDay; h2++)
					crtBuildingsTimetable[d2, h2] = -1;

			foreach (int ai, sts.activitiesForSubgroup) if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
					int d2 = c.times[ai] % r.nDaysPerWeek;
					int h2 = c.times[ai] / r.nDaysPerWeek;

					for (int dur = 0; dur < r.internalActivitiesList[ai].duration; dur++)
					{
						Debug.Assert(h2 + dur < r.nHoursPerDay);
						Debug.Assert(crtBuildingsTimetable[d2, h2 + dur] == -1);
						if (c.rooms[ai] != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM && c.rooms[ai] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
						{
							Debug.Assert(c.rooms[ai] >= 0 && c.rooms[ai] < r.nInternalRooms);
							crtBuildingsTimetable[d2, h2 + dur] = r.internalRoomsList[c.rooms[ai]].buildingIndex;
						}
					}
			}
			/////////////

			for (int d2 = 0; d2 < r.nDaysPerWeek; d2++)
			{
				int h2;
				for (h2 = 0; h2 < r.nHoursPerDay; h2++)
					if (crtBuildingsTimetable[d2, h2] != -1)
						break;

				int crt_building = -1;
				if (h2 < r.nHoursPerDay)
					crt_building = crtBuildingsTimetable[d2, h2];

				int cnt_gaps = 0;

				for (h2++; h2 < r.nHoursPerDay; h2++)
				{
					if (crtBuildingsTimetable[d2, h2] != -1)
					{
						if (crtBuildingsTimetable[d2, h2] == crt_building)
							cnt_gaps = 0;
						else
						{
							if (cnt_gaps < this.minGapsBetweenBuildingChanges)
							{
								nbroken++;

								if (conflictsString != null)
								{
									QString s = tr("Space constraint students min gaps between building changes broken for students=%1 on day %2").arg(r.internalSubgroupsList[sbg].name).arg(r.daysOfTheWeek[d2]);
									s += ". ";
									s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100 * 1));

									dl.append(s);
									cl.append(weightPercentage / 100 * 1);

									conflictsString += s + "\n";
								}
							}

							crt_building = crtBuildingsTimetable[d2, h2];
							cnt_gaps = 0;
						}
					}
					else
						cnt_gaps++;
				}
			}
		}

		if (this.weightPercentage == 100)
			Debug.Assert(nbroken == 0);

		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(Activity a)
	{
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

	private bool isRelatedToRoom(Room r)
	{
		Q_UNUSED(r);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (minGapsBetweenBuildingChanges > r.nHoursPerDay)
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

		if (minGapsBetweenBuildingChanges > r.nHoursPerDay)
			minGapsBetweenBuildingChanges = r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintTeacherMaxBuildingChangesPerDay: SpaceConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTeacherMaxBuildingChangesPerDay) public: int teacher_ID;
	//internal variables


	public int maxBuildingChangesPerDay;

	public QString teacherName = new QString();


	/////////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////////

	public ConstraintTeacherMaxBuildingChangesPerDay() : base()
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_TEACHER_MAX_BUILDING_CHANGES_PER_DAY;
	}

	public ConstraintTeacherMaxBuildingChangesPerDay(double wp, QString tc, int mc) : base(wp)
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_TEACHER_MAX_BUILDING_CHANGES_PER_DAY;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->teacherName=tc;
		this.teacherName.CopyFrom(tc);
		this.maxBuildingChangesPerDay = mc;
	}

	public bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		this.teacher_ID = r.searchTeacher(this.teacherName);

		if (this.teacher_ID < 0)
		{
			SpaceConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint teacher max building changes per day is wrong because it refers to inexistent teacher." + " Please correct it (removing it might be a solution). Please report potential bug. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}

		return true;
	}

	public QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintTeacherMaxBuildingChangesPerDay>\n";

		s += "	<Weight_Percentage>" + CustomFETString.number(weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Teacher>" + GlobalMembersTimetable_defs.protect(this.teacherName) + "</Teacher>\n";
		s += "	<Max_Building_Changes_Per_Day>" + CustomFETString.number(this.maxBuildingChangesPerDay) + "</Max_Building_Changes_Per_Day>\n";

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTeacherMaxBuildingChangesPerDay>\n";

		return s;
	}

	public bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);

		return false;
	}

	public QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = tr("Teacher max building changes per day");
		s += ", ";

		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";

		s += tr("T:%1", "T means teacher").arg(this.teacherName);
		s += ", ";

		s += tr("MC:%1", "MC means max changes").arg(this.maxBuildingChangesPerDay);

		return begin + s + end;
	}

	public QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Space constraint");
		s += "\n";

		s += tr("Teacher maximum building changes per day");
		s += "\n";

		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		s += tr("Teacher=%1").arg(this.teacherName);
		s += "\n";

		s += tr("Maximum building changes per day=%1").arg(this.maxBuildingChangesPerDay);
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

	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>& dl, QString* conflictsString =null)
	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrix roomsMatrix is already calculated, do not calculate it again!
		if (!c.roomsMatrixReady)
		{
			c.roomsMatrixReady = true;
			GlobalMembersSpaceconstraint.rooms_conflicts = c.getRoomsMatrix(ref r, ref GlobalMembersSpaceconstraint.roomsMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken = 0;

		int tch = this.teacher_ID;

		//Better, less memory
		Teacher tchpointer = r.internalTeachersList[tch];
		int[,] crtBuildingsTimetable = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK, GlobalMembersTimetable_defs.MAX_HOURS_PER_DAY];
		for (int d2 = 0; d2 < r.nDaysPerWeek; d2++)
			for (int h2 = 0; h2 < r.nHoursPerDay; h2++)
				crtBuildingsTimetable[d2, h2] = -1;

		foreach (int ai, tchpointer.activitiesForTeacher) if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
		{
				int d2 = c.times[ai] % r.nDaysPerWeek;
				int h2 = c.times[ai] / r.nDaysPerWeek;

				for (int dur = 0; dur < r.internalActivitiesList[ai].duration; dur++)
				{
					Debug.Assert(h2 + dur < r.nHoursPerDay);
					Debug.Assert(crtBuildingsTimetable[d2, h2 + dur] == -1);
					if (c.rooms[ai] != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM && c.rooms[ai] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
					{
						Debug.Assert(c.rooms[ai] >= 0 && c.rooms[ai] < r.nInternalRooms);
						crtBuildingsTimetable[d2, h2 + dur] = r.internalRoomsList[c.rooms[ai]].buildingIndex;
					}
				}
		}
		/////////////

		for (int d2 = 0; d2 < r.nDaysPerWeek; d2++)
		{
			int crt_building = -1;
			int n_changes = 0;
			for (int h2 = 0; h2 < r.nHoursPerDay; h2++)
			{
				if (crtBuildingsTimetable[d2, h2] != -1)
				{
					if (crt_building != crtBuildingsTimetable[d2, h2])
					{
						if (crt_building != -1)
							n_changes++;
						crt_building = crtBuildingsTimetable[d2, h2];
					}
				}
			}

			if (n_changes > this.maxBuildingChangesPerDay)
			{
				nbroken += -this.maxBuildingChangesPerDay + n_changes;

				if (conflictsString != null)
				{
					QString s = tr("Space constraint teacher max building changes per day broken for teacher=%1 on day %2").arg(this.teacherName).arg(r.daysOfTheWeek[d2]);
					s += ". ";
					s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100 * (-maxBuildingChangesPerDay + n_changes)));

					dl.append(s);
					cl.append(weightPercentage / 100 * (-maxBuildingChangesPerDay + n_changes));

					conflictsString += s + "\n";
				}
			}
		}

		if (this.weightPercentage == 100)
			Debug.Assert(nbroken == 0);

		return weightPercentage / 100 * nbroken;
	}

	public bool isRelatedToActivity(Activity a)
	{
		Q_UNUSED(a);

		return false;
	}

	public bool isRelatedToTeacher(Teacher t)
	{
		return this.teacherName == t.name;
	}

	public bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToRoom(Room r)
	{
		Q_UNUSED(r);

		return false;
	}

	public bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxBuildingChangesPerDay > r.nHoursPerDay)
			return true;

		return false;
	}
	public bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	public bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxBuildingChangesPerDay > r.nHoursPerDay)
			maxBuildingChangesPerDay = r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintTeachersMaxBuildingChangesPerDay: SpaceConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTeachersMaxBuildingChangesPerDay) public: int maxBuildingChangesPerDay;


	/////////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintTeachersMaxBuildingChangesPerDay() : base()
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_TEACHERS_MAX_BUILDING_CHANGES_PER_DAY;
	}

	private ConstraintTeachersMaxBuildingChangesPerDay(double wp, int mc) : base(wp)
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_TEACHERS_MAX_BUILDING_CHANGES_PER_DAY;
		this.maxBuildingChangesPerDay = mc;
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

		QString s = "<ConstraintTeachersMaxBuildingChangesPerDay>\n";

		s += "	<Weight_Percentage>" + CustomFETString.number(weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Max_Building_Changes_Per_Day>" + CustomFETString.number(this.maxBuildingChangesPerDay) + "</Max_Building_Changes_Per_Day>\n";

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTeachersMaxBuildingChangesPerDay>\n";

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

		QString s = tr("Teachers max building changes per day");
		s += ", ";

		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";

		s += tr("MC:%1", "MC means max changes").arg(this.maxBuildingChangesPerDay);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Space constraint");
		s += "\n";

		s += tr("Teachers maximum building changes per day");
		s += "\n";

		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		s += tr("Maximum building changes per day=%1").arg(this.maxBuildingChangesPerDay);
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
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>& dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrix roomsMatrix is already calculated, do not calculate it again!
		if (!c.roomsMatrixReady)
		{
			c.roomsMatrixReady = true;
			GlobalMembersSpaceconstraint.rooms_conflicts = c.getRoomsMatrix(ref r, ref GlobalMembersSpaceconstraint.roomsMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken = 0;

		for (int tch = 0; tch < r.nInternalTeachers; tch++)
		{
			//Better, less memory
			Teacher tchpointer = r.internalTeachersList[tch];
			int[,] crtBuildingsTimetable = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK, GlobalMembersTimetable_defs.MAX_HOURS_PER_DAY];
			for (int d2 = 0; d2 < r.nDaysPerWeek; d2++)
				for (int h2 = 0; h2 < r.nHoursPerDay; h2++)
					crtBuildingsTimetable[d2, h2] = -1;

			foreach (int ai, tchpointer.activitiesForTeacher) if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
					int d2 = c.times[ai] % r.nDaysPerWeek;
					int h2 = c.times[ai] / r.nDaysPerWeek;

					for (int dur = 0; dur < r.internalActivitiesList[ai].duration; dur++)
					{
						Debug.Assert(h2 + dur < r.nHoursPerDay);
						Debug.Assert(crtBuildingsTimetable[d2, h2 + dur] == -1);
						if (c.rooms[ai] != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM && c.rooms[ai] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
						{
							Debug.Assert(c.rooms[ai] >= 0 && c.rooms[ai] < r.nInternalRooms);
							crtBuildingsTimetable[d2, h2 + dur] = r.internalRoomsList[c.rooms[ai]].buildingIndex;
						}
					}
			}
			/////////////

			for (int d2 = 0; d2 < r.nDaysPerWeek; d2++)
			{
				int crt_building = -1;
				int n_changes = 0;
				for (int h2 = 0; h2 < r.nHoursPerDay; h2++)
				{
					if (crtBuildingsTimetable[d2, h2] != -1)
					{
						if (crt_building != crtBuildingsTimetable[d2, h2])
						{
							if (crt_building != -1)
								n_changes++;
							crt_building = crtBuildingsTimetable[d2, h2];
						}
					}
				}

				if (n_changes > this.maxBuildingChangesPerDay)
				{
					nbroken += -this.maxBuildingChangesPerDay + n_changes;

					if (conflictsString != null)
					{
						QString s = tr("Space constraint teachers max building changes per day broken for teacher=%1 on day %2").arg(r.internalTeachersList[tch].name).arg(r.daysOfTheWeek[d2]);
						s += ". ";
						s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100 * (-maxBuildingChangesPerDay + n_changes)));

						dl.append(s);
						cl.append(weightPercentage / 100 * (-maxBuildingChangesPerDay + n_changes));

						conflictsString += s + "\n";
					}
				}
			}
		}

		if (this.weightPercentage == 100)
			Debug.Assert(nbroken == 0);

		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(Activity a)
	{
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

	private bool isRelatedToRoom(Room r)
	{
		Q_UNUSED(r);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxBuildingChangesPerDay > r.nHoursPerDay)
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

		if (maxBuildingChangesPerDay > r.nHoursPerDay)
			maxBuildingChangesPerDay = r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintTeacherMaxBuildingChangesPerWeek: SpaceConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTeacherMaxBuildingChangesPerWeek) public: int teacher_ID;
	//internal variables


	public int maxBuildingChangesPerWeek;

	public QString teacherName = new QString();


	/////////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////////

	public ConstraintTeacherMaxBuildingChangesPerWeek() : base()
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_TEACHER_MAX_BUILDING_CHANGES_PER_WEEK;
	}

	public ConstraintTeacherMaxBuildingChangesPerWeek(double wp, QString tc, int mc) : base(wp)
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_TEACHER_MAX_BUILDING_CHANGES_PER_WEEK;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->teacherName=tc;
		this.teacherName.CopyFrom(tc);
		this.maxBuildingChangesPerWeek = mc;
	}

	public bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		this.teacher_ID = r.searchTeacher(this.teacherName);

		if (this.teacher_ID < 0)
		{
			SpaceConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint teacher max building changes per week is wrong because it refers to inexistent teacher." + " Please correct it (removing it might be a solution). Please report potential bug. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}

		return true;
	}

	public bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);

		return false;
	}

	public QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintTeacherMaxBuildingChangesPerWeek>\n";

		s += "	<Weight_Percentage>" + CustomFETString.number(weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Teacher>" + GlobalMembersTimetable_defs.protect(this.teacherName) + "</Teacher>\n";
		s += "	<Max_Building_Changes_Per_Week>" + CustomFETString.number(this.maxBuildingChangesPerWeek) + "</Max_Building_Changes_Per_Week>\n";

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTeacherMaxBuildingChangesPerWeek>\n";

		return s;
	}

	public QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = tr("Teacher max building changes per week");
		s += ", ";

		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";

		s += tr("T:%1", "T means teacher").arg(this.teacherName);
		s += ", ";

		s += tr("MC:%1", "MC means max changes").arg(this.maxBuildingChangesPerWeek);

		return begin + s + end;
	}

	public QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Space constraint");
		s += "\n";

		s += tr("Teacher maximum building changes per week");
		s += "\n";

		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		s += tr("Teacher=%1").arg(this.teacherName);
		s += "\n";

		s += tr("Maximum building changes per week=%1").arg(this.maxBuildingChangesPerWeek);
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

	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>& dl, QString* conflictsString =null)
	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrix roomsMatrix is already calculated, do not calculate it again!
		if (!c.roomsMatrixReady)
		{
			c.roomsMatrixReady = true;
			GlobalMembersSpaceconstraint.rooms_conflicts = c.getRoomsMatrix(ref r, ref GlobalMembersSpaceconstraint.roomsMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken = 0;

		int tch = this.teacher_ID;

		//Better, less memory
		Teacher tchpointer = r.internalTeachersList[tch];
		int[,] crtBuildingsTimetable = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK, GlobalMembersTimetable_defs.MAX_HOURS_PER_DAY];
		for (int d2 = 0; d2 < r.nDaysPerWeek; d2++)
			for (int h2 = 0; h2 < r.nHoursPerDay; h2++)
				crtBuildingsTimetable[d2, h2] = -1;

		foreach (int ai, tchpointer.activitiesForTeacher) if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
		{
				int d2 = c.times[ai] % r.nDaysPerWeek;
				int h2 = c.times[ai] / r.nDaysPerWeek;

				for (int dur = 0; dur < r.internalActivitiesList[ai].duration; dur++)
				{
					Debug.Assert(h2 + dur < r.nHoursPerDay);
					Debug.Assert(crtBuildingsTimetable[d2, h2 + dur] == -1);
					if (c.rooms[ai] != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM && c.rooms[ai] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
					{
						Debug.Assert(c.rooms[ai] >= 0 && c.rooms[ai] < r.nInternalRooms);
						crtBuildingsTimetable[d2, h2 + dur] = r.internalRoomsList[c.rooms[ai]].buildingIndex;
					}
				}
		}
		/////////////

		int n_changes = 0;

		for (int d2 = 0; d2 < r.nDaysPerWeek; d2++)
		{
			int crt_building = -1;
			for (int h2 = 0; h2 < r.nHoursPerDay; h2++)
			{
				if (crtBuildingsTimetable[d2, h2] != -1)
				{
					if (crt_building != crtBuildingsTimetable[d2, h2])
					{
						if (crt_building != -1)
							n_changes++;
						crt_building = crtBuildingsTimetable[d2, h2];
					}
				}
			}
		}

		if (n_changes > this.maxBuildingChangesPerWeek)
		{
			nbroken += n_changes - this.maxBuildingChangesPerWeek;

			if (conflictsString != null)
			{
				QString s = tr("Space constraint teacher max building changes per week broken for teacher=%1").arg(this.teacherName);
				s += ". ";
				s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100 * (n_changes - maxBuildingChangesPerWeek)));

				dl.append(s);
				cl.append(weightPercentage / 100 * (n_changes - maxBuildingChangesPerWeek));

				conflictsString += s + "\n";
			}
		}

		if (this.weightPercentage == 100)
			Debug.Assert(nbroken == 0);

		return weightPercentage / 100 * nbroken;
	}

	public bool isRelatedToActivity(Activity a)
	{
		Q_UNUSED(a);

		return false;
	}

	public bool isRelatedToTeacher(Teacher t)
	{
		return this.teacherName == t.name;
	}

	public bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToRoom(Room r)
	{
		Q_UNUSED(r);

		return false;
	}

	public bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxBuildingChangesPerWeek > r.nDaysPerWeek * r.nHoursPerDay)
			return true;

		return false;
	}
	public bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	public bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (maxBuildingChangesPerWeek > r.nDaysPerWeek * r.nHoursPerDay)
			maxBuildingChangesPerWeek = r.nDaysPerWeek * r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintTeachersMaxBuildingChangesPerWeek: SpaceConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTeachersMaxBuildingChangesPerWeek) public: int maxBuildingChangesPerWeek;


	/////////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintTeachersMaxBuildingChangesPerWeek() : base()
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_TEACHERS_MAX_BUILDING_CHANGES_PER_WEEK;
	}

	private ConstraintTeachersMaxBuildingChangesPerWeek(double wp, int mc) : base(wp)
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_TEACHERS_MAX_BUILDING_CHANGES_PER_WEEK;
		this.maxBuildingChangesPerWeek = mc;
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

		QString s = "<ConstraintTeachersMaxBuildingChangesPerWeek>\n";

		s += "	<Weight_Percentage>" + CustomFETString.number(weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Max_Building_Changes_Per_Week>" + CustomFETString.number(this.maxBuildingChangesPerWeek) + "</Max_Building_Changes_Per_Week>\n";

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTeachersMaxBuildingChangesPerWeek>\n";

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

		QString s = tr("Teachers max building changes per week");
		s += ", ";

		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";

		s += tr("MC:%1", "MC means max changes").arg(this.maxBuildingChangesPerWeek);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Space constraint");
		s += "\n";

		s += tr("Teachers maximum building changes per week");
		s += "\n";

		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		s += tr("Maximum building changes per week=%1").arg(this.maxBuildingChangesPerWeek);
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
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>& dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrix roomsMatrix is already calculated, do not calculate it again!
		if (!c.roomsMatrixReady)
		{
			c.roomsMatrixReady = true;
			GlobalMembersSpaceconstraint.rooms_conflicts = c.getRoomsMatrix(ref r, ref GlobalMembersSpaceconstraint.roomsMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken = 0;

		for (int tch = 0; tch < r.nInternalTeachers; tch++)
		{
			//Better, less memory
			Teacher tchpointer = r.internalTeachersList[tch];
			int[,] crtBuildingsTimetable = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK, GlobalMembersTimetable_defs.MAX_HOURS_PER_DAY];
			for (int d2 = 0; d2 < r.nDaysPerWeek; d2++)
				for (int h2 = 0; h2 < r.nHoursPerDay; h2++)
					crtBuildingsTimetable[d2, h2] = -1;

			foreach (int ai, tchpointer.activitiesForTeacher) if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
					int d2 = c.times[ai] % r.nDaysPerWeek;
					int h2 = c.times[ai] / r.nDaysPerWeek;

					for (int dur = 0; dur < r.internalActivitiesList[ai].duration; dur++)
					{
						Debug.Assert(h2 + dur < r.nHoursPerDay);
						Debug.Assert(crtBuildingsTimetable[d2, h2 + dur] == -1);
						if (c.rooms[ai] != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM && c.rooms[ai] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
						{
							Debug.Assert(c.rooms[ai] >= 0 && c.rooms[ai] < r.nInternalRooms);
							crtBuildingsTimetable[d2, h2 + dur] = r.internalRoomsList[c.rooms[ai]].buildingIndex;
						}
					}
			}
			/////////////

			int n_changes = 0;

			for (int d2 = 0; d2 < r.nDaysPerWeek; d2++)
			{
				int crt_building = -1;
				for (int h2 = 0; h2 < r.nHoursPerDay; h2++)
				{
					if (crtBuildingsTimetable[d2, h2] != -1)
					{
						if (crt_building != crtBuildingsTimetable[d2, h2])
						{
							if (crt_building != -1)
								n_changes++;
							crt_building = crtBuildingsTimetable[d2, h2];
						}
					}
				}
			}

			if (n_changes > this.maxBuildingChangesPerWeek)
			{
				nbroken += n_changes - this.maxBuildingChangesPerWeek;

				if (conflictsString != null)
				{
					QString s = tr("Space constraint teachers max building changes per week broken for teacher=%1").arg(r.internalTeachersList[tch].name);
					s += ". ";
					s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100 * (n_changes - maxBuildingChangesPerWeek)));

					dl.append(s);
					cl.append(weightPercentage / 100 * (n_changes - maxBuildingChangesPerWeek));

					conflictsString += s + "\n";
				}
			}
		}

		if (this.weightPercentage == 100)
			Debug.Assert(nbroken == 0);

		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(Activity a)
	{
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

	private bool isRelatedToRoom(Room r)
	{
		Q_UNUSED(r);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (maxBuildingChangesPerWeek > r.nDaysPerWeek * r.nHoursPerDay)
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

		if (maxBuildingChangesPerWeek > r.nDaysPerWeek * r.nHoursPerDay)
			maxBuildingChangesPerWeek = r.nDaysPerWeek * r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintTeacherMinGapsBetweenBuildingChanges: SpaceConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTeacherMinGapsBetweenBuildingChanges) public: int teacher_ID;
	//internal variables


	public int minGapsBetweenBuildingChanges;

	public QString teacherName = new QString();


	/////////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////////

	public ConstraintTeacherMinGapsBetweenBuildingChanges() : base()
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_TEACHER_MIN_GAPS_BETWEEN_BUILDING_CHANGES;
	}

	public ConstraintTeacherMinGapsBetweenBuildingChanges(double wp, QString tc, int mg) : base(wp)
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_TEACHER_MIN_GAPS_BETWEEN_BUILDING_CHANGES;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->teacherName=tc;
		this.teacherName.CopyFrom(tc);
		this.minGapsBetweenBuildingChanges = mg;
	}

	public bool computeInternalStructure(QWidget parent, ref Rules r)
	{
		this.teacher_ID = r.searchTeacher(this.teacherName);

		if (this.teacher_ID < 0)
		{
			SpaceConstraintIrreconcilableMessage.warning(parent, tr("FET warning"), tr("Constraint teacher min gaps between building changes is wrong because it refers to inexistent teacher." + " Please correct it (removing it might be a solution). Please report potential bug. Constraint is:\n%1").arg(this.getDetailedDescription(ref r)));

			return false;
		}

		return true;
	}

	public bool hasInactiveActivities(ref Rules r)
	{
		Q_UNUSED(r);

		return false;
	}

	public QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintTeacherMinGapsBetweenBuildingChanges>\n";

		s += "	<Weight_Percentage>" + CustomFETString.number(weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Teacher>" + GlobalMembersTimetable_defs.protect(this.teacherName) + "</Teacher>\n";
		s += "	<Min_Gaps_Between_Building_Changes>" + CustomFETString.number(this.minGapsBetweenBuildingChanges) + "</Min_Gaps_Between_Building_Changes>\n";

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTeacherMinGapsBetweenBuildingChanges>\n";

		return s;
	}

	public QString getDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString begin = new QString("");
		if (!active)
			begin = "X - ";

		QString end = new QString("");
		if (!comments.isEmpty())
			end = ", " + tr("C: %1", "Comments").arg(comments);

		QString s = tr("Teacher min gaps between building changes");
		s += ", ";

		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";

		s += tr("T:%1", "T means teacher").arg(this.teacherName);
		s += ", ";

		s += tr("mG:%1", "mG means min gaps").arg(this.minGapsBetweenBuildingChanges);

		return begin + s + end;
	}

	public QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Space constraint");
		s += "\n";

		s += tr("Teacher minimum gaps between building changes");
		s += "\n";

		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		s += tr("Teacher=%1").arg(this.teacherName);
		s += "\n";

		s += tr("Minimum gaps between building changes=%1").arg(this.minGapsBetweenBuildingChanges);
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

	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl)
	{
		return fitness(ref c, ref r, ref cl, ref dl, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>& dl, QString* conflictsString =null)
	public double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrix roomsMatrix is already calculated, do not calculate it again!
		if (!c.roomsMatrixReady)
		{
			c.roomsMatrixReady = true;
			GlobalMembersSpaceconstraint.rooms_conflicts = c.getRoomsMatrix(ref r, ref GlobalMembersSpaceconstraint.roomsMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken = 0;

		int tch = this.teacher_ID;

		//Better, less memory
		Teacher tchpointer = r.internalTeachersList[tch];
		int[,] crtBuildingsTimetable = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK, GlobalMembersTimetable_defs.MAX_HOURS_PER_DAY];
		for (int d2 = 0; d2 < r.nDaysPerWeek; d2++)
			for (int h2 = 0; h2 < r.nHoursPerDay; h2++)
				crtBuildingsTimetable[d2, h2] = -1;

		foreach (int ai, tchpointer.activitiesForTeacher) if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
		{
				int d2 = c.times[ai] % r.nDaysPerWeek;
				int h2 = c.times[ai] / r.nDaysPerWeek;

				for (int dur = 0; dur < r.internalActivitiesList[ai].duration; dur++)
				{
					Debug.Assert(h2 + dur < r.nHoursPerDay);
					Debug.Assert(crtBuildingsTimetable[d2, h2 + dur] == -1);
					if (c.rooms[ai] != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM && c.rooms[ai] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
					{
						Debug.Assert(c.rooms[ai] >= 0 && c.rooms[ai] < r.nInternalRooms);
						crtBuildingsTimetable[d2, h2 + dur] = r.internalRoomsList[c.rooms[ai]].buildingIndex;
					}
				}
		}
		/////////////

		for (int d2 = 0; d2 < r.nDaysPerWeek; d2++)
		{
			int h2;
			for (h2 = 0; h2 < r.nHoursPerDay; h2++)
				if (crtBuildingsTimetable[d2, h2] != -1)
					break;

			int crt_building = -1;
			if (h2 < r.nHoursPerDay)
				crt_building = crtBuildingsTimetable[d2, h2];

			int cnt_gaps = 0;

			for (h2++; h2 < r.nHoursPerDay; h2++)
			{
				if (crtBuildingsTimetable[d2, h2] != -1)
				{
					if (crtBuildingsTimetable[d2, h2] == crt_building)
						cnt_gaps = 0;
					else
					{
						if (cnt_gaps < this.minGapsBetweenBuildingChanges)
						{
							nbroken++;

							if (conflictsString != null)
							{
								QString s = tr("Space constraint teacher min gaps between building changes broken for teacher=%1 on day %2").arg(this.teacherName).arg(r.daysOfTheWeek[d2]);
								s += ". ";
								s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100 * 1));

								dl.append(s);
								cl.append(weightPercentage / 100 * 1);

								conflictsString += s + "\n";
							}
						}

						crt_building = crtBuildingsTimetable[d2, h2];
						cnt_gaps = 0;
					}
				}
				else
					cnt_gaps++;
			}
		}

		if (this.weightPercentage == 100)
			Debug.Assert(nbroken == 0);

		return weightPercentage / 100 * nbroken;
	}

	public bool isRelatedToActivity(Activity a)
	{
		Q_UNUSED(a);

		return false;
	}

	public bool isRelatedToTeacher(Teacher t)
	{
		return this.teacherName == t.name;
	}

	public bool isRelatedToSubject(Subject s)
	{
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToActivityTag(ActivityTag s)
	{
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToStudentsSet(ref Rules r, StudentsSet s)
	{
		Q_UNUSED(r);
		Q_UNUSED(s);

		return false;
	}

	public bool isRelatedToRoom(Room r)
	{
		Q_UNUSED(r);

		return false;
	}

	public bool hasWrongDayOrHour(ref Rules r)
	{
		if (minGapsBetweenBuildingChanges > r.nHoursPerDay)
			return true;

		return false;
	}
	public bool canRepairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		return true;
	}
	public bool repairWrongDayOrHour(ref Rules r)
	{
		Debug.Assert(hasWrongDayOrHour(ref r));

		if (minGapsBetweenBuildingChanges > r.nHoursPerDay)
			minGapsBetweenBuildingChanges = r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintTeachersMinGapsBetweenBuildingChanges: SpaceConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintTeachersMinGapsBetweenBuildingChanges) public: int minGapsBetweenBuildingChanges;


	/////////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////////

	private ConstraintTeachersMinGapsBetweenBuildingChanges() : base()
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_TEACHERS_MIN_GAPS_BETWEEN_BUILDING_CHANGES;
	}

	private ConstraintTeachersMinGapsBetweenBuildingChanges(double wp, int mg) : base(wp)
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_TEACHERS_MIN_GAPS_BETWEEN_BUILDING_CHANGES;
		this.minGapsBetweenBuildingChanges = mg;
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

		QString s = "<ConstraintTeachersMinGapsBetweenBuildingChanges>\n";

		s += "	<Weight_Percentage>" + CustomFETString.number(weightPercentage) + "</Weight_Percentage>\n";
		s += "	<Min_Gaps_Between_Building_Changes>" + CustomFETString.number(this.minGapsBetweenBuildingChanges) + "</Min_Gaps_Between_Building_Changes>\n";

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintTeachersMinGapsBetweenBuildingChanges>\n";

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

		QString s = tr("Teachers min gaps between building changes");
		s += ", ";

		s += tr("WP:%1%", "Weight percentage").arg(CustomFETString.number(this.weightPercentage));
		s += ", ";

		s += tr("mG:%1", "mG means min gaps").arg(this.minGapsBetweenBuildingChanges);

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = tr("Space constraint");
		s += "\n";

		s += tr("Teachers minimum gaps between building changes");
		s += "\n";

		s += tr("Weight (percentage)=%1%").arg(CustomFETString.number(this.weightPercentage));
		s += "\n";

		s += tr("Minimum gaps between building changes=%1").arg(this.minGapsBetweenBuildingChanges);
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
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>& dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrix roomsMatrix is already calculated, do not calculate it again!
		if (!c.roomsMatrixReady)
		{
			c.roomsMatrixReady = true;
			GlobalMembersSpaceconstraint.rooms_conflicts = c.getRoomsMatrix(ref r, ref GlobalMembersSpaceconstraint.roomsMatrix);

			c.changedForMatrixCalculation = false;
		}

		int nbroken = 0;

		for (int tch = 0; tch < r.nInternalTeachers; tch++)
		{
			//Better, less memory
			Teacher tchpointer = r.internalTeachersList[tch];
			int[,] crtBuildingsTimetable = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK, GlobalMembersTimetable_defs.MAX_HOURS_PER_DAY];
			for (int d2 = 0; d2 < r.nDaysPerWeek; d2++)
				for (int h2 = 0; h2 < r.nHoursPerDay; h2++)
					crtBuildingsTimetable[d2, h2] = -1;

			foreach (int ai, tchpointer.activitiesForTeacher) if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
					int d2 = c.times[ai] % r.nDaysPerWeek;
					int h2 = c.times[ai] / r.nDaysPerWeek;

					for (int dur = 0; dur < r.internalActivitiesList[ai].duration; dur++)
					{
						Debug.Assert(h2 + dur < r.nHoursPerDay);
						Debug.Assert(crtBuildingsTimetable[d2, h2 + dur] == -1);
						if (c.rooms[ai] != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM && c.rooms[ai] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
						{
							Debug.Assert(c.rooms[ai] >= 0 && c.rooms[ai] < r.nInternalRooms);
							crtBuildingsTimetable[d2, h2 + dur] = r.internalRoomsList[c.rooms[ai]].buildingIndex;
						}
					}
			}
			/////////////

			for (int d2 = 0; d2 < r.nDaysPerWeek; d2++)
			{
				int h2;
				for (h2 = 0; h2 < r.nHoursPerDay; h2++)
					if (crtBuildingsTimetable[d2, h2] != -1)
						break;

				int crt_building = -1;
				if (h2 < r.nHoursPerDay)
					crt_building = crtBuildingsTimetable[d2, h2];

				int cnt_gaps = 0;

				for (h2++; h2 < r.nHoursPerDay; h2++)
				{
					if (crtBuildingsTimetable[d2, h2] != -1)
					{
						if (crtBuildingsTimetable[d2, h2] == crt_building)
							cnt_gaps = 0;
						else
						{
							if (cnt_gaps < this.minGapsBetweenBuildingChanges)
							{
								nbroken++;

								if (conflictsString != null)
								{
									QString s = tr("Space constraint teachers min gaps between building changes broken for teacher=%1 on day %2").arg(r.internalTeachersList[tch].name).arg(r.daysOfTheWeek[d2]);
									s += ". ";
									s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(weightPercentage / 100 * 1));

									dl.append(s);
									cl.append(weightPercentage / 100 * 1);

									conflictsString += s + "\n";
								}
							}

							crt_building = crtBuildingsTimetable[d2, h2];
							cnt_gaps = 0;
						}
					}
					else
						cnt_gaps++;
				}
			}
		}

		if (this.weightPercentage == 100)
			Debug.Assert(nbroken == 0);

		return weightPercentage / 100 * nbroken;
	}

	private bool isRelatedToActivity(Activity a)
	{
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

	private bool isRelatedToRoom(Room r)
	{
		Q_UNUSED(r);

		return false;
	}

	private bool hasWrongDayOrHour(ref Rules r)
	{
		if (minGapsBetweenBuildingChanges > r.nHoursPerDay)
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

		if (minGapsBetweenBuildingChanges > r.nHoursPerDay)
			minGapsBetweenBuildingChanges = r.nHoursPerDay;

		return true;
	}
}

public abstract class ConstraintActivitiesOccupyMaxDifferentRooms: SpaceConstraint
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(ConstraintActivitiesOccupyMaxDifferentRooms) public: QList<int> activitiesIds;

	private int maxDifferentRooms;

	//internal variables
	private QList<int> _activitiesIndices = new QList<int>();


	//////////////////////////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////////////////////////

	private ConstraintActivitiesOccupyMaxDifferentRooms() : base()
	{
		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITIES_OCCUPY_MAX_DIFFERENT_ROOMS;
	}

	private ConstraintActivitiesOccupyMaxDifferentRooms(double wp, QList<int> a_L, int max_different_rooms) : base(wp)
	{
		this.activitiesIds = a_L;
		this.maxDifferentRooms = max_different_rooms;

		this.type = GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITIES_OCCUPY_MAX_DIFFERENT_ROOMS;
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

		///////////////////////

		if (this._activitiesIndices.count() < 2)
		{
			SpaceConstraintIrreconcilableMessage.warning(parent, tr("FET error in data"), tr("Following constraint is wrong (refers to less than two activities). Please correct it:\n%1").arg(this.getDetailedDescription(ref r)));
			return false;
		}
		else
		{
			Debug.Assert(this._activitiesIndices.count() >= 2);
			return true;
		}
	}

	private bool hasInactiveActivities(ref Rules r)
	{
		//returns true if all or all but one activities are inactive

		int cnt = 0;
		foreach (int aid, this.activitiesIds) if (r.inactiveActivities.contains(aid)) cnt++;

		if (this.activitiesIds.count() >= 2 && (cnt == this.activitiesIds.count() || cnt == this.activitiesIds.count() - 1))
			return true;
		else
			return false;
	}

	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<ConstraintActivitiesOccupyMaxDifferentRooms>\n";

		s += "	<Weight_Percentage>" + CustomFETString.number(this.weightPercentage) + "</Weight_Percentage>\n";

		s += "	<Number_of_Activities>" + CustomFETString.number(this.activitiesIds.count()) + "</Number_of_Activities>\n";
		foreach (int aid, this.activitiesIds) s += "	<Activity_Id>" + CustomFETString.number(aid) + "</Activity_Id>\n";

		s += "	<Max_Number_of_Different_Rooms>" + CustomFETString.number(this.maxDifferentRooms) + "</Max_Number_of_Different_Rooms>\n";

		s += "	<Active>" + GlobalMembersSpaceconstraint.trueFalse(active) + "</Active>\n";
		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";
		s += "</ConstraintActivitiesOccupyMaxDifferentRooms>\n";
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

		QString actids = new QString("");
		foreach (int aid, this.activitiesIds) actids += CustomFETString.number(aid) + new QString(", ");
		actids.chop(2);

		QString s = tr("Activities occupy max different rooms, WP:%1, NA:%2, A: %3, MDR:%4", "Constraint description. WP means weight percentage, " + "NA means the number of activities, A means activities list, MDR means max different rooms").arg(CustomFETString.number(this.weightPercentage)).arg(CustomFETString.number(this.activitiesIds.count())).arg(actids).arg(CustomFETString.number(this.maxDifferentRooms));

		return begin + s + end;
	}

	private QString getDetailedDescription(ref Rules r)
	{
		QString actids = new QString("");
		foreach (int aid, this.activitiesIds) actids += CustomFETString.number(aid) + new QString(", ");
		actids.chop(2);

		QString s = tr("Space constraint");
		s += "\n";
		s += tr("Activities occupy max different rooms");
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
		s += tr("Maximum number of different rooms=%1").arg(CustomFETString.number(this.maxDifferentRooms));
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
//ORIGINAL LINE: double fitness(Solution& c, Rules& r, QList<double>& cl, QList<QString>& dl, QString* conflictsString =null)
	private double fitness(ref Solution c, ref Rules r, ref QList<double> cl, ref QList<QString> dl, QString conflictsString)
	{
		//if the matrix roomsMatrix is already calculated, do not calculate it again!
		if (!c.roomsMatrixReady)
		{
			c.roomsMatrixReady = true;
			GlobalMembersSpaceconstraint.rooms_conflicts = c.getRoomsMatrix(ref r, ref GlobalMembersSpaceconstraint.roomsMatrix);

			c.changedForMatrixCalculation = false;
		}

		//Calculates the number of conflicts

		int nbroken = 0;

		QSet<int> usedRooms = new QSet<int>();

		foreach (int ai, this._activitiesIndices)
		{
			if (c.rooms[ai] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE && c.rooms[ai] != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM)
				if (!usedRooms.contains(c.rooms[ai]))
					usedRooms.insert(c.rooms[ai]);
		}

		if (usedRooms.count() > this.maxDifferentRooms)
		{
			nbroken = 1;

			if (conflictsString != null)
			{
				QString s = tr("Space constraint activities occupy max different rooms broken");
				s += new QString(". ");
				s += tr("This increases the conflicts total by %1").arg(CustomFETString.number(nbroken * weightPercentage / 100));

				dl.append(s);
				cl.append(nbroken * weightPercentage / 100);

				conflictsString += s + "\n";
			}
		}

		if (this.weightPercentage == 100)
			Debug.Assert(nbroken == 0);

		return nbroken * weightPercentage / 100;
	}

	private void removeUseless(ref Rules r)
	{
		QSet<int> validActs = new QSet<int>();

		foreach (Activity * act, r.activitiesList) validActs.insert(act.id);

		QList<int> newActs = new QList<int>();

		foreach (int aid, activitiesIds) if (validActs.contains(aid)) newActs.append(aid);

		activitiesIds = newActs;
	}

	private bool isRelatedToActivity(Activity a)
	{
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

	private bool isRelatedToRoom(Room r)
	{
		Q_UNUSED(r);

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

//////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////

//C++ TO C# CONVERTER WARNING: The declaration of the following method implementation was not found:
//ORIGINAL LINE: SpaceConstraint::SpaceConstraint()

//C++ TO C# CONVERTER WARNING: The declaration of the following method implementation was not found:
//ORIGINAL LINE: SpaceConstraint::~SpaceConstraint()

//C++ TO C# CONVERTER WARNING: The declaration of the following method implementation was not found:
//ORIGINAL LINE: SpaceConstraint::SpaceConstraint(double wp)

//////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////

//C++ TO C# CONVERTER WARNING: The declaration of the following method implementation was not found:
//ORIGINAL LINE: ConstraintBasicCompulsorySpace::ConstraintBasicCompulsorySpace() : SpaceConstraint()

//////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////


public partial class SpaceConstraint
{
	public SpaceConstraint()
	{
		type = CONSTRAINT_GENERIC_SPACE;
    
		active = true;
		comments = new QString("");
	}
	public void Dispose()
	{
	}
	public SpaceConstraint(double wp)
	{
		type = CONSTRAINT_GENERIC_SPACE;
    
		weightPercentage = wp;
		Debug.Assert(wp <= 100 && wp >= 0);
    
		active = true;
		comments = new QString("");
	}
}

public partial class ConstraintBasicCompulsorySpace
{
	public ConstraintBasicCompulsorySpace()
	{
		SpaceConstraint = new <type missing>();
		this.type = CONSTRAINT_BASIC_COMPULSORY_SPACE;
		this.weightPercentage = 100;
	}
}