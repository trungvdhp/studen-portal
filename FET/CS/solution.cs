using System.Diagnostics;

public static class GlobalMembersSolution
{





	//extern bool breakDayHour[MAX_DAYS_PER_WEEK][MAX_HOURS_PER_DAY];
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Matrix2D<bool> breakDayHour;
	//extern bool teacherNotAvailableDayHour[MAX_TEACHERS][MAX_DAYS_PER_WEEK][MAX_HOURS_PER_DAY];
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Matrix3D<bool> teacherNotAvailableDayHour;
}

/*
File solution.cpp
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

//Teachers free periods code contributed by Volker Dirr (http://timetabling.de/)



#if NDEBUG
#endif
/*
File solution.h
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

/**
This class represents a solution (time and space allocation for the activities).
*/
public class Solution
{
	public QList<double> conflictsWeightList = new QList<double>();
	public QList<QString> conflictsDescriptionList = new QList<QString>();
	public double conflictsTotal;

	public bool teachersMatrixReady;
	public bool subgroupsMatrixReady;
	public bool roomsMatrixReady;

	public int nPlacedActivities;

	/*
	You will need to set this to true if altering the times array values.
	The conflicts calculating routine will reset this to false
	at the first teachers matrix and subgroups matrix calculation.
	*/
	public bool changedForMatrixCalculation;

	/**
	This array represents every activity's start time
	(time is a unified representation of hour and day,
	stored as an integer value). We have a special value here:
	UNALLOCATED_TIME, which is a large number.
	*/
	public qint16[] times = new qint16[MAX_ACTIVITIES];

	public qint16[] rooms = new qint16[MAX_ACTIVITIES];

	/**
	Fitness; it is calculated only at the initialization or
	at the modification.
	Important assumption: the rules have to ramain the same;
	otherwise the user has to reset this value to -1
	*/
	public double _fitness;

	/**
	Assignment method. We need to have access to the Rules instantiation
	to know the number of activities.
	*/

	//critical function here - must be optimized for speed
	public void copy(ref Rules r, ref Solution c)
	{
		this._fitness = c._fitness;

		Debug.Assert(r.internalStructureComputed);

		for (int i = 0; i < r.nInternalActivities; i++)
		{
			this.times[i] = c.times[i];
			this.rooms[i] = c.rooms[i];
		}
		//memcpy(times, c.times, r.nActivities * sizeof(times[0]));

		this.changedForMatrixCalculation = c.changedForMatrixCalculation;

		//added in version 5.2.0
		conflictsWeightList = c.conflictsWeightList;
		conflictsDescriptionList = c.conflictsDescriptionList;
		conflictsTotal = c.conflictsTotal;

		teachersMatrixReady = c.teachersMatrixReady;
		subgroupsMatrixReady = c.subgroupsMatrixReady;
		roomsMatrixReady = c.roomsMatrixReady;

		nPlacedActivities = c.nPlacedActivities;
	}

	/**
	Initializes, marking all activities as unscheduled (time)
	*/
	public void init(ref Rules r)
	{
		Debug.Assert(r.internalStructureComputed);

		for (int i = 0; i < r.nInternalActivities; i++)
		{
			this.times[i] = GlobalMembersTimetable_defs.UNALLOCATED_TIME;
			this.rooms[i] = GlobalMembersTimetable_defs.UNALLOCATED_SPACE;
		}

		this._fitness = -1;

		this.changedForMatrixCalculation = true;
	}

	/**
	Marks the starting time of all the activities as undefined
	(all activities are unallocated).
	*/
	public void makeUnallocated(ref Rules r)
	{
		Debug.Assert(r.initialized);
		Debug.Assert(r.internalStructureComputed);

		for (int i = 0; i < r.nInternalActivities; i++)
		{
			this.times[i] = GlobalMembersTimetable_defs.UNALLOCATED_TIME;
			this.rooms[i] = GlobalMembersTimetable_defs.UNALLOCATED_SPACE;
		}

		this._fitness = -1;

		this.changedForMatrixCalculation = true;
	}

	/**
	ATTENTION: if the rules change, the user has to reset _fitness to -1
	<p>
	If conflictsString is not null, then this function will
	append at this string an explanation of the conflicts.
	*/
	public double fitness(ref Rules r)
	{
		return fitness(ref r, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: double fitness(Rules& r, QString* conflictsString =null)
	public double fitness(ref Rules r, QString conflictsString)
	{
		Debug.Assert(r.initialized);
		Debug.Assert(r.internalStructureComputed);

		if (this._fitness >= 0)
			Debug.Assert(this.changedForMatrixCalculation == false);

		if (this._fitness >= 0 && conflictsString == null)
		//If you want to see the log, you have to recompute the fitness, even if it is
		//already computed
			return this._fitness;

		this.changedForMatrixCalculation = true;

		this._fitness = 0;
		//I AM NOT SURE IF THE COMMENT BELOW IS DEPRECATED/FALSE NOW (IT IS OLD).
		//here we must not have compulsory activity preferred time nor
		//compulsory activities same time and/or hour
		//Also, here I compute soft fitness (for faster results,
		//I do not want to pass again through the constraints)

		this.conflictsDescriptionList.clear();
		this.conflictsWeightList.clear();

		this.teachersMatrixReady = false;
		this.subgroupsMatrixReady = false;
		this.roomsMatrixReady = false;

		this.nPlacedActivities = 0;
		for (int i = 0; i < r.nInternalActivities; i++)
			if (this.times[i] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				this.nPlacedActivities++;

		for (int i = 0; i < r.nInternalTimeConstraints; i++)
		{
			QList<QString> sl = new QList<QString>();
			QList<double> cl = new QList<double>();
			this._fitness += r.internalTimeConstraintsList[i].fitness(this, r, cl, sl, conflictsString);

			conflictsWeightList += cl;
			conflictsDescriptionList += sl;
		}
		for (int i = 0; i < r.nInternalSpaceConstraints; i++)
		{
			QList<QString> sl = new QList<QString>();
			QList<double> cl = new QList<double>();
			this._fitness += r.internalSpaceConstraintsList[i].fitness(this, r, cl, sl, conflictsString);
			conflictsWeightList += cl;
			conflictsDescriptionList += sl;
		}

		this.conflictsTotal = 0;
		foreach (double cn, conflictsWeightList)
		{
			//cout<<"cn=="<<cn<<endl;
			conflictsTotal += cn;
		}

#if false
	//	//I cannot put this test. I got situations of assert failed with 15.2 != 15.2 ??? Maybe rounding errors
	//	if(this->_fitness!=conflictsTotal){
	//		cout<<"this->_fitness=="<<this->_fitness<<endl;
	//		cout<<"conflictsTotal=="<<conflictsTotal<<endl;
	//	}
	//	assert(this->_fitness==conflictsTotal);//TODO
#endif

		//sort descending according to conflicts in O(n log n)
		int ttt = conflictsWeightList.count();

		QMultiMap<double, QString> map = new QMultiMap<double, QString>();
		Debug.Assert(conflictsWeightList.count() == conflictsDescriptionList.count());
		for (int i = 0; i < conflictsWeightList.count(); i++)
			map.insert(conflictsWeightList.at(i), conflictsDescriptionList.at(i));

		conflictsWeightList.clear();
		conflictsDescriptionList.clear();

		QMapIterator<double, QString> i = new QMapIterator<double, QString>(map);
		while (i.hasNext())
		{
			i.next();
			conflictsWeightList.prepend(i.key());
			conflictsDescriptionList.prepend(i.value());
		}

		for (int i = 0; i < conflictsWeightList.count() - 1; i++)
			Debug.Assert(conflictsWeightList.at(i) >= conflictsWeightList.at(i + 1));

		Debug.Assert(conflictsWeightList.count() == conflictsDescriptionList.count());
		Debug.Assert(conflictsWeightList.count() == ttt);

		this.changedForMatrixCalculation = false;

		return this._fitness;
	}


	//The following 2 functions (GetTeachersTimetable & GetSubgroupsTimetable)
	//are very similar to the above 2 ones (GetTeachersMatrix & GetSubgroupsMatrix)
	public void getTeachersTimetable(ref Rules r, ref Matrix3D<qint16> a, ref Matrix3D<QList<qint16>> b)
	{
		Debug.Assert(r.initialized);
		Debug.Assert(r.internalStructureComputed);

		a.resize(r.nInternalTeachers, r.nDaysPerWeek, r.nHoursPerDay);
		b.resize(GlobalMembersTimetable_defs.TEACHERS_FREE_PERIODS_N_CATEGORIES, r.nDaysPerWeek, r.nHoursPerDay);

		int i;
		int j;
		int k;
		for (i = 0; i < r.nInternalTeachers; i++)
			for (j = 0; j < r.nDaysPerWeek; j++)
				for (k = 0; k < r.nHoursPerDay; k++)
					a[i][j][k] = GlobalMembersTimetable_defs.UNALLOCATED_ACTIVITY;

		Activity act;
		for (i = 0; i < r.nInternalActivities; i++)
			if (this.times[i] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
				act = r.internalActivitiesList[i];
				int hour = this.times[i] / r.nDaysPerWeek;
				int day = this.times[i] % r.nDaysPerWeek;
				for (int dd = 0; dd < act.duration; dd++)
				{
					Debug.Assert(hour + dd < r.nHoursPerDay);
					for (int ti = 0; ti < act.iTeachersList.count(); ti++)
					{
						int tch = act.iTeachersList.at(ti); //teacher index
						Debug.Assert(a[tch][day][hour + dd] == GlobalMembersTimetable_defs.UNALLOCATED_ACTIVITY);
						a[tch][day][hour + dd] = i;
					}
				}
			}

		//Prepare teachers free periods timetable.
		//Code contributed by Volker Dirr (http://timetabling.de/) BEGIN
		int d;
		int h;
		int tch;
		for (d = 0; d < r.nDaysPerWeek; d++)
		{
			for (h = 0; h < r.nHoursPerDay; h++)
			{
				for (int tfp = 0; tfp < GlobalMembersTimetable_defs.TEACHERS_FREE_PERIODS_N_CATEGORIES; tfp++)
				{
					b[tfp][d][h].clear();
				}
			}
		}
		for (tch = 0; tch < r.nInternalTeachers; tch++)
		{
			for (d = 0; d < r.nDaysPerWeek; d++)
			{
				int firstPeriod = -1;
				int lastPeriod = -1;
				for (h = 0; h < r.nHoursPerDay; h++)
				{
					if (a[tch][d][h] != GlobalMembersTimetable_defs.UNALLOCATED_ACTIVITY)
					{
						if (firstPeriod == -1)
							firstPeriod = h;
						lastPeriod = h;
					}
				}
				if (firstPeriod == -1)
				{
					for (h = 0; h < r.nHoursPerDay; h++)
					{
						b[GlobalMembersTimetable_defs.TEACHER_HAS_A_FREE_DAY][d][h] << tch;
					}
				}
				else
				{
					for (h = 0; h < firstPeriod; h++)
					{
						if (firstPeriod - h == 1)
						{
							b[GlobalMembersTimetable_defs.TEACHER_MUST_COME_EARLIER][d][h] << tch;
						}
						else
						{
							b[GlobalMembersTimetable_defs.TEACHER_MUST_COME_MUCH_EARLIER][d][h] << tch;
						}
					}
					for (; h < lastPeriod + 1; h++)
					{
						if (a[tch][d][h] == GlobalMembersTimetable_defs.UNALLOCATED_ACTIVITY)
						{
							if (a[tch][d][h + 1] == GlobalMembersTimetable_defs.UNALLOCATED_ACTIVITY)
							{
								if (a[tch][d][h - 1] == GlobalMembersTimetable_defs.UNALLOCATED_ACTIVITY)
								{
									b[GlobalMembersTimetable_defs.TEACHER_HAS_BIG_GAP][d][h] << tch;
								}
								else
								{
									b[GlobalMembersTimetable_defs.TEACHER_HAS_BORDER_GAP][d][h] << tch;
								}
							}
							else
							{
								if (a[tch][d][h - 1] == GlobalMembersTimetable_defs.UNALLOCATED_ACTIVITY)
								{
									b[GlobalMembersTimetable_defs.TEACHER_HAS_BORDER_GAP][d][h] << tch;
								}
								else
								{
									b[GlobalMembersTimetable_defs.TEACHER_HAS_SINGLE_GAP][d][h] << tch;
								}
							}
						}
					}
					for (; h < r.nHoursPerDay; h++)
					{
						if (lastPeriod - h == -1)
						{
							b[GlobalMembersTimetable_defs.TEACHER_MUST_STAY_LONGER][d][h] << tch;
						}
						else
						{
							b[GlobalMembersTimetable_defs.TEACHER_MUST_STAY_MUCH_LONGER][d][h] << tch;
						}
					}
				}
			}
		}
		//care about not available teacher and breaks
		for (tch = 0; tch < r.nInternalTeachers; tch++)
		{
			for (d = 0; d < r.nDaysPerWeek; d++)
			{
				for (h = 0; h < r.nHoursPerDay; h++)
				{
					if (GlobalMembersGenerate_pre.teacherNotAvailableDayHour[tch][d][h] == true || GlobalMembersGenerate_pre.breakDayHour[d][h] == true)
					{
						int removed = 0;
						for (int tfp = 0; tfp < GlobalMembersTimetable_defs.TEACHER_IS_NOT_AVAILABLE; tfp++)
						{
							if (b[tfp][d][h].contains(tch))
							{
								removed += b[tfp][d][h].removeAll(tch);
								if (GlobalMembersGenerate_pre.breakDayHour[d][h] == false)
									b[GlobalMembersTimetable_defs.TEACHER_IS_NOT_AVAILABLE][d][h] << tch;
							}
						}
						Debug.Assert(removed == 1);
					}
				}
			}
		}
		//END of Code contributed by Volker Dirr (http://timetabling.de/) END
		//bool visited[MAX_TEACHERS];
		Matrix1D<bool> visited = new Matrix1D<bool>();
		visited.resize(r.nInternalTeachers);
		for (d = 0; d < r.nDaysPerWeek; d++)
		{
			for (h = 0; h < r.nHoursPerDay; h++)
			{
				for (tch = 0; tch < r.nInternalTeachers; tch++)
					visited[tch] = false;
				for (int tfp = 0; tfp < GlobalMembersTimetable_defs.TEACHERS_FREE_PERIODS_N_CATEGORIES; tfp++)
				{
					foreach (int tch, b[tfp][d][h])
					{
						Debug.Assert(!visited[tch]);
						visited[tch] = true;
					}
				}
			}
		}
	}
	//return value is the number of conflicts, which must be 0

	public void getSubgroupsTimetable(ref Rules r, ref Matrix3D<qint16> a)
	{
		Debug.Assert(r.initialized);
		Debug.Assert(r.internalStructureComputed);

		a.resize(r.nInternalSubgroups, r.nDaysPerWeek, r.nHoursPerDay);

		int i;
		int j;
		int k;
		for (i = 0; i < r.nInternalSubgroups; i++)
			for (j = 0; j < r.nDaysPerWeek; j++)
				for (k = 0; k < r.nHoursPerDay; k++)
					a[i][j][k] = GlobalMembersTimetable_defs.UNALLOCATED_ACTIVITY;

		Activity act;
		for (i = 0; i < r.nInternalActivities; i++)
			if (this.times[i] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
				act = r.internalActivitiesList[i];
				int hour = this.times[i] / r.nDaysPerWeek;
				int day = this.times[i] % r.nDaysPerWeek;
				for (int dd = 0; dd < act.duration; dd++)
				{
					Debug.Assert(hour + dd < r.nHoursPerDay);

					for (int isg = 0; isg < act.iSubgroupsList.count(); isg++) //isg -> index subgroup
					{
						int sg = act.iSubgroupsList.at(isg); //sg -> subgroup
						Debug.Assert(a[sg][day][hour + dd] == GlobalMembersTimetable_defs.UNALLOCATED_ACTIVITY);
						a[sg][day][hour + dd] = i;
					}
				}
			}
	}
	//return value is the number of conflicts, which must be 0

	public void getRoomsTimetable(ref Rules r, ref Matrix3D<qint16> a)
	{
		Debug.Assert(r.initialized);
		Debug.Assert(r.internalStructureComputed);

		a.resize(r.nInternalRooms, r.nDaysPerWeek, r.nHoursPerDay);

		int i;
		int j;
		int k;
		for (i = 0; i < r.nInternalRooms; i++)
			for (j = 0; j < r.nDaysPerWeek; j++)
				for (k = 0; k < r.nHoursPerDay; k++)
					a[i][j][k] = GlobalMembersTimetable_defs.UNALLOCATED_ACTIVITY;

		Activity act;
		for (i = 0; i < r.nInternalActivities; i++)
		{
			act = r.internalActivitiesList[i];
			int room = this.rooms[i];
			int hour = times[i] / r.nDaysPerWeek;
			int day = times[i] % r.nDaysPerWeek;
			if (room != GlobalMembersTimetable_defs.UNALLOCATED_SPACE && room != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM && day != GlobalMembersTimetable_defs.UNALLOCATED_TIME && hour != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
				for (int dd = 0; dd < act.duration; dd++)
				{
					Debug.Assert(hour + dd < r.nHoursPerDay);

					Debug.Assert(a[room][day][hour + dd] == GlobalMembersTimetable_defs.UNALLOCATED_ACTIVITY);
					a[room][day][hour + dd] = i;
				}
			}
		}
	}
	//return value is the number of conflicts, which must be 0

	public int getSubgroupsMatrix(ref Rules r, ref Matrix3D<qint8> a)
	{
		Debug.Assert(r.initialized);
		Debug.Assert(r.internalStructureComputed);

		int conflicts = 0;

		a.resize(r.nInternalSubgroups, r.nDaysPerWeek, r.nHoursPerDay);

		int i;
		for (i = 0; i < r.nInternalSubgroups; i++)
			for (int j = 0; j < r.nDaysPerWeek; j++)
				for (int k = 0; k < r.nHoursPerDay; k++)
					a[i][j][k] = 0;

		for (i = 0; i < r.nInternalActivities; i++)
			if (this.times[i] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
				int hour = this.times[i] / r.nDaysPerWeek;
				int day = this.times[i] % r.nDaysPerWeek;
				Activity act = r.internalActivitiesList[i];
				for (int dd = 0; dd < act.duration && hour + dd < r.nHoursPerDay; dd++)
					for (int isg = 0; isg < act.iSubgroupsList.count(); isg++) //isg => index subgroup
					{
						int sg = act.iSubgroupsList.at(isg); //sg => subgroup
						int tmp = a[sg][day][hour + dd];
						conflicts += tmp == 0 ? 0 : 1;
						a[sg][day][hour + dd]++;
					}
			}

		this.changedForMatrixCalculation = false;

		return conflicts;
	}

	public int getTeachersMatrix(ref Rules r, ref Matrix3D<qint8> a)
	{
		Debug.Assert(r.initialized);
		Debug.Assert(r.internalStructureComputed);

		int conflicts = 0;

		a.resize(r.nInternalTeachers, r.nDaysPerWeek, r.nHoursPerDay);

		int i;
		for (i = 0; i < r.nInternalTeachers; i++)
			for (int j = 0; j < r.nDaysPerWeek; j++)
				for (int k = 0; k < r.nHoursPerDay; k++)
					a[i][j][k] = 0;

		for (i = 0; i < r.nInternalActivities; i++)
			if (this.times[i] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
				int hour = this.times[i] / r.nDaysPerWeek;
				int day = this.times[i] % r.nDaysPerWeek;
				Activity act = r.internalActivitiesList[i];
				for (int dd = 0; dd < act.duration && hour + dd < r.nHoursPerDay; dd++)
					for (int it = 0; it < act.iTeachersList.count(); it++)
					{
						int tch = act.iTeachersList.at(it);
						int tmp = a[tch][day][hour + dd];
						conflicts += tmp == 0 ? 0 : 1;
						a[tch][day][hour + dd]++;
					}
			}

		this.changedForMatrixCalculation = false;

		return conflicts;
	}

	public int getRoomsMatrix(ref Rules r, ref Matrix3D<qint8> a)
	{
		Debug.Assert(r.initialized);
		Debug.Assert(r.internalStructureComputed);

		int conflicts = 0;

		a.resize(r.nInternalRooms, r.nDaysPerWeek, r.nHoursPerDay);

		int i;
		for (i = 0; i < r.nInternalRooms; i++)
			for (int j = 0; j < r.nDaysPerWeek; j++)
				for (int k = 0; k < r.nHoursPerDay; k++)
					a[i][j][k] = 0;

		for (i = 0; i < r.nInternalActivities; i++)
		{
			int room = this.rooms[i];
			int hour = times[i] / r.nDaysPerWeek;
			int day = times[i] % r.nDaysPerWeek;
			//int hour = hours[i];
			//int day = days[i];
			if (room != GlobalMembersTimetable_defs.UNALLOCATED_SPACE && room != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM && hour != GlobalMembersTimetable_defs.UNALLOCATED_TIME && day != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
				Activity act = r.internalActivitiesList[i];
				for (int dd = 0; dd < act.duration && hour + dd < r.nHoursPerDay; dd++)
				{
					int tmp = a[room][day][hour + dd];
					conflicts += tmp == 0 ? 0 : 1;
					a[room][day][hour + dd]++;
				}
			}
		}

		this.changedForMatrixCalculation = false;

		return conflicts;
	}
}
