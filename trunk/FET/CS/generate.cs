using System.Diagnostics;
using System;

public static class GlobalMembersGenerate
{

	//a probabilistic function to say if we can skip a constraint based on its percentage weight
	public static bool skipRandom(double weightPercentage)
	{
		if (weightPercentage < 0)
			return true; //non-existing constraint

		if (weightPercentage >= 100.0)
			return false;

		double t = weightPercentage / 100.0;
		Debug.Assert(t >= 0 && t <= 1);

		t *= (double)GlobalMembersTimetable_defs.MM;
		int tt = Math.Floor(t + 0.5);
		Debug.Assert(tt >= 0 && tt <= GlobalMembersTimetable_defs.MM);

		int r = GlobalMembersTimetable_defs.randomKnuth1MM1();
		Debug.Assert(r > 0 && r < GlobalMembersTimetable_defs.MM); //r cannot be 0
		if (tt <= r)
			return true;
		else
			return false;
	}

	//for sorting slots in ascending order of potential conflicts
	public static bool compareFunctionGenerate(int i, int j)
	{
		if (nConflActivitiesL[currentLevel, i] < nConflActivitiesL[currentLevel, j] || (nConflActivitiesL[currentLevel, i] == nConflActivitiesL[currentLevel, j] && nMinDaysBrokenL[currentLevel, i] < nMinDaysBrokenL[currentLevel, j]))
			return true;

		return false;
	}









//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern QMutex mutex; //timetablegenerateform.cpp

	#if ! FET_COMMAND_LINE
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern QSemaphore semaphorePlacedActivity;
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern QSemaphore finishedSemaphore;
	#else
	public static QSemaphore semaphorePlacedActivity = new QSemaphore();
	public static QSemaphore finishedSemaphore = new QSemaphore();
	#endif

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Timetable gt;

	internal static bool[] swappedActivities = new bool[MAX_ACTIVITIES];

	internal static bool foundGoodSwap;

	//not sure, it might be necessary 2*... or even more
	internal static int[] restoreActIndex = new int[4 * MAX_ACTIVITIES]; //the index of the act. to restore
	internal static int[] restoreTime = new int[4 * MAX_ACTIVITIES]; //the time when to restore
	internal static int[] restoreRoom = new int[4 * MAX_ACTIVITIES]; //the time when to restore
	internal static int nRestore;

	internal static int limitcallsrandomswap;

	public const int MAX_LEVEL = 31;

	public const int LEVEL_STOP_CONFLICTS_CALCULATION = MAX_LEVEL;

	internal static int level_limit;

	internal static int ncallsrandomswap;
	internal static int maxncallsrandomswap;

	public static Solution highestStageSolution = new Solution();


	//if level==0, choose best position with lowest number
	//of conflicting activities
	internal static QList<int> conflActivitiesTimeSlot = new QList<int>();
	internal static int timeSlot;
	internal static int roomSlot;


	//int triedRemovals[MAX_ACTIVITIES][MAX_HOURS_PER_WEEK];
	internal static Matrix2D<int> triedRemovals = new Matrix2D<int>();

	internal static bool impossibleActivity;

	internal static int[] invPermutation = new int[MAX_ACTIVITIES];

	public const int INF = 2000000000;


	////////tabu list of tried removals (circular)
	//const int MAX_TABU=MAX_ACTIVITIES*MAX_HOURS_PER_WEEK;
	internal static int tabu_size;
	internal static int crt_tabu_index;
	/*qint16 tabu_activities[MAX_TABU];
	qint16 tabu_times[MAX_TABU];*/
	internal static Matrix1D<qint16> tabu_activities = new Matrix1D<qint16>();
	internal static Matrix1D<qint16> tabu_times = new Matrix1D<qint16>();
	////////////

	/*static qint16 teachersTimetable[MAX_TEACHERS][MAX_DAYS_PER_WEEK][MAX_HOURS_PER_DAY];
	static qint16 subgroupsTimetable[MAX_TOTAL_SUBGROUPS][MAX_DAYS_PER_WEEK][MAX_HOURS_PER_DAY];
	static qint16 roomsTimetable[MAX_ROOMS][MAX_DAYS_PER_WEEK][MAX_HOURS_PER_DAY];*/
	internal static Matrix3D<qint16> teachersTimetable = new Matrix3D<qint16>();
	internal static Matrix3D<qint16> subgroupsTimetable = new Matrix3D<qint16>();
	internal static Matrix3D<qint16> roomsTimetable = new Matrix3D<qint16>();


	/*static qint16 newTeachersTimetable[MAX_TEACHERS][MAX_DAYS_PER_WEEK][MAX_HOURS_PER_DAY];
	static qint16 newSubgroupsTimetable[MAX_TOTAL_SUBGROUPS][MAX_DAYS_PER_WEEK][MAX_HOURS_PER_DAY];
	static qint16 newTeachersDayNHours[MAX_TEACHERS][MAX_DAYS_PER_WEEK];
	static qint16 newTeachersDayNGaps[MAX_TEACHERS][MAX_DAYS_PER_WEEK];
	static qint16 newSubgroupsDayNHours[MAX_TOTAL_SUBGROUPS][MAX_DAYS_PER_WEEK];
	static qint16 newSubgroupsDayNGaps[MAX_TOTAL_SUBGROUPS][MAX_DAYS_PER_WEEK];
	static qint16 newSubgroupsDayNFirstGaps[MAX_TOTAL_SUBGROUPS][MAX_DAYS_PER_WEEK];*/
	internal static Matrix3D<qint16> newTeachersTimetable = new Matrix3D<qint16>();
	internal static Matrix3D<qint16> newSubgroupsTimetable = new Matrix3D<qint16>();
	internal static Matrix2D<qint16> newTeachersDayNHours = new Matrix2D<qint16>();
	internal static Matrix2D<qint16> newTeachersDayNGaps = new Matrix2D<qint16>();
	internal static Matrix2D<qint16> newSubgroupsDayNHours = new Matrix2D<qint16>();
	internal static Matrix2D<qint16> newSubgroupsDayNGaps = new Matrix2D<qint16>();
	internal static Matrix2D<qint16> newSubgroupsDayNFirstGaps = new Matrix2D<qint16>();


	/*static qint16 oldTeachersTimetable[MAX_TEACHERS][MAX_DAYS_PER_WEEK][MAX_HOURS_PER_DAY];
	static qint16 oldSubgroupsTimetable[MAX_TOTAL_SUBGROUPS][MAX_DAYS_PER_WEEK][MAX_HOURS_PER_DAY];
	static qint16 oldTeachersDayNHours[MAX_TEACHERS][MAX_DAYS_PER_WEEK];
	static qint16 oldTeachersDayNGaps[MAX_TEACHERS][MAX_DAYS_PER_WEEK];
	static qint16 oldSubgroupsDayNHours[MAX_TOTAL_SUBGROUPS][MAX_DAYS_PER_WEEK];
	static qint16 oldSubgroupsDayNGaps[MAX_TOTAL_SUBGROUPS][MAX_DAYS_PER_WEEK];
	static qint16 oldSubgroupsDayNFirstGaps[MAX_TOTAL_SUBGROUPS][MAX_DAYS_PER_WEEK];*/
	internal static Matrix3D<qint16> oldTeachersTimetable = new Matrix3D<qint16>();
	internal static Matrix3D<qint16> oldSubgroupsTimetable = new Matrix3D<qint16>();
	internal static Matrix2D<qint16> oldTeachersDayNHours = new Matrix2D<qint16>();
	internal static Matrix2D<qint16> oldTeachersDayNGaps = new Matrix2D<qint16>();
	internal static Matrix2D<qint16> oldSubgroupsDayNHours = new Matrix2D<qint16>();
	internal static Matrix2D<qint16> oldSubgroupsDayNGaps = new Matrix2D<qint16>();
	internal static Matrix2D<qint16> oldSubgroupsDayNFirstGaps = new Matrix2D<qint16>();


	/*static qint16 tchTimetable[MAX_DAYS_PER_WEEK][MAX_HOURS_PER_DAY];
	static qint16 tchDayNHours[MAX_DAYS_PER_WEEK];
	static qint16 tchDayNGaps[MAX_DAYS_PER_WEEK];
	
	static qint16 sbgTimetable[MAX_DAYS_PER_WEEK][MAX_HOURS_PER_DAY];
	static qint16 sbgDayNHours[MAX_DAYS_PER_WEEK];
	static qint16 sbgDayNGaps[MAX_DAYS_PER_WEEK];
	static qint16 sbgDayNFirstGaps[MAX_DAYS_PER_WEEK];*/
	internal static Matrix2D<qint16> tchTimetable = new Matrix2D<qint16>();
	internal static Matrix1D<qint16> tchDayNHours = new Matrix1D<qint16>();
	internal static Matrix1D<qint16> tchDayNGaps = new Matrix1D<qint16>();

	internal static Matrix2D<qint16> sbgTimetable = new Matrix2D<qint16>();
	internal static Matrix1D<qint16> sbgDayNHours = new Matrix1D<qint16>();
	internal static Matrix1D<qint16> sbgDayNGaps = new Matrix1D<qint16>();
	internal static Matrix1D<qint16> sbgDayNFirstGaps = new Matrix1D<qint16>();


	//static QList<int> teacherActivitiesOfTheDay[MAX_TEACHERS][MAX_DAYS_PER_WEEK];
	internal static Matrix2D<QList<int>> teacherActivitiesOfTheDay = new Matrix2D<QList<int>>();

	public static int maxActivitiesPlaced;

	public static QDateTime generationStartDateTime = new QDateTime();
	public static QDateTime generationHighestStageDateTime = new QDateTime();

	public const int MAX_RETRIES_FOR_AN_ACTIVITY_AT_LEVEL_0 = 400000;

	//used at level 0
	internal static Matrix1D<int> l0nWrong = new Matrix1D<int>();
	internal static Matrix1D<int> l0minWrong = new Matrix1D<int>();
	internal static Matrix1D<int> l0minIndexAct = new Matrix1D<int>();

	//2011-09-25
	internal static Matrix1D<QSet<int>> slotSetOfActivities = new Matrix1D<QSet<int>>();
	internal static Matrix1D<bool> slotCanEmpty = new Matrix1D<bool>();

	internal static Matrix1D<QSet<int>> activitiesAtTime = new Matrix1D<QSet<int>>();
	////////////


	public static int max(qint16 a, int b)
	{
		if ((int)a >= b)
			return (int)a;
		else
			return b;
	}

	//faster: (to avoid allocating memory at each call)
	#if 1

	internal static double[,] nMinDaysBrokenL = new double[MAX_LEVEL, MAX_HOURS_PER_WEEK];
	internal static int[,] selectedRoomL = new int[MAX_LEVEL, MAX_HOURS_PER_WEEK];
	internal static int[,] permL = new int[MAX_LEVEL, MAX_HOURS_PER_WEEK];
	internal static QList<int>[,] conflActivitiesL = new QList[MAX_LEVEL, MAX_HOURS_PER_WEEK];
	//static int conflPermL[MAX_LEVEL][MAX_HOURS_PER_WEEK]; //the permutation in increasing order of number of conflicting activities
	internal static int[,] nConflActivitiesL = new int[MAX_LEVEL, MAX_HOURS_PER_WEEK];
	internal static int[,] roomSlotsL = new int[MAX_LEVEL, MAX_HOURS_PER_WEEK];


	internal static int currentLevel;
	#endif
}

/*
File generate.cpp
*/

/*
Copyright 2007 Lalescu Liviu.

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
File generate.h
*/

/*
Copyright 2007 Lalescu Liviu.

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
//class Activity;

//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class QWidget;

/**
This class incorporates the routines for time and space allocation of activities
*/
public partial class Generate: QObject
{
	Q_OBJECT public: Generate();
	public void Dispose()
	{
	}

	private void addAiToNewTimetable(int ai, Activity act, int d, int h)
	{
		//foreach(int tch, act->iTeachersList){
		foreach (int tch, GlobalMembersGenerate_pre.mustComputeTimetableTeachers[ai])
		{
			for (int dur = 0; dur < act.duration; dur++)
			{
				GlobalMembersGenerate.oldTeachersTimetable(tch,d,h + dur) = GlobalMembersGenerate.newTeachersTimetable(tch,d,h + dur);
				GlobalMembersGenerate.newTeachersTimetable(tch,d,h + dur) = ai;
			}
			GlobalMembersGenerate.oldTeachersDayNHours(tch,d) = GlobalMembersGenerate.newTeachersDayNHours(tch,d);
			GlobalMembersGenerate.oldTeachersDayNGaps(tch,d) = GlobalMembersGenerate.newTeachersDayNGaps(tch,d);
		}

		//foreach(int sbg, act->iSubgroupsList){
		foreach (int sbg, GlobalMembersGenerate_pre.mustComputeTimetableSubgroups[ai])
		{
			for (int dur = 0; dur < act.duration; dur++)
			{
				GlobalMembersGenerate.oldSubgroupsTimetable(sbg,d,h + dur) = GlobalMembersGenerate.newSubgroupsTimetable(sbg,d,h + dur);
				GlobalMembersGenerate.newSubgroupsTimetable(sbg,d,h + dur) = ai;
			}
			GlobalMembersGenerate.oldSubgroupsDayNHours(sbg,d) = GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d);
			GlobalMembersGenerate.oldSubgroupsDayNGaps(sbg,d) = GlobalMembersGenerate.newSubgroupsDayNGaps(sbg,d);
			GlobalMembersGenerate.oldSubgroupsDayNFirstGaps(sbg,d) = GlobalMembersGenerate.newSubgroupsDayNFirstGaps(sbg,d);
		}
	}
	private void removeAiFromNewTimetable(int ai, Activity act, int d, int h)
	{
		foreach (int tch, GlobalMembersGenerate_pre.mustComputeTimetableTeachers[ai])
		{
		//foreach(int tch, act->iTeachersList){
			for (int dur = 0; dur < act.duration; dur++)
			{
				Debug.Assert(GlobalMembersGenerate.newTeachersTimetable(tch,d,h + dur) == ai);
				GlobalMembersGenerate.newTeachersTimetable(tch,d,h + dur) = GlobalMembersGenerate.oldTeachersTimetable(tch,d,h + dur);
			}
			GlobalMembersGenerate.newTeachersDayNHours(tch,d) = GlobalMembersGenerate.oldTeachersDayNHours(tch,d);
			GlobalMembersGenerate.newTeachersDayNGaps(tch,d) = GlobalMembersGenerate.oldTeachersDayNGaps(tch,d);
		}

		foreach (int sbg, GlobalMembersGenerate_pre.mustComputeTimetableSubgroups[ai])
		{
		//foreach(int sbg, act->iSubgroupsList){
			for (int dur = 0; dur < act.duration; dur++)
			{
				Debug.Assert(GlobalMembersGenerate.newSubgroupsTimetable(sbg,d,h + dur) == ai);
				GlobalMembersGenerate.newSubgroupsTimetable(sbg,d,h + dur) = GlobalMembersGenerate.oldSubgroupsTimetable(sbg,d,h + dur);
			}
			GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d) = GlobalMembersGenerate.oldSubgroupsDayNHours(sbg,d);
			GlobalMembersGenerate.newSubgroupsDayNGaps(sbg,d) = GlobalMembersGenerate.oldSubgroupsDayNGaps(sbg,d);
			GlobalMembersGenerate.newSubgroupsDayNFirstGaps(sbg,d) = GlobalMembersGenerate.oldSubgroupsDayNFirstGaps(sbg,d);
		}
	}

	private void getTchTimetable(int tch, QList<int> conflActivities)
	{
		for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
			for (int h2 = 0; h2 < gt.rules.nHoursPerDay; h2++)
			{
				int ai2 = GlobalMembersGenerate.newTeachersTimetable(tch,d2,h2);
				if (ai2 >= 0 && !conflActivities.contains(ai2))
					GlobalMembersGenerate.tchTimetable(d2,h2) = ai2;
				else
					GlobalMembersGenerate.tchTimetable(d2,h2) = -1;
			}

		/*for(int dur=0; dur<act->duration; dur++){
			assert(tchTimetable(d,h+dur)==-1);
			tchTimetable(d,h+dur)=ai;
		}*/
	}
	private void getSbgTimetable(int sbg, QList<int> conflActivities)
	{
		for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
			for (int h2 = 0; h2 < gt.rules.nHoursPerDay; h2++)
			{
				int ai2 = GlobalMembersGenerate.newSubgroupsTimetable(sbg,d2,h2);
				if (ai2 >= 0 && !conflActivities.contains(ai2))
					GlobalMembersGenerate.sbgTimetable(d2,h2) = ai2;
				else
					GlobalMembersGenerate.sbgTimetable(d2,h2) = -1;
			}

		/*for(int dur=0; dur<act->duration; dur++){
			assert(sbgTimetable(d,h+dur)==-1);
			sbgTimetable(d,h+dur)=ai;
		}*/
	}

	private void removeAi2FromTchTimetable(int ai2)
	{
		Activity act2 = gt.rules.internalActivitiesList[ai2];
		int d2 = c.times[ai2] % gt.rules.nDaysPerWeek;
		int h2 = c.times[ai2] / gt.rules.nDaysPerWeek;

		for (int dur2 = 0; dur2 < act2.duration; dur2++)
		{
			Debug.Assert(GlobalMembersGenerate.tchTimetable(d2,h2 + dur2) == ai2);
			if (GlobalMembersGenerate.tchTimetable(d2,h2 + dur2) == ai2)
				GlobalMembersGenerate.tchTimetable(d2,h2 + dur2) = -1;
		}
	}
	private void removeAi2FromSbgTimetable(int ai2)
	{
		Activity act2 = gt.rules.internalActivitiesList[ai2];
		int d2 = c.times[ai2] % gt.rules.nDaysPerWeek;
		int h2 = c.times[ai2] / gt.rules.nDaysPerWeek;

		for (int dur2 = 0; dur2 < act2.duration; dur2++)
		{
			Debug.Assert(GlobalMembersGenerate.sbgTimetable(d2,h2 + dur2) == ai2);
			if (GlobalMembersGenerate.sbgTimetable(d2,h2 + dur2) == ai2)
				GlobalMembersGenerate.sbgTimetable(d2,h2 + dur2) = -1;
		}
	}

	private void updateTeachersNHoursGaps(Activity act, int ai, int d)
	{
		Q_UNUSED(act);

		foreach (int tch, GlobalMembersGenerate_pre.mustComputeTimetableTeachers[ai])
		{
		//foreach(int tch, act->iTeachersList){
			int hours = 0;
			int gaps = 0;

			int h;
			for (h = 0; h < gt.rules.nHoursPerDay; h++)
				if (GlobalMembersGenerate.newTeachersTimetable(tch,d,h) >= 0)
					break;
			int ng = 0;
			for (; h < gt.rules.nHoursPerDay; h++)
			{
				if (GlobalMembersGenerate.newTeachersTimetable(tch,d,h) >= 0)
				{
					hours++;
					gaps += ng;
					ng = 0;
				}
				else if (!GlobalMembersGenerate_pre.breakDayHour(d,h) && !GlobalMembersGenerate_pre.teacherNotAvailableDayHour(tch,d,h))
					ng++;
			}
			GlobalMembersGenerate.newTeachersDayNGaps(tch,d) = gaps;
			GlobalMembersGenerate.newTeachersDayNHours(tch,d) = hours;
		}
	}
	private void updateSubgroupsNHoursGaps(Activity act, int ai, int d)
	{
		Q_UNUSED(act);

		foreach (int sbg, GlobalMembersGenerate_pre.mustComputeTimetableSubgroups[ai])
		{
		//foreach(int sbg, act->iSubgroupsList){
			int hours = 0;
			int gaps = 0;
			int nfirstgaps = 0;

			int h;
			for (h = 0; h < gt.rules.nHoursPerDay; h++)
			{
				if (GlobalMembersGenerate.newSubgroupsTimetable(sbg,d,h) >= 0)
					break;
				else if (!GlobalMembersGenerate_pre.breakDayHour(d,h) && !GlobalMembersGenerate_pre.subgroupNotAvailableDayHour(sbg,d,h))
					nfirstgaps++;
			}
			int ng = 0;
			for (; h < gt.rules.nHoursPerDay; h++)
			{
				if (GlobalMembersGenerate.newSubgroupsTimetable(sbg,d,h) >= 0)
				{
					hours++;
					gaps += ng;
					ng = 0;
				}
				else if (!GlobalMembersGenerate_pre.breakDayHour(d,h) && !GlobalMembersGenerate_pre.subgroupNotAvailableDayHour(sbg,d,h))
					ng++;
			}
			GlobalMembersGenerate.newSubgroupsDayNGaps(sbg,d) = gaps;
			GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d) = hours;
			if (hours > 0)
				GlobalMembersGenerate.newSubgroupsDayNFirstGaps(sbg,d) = nfirstgaps;
			else
				GlobalMembersGenerate.newSubgroupsDayNFirstGaps(sbg,d) = 0;
		}
	}

	private void updateTchNHoursGaps(int tch, int d)
	{
		int hours = 0;
		int gaps = 0;

		int h;
		for (h = 0; h < gt.rules.nHoursPerDay; h++)
			if (GlobalMembersGenerate.tchTimetable(d,h) >= 0)
				break;
		int ng = 0;
		for (; h < gt.rules.nHoursPerDay; h++)
		{
			if (GlobalMembersGenerate.tchTimetable(d,h) >= 0)
			{
				hours++;
				gaps += ng;
				ng = 0;
			}
			else if (!GlobalMembersGenerate_pre.breakDayHour(d,h) && !GlobalMembersGenerate_pre.teacherNotAvailableDayHour(tch,d,h))
				ng++;
		}
		GlobalMembersGenerate.tchDayNGaps[d] = gaps;
		GlobalMembersGenerate.tchDayNHours[d] = hours;
	}
	private void updateSbgNHoursGaps(int sbg, int d)
	{
		int hours = 0;
		int gaps = 0;
		int nfirstgaps = 0;

		int h;
		for (h = 0; h < gt.rules.nHoursPerDay; h++)
		{
			if (GlobalMembersGenerate.sbgTimetable(d,h) >= 0)
				break;
			else if (!GlobalMembersGenerate_pre.breakDayHour(d,h) && !GlobalMembersGenerate_pre.subgroupNotAvailableDayHour(sbg,d,h))
				nfirstgaps++;
		}
		int ng = 0;
		for (; h < gt.rules.nHoursPerDay; h++)
		{
			if (GlobalMembersGenerate.sbgTimetable(d,h) >= 0)
			{
				hours++;
				gaps += ng;
				ng = 0;
			}
			else if (!GlobalMembersGenerate_pre.breakDayHour(d,h) && !GlobalMembersGenerate_pre.subgroupNotAvailableDayHour(sbg,d,h))
				ng++;
		}
		GlobalMembersGenerate.sbgDayNGaps[d] = gaps;
		GlobalMembersGenerate.sbgDayNHours[d] = hours;
		if (GlobalMembersGenerate.sbgDayNHours[d] > 0)
			GlobalMembersGenerate.sbgDayNFirstGaps[d] = nfirstgaps;
		else
			GlobalMembersGenerate.sbgDayNFirstGaps[d] = 0;
	}

	private void tchGetNHoursGaps(int tch)
	{
		for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
		{
			GlobalMembersGenerate.tchDayNHours[d2] = 0;
			GlobalMembersGenerate.tchDayNGaps[d2] = 0;
		}
		for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
		{
			bool countGaps = false;
			int ng = 0;
			for (int h2 = 0; h2 < gt.rules.nHoursPerDay; h2++)
			{
				if (GlobalMembersGenerate.tchTimetable(d2,h2) >= 0)
				{
					GlobalMembersGenerate.tchDayNHours[d2]++;
					if (countGaps)
						GlobalMembersGenerate.tchDayNGaps[d2] += ng;
					else
						countGaps = true;
					ng = 0;
				}
				else if (!GlobalMembersGenerate_pre.breakDayHour(d2,h2) && !GlobalMembersGenerate_pre.teacherNotAvailableDayHour(tch,d2,h2))
					ng++;
			}
		}
	}
	private void teacherGetNHoursGaps(int tch)
	{
		if (!GlobalMembersGenerate_pre.mustComputeTimetableTeacher[tch])
			return;

		for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
		{
			GlobalMembersGenerate.newTeachersDayNHours(tch,d2) = 0;
			GlobalMembersGenerate.newTeachersDayNGaps(tch,d2) = 0;
		}
		for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
		{
			bool countGaps = false;
			int ng = 0;
			for (int h2 = 0; h2 < gt.rules.nHoursPerDay; h2++)
			{
				if (GlobalMembersGenerate.newTeachersTimetable(tch,d2,h2) >= 0)
				{
					GlobalMembersGenerate.newTeachersDayNHours(tch,d2)++;
					if (countGaps)
						GlobalMembersGenerate.newTeachersDayNGaps(tch,d2) += ng;
					else
						countGaps = true;
					ng = 0;
				}
				else if (!GlobalMembersGenerate_pre.breakDayHour(d2,h2) && !GlobalMembersGenerate_pre.teacherNotAvailableDayHour(tch,d2,h2))
					ng++;
			}
		}
	}
	private bool teacherRemoveAnActivityFromBeginOrEnd(int tch, int level, int ai, ref QList<int> conflActivities, ref int nConflActivities, ref int removedActivity)
	{
		Q_UNUSED(tch);

		//remove an activity from begin or from end of any day
		QList<int> possibleDays = new QList<int>();
		QList<bool> atBeginning = new QList<bool>();
		QList<int> acts = new QList<int>();
		for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
		{
			if (GlobalMembersGenerate.tchDayNHours[d2] > 0)
			{
				int actIndexBegin = -1;
				int actIndexEnd = -1;
				int h2;
				for (h2 = 0; h2 < gt.rules.nHoursPerDay; h2++)
				{
					if (GlobalMembersGenerate.tchTimetable(d2,h2) >= 0)
					{
						actIndexBegin = GlobalMembersGenerate.tchTimetable(d2,h2);
						break;
					}
				}
				if (actIndexBegin >= 0)
					if (GlobalMembersGenerate_pre.fixedTimeActivity[actIndexBegin] || GlobalMembersGenerate.swappedActivities[actIndexBegin] || actIndexBegin == ai)
						actIndexBegin = -1;
				for (h2 = gt.rules.nHoursPerDay - 1; h2 >= 0; h2--)
				{
					if (GlobalMembersGenerate.tchTimetable(d2,h2) >= 0)
					{
						actIndexEnd = GlobalMembersGenerate.tchTimetable(d2,h2);
						break;
					}
				}
				if (actIndexEnd >= 0)
					if (GlobalMembersGenerate_pre.fixedTimeActivity[actIndexEnd] || GlobalMembersGenerate.swappedActivities[actIndexEnd] || actIndexEnd == ai || actIndexEnd == actIndexBegin)
						actIndexEnd = -1;

				if (actIndexBegin >= 0)
				{
					Debug.Assert(!acts.contains(actIndexBegin));
					possibleDays.append(d2);
					atBeginning.append(true);
					acts.append(actIndexBegin);
				}
				if (actIndexEnd >= 0)
				{
					Debug.Assert(!acts.contains(actIndexEnd));
					possibleDays.append(d2);
					atBeginning.append(false);
					acts.append(actIndexEnd);
				}
			}
		}

		bool possibleBeginOrEnd = true;
		if (possibleDays.count() == 0)
			possibleBeginOrEnd = false;

		if (possibleBeginOrEnd)
		{
			int t;

			if (level == 0)
			{
				int optMinWrong = GlobalMembersGenerate.INF;

				QList<int> tl = new QList<int>();

				for (int q = 0; q < acts.count(); q++)
				{
					int ai2 = acts.at(q);
					if (optMinWrong > GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]))
					{
						 optMinWrong = GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]);
					}
				}

				for (int q = 0; q < acts.count(); q++)
				{
					int ai2 = acts.at(q);
					if (optMinWrong == GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]))
						tl.append(q);
				}

				Debug.Assert(tl.size() >= 1);
				int mpos = tl.at(GlobalMembersTimetable_defs.randomKnuth(tl.size()));

				Debug.Assert(mpos >= 0 && mpos < acts.count());
				t = mpos;
			}
			else
			{
				t = GlobalMembersTimetable_defs.randomKnuth(possibleDays.count());
			}

			Debug.Assert(t >= 0 && t < possibleDays.count());

			int d2 = possibleDays.at(t);
			bool begin = atBeginning.at(t);
			int ai2 = acts.at(t);

			removedActivity = ai2;

			if (begin)
			{
				int h2;
				for (h2 = 0; h2 < gt.rules.nHoursPerDay; h2++)
					if (GlobalMembersGenerate.tchTimetable(d2,h2) >= 0)
						break;
				Debug.Assert(h2 < gt.rules.nHoursPerDay);

				Debug.Assert(GlobalMembersGenerate.tchTimetable(d2,h2) == ai2);

				Debug.Assert(!conflActivities.contains(ai2));
				conflActivities.append(ai2);
				nConflActivities++;
				Debug.Assert(nConflActivities == conflActivities.count());
			}
			else
			{
				int h2;
				for (h2 = gt.rules.nHoursPerDay - 1; h2 >= 0; h2--)
					if (GlobalMembersGenerate.tchTimetable(d2,h2) >= 0)
						break;
				Debug.Assert(h2 >= 0);

				Debug.Assert(GlobalMembersGenerate.tchTimetable(d2,h2) == ai2);

				Debug.Assert(!conflActivities.contains(ai2));
				conflActivities.append(ai2);
				nConflActivities++;
				Debug.Assert(nConflActivities == conflActivities.count());
			}

			return true;
		}
		else
			return false;
	}
	private bool teacherRemoveAnActivityFromAnywhere(int tch, int level, int ai, ref QList<int> conflActivities, ref int nConflActivities, ref int removedActivity)
	{
		Q_UNUSED(tch);

		//remove an activity from anywhere
		QList<int> acts = new QList<int>();
		for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
		{
			if (GlobalMembersGenerate.tchDayNHours[d2] > 0)
			{
				int actIndex = -1;
				int h2;
				for (h2 = 0; h2 < gt.rules.nHoursPerDay; h2++)
					if (GlobalMembersGenerate.tchTimetable(d2,h2) >= 0)
					{
						actIndex = GlobalMembersGenerate.tchTimetable(d2,h2);

						if (GlobalMembersGenerate_pre.fixedTimeActivity[actIndex] || GlobalMembersGenerate.swappedActivities[actIndex] || actIndex == ai || acts.contains(actIndex))
							actIndex = -1;

						if (actIndex >= 0)
						{
							Debug.Assert(!acts.contains(actIndex));
							acts.append(actIndex);
						}
					}
			}
		}

		if (acts.count() > 0)
		{
			int t;

			if (level == 0)
			{
				int optMinWrong = GlobalMembersGenerate.INF;

				QList<int> tl = new QList<int>();

				for (int q = 0; q < acts.count(); q++)
				{
					int ai2 = acts.at(q);
					if (optMinWrong > GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]))
					{
						 optMinWrong = GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]);
					}
				}

				for (int q = 0; q < acts.count(); q++)
				{
					int ai2 = acts.at(q);
					if (optMinWrong == GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]))
						tl.append(q);
				}

				Debug.Assert(tl.size() >= 1);
				int mpos = tl.at(GlobalMembersTimetable_defs.randomKnuth(tl.size()));

				Debug.Assert(mpos >= 0 && mpos < acts.count());
				t = mpos;
			}
			else
			{
				t = GlobalMembersTimetable_defs.randomKnuth(acts.count());
			}

			int ai2 = acts.at(t);

			removedActivity = ai2;

			Debug.Assert(!conflActivities.contains(ai2));
			conflActivities.append(ai2);
			nConflActivities++;
			Debug.Assert(nConflActivities == conflActivities.count());

			return true;
		}
		else
			return false;
	}
	private bool teacherRemoveAnActivityFromBeginOrEndCertainDay(int tch, int d2, int level, int ai, ref QList<int> conflActivities, ref int nConflActivities, ref int removedActivity)
	{
		Q_UNUSED(tch);

		int actIndexBegin = -1;
		int actIndexEnd = -1;

		if (GlobalMembersGenerate.tchDayNHours[d2] > 0)
		{
			for (int h2 = 0; h2 < gt.rules.nHoursPerDay; h2++)
			{
				if (GlobalMembersGenerate.tchTimetable(d2,h2) >= 0)
				{
					actIndexBegin = GlobalMembersGenerate.tchTimetable(d2,h2);
					break;
				}
			}
			if (actIndexBegin >= 0)
				if (GlobalMembersGenerate_pre.fixedTimeActivity[actIndexBegin] || GlobalMembersGenerate.swappedActivities[actIndexBegin] || actIndexBegin == ai)
					actIndexBegin = -1;
			for (int h2 = gt.rules.nHoursPerDay - 1; h2 >= 0; h2--)
			{
				if (GlobalMembersGenerate.tchTimetable(d2,h2) >= 0)
				{
					actIndexEnd = GlobalMembersGenerate.tchTimetable(d2,h2);
					break;
				}
			}
			if (actIndexEnd >= 0)
				if (GlobalMembersGenerate_pre.fixedTimeActivity[actIndexEnd] || GlobalMembersGenerate.swappedActivities[actIndexEnd] || actIndexEnd == ai || actIndexEnd == actIndexBegin)
					actIndexEnd = -1;
		}

		if (actIndexEnd >= 0 || actIndexBegin >= 0)
		{
			int ai2 = -1;
			if (level == 0)
			{
				int optMinWrong = GlobalMembersGenerate.INF;

				if (actIndexBegin >= 0)
				{
					if (optMinWrong > GlobalMembersGenerate.triedRemovals(actIndexBegin,c.times[actIndexBegin]))
					{
						 optMinWrong = GlobalMembersGenerate.triedRemovals(actIndexBegin,c.times[actIndexBegin]);
					}
					ai2 = actIndexBegin;
				}

				if (actIndexEnd >= 0)
				{
					if (optMinWrong > GlobalMembersGenerate.triedRemovals(actIndexEnd,c.times[actIndexEnd]))
					{
						 optMinWrong = GlobalMembersGenerate.triedRemovals(actIndexEnd,c.times[actIndexEnd]);
					}
					ai2 = actIndexEnd;
				}

				if (actIndexBegin >= 0 && actIndexEnd >= 0 && optMinWrong == GlobalMembersGenerate.triedRemovals(actIndexEnd,c.times[actIndexEnd]) && optMinWrong == GlobalMembersGenerate.triedRemovals(actIndexBegin,c.times[actIndexBegin]))
				{
					if (GlobalMembersTimetable_defs.randomKnuth(2) == 0)
						ai2 = actIndexBegin;
					else
						ai2 = actIndexEnd;
				}
			}
			else
			{
				if (actIndexBegin >= 0 && actIndexEnd < 0)
					ai2 = actIndexBegin;
				else if (actIndexEnd >= 0 && actIndexBegin < 0)
					ai2 = actIndexEnd;
				else
				{
					if (GlobalMembersTimetable_defs.randomKnuth(2) == 0)
						ai2 = actIndexBegin;
					else
						ai2 = actIndexEnd;
				}
			}
			Debug.Assert(ai2 >= 0);

			removedActivity = ai2;

			Debug.Assert(!conflActivities.contains(ai2));
			conflActivities.append(ai2);
			nConflActivities++;
			Debug.Assert(nConflActivities == conflActivities.count());

			return true;
		}
		else
			return false;
	}
	private bool teacherRemoveAnActivityFromAnywhereCertainDay(int tch, int d2, int level, int ai, ref QList<int> conflActivities, ref int nConflActivities, ref int removedActivity)
	{
		Q_UNUSED(tch);

		//remove an activity from anywhere
		QList<int> acts = new QList<int>();
		//for(int d2=0; d2<gt.rules.nDaysPerWeek; d2++){
			if (GlobalMembersGenerate.tchDayNHours[d2] > 0)
			{
				int actIndex = -1;
				int h2;
				for (h2 = 0; h2 < gt.rules.nHoursPerDay; h2++)
					if (GlobalMembersGenerate.tchTimetable(d2,h2) >= 0)
					{
						actIndex = GlobalMembersGenerate.tchTimetable(d2,h2);

						if (GlobalMembersGenerate_pre.fixedTimeActivity[actIndex] || GlobalMembersGenerate.swappedActivities[actIndex] || actIndex == ai || acts.contains(actIndex))
							actIndex = -1;

						if (actIndex >= 0)
						{
							Debug.Assert(!acts.contains(actIndex));
							acts.append(actIndex);
						}
					}
			}
		//}

		if (acts.count() > 0)
		{
			int t;

			if (level == 0)
			{
				int optMinWrong = GlobalMembersGenerate.INF;

				QList<int> tl = new QList<int>();

				for (int q = 0; q < acts.count(); q++)
				{
					int ai2 = acts.at(q);
					if (optMinWrong > GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]))
					{
						 optMinWrong = GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]);
					}
				}

				for (int q = 0; q < acts.count(); q++)
				{
					int ai2 = acts.at(q);
					if (optMinWrong == GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]))
						tl.append(q);
				}

				Debug.Assert(tl.size() >= 1);
				int mpos = tl.at(GlobalMembersTimetable_defs.randomKnuth(tl.size()));

				Debug.Assert(mpos >= 0 && mpos < acts.count());
				t = mpos;
			}
			else
			{
				t = GlobalMembersTimetable_defs.randomKnuth(acts.count());
			}

			int ai2 = acts.at(t);

			removedActivity = ai2;

			Debug.Assert(!conflActivities.contains(ai2));
			conflActivities.append(ai2);
			nConflActivities++;
			Debug.Assert(nConflActivities == conflActivities.count());

			return true;
		}
		else
			return false;
	}

	private bool teacherRemoveAnActivityFromAnywhereCertainDayCertainActivityTag(int tch, int d2, int actTag, int level, int ai, ref QList<int> conflActivities, ref int nConflActivities, ref int removedActivity)
	{
		Q_UNUSED(tch);

		//remove an activity from anywhere
		QList<int> acts = new QList<int>();
		//for(int d2=0; d2<gt.rules.nDaysPerWeek; d2++){
			if (GlobalMembersGenerate.tchDayNHours[d2] > 0)
			{
				int actIndex = -1;
				int h2;
				for (h2 = 0; h2 < gt.rules.nHoursPerDay; h2++)
					if (GlobalMembersGenerate.tchTimetable(d2,h2) >= 0)
					{
						actIndex = GlobalMembersGenerate.tchTimetable(d2,h2);

						if (GlobalMembersGenerate_pre.fixedTimeActivity[actIndex] || GlobalMembersGenerate.swappedActivities[actIndex] || actIndex == ai || acts.contains(actIndex) || !gt.rules.internalActivitiesList[actIndex].iActivityTagsSet.contains(actTag))
							actIndex = -1;

						if (actIndex >= 0)
						{
							Debug.Assert(!acts.contains(actIndex));
							acts.append(actIndex);
						}
					}
			}
		//}

		if (acts.count() > 0)
		{
			int t;

			if (level == 0)
			{
				int optMinWrong = GlobalMembersGenerate.INF;

				QList<int> tl = new QList<int>();

				for (int q = 0; q < acts.count(); q++)
				{
					int ai2 = acts.at(q);
					if (optMinWrong > GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]))
					{
						 optMinWrong = GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]);
					}
				}

				for (int q = 0; q < acts.count(); q++)
				{
					int ai2 = acts.at(q);
					if (optMinWrong == GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]))
						tl.append(q);
				}

				Debug.Assert(tl.size() >= 1);
				int mpos = tl.at(GlobalMembersTimetable_defs.randomKnuth(tl.size()));

				Debug.Assert(mpos >= 0 && mpos < acts.count());
				t = mpos;
			}
			else
			{
				t = GlobalMembersTimetable_defs.randomKnuth(acts.count());
			}

			int ai2 = acts.at(t);

			removedActivity = ai2;

			Debug.Assert(!conflActivities.contains(ai2));
			conflActivities.append(ai2);
			nConflActivities++;
			Debug.Assert(nConflActivities == conflActivities.count());

			return true;
		}
		else
			return false;
	}

	private void sbgGetNHoursGaps(int sbg)
	{
		for (int d = 0; d < gt.rules.nDaysPerWeek; d++)
		{
			int hours = 0;
			int gaps = 0;
			int nfirstgaps = 0;

			int h;
			for (h = 0; h < gt.rules.nHoursPerDay; h++)
			{
				if (GlobalMembersGenerate.sbgTimetable(d,h) >= 0)
					break;
				else if (!GlobalMembersGenerate_pre.breakDayHour(d,h) && !GlobalMembersGenerate_pre.subgroupNotAvailableDayHour(sbg,d,h))
					nfirstgaps++;
			}
			int ng = 0;
			for (; h < gt.rules.nHoursPerDay; h++)
			{
				if (GlobalMembersGenerate.sbgTimetable(d,h) >= 0)
				{
					hours++;
					gaps += ng;
					ng = 0;
				}
				else if (!GlobalMembersGenerate_pre.breakDayHour(d,h) && !GlobalMembersGenerate_pre.subgroupNotAvailableDayHour(sbg,d,h))
					ng++;
			}

			GlobalMembersGenerate.sbgDayNGaps[d] = gaps;
			GlobalMembersGenerate.sbgDayNHours[d] = hours;
			if (GlobalMembersGenerate.sbgDayNHours[d] > 0)
				GlobalMembersGenerate.sbgDayNFirstGaps[d] = nfirstgaps;
			else
				GlobalMembersGenerate.sbgDayNFirstGaps[d] = 0;
		}

		/*
		for(int d2=0; d2<gt.rules.nDaysPerWeek; d2++){
			sbgDayNHours[d2]=0;
			sbgDayNGaps[d2]=0;
			sbgDayNFirstGaps[d2]=0;
		}
		for(int d2=0; d2<gt.rules.nDaysPerWeek; d2++){
			bool countGaps=false;
			int ng=0;
			for(int h2=0; h2<gt.rules.nHoursPerDay; h2++){
			if(sbgTimetable(d2,h2)>=0){
					sbgDayNHours[d2]++;
					if(countGaps)
						sbgDayNGaps[d2]+=ng;
					else
						countGaps=true;
					ng=0;
				}
				else if(!breakDayHour(d2,h2) && !subgroupNotAvailableDayHour(sbg,d2,h2))
					ng++;
			}
		}*/
	}

	//students
	private void subgroupGetNHoursGaps(int sbg)
	{
		if (!GlobalMembersGenerate_pre.mustComputeTimetableSubgroup[sbg])
			return;

		for (int d = 0; d < gt.rules.nDaysPerWeek; d++)
		{
			int hours = 0;
			int gaps = 0;
			int nfirstgaps = 0;

			int h;
			for (h = 0; h < gt.rules.nHoursPerDay; h++)
			{
				if (GlobalMembersGenerate.newSubgroupsTimetable(sbg,d,h) >= 0)
					break;
				else if (!GlobalMembersGenerate_pre.breakDayHour(d,h) && !GlobalMembersGenerate_pre.subgroupNotAvailableDayHour(sbg,d,h))
					nfirstgaps++;
			}
			int ng = 0;
			for (; h < gt.rules.nHoursPerDay; h++)
			{
				if (GlobalMembersGenerate.newSubgroupsTimetable(sbg,d,h) >= 0)
				{
					hours++;
					gaps += ng;
					ng = 0;
				}
				else if (!GlobalMembersGenerate_pre.breakDayHour(d,h) && !GlobalMembersGenerate_pre.subgroupNotAvailableDayHour(sbg,d,h))
					ng++;
			}
			GlobalMembersGenerate.newSubgroupsDayNGaps(sbg,d) = gaps;
			GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d) = hours;
			if (hours > 0)
				GlobalMembersGenerate.newSubgroupsDayNFirstGaps(sbg,d) = nfirstgaps;
			else
				GlobalMembersGenerate.newSubgroupsDayNFirstGaps(sbg,d) = 0;
		}

	/*	for(int d2=0; d2<gt.rules.nDaysPerWeek; d2++){
			newSubgroupsDayNHours(sbg,d2)=0;
			newSubgroupsDayNGaps(sbg,d2)=0;
		}
		for(int d2=0; d2<gt.rules.nDaysPerWeek; d2++){
			bool countGaps=false;
			int ng=0;
			for(int h2=0; h2<gt.rules.nHoursPerDay; h2++){
				if(newSubgroupsTimetable(sbg,d2,h2)>=0){
					newSubgroupsDayNHours(sbg,d2)++;
					if(countGaps)
						newSubgroupsDayNGaps(sbg,d2)+=ng;
					else
						countGaps=true;
					ng=0;
				}
				else if(!breakDayHour(d2,h2) && !subgroupNotAvailableDayHour(sbg,d2,h2))
					ng++;
			}
		}*/
	}
	private bool subgroupRemoveAnActivityFromBegin(int sbg, int level, int ai, ref QList<int> conflActivities, ref int nConflActivities, ref int removedActivity)
	{
		Q_UNUSED(sbg);

		//remove an activity from begin of any day
		QList<int> possibleDays = new QList<int>();
		QList<int> acts = new QList<int>();
		for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
		{
			if (GlobalMembersGenerate.sbgDayNHours[d2] > 0)
			{
				int actIndexBegin = -1;
				int h2;
				for (h2 = 0; h2 < gt.rules.nHoursPerDay; h2++)
				{
					if (GlobalMembersGenerate.sbgTimetable(d2,h2) >= 0)
					{
						actIndexBegin = GlobalMembersGenerate.sbgTimetable(d2,h2);
						break;
					}
				}
				if (actIndexBegin >= 0)
					if (GlobalMembersGenerate_pre.fixedTimeActivity[actIndexBegin] || GlobalMembersGenerate.swappedActivities[actIndexBegin] || actIndexBegin == ai)
						actIndexBegin = -1;

				if (actIndexBegin >= 0)
				{
					Debug.Assert(!acts.contains(actIndexBegin));
					possibleDays.append(d2);
					acts.append(actIndexBegin);
				}
			}
		}

		bool possibleBegin = true;
		if (possibleDays.count() == 0)
			possibleBegin = false;

		if (possibleBegin)
		{
			int t;

			if (level == 0)
			{
				int optMinWrong = GlobalMembersGenerate.INF;

				QList<int> tl = new QList<int>();

				for (int q = 0; q < acts.count(); q++)
				{
					int ai2 = acts.at(q);
					if (optMinWrong > GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]))
					{
						 optMinWrong = GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]);
					}
				}

				for (int q = 0; q < acts.count(); q++)
				{
					int ai2 = acts.at(q);
					if (optMinWrong == GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]))
						tl.append(q);
				}

				Debug.Assert(tl.size() >= 1);
				int mpos = tl.at(GlobalMembersTimetable_defs.randomKnuth(tl.size()));

				Debug.Assert(mpos >= 0 && mpos < acts.count());
				t = mpos;
			}
			else
			{
				t = GlobalMembersTimetable_defs.randomKnuth(possibleDays.count());
			}

			Debug.Assert(t >= 0 && t < possibleDays.count());

			int d2 = possibleDays.at(t);
			int ai2 = acts.at(t);

			removedActivity = ai2;

			int h2;
			for (h2 = 0; h2 < gt.rules.nHoursPerDay; h2++)
				if (GlobalMembersGenerate.sbgTimetable(d2,h2) >= 0)
					break;
			Debug.Assert(h2 < gt.rules.nHoursPerDay);

			Debug.Assert(GlobalMembersGenerate.sbgTimetable(d2,h2) == ai2);

			Debug.Assert(!conflActivities.contains(ai2));
			conflActivities.append(ai2);
			nConflActivities++;
			Debug.Assert(nConflActivities == conflActivities.count());

			return true;
		}
		else
			return false;
	}
	private bool subgroupRemoveAnActivityFromEnd(int sbg, int level, int ai, ref QList<int> conflActivities, ref int nConflActivities, ref int removedActivity)
	{
		Q_UNUSED(sbg);

		//remove an activity from begin or from end of any day
		QList<int> possibleDays = new QList<int>();
		QList<int> acts = new QList<int>();
		for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
		{
			if (GlobalMembersGenerate.sbgDayNHours[d2] > 0)
			{
				int actIndexEnd = -1;
				int h2;
				for (h2 = gt.rules.nHoursPerDay - 1; h2 >= 0; h2--)
				{
					if (GlobalMembersGenerate.sbgTimetable(d2,h2) >= 0)
					{
						actIndexEnd = GlobalMembersGenerate.sbgTimetable(d2,h2);
						break;
					}
				}
				if (actIndexEnd >= 0)
					if (GlobalMembersGenerate_pre.fixedTimeActivity[actIndexEnd] || GlobalMembersGenerate.swappedActivities[actIndexEnd] || actIndexEnd == ai)
						actIndexEnd = -1;

				if (actIndexEnd >= 0)
				{
					Debug.Assert(!acts.contains(actIndexEnd));
					possibleDays.append(d2);
					acts.append(actIndexEnd);
				}
			}
		}

		bool possibleEnd = true;
		if (possibleDays.count() == 0)
			possibleEnd = false;

		if (possibleEnd)
		{
			int t;

			if (level == 0)
			{
				int optMinWrong = GlobalMembersGenerate.INF;

				QList<int> tl = new QList<int>();

				for (int q = 0; q < acts.count(); q++)
				{
					int ai2 = acts.at(q);
					if (optMinWrong > GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]))
					{
						 optMinWrong = GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]);
					}
				}

				for (int q = 0; q < acts.count(); q++)
				{
					int ai2 = acts.at(q);
					if (optMinWrong == GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]))
						tl.append(q);
				}

				Debug.Assert(tl.size() >= 1);
				int mpos = tl.at(GlobalMembersTimetable_defs.randomKnuth(tl.size()));

				Debug.Assert(mpos >= 0 && mpos < acts.count());
				t = mpos;
			}
			else
			{
				t = GlobalMembersTimetable_defs.randomKnuth(possibleDays.count());
			}

			Debug.Assert(t >= 0 && t < possibleDays.count());

			int d2 = possibleDays.at(t);
			int ai2 = acts.at(t);

			removedActivity = ai2;

			int h2;
			for (h2 = gt.rules.nHoursPerDay - 1; h2 >= 0; h2--)
				if (GlobalMembersGenerate.sbgTimetable(d2,h2) >= 0)
					break;
			Debug.Assert(h2 >= 0);

			Debug.Assert(GlobalMembersGenerate.sbgTimetable(d2,h2) == ai2);

			Debug.Assert(!conflActivities.contains(ai2));
			conflActivities.append(ai2);
			nConflActivities++;
			Debug.Assert(nConflActivities == conflActivities.count());

			return true;
		}
		else
			return false;
	}
	private bool subgroupRemoveAnActivityFromBeginOrEnd(int sbg, int level, int ai, ref QList<int> conflActivities, ref int nConflActivities, ref int removedActivity)
	{
		Q_UNUSED(sbg);

		//remove an activity from begin or from end of any day
		QList<int> possibleDays = new QList<int>();
		QList<bool> atBeginning = new QList<bool>();
		QList<int> acts = new QList<int>();
		for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
		{
			if (GlobalMembersGenerate.sbgDayNHours[d2] > 0)
			{
				int actIndexBegin = -1;
				int actIndexEnd = -1;
				int h2;
				for (h2 = 0; h2 < gt.rules.nHoursPerDay; h2++)
				{
					if (GlobalMembersGenerate.sbgTimetable(d2,h2) >= 0)
					{
						actIndexBegin = GlobalMembersGenerate.sbgTimetable(d2,h2);
						break;
					}
				}
				if (actIndexBegin >= 0)
					if (GlobalMembersGenerate_pre.fixedTimeActivity[actIndexBegin] || GlobalMembersGenerate.swappedActivities[actIndexBegin] || actIndexBegin == ai)
						actIndexBegin = -1;
				for (h2 = gt.rules.nHoursPerDay - 1; h2 >= 0; h2--)
				{
					if (GlobalMembersGenerate.sbgTimetable(d2,h2) >= 0)
					{
						actIndexEnd = GlobalMembersGenerate.sbgTimetable(d2,h2);
						break;
					}
				}
				if (actIndexEnd >= 0)
					if (GlobalMembersGenerate_pre.fixedTimeActivity[actIndexEnd] || GlobalMembersGenerate.swappedActivities[actIndexEnd] || actIndexEnd == ai || actIndexEnd == actIndexBegin)
						actIndexEnd = -1;

				if (actIndexBegin >= 0)
				{
					Debug.Assert(!acts.contains(actIndexBegin));
					possibleDays.append(d2);
					atBeginning.append(true);
					acts.append(actIndexBegin);
				}
				if (actIndexEnd >= 0)
				{
					Debug.Assert(!acts.contains(actIndexEnd));
					possibleDays.append(d2);
					atBeginning.append(false);
					acts.append(actIndexEnd);
				}
			}
		}

		bool possibleBeginOrEnd = true;
		if (possibleDays.count() == 0)
			possibleBeginOrEnd = false;

		if (possibleBeginOrEnd)
		{
			int t;

			if (level == 0)
			{
				int optMinWrong = GlobalMembersGenerate.INF;

				QList<int> tl = new QList<int>();

				for (int q = 0; q < acts.count(); q++)
				{
					int ai2 = acts.at(q);
					if (optMinWrong > GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]))
					{
						 optMinWrong = GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]);
					}
				}

				for (int q = 0; q < acts.count(); q++)
				{
					int ai2 = acts.at(q);
					if (optMinWrong == GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]))
						tl.append(q);
				}

				Debug.Assert(tl.size() >= 1);
				int mpos = tl.at(GlobalMembersTimetable_defs.randomKnuth(tl.size()));

				Debug.Assert(mpos >= 0 && mpos < acts.count());
				t = mpos;
			}
			else
			{
				t = GlobalMembersTimetable_defs.randomKnuth(possibleDays.count());
			}

			Debug.Assert(t >= 0 && t < possibleDays.count());

			int d2 = possibleDays.at(t);
			bool begin = atBeginning.at(t);
			int ai2 = acts.at(t);

			removedActivity = ai2;

			if (begin)
			{
				int h2;
				for (h2 = 0; h2 < gt.rules.nHoursPerDay; h2++)
					if (GlobalMembersGenerate.sbgTimetable(d2,h2) >= 0)
						break;
				Debug.Assert(h2 < gt.rules.nHoursPerDay);

				Debug.Assert(GlobalMembersGenerate.sbgTimetable(d2,h2) == ai2);

				Debug.Assert(!conflActivities.contains(ai2));
				conflActivities.append(ai2);
				nConflActivities++;
				Debug.Assert(nConflActivities == conflActivities.count());
			}
			else
			{
				int h2;
				for (h2 = gt.rules.nHoursPerDay - 1; h2 >= 0; h2--)
					if (GlobalMembersGenerate.sbgTimetable(d2,h2) >= 0)
						break;
				Debug.Assert(h2 >= 0);

				Debug.Assert(GlobalMembersGenerate.sbgTimetable(d2,h2) == ai2);

				Debug.Assert(!conflActivities.contains(ai2));
				conflActivities.append(ai2);
				nConflActivities++;
				Debug.Assert(nConflActivities == conflActivities.count());
			}

			return true;
		}
		else
			return false;
	}
	private bool subgroupRemoveAnActivityFromAnywhere(int sbg, int level, int ai, ref QList<int> conflActivities, ref int nConflActivities, ref int removedActivity)
	{
		Q_UNUSED(sbg);

		//remove an activity from anywhere
		QList<int> acts = new QList<int>();
		for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
		{
			if (GlobalMembersGenerate.sbgDayNHours[d2] > 0)
			{
				int actIndex = -1;
				int h2;
				for (h2 = 0; h2 < gt.rules.nHoursPerDay; h2++)
					if (GlobalMembersGenerate.sbgTimetable(d2,h2) >= 0)
					{
						actIndex = GlobalMembersGenerate.sbgTimetable(d2,h2);

						if (GlobalMembersGenerate_pre.fixedTimeActivity[actIndex] || GlobalMembersGenerate.swappedActivities[actIndex] || actIndex == ai || acts.contains(actIndex))
							actIndex = -1;

						if (actIndex >= 0)
						{
							Debug.Assert(!acts.contains(actIndex));
							acts.append(actIndex);
						}
					}
			}
		}

		if (acts.count() > 0)
		{
			int t;

			if (level == 0)
			{
				int optMinWrong = GlobalMembersGenerate.INF;

				QList<int> tl = new QList<int>();

				for (int q = 0; q < acts.count(); q++)
				{
					int ai2 = acts.at(q);
					if (optMinWrong > GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]))
					{
						 optMinWrong = GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]);
					}
				}

				for (int q = 0; q < acts.count(); q++)
				{
					int ai2 = acts.at(q);
					if (optMinWrong == GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]))
						tl.append(q);
				}

				Debug.Assert(tl.size() >= 1);
				int mpos = tl.at(GlobalMembersTimetable_defs.randomKnuth(tl.size()));

				Debug.Assert(mpos >= 0 && mpos < acts.count());
				t = mpos;
			}
			else
			{
				t = GlobalMembersTimetable_defs.randomKnuth(acts.count());
			}

			int ai2 = acts.at(t);

			removedActivity = ai2;

			Debug.Assert(!conflActivities.contains(ai2));
			conflActivities.append(ai2);
			nConflActivities++;
			Debug.Assert(nConflActivities == conflActivities.count());

			return true;
		}
		else
			return false;
	}
	private bool subgroupRemoveAnActivityFromBeginCertainDay(int sbg, int d2, int level, int ai, ref QList<int> conflActivities, ref int nConflActivities, ref int removedActivity)
	{
		Q_UNUSED(sbg);
		Q_UNUSED(level);

		if (GlobalMembersGenerate.sbgDayNHours[d2] > 0)
		{
			int actIndexBegin = -1;
			int h2;
			for (h2 = 0; h2 < gt.rules.nHoursPerDay; h2++)
			{
				if (GlobalMembersGenerate.sbgTimetable(d2,h2) >= 0)
				{
					actIndexBegin = GlobalMembersGenerate.sbgTimetable(d2,h2);
					break;
				}
			}
			if (actIndexBegin >= 0)
				if (GlobalMembersGenerate_pre.fixedTimeActivity[actIndexBegin] || GlobalMembersGenerate.swappedActivities[actIndexBegin] || actIndexBegin == ai)
					actIndexBegin = -1;

			if (actIndexBegin >= 0)
			{
				removedActivity = actIndexBegin;

				Debug.Assert(!conflActivities.contains(actIndexBegin));
				conflActivities.append(actIndexBegin);
				nConflActivities++;
				Debug.Assert(nConflActivities == conflActivities.count());

				return true;
			}
			else
				return false;
		}
		else
			return false;
	}
	private bool subgroupRemoveAnActivityFromEndCertainDay(int sbg, int d2, int level, int ai, ref QList<int> conflActivities, ref int nConflActivities, ref int removedActivity)
	{
		Q_UNUSED(sbg);
		Q_UNUSED(level);

		if (GlobalMembersGenerate.sbgDayNHours[d2] > 0)
		{
			int actIndexEnd = -1;
			int h2;
			for (h2 = gt.rules.nHoursPerDay - 1; h2 >= 0; h2--)
			{
				if (GlobalMembersGenerate.sbgTimetable(d2,h2) >= 0)
				{
					actIndexEnd = GlobalMembersGenerate.sbgTimetable(d2,h2);
					break;
				}
			}
			if (actIndexEnd >= 0)
				if (GlobalMembersGenerate_pre.fixedTimeActivity[actIndexEnd] || GlobalMembersGenerate.swappedActivities[actIndexEnd] || actIndexEnd == ai)
					actIndexEnd = -1;

			if (actIndexEnd >= 0)
			{
				removedActivity = actIndexEnd;

				Debug.Assert(!conflActivities.contains(actIndexEnd));
				conflActivities.append(actIndexEnd);
				nConflActivities++;
				Debug.Assert(nConflActivities == conflActivities.count());

				return true;
			}
			else
				return false;
		}
		else
			return false;
	}
	private bool subgroupRemoveAnActivityFromAnywhereCertainDay(int sbg, int d2, int level, int ai, ref QList<int> conflActivities, ref int nConflActivities, ref int removedActivity)
	{
		Q_UNUSED(sbg);

		//remove an activity from anywhere
		QList<int> acts = new QList<int>();
		//for(int d2=0; d2<gt.rules.nDaysPerWeek; d2++){
			if (GlobalMembersGenerate.sbgDayNHours[d2] > 0)
			{
				int actIndex = -1;
				int h2;
				for (h2 = 0; h2 < gt.rules.nHoursPerDay; h2++)
					if (GlobalMembersGenerate.sbgTimetable(d2,h2) >= 0)
					{
						actIndex = GlobalMembersGenerate.sbgTimetable(d2,h2);

						if (GlobalMembersGenerate_pre.fixedTimeActivity[actIndex] || GlobalMembersGenerate.swappedActivities[actIndex] || actIndex == ai || acts.contains(actIndex))
							actIndex = -1;

						if (actIndex >= 0)
						{
							Debug.Assert(!acts.contains(actIndex));
							acts.append(actIndex);
						}
					}
			}
		//}

		if (acts.count() > 0)
		{
			int t;

			if (level == 0)
			{
				int optMinWrong = GlobalMembersGenerate.INF;

				QList<int> tl = new QList<int>();

				for (int q = 0; q < acts.count(); q++)
				{
					int ai2 = acts.at(q);
					if (optMinWrong > GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]))
					{
						 optMinWrong = GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]);
					}
				}

				for (int q = 0; q < acts.count(); q++)
				{
					int ai2 = acts.at(q);
					if (optMinWrong == GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]))
						tl.append(q);
				}

				Debug.Assert(tl.size() >= 1);
				int mpos = tl.at(GlobalMembersTimetable_defs.randomKnuth(tl.size()));

				Debug.Assert(mpos >= 0 && mpos < acts.count());
				t = mpos;
			}
			else
			{
				t = GlobalMembersTimetable_defs.randomKnuth(acts.count());
			}

			int ai2 = acts.at(t);

			removedActivity = ai2;

			Debug.Assert(!conflActivities.contains(ai2));
			conflActivities.append(ai2);
			nConflActivities++;
			Debug.Assert(nConflActivities == conflActivities.count());

			return true;
		}
		else
			return false;
	}

	private bool subgroupRemoveAnActivityFromAnywhereCertainDayCertainActivityTag(int sbg, int d2, int actTag, int level, int ai, ref QList<int> conflActivities, ref int nConflActivities, ref int removedActivity)
	{
		Q_UNUSED(sbg);

		//remove an activity from anywhere
		QList<int> acts = new QList<int>();
		//for(int d2=0; d2<gt.rules.nDaysPerWeek; d2++){
			if (GlobalMembersGenerate.sbgDayNHours[d2] > 0)
			{
				int actIndex = -1;
				int h2;
				for (h2 = 0; h2 < gt.rules.nHoursPerDay; h2++)
					if (GlobalMembersGenerate.sbgTimetable(d2,h2) >= 0)
					{
						actIndex = GlobalMembersGenerate.sbgTimetable(d2,h2);

						if (GlobalMembersGenerate_pre.fixedTimeActivity[actIndex] || GlobalMembersGenerate.swappedActivities[actIndex] || actIndex == ai || acts.contains(actIndex) || !gt.rules.internalActivitiesList[actIndex].iActivityTagsSet.contains(actTag))
							actIndex = -1;

						if (actIndex >= 0)
						{
							Debug.Assert(!acts.contains(actIndex));
							acts.append(actIndex);
						}
					}
			}
		//}

		if (acts.count() > 0)
		{
			int t;

			if (level == 0)
			{
				int optMinWrong = GlobalMembersGenerate.INF;

				QList<int> tl = new QList<int>();

				for (int q = 0; q < acts.count(); q++)
				{
					int ai2 = acts.at(q);
					if (optMinWrong > GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]))
					{
						 optMinWrong = GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]);
					}
				}

				for (int q = 0; q < acts.count(); q++)
				{
					int ai2 = acts.at(q);
					if (optMinWrong == GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]))
						tl.append(q);
				}

				Debug.Assert(tl.size() >= 1);
				int mpos = tl.at(GlobalMembersTimetable_defs.randomKnuth(tl.size()));

				Debug.Assert(mpos >= 0 && mpos < acts.count());
				t = mpos;
			}
			else
			{
				t = GlobalMembersTimetable_defs.randomKnuth(acts.count());
			}

			int ai2 = acts.at(t);

			removedActivity = ai2;

			Debug.Assert(!conflActivities.contains(ai2));
			conflActivities.append(ai2);
			nConflActivities++;
			Debug.Assert(nConflActivities == conflActivities.count());

			return true;
		}
		else
			return false;
	}


	//2012-04-29
	private bool checkActivitiesOccupyMaxDifferentRooms(QList<int> globalConflActivities, int rm, int level, int ai, ref QList<int> tmp_list)
	{
		foreach (ActivitiesOccupyMaxDifferentRooms_item * item, GlobalMembersGenerate_pre.aomdrListForActivity[ai])
		{
			//preliminary
			QSet<int> occupiedRoomsSet = new QSet<int>();
			foreach (int ai2, item.activitiesList) if (ai2 != ai && !globalConflActivities.contains(ai2) && !tmp_list.contains(ai2))
			{
					int rm2 = c.rooms[ai2];
					if (rm2 != GlobalMembersTimetable_defs.UNALLOCATED_SPACE && rm2 != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM)
						if (!occupiedRoomsSet.contains(rm2))
						{
							occupiedRoomsSet.insert(rm2);
							if (occupiedRoomsSet.count() == item.maxDifferentRooms) //no further testing needed
								break;
						}
			}

			if (!globalConflActivities.contains(ai) && !tmp_list.contains(ai)) //should be always true
				if (rm != GlobalMembersTimetable_defs.UNALLOCATED_SPACE && rm != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM) //should be always true
					if (!occupiedRoomsSet.contains(rm))
						occupiedRoomsSet.insert(rm);

			if (occupiedRoomsSet.count() <= item.maxDifferentRooms)
				continue;

			//correction needed
			QList<QSet<int>> activitiesInRoom = new QList<QSet<int>>();
			occupiedRoomsSet.clear();
			QList<int> occupiedRoomsList = new QList<int>();
			QHash<int, int> roomIndexInOccupiedRoomsList = new QHash<int, int>();
			QList<bool> canEmptyRoom = new QList<bool>();

			foreach (int ai2, item.activitiesList) if (!globalConflActivities.contains(ai2) && !tmp_list.contains(ai2))
			{
					int rm2;
					if (ai2 == ai)
						rm2 = rm;
					else
						rm2 = c.rooms[ai2];
					if (rm2 != GlobalMembersTimetable_defs.UNALLOCATED_SPACE && rm2 != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM)
					{
						int ind;
						if (!occupiedRoomsSet.contains(rm2))
						{
							occupiedRoomsSet.insert(rm2);
							occupiedRoomsList.append(rm2);
							canEmptyRoom.append(true);

							QSet<int> tl = new QSet<int>();
							tl.insert(ai2);
							activitiesInRoom.append(tl);

							ind = activitiesInRoom.count() - 1;
							roomIndexInOccupiedRoomsList.insert(rm2, ind);
						}
						else
						{
							Debug.Assert(roomIndexInOccupiedRoomsList.contains(rm2));
							ind = roomIndexInOccupiedRoomsList.value(rm2);
							Debug.Assert(ind >= 0 && ind < activitiesInRoom.count());
							activitiesInRoom[ind].insert(ai2);
						}

						if (ai2 == ai || GlobalMembersGenerate_pre.fixedTimeActivity[ai2] || GlobalMembersGenerate.swappedActivities[ai2])
							if (canEmptyRoom[ind] == true)
								canEmptyRoom[ind] = false;
					}
			}

			Debug.Assert(occupiedRoomsSet.count() == item.maxDifferentRooms + 1);

			QList<int> candidates = new QList<int>();
			foreach (int rm2, occupiedRoomsList)
			{
				Debug.Assert(roomIndexInOccupiedRoomsList.contains(rm2));
				int ind = roomIndexInOccupiedRoomsList.value(rm2);
				if (canEmptyRoom.at(ind) == true)
					candidates.append(ind);
			}

			if (level == 0)
			{
				QList<int> finalCandidates = new QList<int>();

				int optConflActivities = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
				int optMinWrong = GlobalMembersGenerate.INF;
				int optNWrong = GlobalMembersGenerate.INF;
				int optMinIndexAct = gt.rules.nInternalActivities;

				//phase 1
				foreach (int ind, candidates)
				{
					QSet<int> activitiesForCandidate = activitiesInRoom.at(ind);

					int tmp_n_confl_acts = activitiesForCandidate.count();
					int tmp_minWrong = GlobalMembersGenerate.INF;
					int tmp_nWrong = 0;
					int tmp_minIndexAct = gt.rules.nInternalActivities;

					if (activitiesForCandidate.count() > 0)
					{
						foreach (int ai2, activitiesForCandidate)
						{
							tmp_minWrong = min(tmp_minWrong, GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]));
							tmp_nWrong += GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]);
							tmp_minIndexAct = min(tmp_minIndexAct, GlobalMembersGenerate.invPermutation[ai2]);
						}
					}
					else
					{
						Debug.Assert(0);
						tmp_minWrong = 0;
						tmp_nWrong = 0;
						tmp_minIndexAct = -1;
					}

					if (optMinWrong > tmp_minWrong || (optMinWrong == tmp_minWrong && optNWrong > tmp_nWrong) || (optMinWrong == tmp_minWrong && optNWrong == tmp_nWrong && optConflActivities > tmp_n_confl_acts) || (optMinWrong == tmp_minWrong && optNWrong == tmp_nWrong && optConflActivities == tmp_n_confl_acts && optMinIndexAct > tmp_minIndexAct))
					{
						optConflActivities = tmp_n_confl_acts;
						optMinWrong = tmp_minWrong;
						optNWrong = tmp_nWrong;
						optMinIndexAct = tmp_minIndexAct;
					}
				}

				//phase 2
				foreach (int ind, candidates)
				{
					QSet<int> activitiesForCandidate = activitiesInRoom.at(ind);

					int tmp_n_confl_acts = activitiesForCandidate.count();
					int tmp_minWrong = GlobalMembersGenerate.INF;
					int tmp_nWrong = 0;
					int tmp_minIndexAct = gt.rules.nInternalActivities;

					if (activitiesForCandidate.count() > 0)
					{
						foreach (int ai2, activitiesForCandidate)
						{
							tmp_minWrong = min(tmp_minWrong, GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]));
							tmp_nWrong += GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]);
							tmp_minIndexAct = min(tmp_minIndexAct, GlobalMembersGenerate.invPermutation[ai2]);
						}
					}
					else
					{
						Debug.Assert(0);
						tmp_minWrong = 0;
						tmp_nWrong = 0;
						tmp_minIndexAct = -1;
					}

					if (optMinWrong == tmp_minWrong && optNWrong == tmp_nWrong && optConflActivities == tmp_n_confl_acts && optMinIndexAct == tmp_minIndexAct)
					{
						finalCandidates.append(ind);
					}
				}

				//phase 3
				if (candidates.count() > 0)
					Debug.Assert(finalCandidates.count() > 0);
				candidates = finalCandidates;
			}
			else //if(level>0)
			{
				QList<int> finalCandidates = new QList<int>();

				int optConflActivities = GlobalMembersTimetable_defs.MAX_ACTIVITIES;

				foreach (int ind, candidates)
				{
					if (activitiesInRoom.at(ind).count() < optConflActivities)
					{
						optConflActivities = activitiesInRoom.at(ind).count();
						finalCandidates.clear();
						finalCandidates.append(ind);
					}
					else if (activitiesInRoom.at(ind).count() == optConflActivities)
					{
						finalCandidates.append(ind);
					}
				}

				if (candidates.count() > 0)
					Debug.Assert(finalCandidates.count() > 0);
				candidates = finalCandidates;
			}

			if (candidates.count() == 0)
				return false;

			int indexToRemove = candidates.at(GlobalMembersTimetable_defs.randomKnuth(candidates.count()));
			Debug.Assert(canEmptyRoom.at(indexToRemove) == true);

			//To keep generation identical on all computers - 2013-01-03
			QList<int> tmpListFromSet = activitiesInRoom.at(indexToRemove).toList();
			qSort(tmpListFromSet);
			//Randomize list
			for (int i = 0; i < tmpListFromSet.count(); i++)
			{
				int t = tmpListFromSet.at(i);
				int r = GlobalMembersTimetable_defs.randomKnuth(tmpListFromSet.count() - i);
				tmpListFromSet[i] = tmpListFromSet[i + r];
				tmpListFromSet[i + r] = t;
			}

			foreach (int ai2, tmpListFromSet)
			{
				Debug.Assert(!globalConflActivities.contains(ai2) && !tmp_list.contains(ai2));
				Debug.Assert(ai2 != ai && !GlobalMembersGenerate_pre.fixedTimeActivity[ai2] && !GlobalMembersGenerate.swappedActivities[ai2]);
				tmp_list.append(ai2);
			}
		}

		return true;
	}

	//only one out of sbg and tch is >=0, other one is -1
	private bool checkBuildingChanges(int sbg, int tch, QList<int> globalConflActivities, int rm, int level, Activity act, int ai, int d, int h, ref QList<int> tmp_list)
	{
		Debug.Assert((sbg == -1 && tch >= 0) || (sbg >= 0 && tch == -1));
		if (sbg >= 0)
			Debug.Assert(sbg < gt.rules.nInternalSubgroups);
		if (tch >= 0)
			Debug.Assert(tch < gt.rules.nInternalTeachers);

		if (sbg >= 0)
			Debug.Assert(GlobalMembersGenerate_pre.minGapsBetweenBuildingChangesForStudentsPercentages[sbg] >= 0 || GlobalMembersGenerate_pre.maxBuildingChangesPerDayForStudentsPercentages[sbg] >= 0 || GlobalMembersGenerate_pre.maxBuildingChangesPerWeekForStudentsPercentages[sbg] >= 0);
		if (tch >= 0)
			Debug.Assert(GlobalMembersGenerate_pre.minGapsBetweenBuildingChangesForTeachersPercentages[tch] >= 0 || GlobalMembersGenerate_pre.maxBuildingChangesPerDayForTeachersPercentages[tch] >= 0 || GlobalMembersGenerate_pre.maxBuildingChangesPerWeekForTeachersPercentages[tch] >= 0);

		int[] buildings = new int[GlobalMembersTimetable_defs.MAX_HOURS_PER_DAY];
		int[] activities = new int[GlobalMembersTimetable_defs.MAX_HOURS_PER_DAY];
		for (int h2 = 0; h2 < gt.rules.nHoursPerDay; h2++)
		{
			int ai2;
			if (sbg >= 0)
				ai2 = GlobalMembersGenerate.newSubgroupsTimetable(sbg,d,h2);
			else
				ai2 = GlobalMembersGenerate.newTeachersTimetable(tch,d,h2);

			if (ai2 >= 0 && !globalConflActivities.contains(ai2) && !tmp_list.contains(ai2))
			{
				int rm2;
				if (h2 >= h && h2 < h + act.duration)
				{
					Debug.Assert(ai2 == ai);
					rm2 = rm;
				}
				else
					rm2 = c.rooms[ai2];
				if (rm2 != GlobalMembersTimetable_defs.UNALLOCATED_SPACE && rm2 != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM)
				{
					Debug.Assert(rm2 >= 0);
					activities[h2] = ai2;
					buildings[h2] = gt.rules.internalRoomsList[rm2].buildingIndex;
				}
				else
				{
					activities[h2] = ai2;
					buildings[h2] = -1;
				}
			}
			else
			{
				buildings[h2] = -1;
				activities[h2] = -1;
			}
		}

		if (buildings[h] == -1) //no problem
			return true;

		//min gaps
		double perc;
		int mg;
		if (sbg >= 0)
		{
			perc = GlobalMembersGenerate_pre.minGapsBetweenBuildingChangesForStudentsPercentages[sbg];
			mg = GlobalMembersGenerate_pre.minGapsBetweenBuildingChangesForStudentsMinGaps[sbg];
		}
		else
		{
			perc = GlobalMembersGenerate_pre.minGapsBetweenBuildingChangesForTeachersPercentages[tch];
			mg = GlobalMembersGenerate_pre.minGapsBetweenBuildingChangesForTeachersMinGaps[tch];
		}
		if (perc >= 0)
		{
			for (int h2 = GlobalMembersGenerate.max(0, h - mg); h2 <= min(h + act.duration - 1 + mg, gt.rules.nHoursPerDay - 1); h2++)
				if (!(h2 >= h && h2 < h + act.duration))
					if (buildings[h2] != buildings[h] && buildings[h2] != -1)
					{
						int ai2 = activities[h2];
						Debug.Assert(ai2 >= 0);
						if (!GlobalMembersGenerate.swappedActivities[ai2] && !(GlobalMembersGenerate_pre.fixedTimeActivity[ai2] GlobalMembersGenerate_pre.fixedSpaceActivity[ai2]))
						{
							if (!tmp_list.contains(ai2))
							{
								tmp_list.append(ai2);

								int ha = c.times[ai2] / gt.rules.nDaysPerWeek;
								int dura = gt.rules.internalActivitiesList[ai2].duration;
								for (int h3 = ha; h3 < ha + dura; h3++)
								{
									Debug.Assert(activities[h3] == ai2);
									Debug.Assert(buildings[h3] != -1);
									buildings[h3] = -1;
									activities[h3] = -1;
								}
							}
						}
						else
						{
							return false;
						}
					}
		}

		//max changes per day
		int mc;
		if (sbg >= 0)
		{
			perc = GlobalMembersGenerate_pre.maxBuildingChangesPerDayForStudentsPercentages[sbg];
			mc = GlobalMembersGenerate_pre.maxBuildingChangesPerDayForStudentsMaxChanges[sbg];
		}
		else
		{
			perc = GlobalMembersGenerate_pre.maxBuildingChangesPerDayForTeachersPercentages[tch];
			mc = GlobalMembersGenerate_pre.maxBuildingChangesPerDayForTeachersMaxChanges[tch];
		}

		if (perc >= 0)
		{
			int crt_building = -1;
			int n_changes = 0;
			for (int h2 = 0; h2 < gt.rules.nHoursPerDay; h2++)
				if (buildings[h2] != -1)
				{
					if (crt_building != buildings[h2])
					{
						if (crt_building != -1)
							n_changes++;
						crt_building = buildings[h2];
					}
				}

			if (n_changes > mc) //not OK
			{
				if (level >= GlobalMembersGenerate.LEVEL_STOP_CONFLICTS_CALCULATION)
					return false;

				QList<int> removableActsList = new QList<int>();
				for (int h2 = 0; h2 < gt.rules.nHoursPerDay; h2++)
				{
					if (!(h2 >= h && h2 < h + act.duration))
						if (buildings[h2] != -1 && activities[h2] >= 0 && !GlobalMembersGenerate.swappedActivities[activities[h2]] && !(GlobalMembersGenerate_pre.fixedTimeActivity[activities[h2]] GlobalMembersGenerate_pre.fixedSpaceActivity[activities[h2]]))
							if (!removableActsList.contains(activities[h2]))
							{
								removableActsList.append(activities[h2]);
								Debug.Assert(!globalConflActivities.contains(activities[h2]));
								Debug.Assert(!tmp_list.contains(activities[h2]));
							}
				}

				for (;;)
				{
					int ai2 = -1;
					QList<int> optimalRemovableActs = new QList<int>();
					if (level == 0)
					{
						int nWrong = GlobalMembersGenerate.INF;
						foreach (int a, removableActsList) if (nWrong > GlobalMembersGenerate.triedRemovals(a,c.times[a]))
						{
								nWrong = GlobalMembersGenerate.triedRemovals(a,c.times[a]);
						}
						foreach (int a, removableActsList) if (nWrong == GlobalMembersGenerate.triedRemovals(a,c.times[a])) optimalRemovableActs.append(a);
					}
					else
						optimalRemovableActs = removableActsList;

					if (removableActsList.count() > 0)
						Debug.Assert(optimalRemovableActs.count() > 0);

					if (optimalRemovableActs.count() == 0)
						return false;

					ai2 = optimalRemovableActs.at(GlobalMembersTimetable_defs.randomKnuth(optimalRemovableActs.count()));

					Debug.Assert(!GlobalMembersGenerate.swappedActivities[ai2]);
					Debug.Assert(!(GlobalMembersGenerate_pre.fixedTimeActivity[ai2] GlobalMembersGenerate_pre.fixedSpaceActivity[ai2]));
					Debug.Assert(!globalConflActivities.contains(ai2));
					Debug.Assert(!tmp_list.contains(ai2));
					Debug.Assert(ai2 >= 0);

					tmp_list.append(ai2);

					int t = removableActsList.removeAll(ai2);
					Debug.Assert(t == 1);

					int ha = c.times[ai2] / gt.rules.nDaysPerWeek;
					int da = gt.rules.internalActivitiesList[ai2].duration;
					for (int h2 = ha; h2 < ha + da; h2++)
					{
						Debug.Assert(activities[h2] == ai2);
						Debug.Assert(buildings[h2] != -1);
						buildings[h2] = -1;
						activities[h2] = -1;
					}

					int crt_building = -1;
					int n_changes = 0;
					for (int h2 = 0; h2 < gt.rules.nHoursPerDay; h2++)
						if (buildings[h2] != -1)
						{
							if (crt_building != buildings[h2])
							{
								if (crt_building != -1)
									n_changes++;
								crt_building = buildings[h2];
							}
						}

					if (n_changes <= mc) //OK
					{
						break;
					}
				}
			}
		}

		//max changes per week
		if (sbg >= 0)
		{
			perc = GlobalMembersGenerate_pre.maxBuildingChangesPerWeekForStudentsPercentages[sbg];
			mc = GlobalMembersGenerate_pre.maxBuildingChangesPerWeekForStudentsMaxChanges[sbg];
		}
		else
		{
			perc = GlobalMembersGenerate_pre.maxBuildingChangesPerWeekForTeachersPercentages[tch];
			mc = GlobalMembersGenerate_pre.maxBuildingChangesPerWeekForTeachersMaxChanges[tch];
		}
		if (perc == -1)
		{
			Debug.Assert(mc == -1);
			return true;
		}

		//I would like to get rid of these large static variables, but making them dynamic slows down ~33% for a sample from Timisoara Economics
		int[,] weekBuildings = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK, GlobalMembersTimetable_defs.MAX_HOURS_PER_DAY];
		int[,] weekActivities = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK, GlobalMembersTimetable_defs.MAX_HOURS_PER_DAY];
		for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
		{
			for (int h2 = 0; h2 < gt.rules.nHoursPerDay; h2++)
			{
				int ai2;
				if (sbg >= 0)
					ai2 = GlobalMembersGenerate.newSubgroupsTimetable(sbg,d2,h2);
				else
					ai2 = GlobalMembersGenerate.newTeachersTimetable(tch,d2,h2);

				if (ai2 >= 0 && !globalConflActivities.contains(ai2) && !tmp_list.contains(ai2))
				{
					int rm2;
					if (d == d2 && h2 >= h && h2 < h + act.duration)
					{
						Debug.Assert(ai2 == ai);
						rm2 = rm;
					}
					else
						rm2 = c.rooms[ai2];
					if (rm2 != GlobalMembersTimetable_defs.UNALLOCATED_SPACE && rm2 != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM)
					{
						Debug.Assert(rm2 >= 0);
						weekActivities[d2, h2] = ai2;
						weekBuildings[d2, h2] = gt.rules.internalRoomsList[rm2].buildingIndex;
					}
					else
					{
						weekActivities[d2, h2] = ai2;
						weekBuildings[d2, h2] = -1;
					}
				}
				else
				{
					weekBuildings[d2, h2] = -1;
					weekActivities[d2, h2] = -1;
				}
			}
		}

		int n_changes = 0;
		for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
		{
			int crt_building = -1;
			for (int h2 = 0; h2 < gt.rules.nHoursPerDay; h2++)
				if (weekBuildings[d2, h2] != -1)
				{
					if (crt_building != weekBuildings[d2, h2])
					{
						if (crt_building != -1)
							n_changes++;
						crt_building = weekBuildings[d2, h2];
					}
				}
		}

		if (n_changes > mc) //not OK
		{
			if (level >= GlobalMembersGenerate.LEVEL_STOP_CONFLICTS_CALCULATION)
				return false;

			QList<int> removableActsList = new QList<int>();
			for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
			{
				for (int h2 = 0; h2 < gt.rules.nHoursPerDay; h2++)
				{
					if (!(d2 == d && h2 >= h && h2 < h + act.duration))
						if (weekBuildings[d2, h2] != -1 && weekActivities[d2, h2] >= 0 && !GlobalMembersGenerate.swappedActivities[weekActivities[d2, h2]] && !(GlobalMembersGenerate_pre.fixedTimeActivity[weekActivities[d2, h2]] GlobalMembersGenerate_pre.fixedSpaceActivity[weekActivities[d2, h2]]))
							if (!removableActsList.contains(weekActivities[d2, h2]))
							{
								removableActsList.append(weekActivities[d2, h2]);
								Debug.Assert(!globalConflActivities.contains(weekActivities[d2, h2]));
								Debug.Assert(!tmp_list.contains(weekActivities[d2, h2]));
							}
				}
			}

			for (;;)
			{
				int ai2 = -1;
				QList<int> optimalRemovableActs = new QList<int>();
				if (level == 0)
				{
					int nWrong = GlobalMembersGenerate.INF;
					foreach (int a, removableActsList) if (nWrong > GlobalMembersGenerate.triedRemovals(a,c.times[a]))
					{
							nWrong = GlobalMembersGenerate.triedRemovals(a,c.times[a]);
					}
					foreach (int a, removableActsList) if (nWrong == GlobalMembersGenerate.triedRemovals(a,c.times[a])) optimalRemovableActs.append(a);
				}
				else
					optimalRemovableActs = removableActsList;

				if (removableActsList.count() > 0)
					Debug.Assert(optimalRemovableActs.count() > 0);

				if (optimalRemovableActs.count() == 0)
					return false;

				ai2 = optimalRemovableActs.at(GlobalMembersTimetable_defs.randomKnuth(optimalRemovableActs.count()));

				Debug.Assert(!GlobalMembersGenerate.swappedActivities[ai2]);
				Debug.Assert(!(GlobalMembersGenerate_pre.fixedTimeActivity[ai2] GlobalMembersGenerate_pre.fixedSpaceActivity[ai2]));
				Debug.Assert(!globalConflActivities.contains(ai2));
				Debug.Assert(!tmp_list.contains(ai2));
				Debug.Assert(ai2 >= 0);

				tmp_list.append(ai2);

				int t = removableActsList.removeAll(ai2);
				Debug.Assert(t == 1);

				int ha = c.times[ai2] / gt.rules.nDaysPerWeek;
				int da = c.times[ai2] % gt.rules.nDaysPerWeek;
				int dura = gt.rules.internalActivitiesList[ai2].duration;
				for (int h2 = ha; h2 < ha + dura; h2++)
				{
					Debug.Assert(weekActivities[da, h2] == ai2);
					Debug.Assert(weekBuildings[da, h2] != -1);
					weekBuildings[da, h2] = -1;
					weekActivities[da, h2] = -1;
				}

				int n_changes = 0;
				for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
				{
					int crt_building = -1;
					for (int h2 = 0; h2 < gt.rules.nHoursPerDay; h2++)
						if (weekBuildings[d2, h2] != -1)
						{
							if (crt_building != weekBuildings[d2, h2])
							{
								if (crt_building != -1)
									n_changes++;
								crt_building = weekBuildings[d2, h2];
							}
						}
				}

				if (n_changes <= mc) //OK
				{
					break;
				}
			}
		}

		return true;
	}
	private bool chooseRoom(QList<int> listOfRooms, QList<int> globalConflActivities, int level, Activity act, int ai, int d, int h, ref int roomSlot, ref int selectedSlot, ref QList<int> localConflActivities)
	{
		roomSlot = selectedSlot = GlobalMembersTimetable_defs.UNSPECIFIED_ROOM; //if we don't find a room, return these values

		Q_UNUSED(ai);

		int optConflActivities = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
		int optMinWrong = GlobalMembersGenerate.INF;
		int optNWrong = GlobalMembersGenerate.INF;
		int optMinIndexAct = gt.rules.nInternalActivities;

		QList<QList<int>> conflActivitiesRooms = new QList<QList<int>>();
		QList<int> nConflActivitiesRooms = new QList<int>();
		QList<int> listedRooms = new QList<int>();

		QList<int> minWrong = new QList<int>();
		QList<int> nWrong = new QList<int>();
		QList<int> minIndexAct = new QList<int>();

		QList<int> tmp_list = new QList<int>();
		int tmp_n_confl_acts;
		int tmp_minWrong;
		int tmp_nWrong;
		int tmp_minIndexAct;

		int newtime = d + h * gt.rules.nDaysPerWeek;

		foreach (int rm, listOfRooms)
		{
			int dur;
			for (dur = 0; dur < act.duration; dur++)
				if (GlobalMembersGenerate_pre.notAllowedRoomTimePercentages[rm][newtime + dur * gt.rules.nDaysPerWeek] >= 0 && !GlobalMembersGenerate.skipRandom(GlobalMembersGenerate_pre.notAllowedRoomTimePercentages[rm][newtime + dur * gt.rules.nDaysPerWeek]))
					 break;

			if (dur == act.duration)
			{
				tmp_list.clear();

				int dur2;
				for (dur2 = 0; dur2 < act.duration; dur2++)
				{
					int ai2 = GlobalMembersGenerate.roomsTimetable(rm,d,h + dur2);
					if (ai2 >= 0)
					{
						if (!globalConflActivities.contains(ai2))
						{
							if (GlobalMembersGenerate.swappedActivities[ai2] || (GlobalMembersGenerate_pre.fixedTimeActivity[ai2] GlobalMembersGenerate_pre.fixedSpaceActivity[ai2]))
							{
								tmp_n_confl_acts = GlobalMembersTimetable_defs.MAX_ACTIVITIES; //not really needed
								break;
							}
							else
							{
								if (!tmp_list.contains(ai2))
								{
									tmp_list.append(ai2);
								}
							}
						}
					}
				}
				if (dur2 == act.duration)
				{
					//see building changes

					//building changes for students
					bool ok = true;
					foreach (int sbg, act.iSubgroupsList)
					{
						if (GlobalMembersGenerate_pre.minGapsBetweenBuildingChangesForStudentsPercentages[sbg] >= 0 || GlobalMembersGenerate_pre.maxBuildingChangesPerDayForStudentsPercentages[sbg] >= 0 || GlobalMembersGenerate_pre.maxBuildingChangesPerWeekForStudentsPercentages[sbg] >= 0)
						{
							ok = checkBuildingChanges(sbg, -1, globalConflActivities, rm, level, act, ai, d, h, ref tmp_list);
							if (!ok)
								break;
						}
					}

					if (!ok)
						continue;

					//building changes for teachers
					foreach (int tch, act.iTeachersList)
					{
						if (GlobalMembersGenerate_pre.minGapsBetweenBuildingChangesForTeachersPercentages[tch] >= 0 || GlobalMembersGenerate_pre.maxBuildingChangesPerDayForTeachersPercentages[tch] >= 0 || GlobalMembersGenerate_pre.maxBuildingChangesPerWeekForTeachersPercentages[tch] >= 0)
						{
							ok = checkBuildingChanges(-1, tch, globalConflActivities, rm, level, act, ai, d, h, ref tmp_list);
							if (!ok)
								break;
						}
					}

					if (!ok)
						continue;

					//max occupied rooms for a set of activities - 2012-04-29
					if (GlobalMembersGenerate_pre.aomdrListForActivity[ai].count() > 0)
						ok = checkActivitiesOccupyMaxDifferentRooms(globalConflActivities, rm, level, ai, ref tmp_list);

					if (!ok)
						continue;

					tmp_n_confl_acts = 0;

					tmp_minWrong = GlobalMembersGenerate.INF;
					tmp_nWrong = 0;

					tmp_minIndexAct = gt.rules.nInternalActivities;

					tmp_n_confl_acts = tmp_list.count();

					if (level == 0)
					{
						if (tmp_list.count() > 0) //serious bug corrected on 2012-05-02, but it seems that it didn't affect people until now
						{
							foreach (int ai2, tmp_list)
							{
								tmp_minWrong = min(tmp_minWrong, GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]));
								tmp_nWrong += GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]);
								tmp_minIndexAct = min(tmp_minIndexAct, GlobalMembersGenerate.invPermutation[ai2]);
							}
						}
						else
						{
							tmp_minWrong = 0;
							tmp_nWrong = 0;
							tmp_minIndexAct = -1;
						}
					}

					listedRooms.append(rm);
					nConflActivitiesRooms.append(tmp_n_confl_acts);
					conflActivitiesRooms.append(tmp_list);

					if (level > 0)
					{
						if (tmp_n_confl_acts < optConflActivities)
							optConflActivities = tmp_n_confl_acts;
					}
					else // if(level==0)
					{
						minWrong.append(tmp_minWrong);
						nWrong.append(tmp_nWrong);
						minIndexAct.append(tmp_minIndexAct);

						if (optMinWrong > tmp_minWrong || (optMinWrong == tmp_minWrong && optNWrong > tmp_nWrong) || (optMinWrong == tmp_minWrong && optNWrong == tmp_nWrong && optConflActivities > tmp_n_confl_acts) || (optMinWrong == tmp_minWrong && optNWrong == tmp_nWrong && optConflActivities == tmp_n_confl_acts && optMinIndexAct > tmp_minIndexAct))
						{
							optConflActivities = tmp_n_confl_acts;
							optMinWrong = tmp_minWrong;
							optNWrong = tmp_nWrong;
							optMinIndexAct = tmp_minIndexAct;
						}
					}
				}
			}
			else //not really needed
				tmp_n_confl_acts = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
		}

		if (optConflActivities == GlobalMembersTimetable_defs.MAX_ACTIVITIES) //roomSlot == selectedSlot == UNSPECIFIED_ROOM
			return false;

		Debug.Assert(optConflActivities < GlobalMembersTimetable_defs.MAX_ACTIVITIES);

		QList<int> allowedRoomsIndex = new QList<int>();

		Debug.Assert(listedRooms.count() == nConflActivitiesRooms.count());
		Debug.Assert(listedRooms.count() == conflActivitiesRooms.count());

		if (level > 0)
		{
			for (int q = 0; q < listedRooms.count(); q++)
			{
				if (nConflActivitiesRooms.at(q) == optConflActivities)
				{
					allowedRoomsIndex.append(q);
				}
			}
		}
		else
		{
			for (int q = 0; q < listedRooms.count(); q++)
			{
				if (optMinWrong == minWrong.at(q) && optNWrong == nWrong.at(q) && optConflActivities == nConflActivitiesRooms.at(q) && optMinIndexAct == minIndexAct.at(q))
				{
					allowedRoomsIndex.append(q);
				}
			}
			/*if(allowedRoomsIndex.count()!=1)
				cout<<"allowedRoomsIndex.count()=="<<allowedRoomsIndex.count()<<endl;
			assert(allowedRoomsIndex.count()==1);*/
		}

		Debug.Assert(allowedRoomsIndex.count() > 0);
		int q = GlobalMembersTimetable_defs.randomKnuth(allowedRoomsIndex.count());
		int t = allowedRoomsIndex.at(q);
		Debug.Assert(t >= 0 && t < listedRooms.count());
		int r = listedRooms.at(t);
		Debug.Assert(r >= 0 && r < gt.rules.nInternalRooms);
		selectedSlot = r;
		roomSlot = r;

		Debug.Assert(nConflActivitiesRooms.at(t) == conflActivitiesRooms.at(t).count());

		localConflActivities.clear(); /////Liviu: added 22 august 2008, nasty crash bug fix

		foreach (int a, conflActivitiesRooms.at(t))
		{
			Debug.Assert(!globalConflActivities.contains(a));
			Debug.Assert(!localConflActivities.contains(a)); ///////////Liviu: added 22 august 2008
			localConflActivities.append(a);
		}

		return true;
	}
	private bool getHomeRoom(QList<int> globalConflActivities, int level, Activity act, int ai, int d, int h, ref int roomSlot, ref int selectedSlot, ref QList<int> localConflActivities)
	{
		Debug.Assert(!GlobalMembersGenerate_pre.unspecifiedHomeRoom[ai]);

		return chooseRoom(GlobalMembersGenerate_pre.activitiesHomeRoomsHomeRooms[ai], globalConflActivities, level, act, ai, d, h, ref roomSlot, ref selectedSlot, ref localConflActivities);
	}
	private bool getPreferredRoom(QList<int> globalConflActivities, int level, Activity act, int ai, int d, int h, ref int roomSlot, ref int selectedSlot, ref QList<int> localConflActivities, ref bool canBeUnspecifiedPreferredRoom)
	{
		Debug.Assert(!GlobalMembersGenerate_pre.unspecifiedPreferredRoom[ai]);

		bool unspecifiedRoom = true;
		QSet<int> allowedRooms = new QSet<int>();
		foreach (PreferredRoomsItem it, GlobalMembersGenerate_pre.activitiesPreferredRoomsList[ai])
		{
			bool skip = GlobalMembersGenerate.skipRandom(it.percentage);

			if (!skip)
			{
				if (unspecifiedRoom)
				{
					unspecifiedRoom = false;
					allowedRooms = it.preferredRooms;
				}
				else
				{
					allowedRooms.intersect(it.preferredRooms);
				}
			}
			else
			{
				if (unspecifiedRoom)
				{
					allowedRooms.unite(it.preferredRooms);
				}
				else
				{
					//do nothing
				}
			}
		}

		QList<int> allowedRoomsList = new QList<int>();
		foreach (int rm, allowedRooms) allowedRoomsList.append(rm);
		qSort(allowedRoomsList); //To keep generation identical on all computers - 2013-01-03
		//Randomize list
		for (int i = 0; i < allowedRoomsList.count(); i++)
		{
			int t = allowedRoomsList.at(i);
			int r = GlobalMembersTimetable_defs.randomKnuth(allowedRoomsList.count() - i);
			allowedRoomsList[i] = allowedRoomsList[i + r];
			allowedRoomsList[i + r] = t;
		}

		canBeUnspecifiedPreferredRoom = unspecifiedRoom;

		return chooseRoom(allowedRoomsList, globalConflActivities, level, act, ai, d, h, ref roomSlot, ref selectedSlot, ref localConflActivities);
	}
	private bool getRoom(int level, Activity act, int ai, int d, int h, ref int roomSlot, ref int selectedSlot, ref QList<int> conflActivities, ref int nConflActivities)
	{
		bool okp;
		bool okh;

		QList<int> localConflActivities = new QList<int>();

		if (GlobalMembersGenerate_pre.unspecifiedPreferredRoom[ai])
		{
			if (GlobalMembersGenerate_pre.unspecifiedHomeRoom[ai])
			{
				roomSlot = GlobalMembersTimetable_defs.UNSPECIFIED_ROOM;
				selectedSlot = GlobalMembersTimetable_defs.UNSPECIFIED_ROOM;
				return true;
			}
			else
			{
				okh = getHomeRoom(conflActivities, level, act, ai, d, h, ref roomSlot, ref selectedSlot, ref localConflActivities);
				if (okh)
				{
					foreach (int t, localConflActivities)
					{
						conflActivities.append(t);
						nConflActivities++;
					}
					return okh;
				}
				else
				{
					okh = GlobalMembersGenerate.skipRandom(GlobalMembersGenerate_pre.activitiesHomeRoomsPercentage[ai]);
					return okh;
				}
			}
		}
		else
		{
			bool canBeUnspecifiedPreferredRoom;

			okp = getPreferredRoom(conflActivities, level, act, ai, d, h, ref roomSlot, ref selectedSlot, ref localConflActivities, ref canBeUnspecifiedPreferredRoom);
			if (okp && localConflActivities.count() == 0)
			{
				/*foreach(int t, localConflActivities){
					conflActivities.append(t);
					nConflActivities++;
				}
				assert(nConflActivities==conflActivities.count());*/
				return okp;
			}
			else if (okp)
			{
				if (canBeUnspecifiedPreferredRoom) //skipRandom(activitiesPreferredRoomsPercentage[ai])){
				{
					//get a home room
					if (GlobalMembersGenerate_pre.unspecifiedHomeRoom[ai])
					{
						roomSlot = GlobalMembersTimetable_defs.UNSPECIFIED_ROOM;
						selectedSlot = GlobalMembersTimetable_defs.UNSPECIFIED_ROOM;
						return true;
					}

					okh = getHomeRoom(conflActivities, level, act, ai, d, h, ref roomSlot, ref selectedSlot, ref localConflActivities);
					if (okh)
					{
						foreach (int t, localConflActivities)
						{
							conflActivities.append(t);
							nConflActivities++;
						}
						return okh;
					}
					else
					{
						okh = GlobalMembersGenerate.skipRandom(GlobalMembersGenerate_pre.activitiesHomeRoomsPercentage[ai]);
						return okh;
					}
				}
				else
				{
					foreach (int t, localConflActivities)
					{
						conflActivities.append(t);
						nConflActivities++;
					}
					Debug.Assert(nConflActivities == conflActivities.count());
					Debug.Assert(okp == true);
					return okp;
					//get this preferred room
				}
			}
			else //!ok from preferred room, search a home room
			{
				if (canBeUnspecifiedPreferredRoom) //skipRandom(activitiesPreferredRoomsPercentage[ai])){
				{
					//get a home room
					if (GlobalMembersGenerate_pre.unspecifiedHomeRoom[ai])
					{
						roomSlot = GlobalMembersTimetable_defs.UNSPECIFIED_ROOM;
						selectedSlot = GlobalMembersTimetable_defs.UNSPECIFIED_ROOM;
						return true;
					}

					okh = getHomeRoom(conflActivities, level, act, ai, d, h, ref roomSlot, ref selectedSlot, ref localConflActivities);
					if (okh)
					{
						foreach (int t, localConflActivities)
						{
							conflActivities.append(t);
							nConflActivities++;
						}
						return okh;
					}
					else
					{
						okh = GlobalMembersGenerate.skipRandom(GlobalMembersGenerate_pre.activitiesHomeRoomsPercentage[ai]);
						return okh;
					}
				}
				else
				{
					Debug.Assert(okp == false);
					return okp;
				}
			}
		}
	}

	private Solution c = new Solution();

	private int nPlacedActivities;

	//difficult activities
	private int nDifficultActivities;
	private int[] difficultActivities = new int[MAX_ACTIVITIES];

	private int searchTime; //seconds

	private int timeToHighestStage; //seconds

	private bool abortOptimization;

	private bool precompute(QWidget parent)
	{
		return precompute(parent, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: bool precompute(QWidget* parent, QTextStream* initialOrderStream =null)
	private bool precompute(QWidget parent, QTextStream initialOrderStream)
	{
		return GlobalMembersGenerate_pre.processTimeSpaceConstraints(parent, initialOrderStream);
	}

	private void generate(int maxSeconds, ref bool impossible, ref bool timeExceeded, bool threaded)
	{
		generate(maxSeconds, ref impossible, ref timeExceeded, threaded, null);
	}
//C++ TO C# CONVERTER NOTE: Overloaded method(s) are created above to convert the following method having default parameters:
//ORIGINAL LINE: void generate(int maxSeconds, bool& impossible, bool& timeExceeded, bool threaded, QTextStream* maxPlacedActivityStream =null)
	private void generate(int maxSeconds, ref bool impossible, ref bool timeExceeded, bool threaded, QTextStream maxPlacedActivityStream)
	{
		this.isThreaded = threaded;

		GlobalMembersGenerate.l0nWrong.resize(gt.rules.nHoursPerWeek);
		GlobalMembersGenerate.l0minWrong.resize(gt.rules.nHoursPerWeek);
		GlobalMembersGenerate.l0minIndexAct.resize(gt.rules.nHoursPerWeek);

		GlobalMembersGenerate.teachersTimetable.resize(gt.rules.nInternalTeachers, gt.rules.nDaysPerWeek, gt.rules.nHoursPerDay);
		GlobalMembersGenerate.subgroupsTimetable.resize(gt.rules.nInternalSubgroups, gt.rules.nDaysPerWeek, gt.rules.nHoursPerDay);
		GlobalMembersGenerate.roomsTimetable.resize(gt.rules.nInternalRooms, gt.rules.nDaysPerWeek, gt.rules.nHoursPerDay);

		GlobalMembersGenerate.newTeachersTimetable.resize(gt.rules.nInternalTeachers, gt.rules.nDaysPerWeek, gt.rules.nHoursPerDay);
		GlobalMembersGenerate.newSubgroupsTimetable.resize(gt.rules.nInternalSubgroups, gt.rules.nDaysPerWeek, gt.rules.nHoursPerDay);
		GlobalMembersGenerate.newTeachersDayNHours.resize(gt.rules.nInternalTeachers, gt.rules.nDaysPerWeek);
		GlobalMembersGenerate.newTeachersDayNGaps.resize(gt.rules.nInternalTeachers, gt.rules.nDaysPerWeek);
		GlobalMembersGenerate.newSubgroupsDayNHours.resize(gt.rules.nInternalSubgroups, gt.rules.nDaysPerWeek);
		GlobalMembersGenerate.newSubgroupsDayNGaps.resize(gt.rules.nInternalSubgroups, gt.rules.nDaysPerWeek);
		GlobalMembersGenerate.newSubgroupsDayNFirstGaps.resize(gt.rules.nInternalSubgroups, gt.rules.nDaysPerWeek);

		GlobalMembersGenerate.oldTeachersTimetable.resize(gt.rules.nInternalTeachers, gt.rules.nDaysPerWeek, gt.rules.nHoursPerDay);
		GlobalMembersGenerate.oldSubgroupsTimetable.resize(gt.rules.nInternalSubgroups, gt.rules.nDaysPerWeek, gt.rules.nHoursPerDay);
		GlobalMembersGenerate.oldTeachersDayNHours.resize(gt.rules.nInternalTeachers, gt.rules.nDaysPerWeek);
		GlobalMembersGenerate.oldTeachersDayNGaps.resize(gt.rules.nInternalTeachers, gt.rules.nDaysPerWeek);
		GlobalMembersGenerate.oldSubgroupsDayNHours.resize(gt.rules.nInternalSubgroups, gt.rules.nDaysPerWeek);
		GlobalMembersGenerate.oldSubgroupsDayNGaps.resize(gt.rules.nInternalSubgroups, gt.rules.nDaysPerWeek);
		GlobalMembersGenerate.oldSubgroupsDayNFirstGaps.resize(gt.rules.nInternalSubgroups, gt.rules.nDaysPerWeek);


		GlobalMembersGenerate.tchTimetable.resize(gt.rules.nDaysPerWeek, gt.rules.nHoursPerDay);
		GlobalMembersGenerate.tchDayNHours.resize(gt.rules.nDaysPerWeek);
		GlobalMembersGenerate.tchDayNGaps.resize(gt.rules.nDaysPerWeek);

		GlobalMembersGenerate.sbgTimetable.resize(gt.rules.nDaysPerWeek, gt.rules.nHoursPerDay);
		GlobalMembersGenerate.sbgDayNHours.resize(gt.rules.nDaysPerWeek);
		GlobalMembersGenerate.sbgDayNGaps.resize(gt.rules.nDaysPerWeek);
		GlobalMembersGenerate.sbgDayNFirstGaps.resize(gt.rules.nDaysPerWeek);

		GlobalMembersGenerate.teacherActivitiesOfTheDay.resize(gt.rules.nInternalTeachers, gt.rules.nDaysPerWeek);

		//2011-09-30
		if (GlobalMembersGenerate_pre.haveActivitiesOccupyOrSimultaneousConstraints)
		{
			GlobalMembersGenerate.activitiesAtTime.resize(gt.rules.nHoursPerWeek);

			GlobalMembersGenerate.slotSetOfActivities.resize(gt.rules.nHoursPerWeek);
			GlobalMembersGenerate.slotCanEmpty.resize(gt.rules.nHoursPerWeek);
		}

	if (threaded)
	{
			mutex.lock();
	}
		c.makeUnallocated(ref gt.rules);

		nDifficultActivities = 0;

		impossible = false;
		timeExceeded = false;

		GlobalMembersGenerate.maxncallsrandomswap = -1;

		GlobalMembersGenerate.impossibleActivity = false;

		GlobalMembersGenerate.maxActivitiesPlaced = 0;

	if (threaded)
	{
			mutex.unlock();
	}

		GlobalMembersGenerate.triedRemovals.resize(gt.rules.nInternalActivities, gt.rules.nHoursPerWeek);
		for (int i = 0; i < gt.rules.nInternalActivities; i++)
			for (int j = 0; j < gt.rules.nHoursPerWeek; j++)
				GlobalMembersGenerate.triedRemovals(i,j) = 0;

		////////init tabu
		GlobalMembersGenerate.tabu_size = gt.rules.nInternalActivities * gt.rules.nHoursPerWeek;
		//assert(tabu_size<=MAX_TABU);
		GlobalMembersGenerate.crt_tabu_index = 0;
		/*qint16 tabu_activities[MAX_TABU];
		qint16 tabu_times[MAX_TABU];*/
		GlobalMembersGenerate.tabu_activities.resize(GlobalMembersGenerate.tabu_size);
		GlobalMembersGenerate.tabu_times.resize(GlobalMembersGenerate.tabu_size);
		for (int i = 0; i < GlobalMembersGenerate.tabu_size; i++)
			GlobalMembersGenerate.tabu_activities[i] = GlobalMembersGenerate.tabu_times[i] = -1;
		/////////////////

		//abortOptimization=false; you have to take care of this before calling this function

		for (int i = 0; i < gt.rules.nInternalActivities; i++)
			GlobalMembersGenerate.invPermutation[GlobalMembersGenerate_pre.permutation[i]] = i;

		for (int i = 0; i < gt.rules.nInternalActivities; i++)
			GlobalMembersGenerate.swappedActivities[GlobalMembersGenerate_pre.permutation[i]] = false;

		//tzset();
		time_t starting_time = new time_t();
		time(starting_time);

	if (threaded)
	{
			mutex.lock();
	}
		timeToHighestStage = 0;
		searchTime = 0;
		GlobalMembersGenerate.generationStartDateTime = QDateTime.currentDateTime();
	if (threaded)
	{
			mutex.unlock();
	}

		//2000 was before
		//limitcallsrandomswap=1000; //1600, 1500 also good values, 1000 too low???
		GlobalMembersGenerate.limitcallsrandomswap = 2 * gt.rules.nInternalActivities; //???? value found practically

		GlobalMembersGenerate.level_limit = 14; //20; //16

		Debug.Assert(GlobalMembersGenerate.level_limit < GlobalMembersGenerate.MAX_LEVEL);

		for (int added_act = 0; added_act < gt.rules.nInternalActivities; added_act++)
		{
			prevvalue:

	if (threaded)
	{
			mutex.lock();
	}
			if (abortOptimization)
			{
	if (threaded)
	{
				mutex.unlock();
	}
				return;
			}
			time_t crt_time = new time_t();
			time(crt_time);
			searchTime = (int)(crt_time - starting_time);

			if (searchTime >= maxSeconds)
			{
	if (threaded)
	{
				mutex.unlock();
	}

				timeExceeded = true;

				return;
			}

			for (int i = 0; i <= added_act; i++)
				GlobalMembersGenerate.swappedActivities[GlobalMembersGenerate_pre.permutation[i]] = false;
			for (int i = added_act + 1; i < gt.rules.nInternalActivities; i++)
				Debug.Assert(!GlobalMembersGenerate.swappedActivities[GlobalMembersGenerate_pre.permutation[i]]);

			Console.Write("\n");
			Console.Write("Trying to place activity number added_act==");
			Console.Write(added_act);
			Console.Write("\nwith id==");
			Console.Write(gt.rules.internalActivitiesList[GlobalMembersGenerate_pre.permutation[added_act]].id);
			Console.Write(", from nInternalActivities==");
			Console.Write(gt.rules.nInternalActivities);
			Console.Write("\n");

			 //verifyUnallocated(permutation[added_act]]);
			//assert(c.times[permutation[added_act]]==UNALLOCATED_TIME);
			//assert(c.rooms[permutation[added_act]]==UNALLOCATED_SPACE);
			if (GlobalMembersGenerate_pre.fixedTimeActivity[GlobalMembersGenerate_pre.permutation[added_act]] && GlobalMembersGenerate_pre.fixedSpaceActivity[GlobalMembersGenerate_pre.permutation[added_act]])
			{
				Debug.Assert(c.times[GlobalMembersGenerate_pre.permutation[added_act]] == GlobalMembersTimetable_defs.UNALLOCATED_TIME);
				Debug.Assert(c.rooms[GlobalMembersGenerate_pre.permutation[added_act]] == GlobalMembersTimetable_defs.UNALLOCATED_SPACE);
			}
			else if (GlobalMembersGenerate_pre.fixedTimeActivity[GlobalMembersGenerate_pre.permutation[added_act]] && !GlobalMembersGenerate_pre.fixedSpaceActivity[GlobalMembersGenerate_pre.permutation[added_act]])
			{
				Debug.Assert(c.rooms[GlobalMembersGenerate_pre.permutation[added_act]] == GlobalMembersTimetable_defs.UNALLOCATED_SPACE);
			}
			else if (!GlobalMembersGenerate_pre.fixedTimeActivity[GlobalMembersGenerate_pre.permutation[added_act]])
			{
				Debug.Assert(c.times[GlobalMembersGenerate_pre.permutation[added_act]] == GlobalMembersTimetable_defs.UNALLOCATED_TIME);
				Debug.Assert(c.rooms[GlobalMembersGenerate_pre.permutation[added_act]] == GlobalMembersTimetable_defs.UNALLOCATED_SPACE);
			}
			else
				Debug.Assert(0);

			for (int i = 0; i < added_act; i++)
			{
				if (c.times[GlobalMembersGenerate_pre.permutation[i]] == GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
					Console.Write("ERROR: act with id==");
					Console.Write(gt.rules.internalActivitiesList[GlobalMembersGenerate_pre.permutation[i]].id);
					Console.Write(" has time unallocated");
					Console.Write("\n");
				}
				Debug.Assert(c.times[GlobalMembersGenerate_pre.permutation[i]] != GlobalMembersTimetable_defs.UNALLOCATED_TIME);
				/*for(int j=0; j<gt.rules.internalActivitiesList[permutation[i]].duration; j++)
					tlistSet[c.times[permutation[i]]+j*gt.rules.nDaysPerWeek].insert(permutation[i]);*/

				if (c.rooms[GlobalMembersGenerate_pre.permutation[i]] == GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
				{
					Console.Write("ERROR: act with id==");
					Console.Write(gt.rules.internalActivitiesList[GlobalMembersGenerate_pre.permutation[i]].id);
					Console.Write(" has room unallocated");
					Console.Write("\n");
				}
				Debug.Assert(c.rooms[GlobalMembersGenerate_pre.permutation[i]] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE);
			}

			///////////////rooms' timetable
			for (int i = 0; i < gt.rules.nInternalRooms; i++)
				for (int j = 0; j < gt.rules.nDaysPerWeek; j++)
					for (int k = 0; k < gt.rules.nHoursPerDay; k++)
						GlobalMembersGenerate.roomsTimetable(i,j,k) = -1;
			for (int j = 0; j < added_act; j++)
			{
				int i = GlobalMembersGenerate_pre.permutation[j];
				Debug.Assert(c.rooms[i] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE);
				if (c.rooms[i] != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM)
				{
					int rm = c.rooms[i];

					Activity act = gt.rules.internalActivitiesList[i];
					int hour = c.times[i] / gt.rules.nDaysPerWeek;
					int day = c.times[i] % gt.rules.nDaysPerWeek;
					for (int dd = 0; dd < act.duration && hour + dd < gt.rules.nHoursPerDay; dd++)
					{
						Debug.Assert(GlobalMembersGenerate.roomsTimetable(rm,day,hour + dd) == -1);
						GlobalMembersGenerate.roomsTimetable(rm,day,hour + dd) = i;
					}
				}
			}
			///////////////////////////////

			//subgroups' timetable
			for (int i = 0; i < gt.rules.nInternalSubgroups; i++)
				for (int j = 0; j < gt.rules.nDaysPerWeek; j++)
					for (int k = 0; k < gt.rules.nHoursPerDay; k++)
					{
						GlobalMembersGenerate.subgroupsTimetable(i,j,k) = -1;
					}
			for (int j = 0; j < gt.rules.nInternalActivities ; j++) //added_act
			{
				int i = GlobalMembersGenerate_pre.permutation[j];
				if (j < added_act)
				{
					Debug.Assert(c.times[i] != GlobalMembersTimetable_defs.UNALLOCATED_TIME);
				}
				else
				{
					if (c.times[i] == GlobalMembersTimetable_defs.UNALLOCATED_TIME)
						continue;
				}
				Debug.Assert(c.times[i] != GlobalMembersTimetable_defs.UNALLOCATED_TIME);
				Activity act = gt.rules.internalActivitiesList[i];
				int hour = c.times[i] / gt.rules.nDaysPerWeek;
				int day = c.times[i] % gt.rules.nDaysPerWeek;
				foreach (int sb, act.iSubgroupsList)
				{
					for (int dd = 0; dd < act.duration && hour + dd < gt.rules.nHoursPerDay; dd++)
					{
						Debug.Assert(GlobalMembersGenerate.subgroupsTimetable(sb,day,hour + dd) == -1);
						GlobalMembersGenerate.subgroupsTimetable(sb,day,hour + dd) = i;
					}
				}
			}

			//new
			for (int i = 0; i < gt.rules.nInternalSubgroups; i++)
				for (int j = 0; j < gt.rules.nDaysPerWeek; j++)
					for (int k = 0; k < gt.rules.nHoursPerDay; k++)
					{
						GlobalMembersGenerate.newSubgroupsTimetable(i,j,k) = -1;
					}
			for (int j = 0; j < gt.rules.nInternalActivities ; j++) //added_act
			{
				int i = GlobalMembersGenerate_pre.permutation[j];
				if (j < added_act)
				{
					Debug.Assert(c.times[i] != GlobalMembersTimetable_defs.UNALLOCATED_TIME);
				}
				else
				{
					if (c.times[i] == GlobalMembersTimetable_defs.UNALLOCATED_TIME)
						continue;
				}
				Debug.Assert(c.times[i] != GlobalMembersTimetable_defs.UNALLOCATED_TIME);
				Activity act = gt.rules.internalActivitiesList[i];
				int hour = c.times[i] / gt.rules.nDaysPerWeek;
				int day = c.times[i] % gt.rules.nDaysPerWeek;
				foreach (int sb, act.iSubgroupsList)
				{
					for (int dd = 0; dd < act.duration && hour + dd < gt.rules.nHoursPerDay; dd++)
					{
						Debug.Assert(GlobalMembersGenerate.newSubgroupsTimetable(sb,day,hour + dd) == -1);
						GlobalMembersGenerate.newSubgroupsTimetable(sb,day,hour + dd) = i;
					}
				}
			}

			for (int i = 0; i < gt.rules.nInternalSubgroups; i++)
				subgroupGetNHoursGaps(i);

			//teachers' timetable
			for (int i = 0; i < gt.rules.nInternalTeachers; i++)
				for (int j = 0; j < gt.rules.nDaysPerWeek; j++)
					for (int k = 0; k < gt.rules.nHoursPerDay; k++)
					{
						GlobalMembersGenerate.teachersTimetable(i,j,k) = -1;
					}
			for (int j = 0; j < gt.rules.nInternalActivities ; j++) //added_act
			{
				int i = GlobalMembersGenerate_pre.permutation[j];
				if (j < added_act)
				{
					Debug.Assert(c.times[i] != GlobalMembersTimetable_defs.UNALLOCATED_TIME);
				}
				else
				{
					if (c.times[i] == GlobalMembersTimetable_defs.UNALLOCATED_TIME)
						continue;
				}
				Debug.Assert(c.times[i] != GlobalMembersTimetable_defs.UNALLOCATED_TIME);
				Activity act = gt.rules.internalActivitiesList[i];
				int hour = c.times[i] / gt.rules.nDaysPerWeek;
				int day = c.times[i] % gt.rules.nDaysPerWeek;
				foreach (int tc, act.iTeachersList)
				{
					for (int dd = 0; dd < act.duration && hour + dd < gt.rules.nHoursPerDay; dd++)
					{
						Debug.Assert(GlobalMembersGenerate.teachersTimetable(tc,day,hour + dd) == -1);
						GlobalMembersGenerate.teachersTimetable(tc,day,hour + dd) = i;
					}
				}
			}

			//new
			for (int i = 0; i < gt.rules.nInternalTeachers; i++)
				for (int j = 0; j < gt.rules.nDaysPerWeek; j++)
					for (int k = 0; k < gt.rules.nHoursPerDay; k++)
					{
						GlobalMembersGenerate.newTeachersTimetable(i,j,k) = -1;
					}
			for (int j = 0; j < gt.rules.nInternalActivities ; j++) //added_act
			{
				int i = GlobalMembersGenerate_pre.permutation[j];
				if (j < added_act)
				{
					Debug.Assert(c.times[i] != GlobalMembersTimetable_defs.UNALLOCATED_TIME);
				}
				else
				{
					if (c.times[i] == GlobalMembersTimetable_defs.UNALLOCATED_TIME)
						continue;
				}
				Debug.Assert(c.times[i] != GlobalMembersTimetable_defs.UNALLOCATED_TIME);
				Activity act = gt.rules.internalActivitiesList[i];
				int hour = c.times[i] / gt.rules.nDaysPerWeek;
				int day = c.times[i] % gt.rules.nDaysPerWeek;
				foreach (int tc, act.iTeachersList)
				{
					for (int dd = 0; dd < act.duration && hour + dd < gt.rules.nHoursPerDay; dd++)
					{
						Debug.Assert(GlobalMembersGenerate.newTeachersTimetable(tc,day,hour + dd) == -1);
						GlobalMembersGenerate.newTeachersTimetable(tc,day,hour + dd) = i;
					}
				}
			}

			for (int i = 0; i < gt.rules.nInternalTeachers; i++)
				teacherGetNHoursGaps(i);

			//////////////care for teachers max days per week
			for (int i = 0; i < gt.rules.nInternalTeachers; i++)
				for (int j = 0; j < gt.rules.nDaysPerWeek; j++)
					GlobalMembersGenerate.teacherActivitiesOfTheDay(i,j).clear();

			for (int i = 0; i < gt.rules.nInternalActivities ; i++) //added_act
			{
				if (i < added_act)
				{
				}
				else
				{
					if (c.times[GlobalMembersGenerate_pre.permutation[i]] == GlobalMembersTimetable_defs.UNALLOCATED_TIME)
						continue;
				}
				//Activity* act=&gt.rules.internalActivitiesList[permutation[i]];
				int d = c.times[GlobalMembersGenerate_pre.permutation[i]] % gt.rules.nDaysPerWeek;

				foreach (int j, GlobalMembersGenerate_pre.teachersWithMaxDaysPerWeekForActivities[GlobalMembersGenerate_pre.permutation[i]])
				{
					Debug.Assert(GlobalMembersGenerate.teacherActivitiesOfTheDay(j,d).indexOf(GlobalMembersGenerate_pre.permutation[i]) == -1);
					GlobalMembersGenerate.teacherActivitiesOfTheDay(j,d).append(GlobalMembersGenerate_pre.permutation[i]);
				}
			}
			//////////////

			//2011-09-30
			if (GlobalMembersGenerate_pre.haveActivitiesOccupyOrSimultaneousConstraints)
			{
				for (int t = 0; t < gt.rules.nHoursPerWeek; t++)
					GlobalMembersGenerate.activitiesAtTime[t].clear();

				for (int j = 0; j < gt.rules.nInternalActivities ; j++) //added_act
				{
					int i = GlobalMembersGenerate_pre.permutation[j];
					if (j < added_act)
					{
						Debug.Assert(c.times[i] != GlobalMembersTimetable_defs.UNALLOCATED_TIME);
					}
					else
					{
						if (c.times[i] == GlobalMembersTimetable_defs.UNALLOCATED_TIME)
							continue;
					}
					Debug.Assert(c.times[i] != GlobalMembersTimetable_defs.UNALLOCATED_TIME);

					Activity act = gt.rules.internalActivitiesList[i];

					for (int t = c.times[i]; t < c.times[i] + act.duration * gt.rules.nDaysPerWeek; t += gt.rules.nDaysPerWeek)
					{
						Debug.Assert(!GlobalMembersGenerate.activitiesAtTime[t].contains(i));
						GlobalMembersGenerate.activitiesAtTime[t].insert(i);
					}
				}
			}
			//////////////

			GlobalMembersGenerate.foundGoodSwap = false;

			Debug.Assert(!GlobalMembersGenerate.swappedActivities[GlobalMembersGenerate_pre.permutation[added_act]]);
			GlobalMembersGenerate.swappedActivities[GlobalMembersGenerate_pre.permutation[added_act]] = true;

			GlobalMembersGenerate.nRestore = 0;
			GlobalMembersGenerate.ncallsrandomswap = 0;
			randomSwap(GlobalMembersGenerate_pre.permutation[added_act], 0);

			if (!GlobalMembersGenerate.foundGoodSwap)
			{
				if (GlobalMembersGenerate.impossibleActivity)
				{
	if (threaded)
	{
					mutex.unlock();
	}
					nDifficultActivities = 1;
					difficultActivities[0] = GlobalMembersGenerate_pre.permutation[added_act];

					impossible = true;

					emit(impossibleToSolve());

					return;
				}

				//update difficult activities (activities which are placed correctly so far, together with added_act
				nDifficultActivities = added_act + 1;
				Console.Write("nDifficultActivities==");
				Console.Write(nDifficultActivities);
				Console.Write("\n");
				for (int j = 0; j <= added_act; j++)
					difficultActivities[j] = GlobalMembersGenerate_pre.permutation[j];

	//////////////////////
				Debug.Assert(GlobalMembersGenerate.conflActivitiesTimeSlot.count() > 0);

				Console.Write("conflActivitiesTimeSlot.count()==");
				Console.Write(GlobalMembersGenerate.conflActivitiesTimeSlot.count());
				Console.Write("\n");
				foreach (int i, GlobalMembersGenerate.conflActivitiesTimeSlot)
				{
					Console.Write("Confl activity id:");
					Console.Write(gt.rules.internalActivitiesList[i].id);
					Console.Write(" time of this activity:");
					Console.Write(c.times[i]);
					if (c.rooms[i] != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM)
					{
						Console.Write(" room of this activity:");
						Console.Write(qPrintable(gt.rules.internalRoomsList[c.rooms[i]].name));
						Console.Write("\n");
					}
					else
					{
						Console.Write(" room of this activity: UNSPECIFIED_ROOM");
						Console.Write("\n");
					}
				}
				//cout<<endl;
				Console.Write("timeSlot==");
				Console.Write(GlobalMembersGenerate.timeSlot);
				Console.Write("\n");
				if (GlobalMembersGenerate.roomSlot != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM)
				{
					Console.Write("roomSlot==");
					Console.Write(qPrintable(gt.rules.internalRoomsList[GlobalMembersGenerate.roomSlot].name));
					Console.Write("\n");
				}
				else
				{
					Console.Write("roomSlot==UNSPECIFIED_ROOM");
					Console.Write("\n");
				}

				QList<int> ok = new QList<int>();
				QList<int> confl = new QList<int>();
				for (int j = 0; j < added_act; j++)
				{
					if (GlobalMembersGenerate.conflActivitiesTimeSlot.indexOf(GlobalMembersGenerate_pre.permutation[j]) != -1)
					{
						if (GlobalMembersGenerate.triedRemovals(GlobalMembersGenerate_pre.permutation[j],c.times[GlobalMembersGenerate_pre.permutation[j]]) > 0)
						{
							Console.Write("Warning - explored removal: id==");
							Console.Write(gt.rules.internalActivitiesList[GlobalMembersGenerate_pre.permutation[j]].id);
							Console.Write(", time==");
							Console.Write(c.times[GlobalMembersGenerate_pre.permutation[j]]);
							Console.Write(", times==");
							Console.Write(GlobalMembersGenerate.triedRemovals(GlobalMembersGenerate_pre.permutation[j],c.times[GlobalMembersGenerate_pre.permutation[j]]));
							Console.Write("\n");
						}
						GlobalMembersGenerate.triedRemovals(GlobalMembersGenerate_pre.permutation[j],c.times[GlobalMembersGenerate_pre.permutation[j]])++;

						/////update tabu
						int a = GlobalMembersGenerate.tabu_activities[GlobalMembersGenerate.crt_tabu_index];
						int t = GlobalMembersGenerate.tabu_times[GlobalMembersGenerate.crt_tabu_index];
						if (a >= 0 && t >= 0)
						{
							Debug.Assert(GlobalMembersGenerate.triedRemovals(a,t) > 0);
							GlobalMembersGenerate.triedRemovals(a,t)--;
							//cout<<"Removing activity with id=="<<gt.rules.internalActivitiesList[a].id<<", time=="<<t<<endl;
						}
						GlobalMembersGenerate.tabu_activities[GlobalMembersGenerate.crt_tabu_index] = GlobalMembersGenerate_pre.permutation[j];
						GlobalMembersGenerate.tabu_times[GlobalMembersGenerate.crt_tabu_index] = c.times[GlobalMembersGenerate_pre.permutation[j]];
						//cout<<"Inserting activity with id=="<<gt.rules.internalActivitiesList[permutation[j]].id<<", time=="<<c.times[permutation[j]]<<endl;
						GlobalMembersGenerate.crt_tabu_index = (GlobalMembersGenerate.crt_tabu_index + 1) % GlobalMembersGenerate.tabu_size;
						////////////////

						confl.append(GlobalMembersGenerate_pre.permutation[j]);
					}
					else
						ok.append(GlobalMembersGenerate_pre.permutation[j]);
				}

				Debug.Assert(confl.count() == GlobalMembersGenerate.conflActivitiesTimeSlot.count());

				int j = 0;
				int tmp = GlobalMembersGenerate_pre.permutation[added_act];
				foreach (int k, ok)
				{
					GlobalMembersGenerate_pre.permutation[j] = k;
					GlobalMembersGenerate.invPermutation[k] = j;
					j++;
				}
				int q = j;
				//cout<<"q=="<<q<<endl;
				GlobalMembersGenerate_pre.permutation[j] = tmp;
				GlobalMembersGenerate.invPermutation[tmp] = j;
				j++;
				Console.Write("id of permutation[j==");
				Console.Write(j - 1);
				Console.Write("]==");
				Console.Write(gt.rules.internalActivitiesList[GlobalMembersGenerate_pre.permutation[j - 1]].id);
				Console.Write("\n");
				Console.Write("conflicting:");
				Console.Write("\n");
				foreach (int k, confl)
				{
					GlobalMembersGenerate_pre.permutation[j] = k;
					GlobalMembersGenerate.invPermutation[k] = j;
					j++;
					Console.Write("id of permutation[j==");
					Console.Write(j - 1);
					Console.Write("]==");
					Console.Write(gt.rules.internalActivitiesList[GlobalMembersGenerate_pre.permutation[j - 1]].id);
					Console.Write("\n");
				}
				Debug.Assert(j == added_act + 1);

				//check
				/*int pv[MAX_ACTIVITIES];
				for(int i=0; i<gt.rules.nInternalActivities; i++)
					pv[i]=0;
				for(int i=0; i<gt.rules.nInternalActivities; i++)
					pv[permutation[i]]++;
				for(int i=0; i<gt.rules.nInternalActivities; i++)
					assert(pv[i]==1);*/
				//

				Console.Write("tmp represents activity with id==");
				Console.Write(gt.rules.internalActivitiesList[tmp].id);
				Console.Write(" initial time: ");
				Console.Write(c.times[tmp]);
				Console.Write(" final time: ");
				Console.Write(GlobalMembersGenerate.timeSlot);
				Console.Write("\n");
				c.times[tmp] = GlobalMembersGenerate.timeSlot;
				c.rooms[tmp] = GlobalMembersGenerate.roomSlot;

				for (int i = q + 1; i <= added_act; i++)
				{
					if (!GlobalMembersGenerate_pre.fixedTimeActivity[GlobalMembersGenerate_pre.permutation[i]])
						c.times[GlobalMembersGenerate_pre.permutation[i]] = GlobalMembersTimetable_defs.UNALLOCATED_TIME;
					c.rooms[GlobalMembersGenerate_pre.permutation[i]] = GlobalMembersTimetable_defs.UNALLOCATED_SPACE;
				}
				c._fitness = -1;
				c.changedForMatrixCalculation = true;

				added_act = q + 1;
	if (threaded)
	{
				mutex.unlock();
	}

				//if(semaphorePlacedActivity){
					emit(activityPlaced(q + 1));
	if (threaded)
	{
					GlobalMembersGenerate.semaphorePlacedActivity.acquire();
	}
				//}

				goto prevvalue;
	//////////////////////
			}
			else //if foundGoodSwap==true
			{
				nPlacedActivities = added_act + 1;

				if (GlobalMembersGenerate.maxActivitiesPlaced < added_act + 1)
				{
					GlobalMembersGenerate.generationHighestStageDateTime = QDateTime.currentDateTime();
					time_t tmp = new time_t();
					time(tmp);
					timeToHighestStage = (int)(tmp - starting_time);

					GlobalMembersGenerate.highestStageSolution.copy(ref gt.rules, ref c);

					GlobalMembersGenerate.maxActivitiesPlaced = added_act + 1;

					if (maxPlacedActivityStream != null)
					{
						int sec = timeToHighestStage;
						int hh = sec / 3600;
						sec %= 3600;
						int mm = sec / 60;
						sec %= 60;
						QString s = tr("At time %1 h %2 m %3 s, FET reached %4 activities placed", "h=hours, m=minutes, s=seconds. Please leave spaces between 'time', %1, h, %2, m, %3, s, so they are visible").arg(hh).arg(mm).arg(sec).arg(GlobalMembersGenerate.maxActivitiesPlaced);
						//s+="\n";
						//QString s=QString("At time ")+CustomFETString::number(hh)+QString(" h ")+CustomFETString::number(mm)+QString(" m ")+CustomFETString::number(sec)
						//	+QString(" s, FET reached ")+CustomFETString::number(maxActivitiesPlaced)+QString(" activities placed\n");

						maxPlacedActivityStream << s << "\n";
						//(*maxPlacedActivityStream).flush();
					}
				}

	if (threaded)
	{
				mutex.unlock();
	}
				emit(activityPlaced(added_act + 1));
	if (threaded)
	{
				GlobalMembersGenerate.semaphorePlacedActivity.acquire();
	}
	if (threaded)
	{
				mutex.lock();
	}
				if (added_act == gt.rules.nInternalActivities && GlobalMembersGenerate.foundGoodSwap)
				{
	if (threaded)
	{
					mutex.unlock();
	}
					break;
				}

				bool ok = true;
				for (int i = 0; i <= added_act; i++)
				{
					if (c.times[GlobalMembersGenerate_pre.permutation[i]] == GlobalMembersTimetable_defs.UNALLOCATED_TIME)
					{
						Console.Write("ERROR: act with id==");
						Console.Write(gt.rules.internalActivitiesList[GlobalMembersGenerate_pre.permutation[i]].id);
						Console.Write(" has time unallocated");
						Console.Write("\n");
						ok = false;
					}
					if (c.rooms[GlobalMembersGenerate_pre.permutation[i]] == GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
					{
						Console.Write("ERROR: act with id==");
						Console.Write(gt.rules.internalActivitiesList[GlobalMembersGenerate_pre.permutation[i]].id);
						Console.Write(" has room unallocated");
						Console.Write("\n");
						ok = false;
					}
				}
				Debug.Assert(ok);
			}

	if (threaded)
	{
			mutex.unlock();
	}
		}

		time_t end_time = new time_t();
		time(end_time);
		searchTime = (int)(end_time - starting_time);
		Console.Write("Total searching time (seconds): ");
		Console.Write((int)(end_time - starting_time));
		Console.Write("\n");

		emit(simulationFinished());

		GlobalMembersGenerate.finishedSemaphore.release();
	}

	private void moveActivity(int ai, int fromslot, int toslot, int fromroom, int toroom)
	{
		Activity act = gt.rules.internalActivitiesList[ai];

		//cout<<"here: id of act=="<<act->id<<", fromslot=="<<fromslot<<", toslot=="<<toslot<<endl;

		Debug.Assert(fromslot == c.times[ai]);
		Debug.Assert(fromroom == c.rooms[ai]);

		if (!GlobalMembersGenerate_pre.fixedTimeActivity[ai] && (fromslot == GlobalMembersTimetable_defs.UNALLOCATED_TIME || fromroom == GlobalMembersTimetable_defs.UNALLOCATED_SPACE))
			Debug.Assert(fromslot == GlobalMembersTimetable_defs.UNALLOCATED_TIME && fromroom == GlobalMembersTimetable_defs.UNALLOCATED_SPACE);
		if (!GlobalMembersGenerate_pre.fixedTimeActivity[ai] && (toslot == GlobalMembersTimetable_defs.UNALLOCATED_TIME || toroom == GlobalMembersTimetable_defs.UNALLOCATED_SPACE))
			Debug.Assert(toslot == GlobalMembersTimetable_defs.UNALLOCATED_TIME && toroom == GlobalMembersTimetable_defs.UNALLOCATED_SPACE);

		if (fromslot != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
		{
			int d = fromslot % gt.rules.nDaysPerWeek;
			int h = fromslot / gt.rules.nDaysPerWeek;

			////////////////rooms
			int rm = c.rooms[ai];
			if (rm != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM && rm != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
				for (int dd = 0; dd < gt.rules.internalActivitiesList[ai].duration; dd++)
				{
					Debug.Assert(dd + h < gt.rules.nHoursPerDay);
					if (GlobalMembersGenerate.roomsTimetable(rm,d,h + dd) == ai)
						GlobalMembersGenerate.roomsTimetable(rm,d,h + dd) = -1;
					else
						Debug.Assert(0);
				}
			/////////////////////

			if (fromslot != toslot)
			{
				//timetable of students
				for (int q = 0; q < act.iSubgroupsList.count(); q++)
				{
					int sb = act.iSubgroupsList.at(q);
					for (int dd = 0; dd < gt.rules.internalActivitiesList[ai].duration; dd++)
					{
						Debug.Assert(dd + h < gt.rules.nHoursPerDay);

						Debug.Assert(GlobalMembersGenerate.subgroupsTimetable(sb,d,h + dd) == ai);
						GlobalMembersGenerate.subgroupsTimetable(sb,d,h + dd) = -1;
					}
				}

				foreach (int sb, GlobalMembersGenerate_pre.mustComputeTimetableSubgroups[ai])
				{
					for (int dd = 0; dd < gt.rules.internalActivitiesList[ai].duration; dd++)
					{
						Debug.Assert(dd + h < gt.rules.nHoursPerDay);

						Debug.Assert(GlobalMembersGenerate.newSubgroupsTimetable(sb,d,h + dd) == ai);
						GlobalMembersGenerate.newSubgroupsTimetable(sb,d,h + dd) = -1;
					}
				}

				updateSubgroupsNHoursGaps(act, ai, d);

				//teachers' timetable
				for (int q = 0; q < act.iTeachersList.count(); q++)
				{
					int tch = act.iTeachersList.at(q);
					for (int dd = 0; dd < gt.rules.internalActivitiesList[ai].duration; dd++)
					{
						Debug.Assert(dd + h < gt.rules.nHoursPerDay);

						Debug.Assert(GlobalMembersGenerate.teachersTimetable(tch,d,h + dd) == ai);
						GlobalMembersGenerate.teachersTimetable(tch,d,h + dd) = -1;
					}
				}

				foreach (int tch, GlobalMembersGenerate_pre.mustComputeTimetableTeachers[ai])
				{
					for (int dd = 0; dd < gt.rules.internalActivitiesList[ai].duration; dd++)
					{
						Debug.Assert(dd + h < gt.rules.nHoursPerDay);

						Debug.Assert(GlobalMembersGenerate.newTeachersTimetable(tch,d,h + dd) == ai);
						GlobalMembersGenerate.newTeachersTimetable(tch,d,h + dd) = -1;
					}
				}

				updateTeachersNHoursGaps(act, ai, d);

				//update teachers' list of activities for each day
				/////////////////
				foreach (int tch, GlobalMembersGenerate_pre.teachersWithMaxDaysPerWeekForActivities[ai])
				{
					int tt = GlobalMembersGenerate.teacherActivitiesOfTheDay(tch,d).removeAll(ai);
					Debug.Assert(tt == 1);
				}
				/////////////////

				//2011-09-30
				if (GlobalMembersGenerate_pre.haveActivitiesOccupyOrSimultaneousConstraints)
				{
					for (int t = fromslot; t < fromslot + act.duration * gt.rules.nDaysPerWeek; t += gt.rules.nDaysPerWeek)
					{
						Debug.Assert(GlobalMembersGenerate.activitiesAtTime[t].contains(ai));
						GlobalMembersGenerate.activitiesAtTime[t].remove(ai);
					}
				}
			}
		}

		c.times[ai] = toslot;
		c.rooms[ai] = toroom;
		c._fitness = -1;
		c.changedForMatrixCalculation = true;

		if (toslot != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
		{
			int d = toslot % gt.rules.nDaysPerWeek;
			int h = toslot / gt.rules.nDaysPerWeek;

			////////////////rooms
			int rm = c.rooms[ai];
			if (rm != GlobalMembersTimetable_defs.UNSPECIFIED_ROOM && rm != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
				for (int dd = 0; dd < gt.rules.internalActivitiesList[ai].duration; dd++)
				{
					Debug.Assert(dd + h < gt.rules.nHoursPerDay);

					Debug.Assert(rm != GlobalMembersTimetable_defs.UNALLOCATED_SPACE);
					/*if(roomsTimetable(rm,d,h+dd)>=0){
						cout<<"room is: "<<qPrintable(gt.rules.internalRoomsList[rm]->name)<<endl;
						cout<<"day is "<<qPrintable(gt.rules.daysOfTheWeek[d])<<endl;
						cout<<"hour is "<<qPrintable(gt.rules.hoursOfTheDay[h+dd])<<endl;
						cout<<"roomsTimetable(rm,d,h+dd) is "<<roomsTimetable(rm,d,h+dd)<<endl;
						cout<<"and represents room "<<qPrintable(gt.rules.internalRoomsList[roomsTimetable(rm,d,h+dd)]->name)<<endl;
					}*/

					Debug.Assert(GlobalMembersGenerate.roomsTimetable(rm,d,h + dd) == -1);
					GlobalMembersGenerate.roomsTimetable(rm,d,h + dd) = ai;
				}
			/////////////////////

			if (fromslot != toslot)
			{
				//compute timetable of subgroups
				for (int q = 0; q < act.iSubgroupsList.count(); q++)
				{
					int sb = act.iSubgroupsList.at(q);
					for (int dd = 0; dd < gt.rules.internalActivitiesList[ai].duration; dd++)
					{
						Debug.Assert(dd + h < gt.rules.nHoursPerDay);

						Debug.Assert(GlobalMembersGenerate.subgroupsTimetable(sb,d,h + dd) == -1);
						GlobalMembersGenerate.subgroupsTimetable(sb,d,h + dd) = ai;
					}
				}

				foreach (int sb, GlobalMembersGenerate_pre.mustComputeTimetableSubgroups[ai])
				{
					for (int dd = 0; dd < gt.rules.internalActivitiesList[ai].duration; dd++)
					{
						Debug.Assert(dd + h < gt.rules.nHoursPerDay);

						Debug.Assert(GlobalMembersGenerate.newSubgroupsTimetable(sb,d,h + dd) == -1);
						GlobalMembersGenerate.newSubgroupsTimetable(sb,d,h + dd) = ai;
					}
				}

				updateSubgroupsNHoursGaps(act, ai, d);

				//teachers' timetable
				for (int q = 0; q < act.iTeachersList.count(); q++)
				{
					int tch = act.iTeachersList.at(q);
					for (int dd = 0; dd < gt.rules.internalActivitiesList[ai].duration; dd++)
					{
						Debug.Assert(dd + h < gt.rules.nHoursPerDay);

						Debug.Assert(GlobalMembersGenerate.teachersTimetable(tch,d,h + dd) == -1);
						GlobalMembersGenerate.teachersTimetable(tch,d,h + dd) = ai;
					}
				}

				foreach (int tch, GlobalMembersGenerate_pre.mustComputeTimetableTeachers[ai])
				{
					for (int dd = 0; dd < gt.rules.internalActivitiesList[ai].duration; dd++)
					{
						Debug.Assert(dd + h < gt.rules.nHoursPerDay);

						Debug.Assert(GlobalMembersGenerate.newTeachersTimetable(tch,d,h + dd) == -1);
						GlobalMembersGenerate.newTeachersTimetable(tch,d,h + dd) = ai;
					}
				}

				//////////
				updateTeachersNHoursGaps(act, ai, d);



				//update teachers' list of activities for each day
				/////////////////
				foreach (int tch, GlobalMembersGenerate_pre.teachersWithMaxDaysPerWeekForActivities[ai])
				{
					Debug.Assert(GlobalMembersGenerate.teacherActivitiesOfTheDay(tch,d).indexOf(ai) == -1);
					GlobalMembersGenerate.teacherActivitiesOfTheDay(tch,d).append(ai);
				}
				/////////////////

				//2011-09-30
				if (GlobalMembersGenerate_pre.haveActivitiesOccupyOrSimultaneousConstraints)
				{
					for (int t = toslot; t < toslot + act.duration * gt.rules.nDaysPerWeek; t += gt.rules.nDaysPerWeek)
					{
						Debug.Assert(!GlobalMembersGenerate.activitiesAtTime[t].contains(ai));
						GlobalMembersGenerate.activitiesAtTime[t].insert(ai);
					}
				}
			}
		}
	}

	private void randomSwap(int ai, int level)
	{
		//cout<<"level=="<<level<<endl;

		if (level == 0)
		{
			GlobalMembersGenerate.conflActivitiesTimeSlot.clear();
			GlobalMembersGenerate.timeSlot = -1;

			/*for(int l=0; l<level_limit; l++)
				for(int i=0; i<gt.rules.nHoursPerWeek; i++){
					nMinDaysBrokenL[l][i]=0;
					selectedRoomL[l][i]=-1;
					permL[l][i]=-1;
					conflActivitiesL[l][i].clear();
					conflPermL[l][i]=-1;
					nConflActivitiesL[l][i]=0;
					roomSlotsL[l][i]=-1;
				}*/
		}

		if (level >= GlobalMembersGenerate.level_limit)
		{
			return;
		}

		if (GlobalMembersGenerate.ncallsrandomswap >= GlobalMembersGenerate.limitcallsrandomswap)
			return;

		/*for(int i=0; i<gt.rules.nHoursPerWeek; i++){
			nMinDaysBroken[i]=0;
			selectedRoom[i]=-1;
			perm[i]=-1;
			conflActivities[i].clear();
			conflPerm[i]=-1;
			nConflActivities[i]=0;
			roomSlots[i]=-1;
		}*/

		GlobalMembersGenerate.ncallsrandomswap++;

		Activity act = gt.rules.internalActivitiesList[ai];

		bool updateSubgroups = (GlobalMembersGenerate_pre.mustComputeTimetableSubgroups[ai].count() > 0);
		bool updateTeachers = (GlobalMembersGenerate_pre.mustComputeTimetableTeachers[ai].count() > 0);

#if false
	//	double nMinDaysBroken[MAX_HOURS_PER_WEEK]; //to count for broken min days between activities constraints
	//
	//	int selectedRoom[MAX_HOURS_PER_WEEK];
#endif

		//cout<<"ai=="<<ai<<", corresponding to id=="<<gt.rules.internalActivitiesList[ai].id<<", level=="<<level<<endl;

		//generate random permutation in linear time like in CLR (Cormen, Leiserson and Rivest - Introduction to algorithms).
		//this is used to scan times in random order
#if false
	//	int perm[MAX_HOURS_PER_WEEK];
#endif

		int activity_count_impossible_tries = 1;

	again_if_impossible_activity:

		for (int i = 0; i < gt.rules.nHoursPerWeek; i++)
#if perm_ConditionalDefinition1
			GlobalMembersGenerate.permL[level, i] = i;
#else
			perm[i] = i;
#endif
		for (int i = 0; i < gt.rules.nHoursPerWeek; i++)
		{
#if perm_ConditionalDefinition1
			int t = GlobalMembersGenerate.permL[level, i];
#else
			int t = perm[i];
#endif
			int r = GlobalMembersTimetable_defs.randomKnuth(gt.rules.nHoursPerWeek - i);
#if perm_ConditionalDefinition1
			GlobalMembersGenerate.permL[level, i] = GlobalMembersGenerate.permL[level, i + r];
#else
			perm[i] = perm[i + r];
#endif
#if perm_ConditionalDefinition1
			GlobalMembersGenerate.permL[level, i + r] = t;
#else
			perm[i + r] = t;
#endif
		}

		/*int checkPerm[MAX_HOURS_PER_WEEK];
		for(int i=0; i<gt.rules.nHoursPerWeek; i++)
			checkPerm[i]=false;
		for(int i=0; i<gt.rules.nHoursPerWeek; i++)
			checkPerm[perm[i]]=true;
		for(int i=0; i<gt.rules.nHoursPerWeek; i++)
			assert(checkPerm[i]==true);*/

		/*
		cout<<"Perm: ";
		for(int i=0; i<gt.rules.nHoursPerWeek; i++)
			cout<<", perm["<<i<<"]="<<perm[i];
		cout<<endl;
		*/

		//record the conflicting activities for each timeslot
#if false
	//	QList<int> conflActivities[MAX_HOURS_PER_WEEK];
	//	int conflPerm[MAX_HOURS_PER_WEEK]; //the permutation in increasing order of number of conflicting activities
	//	int nConflActivities[MAX_HOURS_PER_WEEK];
	//
	//	int roomSlots[MAX_HOURS_PER_WEEK];
#endif

		for (int n = 0; n < gt.rules.nHoursPerWeek; n++)
		{
#if perm_ConditionalDefinition1
			int newtime = GlobalMembersGenerate.permL[level, n];
#else
			int newtime = perm[n];
#endif

			if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
				if (c.times[ai] != newtime)
				{
#if nConflActivities_ConditionalDefinition1
					GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
					nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
					continue;
				}
			}

#if nConflActivities_ConditionalDefinition1
			GlobalMembersGenerate.nConflActivitiesL[level, newtime] = 0;
#else
			nConflActivities[newtime] = 0;
#endif
#if conflActivities_ConditionalDefinition1
			GlobalMembersGenerate.conflActivitiesL[level, newtime].clear();
#else
			conflActivities[newtime].clear();
#endif

			int d = newtime % gt.rules.nDaysPerWeek;
			int h = newtime / gt.rules.nDaysPerWeek;

			/*if(updateSubgroups || updateTeachers){
				addAiToNewTimetable(ai, act, d, h);
				if(updateTeachers)
					updateTeachersNHoursGaps(act, ai, d);
				if(updateSubgroups)
					updateSubgroupsNHoursGaps(act, ai, d);
			}*/

#if nMinDaysBroken_ConditionalDefinition1
			GlobalMembersGenerate.nMinDaysBrokenL[level, newtime] = 0.0;
#else
			nMinDaysBroken[newtime] = 0.0;
#endif

			bool okbasictime;
			bool okmindays;
			bool okmaxdays;
			bool oksamestartingtime;
			bool oksamestartinghour;
			bool oksamestartingday;
			bool oknotoverlapping;
			bool oktwoactivitiesconsecutive;
			bool oktwoactivitiesgrouped;
			bool okthreeactivitiesgrouped;
			bool oktwoactivitiesordered;
			bool okactivityendsstudentsday;
			bool okstudentsearlymaxbeginningsatsecondhour;
			bool okstudentsmaxgapsperweek;
			bool okstudentsmaxgapsperday;
			bool okstudentsmaxhoursdaily;
			bool okstudentsmaxhourscontinuously;
			bool okstudentsminhoursdaily;
			bool okstudentsintervalmaxdaysperweek;
			bool okteachermaxdaysperweek;
			bool okteachersintervalmaxdaysperweek;
			bool okteachersmaxgapsperweek;
			bool okteachersmaxgapsperday;
			bool okteachersmaxhoursdaily;
			bool okteachersmaxhourscontinuously;
			bool okteachersminhoursdaily;
			bool okteachersmindaysperweek;
			bool okmingapsbetweenactivities;

			bool okteachersactivitytagmaxhourscontinuously;
			bool okstudentsactivitytagmaxhourscontinuously;

			bool okteachersactivitytagmaxhoursdaily;
			bool okstudentsactivitytagmaxhoursdaily;

			//2011-09-25
			bool okactivitiesoccupymaxtimeslotsfromselection;

			//2011-09-30
			bool okactivitiesmaxsimultaneousinselectedtimeslots;

			if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				goto skip_here_if_already_allocated_in_time;

	/////////////////////////////////////////////////////////////////////////////////////////////

			//not too late
			//unneeded code, because notAllowedTimesPercentages(ai,newtime)==100 now
			//you can comment this code, but you cannot put an assert failed, because the test is done in next section (see 13 lines below).
			if (h + act.duration > gt.rules.nHoursPerDay)
			{
				//if(updateSubgroups || updateTeachers)
				//	removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

	/////////////////////////////////////////////////////////////////////////////////////////////

			//allowed (tch&st not available, break, act(s) preferred time(s))
			if (!GlobalMembersGenerate.skipRandom(GlobalMembersGenerate_pre.notAllowedTimesPercentages(ai,newtime)))
			{
				//if(updateSubgroups || updateTeachers)
				//	removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

	/////////////////////////////////////////////////////////////////////////////////////////////

			//care about basic time constraints
			okbasictime = true;

			///////////////////////////////////
			//added in 5.0.0-preview30
			//same teacher?
			for (int dur = 0; dur < act.duration; dur++)
			{
				Debug.Assert(h + dur < gt.rules.nHoursPerDay);
				//for(int q=0; q<act->iTeachersList.count(); q++){
				//	int tch=act->iTeachersList.at(q);
				foreach (int tch, act.iTeachersList)
				{
					if (GlobalMembersGenerate.teachersTimetable(tch,d,h + dur) >= 0)
					{
						int ai2 = GlobalMembersGenerate.teachersTimetable(tch,d,h + dur);
						Debug.Assert(ai2 != ai);

						Debug.Assert(GlobalMembersGenerate_pre.activitiesConflictingPercentage(ai,ai2) == 100);
						if (!GlobalMembersGenerate.skipRandom(GlobalMembersGenerate_pre.activitiesConflictingPercentage(ai,ai2)))
						{
							if (GlobalMembersGenerate_pre.fixedTimeActivity[ai2] || GlobalMembersGenerate.swappedActivities[ai2])
							{
								okbasictime = false;
								goto impossiblebasictime;
							}

#if conflActivities_ConditionalDefinition1
							if (!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
							if (!conflActivities[newtime].contains(ai2))
#endif
							{
							//if(conflActivities[newtime].indexOf(ai2)==-1){
								//conflActivities[newtime].append(ai2);

#if conflActivities_ConditionalDefinition1
								GlobalMembersGenerate.conflActivitiesL[level, newtime].append(ai2);
#else
								conflActivities[newtime].append(ai2);
#endif
#if nConflActivities_ConditionalDefinition1
								GlobalMembersGenerate.nConflActivitiesL[level, newtime]++;
#else
								nConflActivities[newtime]++;
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(GlobalMembersGenerate.nConflActivitiesL[level, newtime] == GlobalMembersGenerate.conflActivitiesL[level, newtime].count());
#else
								Debug.Assert(nConflActivities[newtime] == GlobalMembersGenerate.conflActivitiesL[level, newtime].count());
#endif
#else
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(GlobalMembersGenerate.nConflActivitiesL[level, newtime] == conflActivities[newtime].count());
#else
								Debug.Assert(nConflActivities[newtime] == conflActivities[newtime].count());
#endif
#endif
								//addConflActivity(conflActivities[newtime], nConflActivities[newtime], ai2, &gt.rules.internalActivitiesList[ai2]);
							}
						}
					}
				}
			}
			//same subgroup?
			for (int dur = 0; dur < act.duration; dur++)
			{
				Debug.Assert(h + dur < gt.rules.nHoursPerDay);
				//for(int q=0; q<act->iSubgroupsList.count(); q++){
				//	int sbg=act->iSubgroupsList.at(q);
				foreach (int sbg, act.iSubgroupsList)
				{
					if (GlobalMembersGenerate.subgroupsTimetable(sbg,d,h + dur) >= 0)
					{
						int ai2 = GlobalMembersGenerate.subgroupsTimetable(sbg,d,h + dur);
						Debug.Assert(ai2 != ai);

						Debug.Assert(GlobalMembersGenerate_pre.activitiesConflictingPercentage(ai,ai2) == 100);
						if (!GlobalMembersGenerate.skipRandom(GlobalMembersGenerate_pre.activitiesConflictingPercentage(ai,ai2)))
						{
							if (GlobalMembersGenerate_pre.fixedTimeActivity[ai2] || GlobalMembersGenerate.swappedActivities[ai2])
							{
								okbasictime = false;
								goto impossiblebasictime;
							}

#if conflActivities_ConditionalDefinition1
							if (!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
							if (!conflActivities[newtime].contains(ai2))
#endif
							{
							//if(conflActivities[newtime].indexOf(ai2)==-1){
								//conflActivities[newtime].append(ai2);

#if conflActivities_ConditionalDefinition1
								GlobalMembersGenerate.conflActivitiesL[level, newtime].append(ai2);
#else
								conflActivities[newtime].append(ai2);
#endif
#if nConflActivities_ConditionalDefinition1
								GlobalMembersGenerate.nConflActivitiesL[level, newtime]++;
#else
								nConflActivities[newtime]++;
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(GlobalMembersGenerate.nConflActivitiesL[level, newtime] == GlobalMembersGenerate.conflActivitiesL[level, newtime].count());
#else
								Debug.Assert(nConflActivities[newtime] == GlobalMembersGenerate.conflActivitiesL[level, newtime].count());
#endif
#else
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(GlobalMembersGenerate.nConflActivitiesL[level, newtime] == conflActivities[newtime].count());
#else
								Debug.Assert(nConflActivities[newtime] == conflActivities[newtime].count());
#endif
#endif
								//addConflActivity(conflActivities[newtime], nConflActivities[newtime], ai2, &gt.rules.internalActivitiesList[ai2]);
							}
						}
					}
				}
			}
			///////////////////////////////////

	impossiblebasictime:
			if (!okbasictime)
			{
				//if(updateSubgroups || updateTeachers)
				//	removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

			/*foreach(int ai2, conflActivities[newtime])
				assert(!swappedActivities[ai2]);*/

	/////////////////////////////////////////////////////////////////////////////////////////////

			//care about min days
			okmindays = true;

			for (int i = 0; i < GlobalMembersGenerate_pre.minDaysListOfActivities[ai].count(); i++)
			{
				int ai2 = GlobalMembersGenerate_pre.minDaysListOfActivities[ai].at(i);
				int md = GlobalMembersGenerate_pre.minDaysListOfMinDays[ai].at(i);
				int ai2time = c.times[ai2];
				if (ai2time != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
					int d2 = ai2time % gt.rules.nDaysPerWeek;
					int h2 = ai2time / gt.rules.nDaysPerWeek;
					if (md > Math.Abs(d - d2))
					{
						bool okrand = GlobalMembersGenerate.skipRandom(GlobalMembersGenerate_pre.minDaysListOfWeightPercentages[ai].at(i));
						//if(fixedTimeActivity[ai] && minDaysListOfWeightPercentages[ai].at(i)<100.0)
						//	okrand=true;

						//broken min days - there is a minDaysBrokenAllowancePercentage% chance to place them adjacent

						if (GlobalMembersGenerate_pre.minDaysListOfConsecutiveIfSameDay[ai].at(i) == true) //must place them adjacent if on same day
						{
							if (okrand && ((d == d2 && (h + act.duration == h2 || h2 + gt.rules.internalActivitiesList[ai2].duration == h)) || d != d2))
							{
								 //nMinDaysBroken[newtime]++;
#if nMinDaysBroken_ConditionalDefinition1
								 GlobalMembersGenerate.nMinDaysBrokenL[level, newtime] += GlobalMembersGenerate_pre.minDaysListOfWeightPercentages[ai].at(i) / 100.0;
#else
								 nMinDaysBroken[newtime] += GlobalMembersGenerate_pre.minDaysListOfWeightPercentages[ai].at(i) / 100.0;
#endif
							}
							else
							{
								if (GlobalMembersGenerate_pre.fixedTimeActivity[ai2] || GlobalMembersGenerate.swappedActivities[ai2])
								{
									okmindays = false;
									goto impossiblemindays;
								}

								//if(conflActivities[newtime].indexOf(ai2)==-1){
#if conflActivities_ConditionalDefinition1
								if (!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
								if (!conflActivities[newtime].contains(ai2))
#endif
								{
									//conflActivities[newtime].append(ai2);

#if conflActivities_ConditionalDefinition1
									GlobalMembersGenerate.conflActivitiesL[level, newtime].append(ai2);
#else
									conflActivities[newtime].append(ai2);
#endif
#if nConflActivities_ConditionalDefinition1
									GlobalMembersGenerate.nConflActivitiesL[level, newtime]++;
#else
									nConflActivities[newtime]++;
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
									Debug.Assert(GlobalMembersGenerate.nConflActivitiesL[level, newtime] == GlobalMembersGenerate.conflActivitiesL[level, newtime].count());
#else
									Debug.Assert(nConflActivities[newtime] == GlobalMembersGenerate.conflActivitiesL[level, newtime].count());
#endif
#else
#if nConflActivities_ConditionalDefinition1
									Debug.Assert(GlobalMembersGenerate.nConflActivitiesL[level, newtime] == conflActivities[newtime].count());
#else
									Debug.Assert(nConflActivities[newtime] == conflActivities[newtime].count());
#endif
#endif
									//addConflActivity(conflActivities[newtime], nConflActivities[newtime], ai2, &gt.rules.internalActivitiesList[ai2]);
								}
							}
						}
						else //can place them anywhere
						{
							if (okrand)
							{
								 //nMinDaysBroken[newtime]++;
#if nMinDaysBroken_ConditionalDefinition1
								 GlobalMembersGenerate.nMinDaysBrokenL[level, newtime] += GlobalMembersGenerate_pre.minDaysListOfWeightPercentages[ai].at(i) / 100.0;
#else
								 nMinDaysBroken[newtime] += GlobalMembersGenerate_pre.minDaysListOfWeightPercentages[ai].at(i) / 100.0;
#endif
							}
							else
							{
								if (GlobalMembersGenerate_pre.fixedTimeActivity[ai2] || GlobalMembersGenerate.swappedActivities[ai2])
								{
									okmindays = false;
									goto impossiblemindays;
								}

								//if(conflActivities[newtime].indexOf(ai2)==-1){
#if conflActivities_ConditionalDefinition1
								if (!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
								if (!conflActivities[newtime].contains(ai2))
#endif
								{
									//conflActivities[newtime].append(ai2);

#if conflActivities_ConditionalDefinition1
									GlobalMembersGenerate.conflActivitiesL[level, newtime].append(ai2);
#else
									conflActivities[newtime].append(ai2);
#endif
#if nConflActivities_ConditionalDefinition1
									GlobalMembersGenerate.nConflActivitiesL[level, newtime]++;
#else
									nConflActivities[newtime]++;
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
									Debug.Assert(GlobalMembersGenerate.nConflActivitiesL[level, newtime] == GlobalMembersGenerate.conflActivitiesL[level, newtime].count());
#else
									Debug.Assert(nConflActivities[newtime] == GlobalMembersGenerate.conflActivitiesL[level, newtime].count());
#endif
#else
#if nConflActivities_ConditionalDefinition1
									Debug.Assert(GlobalMembersGenerate.nConflActivitiesL[level, newtime] == conflActivities[newtime].count());
#else
									Debug.Assert(nConflActivities[newtime] == conflActivities[newtime].count());
#endif
#endif
									//addConflActivity(conflActivities[newtime], nConflActivities[newtime], ai2, &gt.rules.internalActivitiesList[ai2]);
								}
							}
						}
					}
				}
			}
	impossiblemindays:
			if (!okmindays)
			{
				//if(updateSubgroups || updateTeachers)
				//	removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

			/*foreach(int ai2, conflActivities[newtime])
				assert(!swappedActivities[ai2]);*/

	/////////////////////////////////////////////////////////////////////////////////////////////

			//care about max days between activities
			okmaxdays = true;

			for (int i = 0; i < GlobalMembersGenerate_pre.maxDaysListOfActivities[ai].count(); i++)
			{
				int ai2 = GlobalMembersGenerate_pre.maxDaysListOfActivities[ai].at(i);
				int md = GlobalMembersGenerate_pre.maxDaysListOfMaxDays[ai].at(i);
				int ai2time = c.times[ai2];
				if (ai2time != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
					int d2 = ai2time % gt.rules.nDaysPerWeek;
					//int h2=ai2time/gt.rules.nDaysPerWeek;
					if (md < Math.Abs(d - d2))
					{
						bool okrand = GlobalMembersGenerate.skipRandom(GlobalMembersGenerate_pre.maxDaysListOfWeightPercentages[ai].at(i));
						if (!okrand)
						{
							if (GlobalMembersGenerate_pre.fixedTimeActivity[ai2] || GlobalMembersGenerate.swappedActivities[ai2])
							{
								okmaxdays = false;
								goto impossiblemaxdays;
							}

#if conflActivities_ConditionalDefinition1
							if (!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
							if (!conflActivities[newtime].contains(ai2))
#endif
							{
#if conflActivities_ConditionalDefinition1
								GlobalMembersGenerate.conflActivitiesL[level, newtime].append(ai2);
#else
								conflActivities[newtime].append(ai2);
#endif

#if nConflActivities_ConditionalDefinition1
								GlobalMembersGenerate.nConflActivitiesL[level, newtime]++;
#else
								nConflActivities[newtime]++;
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(GlobalMembersGenerate.nConflActivitiesL[level, newtime] == GlobalMembersGenerate.conflActivitiesL[level, newtime].count());
#else
								Debug.Assert(nConflActivities[newtime] == GlobalMembersGenerate.conflActivitiesL[level, newtime].count());
#endif
#else
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(GlobalMembersGenerate.nConflActivitiesL[level, newtime] == conflActivities[newtime].count());
#else
								Debug.Assert(nConflActivities[newtime] == conflActivities[newtime].count());
#endif
#endif
							}
						}
					}
				}
			}
	impossiblemaxdays:
			if (!okmaxdays)
			{
#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

			/*foreach(int ai2, conflActivities[newtime])
				assert(!swappedActivities[ai2]);*/

	/////////////////////////////////////////////////////////////////////////////////////////////
			//care about min gaps between activities
			okmingapsbetweenactivities = true;

			for (int i = 0; i < GlobalMembersGenerate_pre.minGapsBetweenActivitiesListOfActivities[ai].count(); i++)
			{
				int ai2 = GlobalMembersGenerate_pre.minGapsBetweenActivitiesListOfActivities[ai].at(i);
				int mg = GlobalMembersGenerate_pre.minGapsBetweenActivitiesListOfMinGaps[ai].at(i);
				int ai2time = c.times[ai2];
				if (ai2time != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
					int d2 = ai2time % gt.rules.nDaysPerWeek;
					int h2 = ai2time / gt.rules.nDaysPerWeek;
					int duration2 = gt.rules.internalActivitiesList[ai2].duration;
					bool oktmp = true;
					if (d == d2)
					{
						if (h2 >= h)
						{
							if (h + act.duration + mg > h2)
							{
								oktmp = false;
							}
						}
						else
						{
							if (h2 + duration2 + mg > h)
							{
								oktmp = false;
							}
						}
					}

					if (!oktmp)
					{
						bool okrand = GlobalMembersGenerate.skipRandom(GlobalMembersGenerate_pre.minGapsBetweenActivitiesListOfWeightPercentages[ai].at(i));

						//if(fixedTimeActivity[ai] && minGapsBetweenActivitiesListOfWeightPercentages[ai].at(i)<100.0)
						//	okrand=true;

						if (!okrand)
						{
							if (GlobalMembersGenerate_pre.fixedTimeActivity[ai2] || GlobalMembersGenerate.swappedActivities[ai2])
							{
								okmingapsbetweenactivities = false;
								goto impossiblemingapsbetweenactivities;
							}

#if conflActivities_ConditionalDefinition1
							if (!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
							if (!conflActivities[newtime].contains(ai2))
#endif
							{
#if conflActivities_ConditionalDefinition1
								GlobalMembersGenerate.conflActivitiesL[level, newtime].append(ai2);
#else
								conflActivities[newtime].append(ai2);
#endif
#if nConflActivities_ConditionalDefinition1
								GlobalMembersGenerate.nConflActivitiesL[level, newtime]++;
#else
								nConflActivities[newtime]++;
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(GlobalMembersGenerate.nConflActivitiesL[level, newtime] == GlobalMembersGenerate.conflActivitiesL[level, newtime].count());
#else
								Debug.Assert(nConflActivities[newtime] == GlobalMembersGenerate.conflActivitiesL[level, newtime].count());
#endif
#else
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(GlobalMembersGenerate.nConflActivitiesL[level, newtime] == conflActivities[newtime].count());
#else
								Debug.Assert(nConflActivities[newtime] == conflActivities[newtime].count());
#endif
#endif
							}
						}
					}
				}
			}
	impossiblemingapsbetweenactivities:
			if (!okmingapsbetweenactivities)
			{
				//if(updateSubgroups || updateTeachers)
				//	removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

			/*foreach(int ai2, conflActivities[newtime])
				assert(!swappedActivities[ai2]);*/

	/////////////////////////////////////////////////////////////////////////////////////////////

			//allowed from same starting time
			oksamestartingtime = true;

			for (int i = 0; i < GlobalMembersGenerate_pre.activitiesSameStartingTimeActivities[ai].count(); i++)
			{
				int ai2 = GlobalMembersGenerate_pre.activitiesSameStartingTimeActivities[ai].at(i);
				double perc = GlobalMembersGenerate_pre.activitiesSameStartingTimePercentages[ai].at(i);
				if (c.times[ai2] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
					bool sR = GlobalMembersGenerate.skipRandom(perc);

					//if(fixedTimeActivity[ai] && perc<100.0)
					//	sR=true;

					if (newtime != c.times[ai2] && !sR)
					{
						Debug.Assert(ai2 != ai);

						if (GlobalMembersGenerate_pre.fixedTimeActivity[ai2] || GlobalMembersGenerate.swappedActivities[ai2])
						{
							oksamestartingtime = false;
							goto impossiblesamestartingtime;
						}

#if conflActivities_ConditionalDefinition1
						if (!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
						if (!conflActivities[newtime].contains(ai2))
#endif
						{
						//if(conflActivities[newtime].indexOf(ai2)==-1){
							//conflActivities[newtime].append(ai2);

#if conflActivities_ConditionalDefinition1
							GlobalMembersGenerate.conflActivitiesL[level, newtime].append(ai2);
#else
							conflActivities[newtime].append(ai2);
#endif
#if nConflActivities_ConditionalDefinition1
							GlobalMembersGenerate.nConflActivitiesL[level, newtime]++;
#else
							nConflActivities[newtime]++;
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif
							//addConflActivity(conflActivities[newtime], nConflActivities[newtime], ai2, &gt.rules.internalActivitiesList[ai2]);
						}
					}
				}
			}
	impossiblesamestartingtime:
			if (!oksamestartingtime)
			{
				//if(updateSubgroups || updateTeachers)
				//	removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

			/*foreach(int ai2, conflActivities[newtime])
				assert(!swappedActivities[ai2]);*/

	/////////////////////////////////////////////////////////////////////////////////////////////

			//allowed from same starting hour
			oksamestartinghour = true;

			for (int i = 0; i < GlobalMembersGenerate_pre.activitiesSameStartingHourActivities[ai].count(); i++)
			{
				int ai2 = GlobalMembersGenerate_pre.activitiesSameStartingHourActivities[ai].at(i);
				double perc = GlobalMembersGenerate_pre.activitiesSameStartingHourPercentages[ai].at(i);
				if (c.times[ai2] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
					bool sR = GlobalMembersGenerate.skipRandom(perc);

					//if(fixedTimeActivity[ai] && perc<100.0)
					//	sR=true;

					if ((newtime / gt.rules.nDaysPerWeek) != (c.times[ai2] / gt.rules.nDaysPerWeek) && !sR)
					{
						if (GlobalMembersGenerate_pre.fixedTimeActivity[ai2] || GlobalMembersGenerate.swappedActivities[ai2])
						{
							oksamestartinghour = false;
							goto impossiblesamestartinghour;
						}

#if conflActivities_ConditionalDefinition1
						if (!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
						if (!conflActivities[newtime].contains(ai2))
#endif
						{
						//if(conflActivities[newtime].indexOf(ai2)==-1){

#if conflActivities_ConditionalDefinition1
							GlobalMembersGenerate.conflActivitiesL[level, newtime].append(ai2);
#else
							conflActivities[newtime].append(ai2);
#endif
#if nConflActivities_ConditionalDefinition1
							GlobalMembersGenerate.nConflActivitiesL[level, newtime]++;
#else
							nConflActivities[newtime]++;
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif
							//addConflActivity(conflActivities[newtime], nConflActivities[newtime], ai2, &gt.rules.internalActivitiesList[ai2]);
						}
					}
				}
			}
	impossiblesamestartinghour:
			if (!oksamestartinghour)
			{
				//if(updateSubgroups || updateTeachers)
				//	removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

			/*foreach(int ai2, conflActivities[newtime])
				assert(!swappedActivities[ai2]);*/

	/////////////////////////////////////////////////////////////////////////////////////////////

			//allowed from same starting day
			oksamestartingday = true;

			for (int i = 0; i < GlobalMembersGenerate_pre.activitiesSameStartingDayActivities[ai].count(); i++)
			{
				int ai2 = GlobalMembersGenerate_pre.activitiesSameStartingDayActivities[ai].at(i);
				double perc = GlobalMembersGenerate_pre.activitiesSameStartingDayPercentages[ai].at(i);
				if (c.times[ai2] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
					bool sR = GlobalMembersGenerate.skipRandom(perc);

					//if(fixedTimeActivity[ai] && perc<100.0)
					//	sR=true;

					if ((newtime % gt.rules.nDaysPerWeek) != (c.times[ai2] % gt.rules.nDaysPerWeek) && !sR)
					{
						if (GlobalMembersGenerate_pre.fixedTimeActivity[ai2] || GlobalMembersGenerate.swappedActivities[ai2])
						{
							oksamestartingday = false;
							goto impossiblesamestartingday;
						}

#if conflActivities_ConditionalDefinition1
						if (!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
						if (!conflActivities[newtime].contains(ai2))
#endif
						{
						//if(conflActivities[newtime].indexOf(ai2)==-1){

#if conflActivities_ConditionalDefinition1
							GlobalMembersGenerate.conflActivitiesL[level, newtime].append(ai2);
#else
							conflActivities[newtime].append(ai2);
#endif
#if nConflActivities_ConditionalDefinition1
							GlobalMembersGenerate.nConflActivitiesL[level, newtime]++;
#else
							nConflActivities[newtime]++;
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif
							//addConflActivity(conflActivities[newtime], nConflActivities[newtime], ai2, &gt.rules.internalActivitiesList[ai2]);
						}
					}
				}
			}
	impossiblesamestartingday:
			if (!oksamestartingday)
			{
				//if(updateSubgroups || updateTeachers)
				//	removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

			/*foreach(int ai2, conflActivities[newtime])
				assert(!swappedActivities[ai2]);*/

	/////////////////////////////////////////////////////////////////////////////////////////////

			//allowed from not overlapping
			oknotoverlapping = true;

			for (int i = 0; i < GlobalMembersGenerate_pre.activitiesNotOverlappingActivities[ai].count(); i++)
			{
				int ai2 = GlobalMembersGenerate_pre.activitiesNotOverlappingActivities[ai].at(i);
				double perc = GlobalMembersGenerate_pre.activitiesNotOverlappingPercentages[ai].at(i);
				if (c.times[ai2] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
					int d2 = c.times[ai2] % gt.rules.nDaysPerWeek;
					//int h2=c.times[ai2]/gt.rules.nDaysPerWeek;
					if (d == d2)
					{
						int st = newtime;
						int en = st + gt.rules.nDaysPerWeek * act.duration;
						int st2 = c.times[ai2];
						int en2 = st2 + gt.rules.nDaysPerWeek * gt.rules.internalActivitiesList[ai2].duration;

						bool sR = GlobalMembersGenerate.skipRandom(perc);
						//if(fixedTimeActivity[ai] && perc<100.0)
						//	sR=true;

						if (!(en <= st2 || en2 <= st) && !sR)
						{
							Debug.Assert(ai2 != ai);

							if (GlobalMembersGenerate_pre.fixedTimeActivity[ai2] || GlobalMembersGenerate.swappedActivities[ai2])
							{
								oknotoverlapping = false;
								goto impossiblenotoverlapping;
							}

#if conflActivities_ConditionalDefinition1
							if (!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
							if (!conflActivities[newtime].contains(ai2))
#endif
							{
							//if(conflActivities[newtime].indexOf(ai2)==-1){
								//conflActivities[newtime].append(ai2);

#if conflActivities_ConditionalDefinition1
								GlobalMembersGenerate.conflActivitiesL[level, newtime].append(ai2);
#else
								conflActivities[newtime].append(ai2);
#endif
#if nConflActivities_ConditionalDefinition1
								GlobalMembersGenerate.nConflActivitiesL[level, newtime]++;
#else
								nConflActivities[newtime]++;
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif
								//addConflActivity(conflActivities[newtime], nConflActivities[newtime], ai2, &gt.rules.internalActivitiesList[ai2]);
							}
						}
					}
				}
			}
	impossiblenotoverlapping:
			if (!oknotoverlapping)
			{
				//if(updateSubgroups || updateTeachers)
				//	removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

			/*foreach(int ai2, conflActivities[newtime])
				assert(!swappedActivities[ai2]);*/

	/////////////////////////////////////////////////////////////////////////////////////////////

			//allowed from 2 activities consecutive
			oktwoactivitiesconsecutive = true;

			for (int i = 0; i < GlobalMembersGenerate_pre.constrTwoActivitiesConsecutiveActivities[ai].count(); i++)
			{
				//direct
				int ai2 = GlobalMembersGenerate_pre.constrTwoActivitiesConsecutiveActivities[ai].at(i);
				double perc = GlobalMembersGenerate_pre.constrTwoActivitiesConsecutivePercentages[ai].at(i);
				if (c.times[ai2] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
					int d2 = c.times[ai2] % gt.rules.nDaysPerWeek;
					int h2 = c.times[ai2] / gt.rules.nDaysPerWeek;
					bool ok = true;

					if (d2 != d)
						ok = false;
					else if (h + act.duration > h2)
						ok = false;
					else if (d == d2)
					{
						int kk;
						for (kk = h + act.duration; kk < gt.rules.nHoursPerDay; kk++)
							if (!GlobalMembersGenerate_pre.breakDayHour(d,kk))
								break;
						Debug.Assert(kk <= h2);
						if (kk != h2)
							ok = false;
					}

					bool sR = GlobalMembersGenerate.skipRandom(perc);
					//if(fixedTimeActivity[ai] && perc<100.0)
					//	sR=true;

					if (!ok && !sR)
					{
						Debug.Assert(ai2 != ai);

						if (GlobalMembersGenerate_pre.fixedTimeActivity[ai2] || GlobalMembersGenerate.swappedActivities[ai2])
						{
							oktwoactivitiesconsecutive = false;
							goto impossibletwoactivitiesconsecutive;
						}

#if conflActivities_ConditionalDefinition1
						if (!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
						if (!conflActivities[newtime].contains(ai2))
#endif
						{
						//if(conflActivities[newtime].indexOf(ai2)==-1){

#if conflActivities_ConditionalDefinition1
							GlobalMembersGenerate.conflActivitiesL[level, newtime].append(ai2);
#else
							conflActivities[newtime].append(ai2);
#endif
							//conflActivities[newtime].append(ai2);
#if nConflActivities_ConditionalDefinition1
							GlobalMembersGenerate.nConflActivitiesL[level, newtime]++;
#else
							nConflActivities[newtime]++;
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif
							//addConflActivity(conflActivities[newtime], nConflActivities[newtime], ai2, &gt.rules.internalActivitiesList[ai2]);
						}
					}
				}
			}

			for (int i = 0; i < GlobalMembersGenerate_pre.inverseConstrTwoActivitiesConsecutiveActivities[ai].count(); i++)
			{
				//inverse
				int ai2 = GlobalMembersGenerate_pre.inverseConstrTwoActivitiesConsecutiveActivities[ai].at(i);
				double perc = GlobalMembersGenerate_pre.inverseConstrTwoActivitiesConsecutivePercentages[ai].at(i);
				if (c.times[ai2] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
					int d2 = c.times[ai2] % gt.rules.nDaysPerWeek;
					int h2 = c.times[ai2] / gt.rules.nDaysPerWeek;
					bool ok = true;

					if (d2 != d)
						ok = false;
					else if (h2 + gt.rules.internalActivitiesList[ai2].duration > h)
						ok = false;
					else if (d == d2)
					{
						int kk;
						for (kk = h2 + gt.rules.internalActivitiesList[ai2].duration; kk < gt.rules.nHoursPerDay; kk++)
							if (!GlobalMembersGenerate_pre.breakDayHour(d,kk))
								break;
						Debug.Assert(kk <= h);
						if (kk != h)
							ok = false;
					}

					bool sR = GlobalMembersGenerate.skipRandom(perc);
					//if(fixedTimeActivity[ai] && perc<100.0)
					//	sR=true;

					if (!ok && !sR)
					{
						Debug.Assert(ai2 != ai);

						if (GlobalMembersGenerate_pre.fixedTimeActivity[ai2] || GlobalMembersGenerate.swappedActivities[ai2])
						{
							oktwoactivitiesconsecutive = false;
							goto impossibletwoactivitiesconsecutive;
						}

#if conflActivities_ConditionalDefinition1
						if (!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
						if (!conflActivities[newtime].contains(ai2))
#endif
						{
						//if(conflActivities[newtime].indexOf(ai2)==-1){
#if conflActivities_ConditionalDefinition1
							GlobalMembersGenerate.conflActivitiesL[level, newtime].append(ai2);
#else
							conflActivities[newtime].append(ai2);
#endif
							//conflActivities[newtime].append(ai2);
#if nConflActivities_ConditionalDefinition1
							GlobalMembersGenerate.nConflActivitiesL[level, newtime]++;
#else
							nConflActivities[newtime]++;
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif
							//addConflActivity(conflActivities[newtime], nConflActivities[newtime], ai2, &gt.rules.internalActivitiesList[ai2]);
						}
					}
				}
			}

	impossibletwoactivitiesconsecutive:
			if (!oktwoactivitiesconsecutive)
			{
				//if(updateSubgroups || updateTeachers)
				//	removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

			/*foreach(int ai2, conflActivities[newtime])
				assert(!swappedActivities[ai2]);*/

	/////////////////////////////////////////////////////////////////////////////////////////////

			//allowed from 2 activities grouped
			oktwoactivitiesgrouped = true;

			for (int i = 0; i < GlobalMembersGenerate_pre.constrTwoActivitiesGroupedActivities[ai].count(); i++)
			{
				//direct
				int ai2 = GlobalMembersGenerate_pre.constrTwoActivitiesGroupedActivities[ai].at(i);
				double perc = GlobalMembersGenerate_pre.constrTwoActivitiesGroupedPercentages[ai].at(i);
				if (c.times[ai2] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
					int d2 = c.times[ai2] % gt.rules.nDaysPerWeek;
					int h2 = c.times[ai2] / gt.rules.nDaysPerWeek;
					bool ok = true;

					if (d2 != d)
					{
						ok = false;
					}
					else if (d == d2 && h2 + gt.rules.internalActivitiesList[ai2].duration <= h)
					{
						int kk;
						for (kk = h2 + gt.rules.internalActivitiesList[ai2].duration; kk < gt.rules.nHoursPerDay; kk++)
							if (!GlobalMembersGenerate_pre.breakDayHour(d2,kk))
								break;
						Debug.Assert(kk <= h);
						if (kk != h)
							ok = false;
					}
					else if (d == d2 && h + act.duration <= h2)
					{
						int kk;
						for (kk = h + act.duration; kk < gt.rules.nHoursPerDay; kk++)
							if (!GlobalMembersGenerate_pre.breakDayHour(d,kk))
								break;
						Debug.Assert(kk <= h2);
						if (kk != h2)
							ok = false;
					}
					else
						ok = false;

					bool sR = GlobalMembersGenerate.skipRandom(perc);
					//if(fixedTimeActivity[ai] && perc<100.0)
					//	sR=true;

					if (!ok && !sR)
					{
						Debug.Assert(ai2 != ai);

						if (GlobalMembersGenerate_pre.fixedTimeActivity[ai2] || GlobalMembersGenerate.swappedActivities[ai2])
						{
							oktwoactivitiesgrouped = false;
							goto impossibletwoactivitiesgrouped;
						}

#if conflActivities_ConditionalDefinition1
						if (!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
						if (!conflActivities[newtime].contains(ai2))
#endif
						{
						//if(conflActivities[newtime].indexOf(ai2)==-1){

#if conflActivities_ConditionalDefinition1
							GlobalMembersGenerate.conflActivitiesL[level, newtime].append(ai2);
#else
							conflActivities[newtime].append(ai2);
#endif
							//conflActivities[newtime].append(ai2);
#if nConflActivities_ConditionalDefinition1
							GlobalMembersGenerate.nConflActivitiesL[level, newtime]++;
#else
							nConflActivities[newtime]++;
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif
							//addConflActivity(conflActivities[newtime], nConflActivities[newtime], ai2, &gt.rules.internalActivitiesList[ai2]);
						}
					}
				}
			}

	impossibletwoactivitiesgrouped:
			if (!oktwoactivitiesgrouped)
			{
				//if(updateSubgroups || updateTeachers)
				//	removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

			/*foreach(int ai2, conflActivities[newtime])
				assert(!swappedActivities[ai2]);*/

	/////////////////////////////////////////////////////////////////////////////////////////////

			//allowed from 3 activities grouped
			okthreeactivitiesgrouped = true;

			for (int i = 0; i < GlobalMembersGenerate_pre.constrThreeActivitiesGroupedActivities[ai].count(); i++)
			{
				int ai2 = GlobalMembersGenerate_pre.constrThreeActivitiesGroupedActivities[ai].at(i).first;
				int ai3 = GlobalMembersGenerate_pre.constrThreeActivitiesGroupedActivities[ai].at(i).second;
				double perc = GlobalMembersGenerate_pre.constrThreeActivitiesGroupedPercentages[ai].at(i);

				bool sR = GlobalMembersGenerate.skipRandom(perc);
				//if(fixedTimeActivity[ai] && perc<100.0)
				//	sR=true;

				int aip1 = -1; //ai placed
				int aip2 = -1;
				int ainp1 = -1; //ai not placed
				int ainp2 = -1;
#if conflActivities_ConditionalDefinition1
				if (c.times[ai2] == GlobalMembersTimetable_defs.UNALLOCATED_TIME || GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
				if (c.times[ai2] == GlobalMembersTimetable_defs.UNALLOCATED_TIME || conflActivities[newtime].contains(ai2))
#endif
					ainp1 = ai2;
				else
					aip1 = ai2;
#if conflActivities_ConditionalDefinition1
				if (c.times[ai3] == GlobalMembersTimetable_defs.UNALLOCATED_TIME || GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai3))
#else
				if (c.times[ai3] == GlobalMembersTimetable_defs.UNALLOCATED_TIME || conflActivities[newtime].contains(ai3))
#endif
				{
					if (ainp1 == -1)
						ainp1 = ai3;
					else
						ainp2 = ai3;
				}
				else
				{
					if (aip1 == -1)
						aip1 = ai3;
					else
						aip2 = ai3;
				}

				int cnt = 0;
				if (ainp1 >= 0)
					cnt++;
				if (ainp2 >= 0)
					cnt++;
				if (aip1 >= 0)
					cnt++;
				if (aip2 >= 0)
					cnt++;
				Debug.Assert(cnt == 2);

				bool ok;

				if (aip1 == -1)
				{
					//ok - both not placed
					ok = true;
				}
				else if (aip2 == -1)
				{
					//only one placed, one not placed
					int dp1 = c.times[aip1] % gt.rules.nDaysPerWeek;
					int hp1 = c.times[aip1] / gt.rules.nDaysPerWeek;
					int durp1 = gt.rules.internalActivitiesList[aip1].duration;

					int hoursBetweenThem = -1;

					if (dp1 != d)
						hoursBetweenThem = -1;
					else if (dp1 == d && h >= hp1 + durp1)
					{
						hoursBetweenThem = 0;
						for (int kk = hp1 + durp1; kk < h; kk++)
							if (!GlobalMembersGenerate_pre.breakDayHour(d,kk))
							{
								//check that the working hours are not separated by a break
								//assertion that durp1>0, so the kk-1 >= 0
								if (GlobalMembersGenerate_pre.breakDayHour(d,kk - 1) && hoursBetweenThem > 0)
								{
									hoursBetweenThem = -1;
									break;
								}

								hoursBetweenThem++;
							}
					}
					else if (dp1 == d && hp1 >= h + act.duration)
					{
						hoursBetweenThem = 0;
						for (int kk = h + act.duration; kk < hp1; kk++)
							if (!GlobalMembersGenerate_pre.breakDayHour(d,kk))
							{
								//check that the working hours are not separated by a break
								//assertion that act->duration>0, so the kk-1 >= 0
								if (GlobalMembersGenerate_pre.breakDayHour(d,kk - 1) && hoursBetweenThem > 0)
								{
									hoursBetweenThem = -1;
									break;
								}

								hoursBetweenThem++;
							}
					}
					else
						hoursBetweenThem = -1;

					Debug.Assert(ainp1 >= 0);
					if (hoursBetweenThem == 0 || hoursBetweenThem == gt.rules.internalActivitiesList[ainp1].duration)
						//OK
						ok = true;
					else
						//not OK
						ok = false;
				}
				else
				{
					Debug.Assert(aip1 >= 0 && aip2 >= 0);
					//both placed
					int dp1 = c.times[aip1] % gt.rules.nDaysPerWeek;
					int hp1 = c.times[aip1] / gt.rules.nDaysPerWeek;
					//int durp1=gt.rules.internalActivitiesList[aip1].duration;

					int dp2 = c.times[aip2] % gt.rules.nDaysPerWeek;
					int hp2 = c.times[aip2] / gt.rules.nDaysPerWeek;
					//int durp2=gt.rules.internalActivitiesList[aip2].duration;

					if (dp1 == dp2 && dp1 == d)
					{
						int ao1 = -1; //order them, 1 then 2 then 3
						int ao2 = -1;
						int ao3 = -1;
						if (h >= hp1 && h >= hp2 && hp2 >= hp1)
						{
							ao1 = aip1;
							ao2 = aip2;
							ao3 = ai;
						}
						else if (h >= hp1 && h >= hp2 && hp1 >= hp2)
						{
							ao1 = aip2;
							ao2 = aip1;
							ao3 = ai;
						}
						else if (hp1 >= h && hp1 >= hp2 && h >= hp2)
						{
							ao1 = aip2;
							ao2 = ai;
							ao3 = aip1;
						}
						else if (hp1 >= h && hp1 >= hp2 && hp2 >= h)
						{
							ao1 = ai;
							ao2 = aip2;
							ao3 = aip1;
						}
						else if (hp2 >= h && hp2 >= hp1 && h >= hp1)
						{
							ao1 = aip1;
							ao2 = ai;
							ao3 = aip2;
						}
						else if (hp2 >= h && hp2 >= hp1 && hp1 >= h)
						{
							ao1 = ai;
							ao2 = aip1;
							ao3 = aip2;
						}
						else
							Debug.Assert(0);

						int do1;
						int ho1;
						int duro1;

						int do2;
						int ho2;
						int duro2;

						int do3;
						int ho3;
						//int duro3;

						if (ao1 == ai)
						{
							do1 = d;
							ho1 = h;
							duro1 = act.duration;
						}
						else
						{
							do1 = c.times[ao1] % gt.rules.nDaysPerWeek;
							ho1 = c.times[ao1] / gt.rules.nDaysPerWeek;
							duro1 = gt.rules.internalActivitiesList[ao1].duration;
						}

						if (ao2 == ai)
						{
							do2 = d;
							ho2 = h;
							duro2 = act.duration;
						}
						else
						{
							do2 = c.times[ao2] % gt.rules.nDaysPerWeek;
							ho2 = c.times[ao2] / gt.rules.nDaysPerWeek;
							duro2 = gt.rules.internalActivitiesList[ao2].duration;
						}

						if (ao3 == ai)
						{
							do3 = d;
							ho3 = h;
							//duro3=act->duration;
						}
						else
						{
							do3 = c.times[ao3] % gt.rules.nDaysPerWeek;
							ho3 = c.times[ao3] / gt.rules.nDaysPerWeek;
							//duro3=gt.rules.internalActivitiesList[ao3].duration;
						}

						Debug.Assert(do1 == do2 && do1 == do3);
						if (ho1 + duro1 <= ho2 && ho2 + duro2 <= ho3)
						{
							int hoursBetweenThem = 0;

							for (int kk = ho1 + duro1; kk < ho2; kk++)
								if (!GlobalMembersGenerate_pre.breakDayHour(d,kk))
									hoursBetweenThem++;
							for (int kk = ho2 + duro2; kk < ho3; kk++)
								if (!GlobalMembersGenerate_pre.breakDayHour(d,kk))
									hoursBetweenThem++;

							if (hoursBetweenThem == 0)
								ok = true;
							else
								ok = false;
						}
						else
						{
							//not OK
							ok = false;
						}
					}
					else
					{
						//not OK
						ok = false;
					}
				}

				bool again; //=false;

				if (!ok && !sR)
				{
					int aidisplaced = -1;

					if (aip2 >= 0) //two placed activities
					{
						again = true;

						QList<int> acts = new QList<int>();

						if (!GlobalMembersGenerate_pre.fixedTimeActivity[aip1] && !GlobalMembersGenerate.swappedActivities[aip1])
							acts.append(aip1);
						if (!GlobalMembersGenerate_pre.fixedTimeActivity[aip2] && !GlobalMembersGenerate.swappedActivities[aip2])
							acts.append(aip2);

						if (acts.count() == 0)
							aidisplaced = -1;
						else if (acts.count() == 1)
							aidisplaced = acts.at(0);
						else
						{
							int t;
							if (level == 0)
							{
								int optMinWrong = GlobalMembersGenerate.INF;

								QList<int> tl = new QList<int>();

								for (int q = 0; q < acts.count(); q++)
								{
									int tta = acts.at(q);
									if (optMinWrong > GlobalMembersGenerate.triedRemovals(tta,c.times[tta]))
									{
										 optMinWrong = GlobalMembersGenerate.triedRemovals(tta,c.times[tta]);
									}
								}

								for (int q = 0; q < acts.count(); q++)
								{
									int tta = acts.at(q);
									if (optMinWrong == GlobalMembersGenerate.triedRemovals(tta,c.times[tta]))
										tl.append(q);
								}

								Debug.Assert(tl.size() >= 1);
								int mpos = tl.at(GlobalMembersTimetable_defs.randomKnuth(tl.size()));

								Debug.Assert(mpos >= 0 && mpos < acts.count());
								t = mpos;
							}
							else
							{
								t = GlobalMembersTimetable_defs.randomKnuth(acts.count());
							}

							aidisplaced = acts.at(t);
						}
					}
					else
					{
						again = false;
						Debug.Assert(aip1 >= 0);
						if (!GlobalMembersGenerate_pre.fixedTimeActivity[aip1] && !GlobalMembersGenerate.swappedActivities[aip1])
							aidisplaced = aip1;
						else
							aidisplaced = -1;
					}

					Debug.Assert(aidisplaced != ai);

					if (aidisplaced == -1)
					{
						okthreeactivitiesgrouped = false;
						goto impossiblethreeactivitiesgrouped;
					}
					if (GlobalMembersGenerate_pre.fixedTimeActivity[aidisplaced] || GlobalMembersGenerate.swappedActivities[aidisplaced])
					{
						okthreeactivitiesgrouped = false;
						goto impossiblethreeactivitiesgrouped;
					}

#if conflActivities_ConditionalDefinition1
					Debug.Assert(!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(aidisplaced));
#else
					Debug.Assert(!conflActivities[newtime].contains(aidisplaced));
#endif
#if conflActivities_ConditionalDefinition1
					GlobalMembersGenerate.conflActivitiesL[level, newtime].append(aidisplaced);
#else
					conflActivities[newtime].append(aidisplaced);
#endif
#if nConflActivities_ConditionalDefinition1
					GlobalMembersGenerate.nConflActivitiesL[level, newtime]++;
#else
					nConflActivities[newtime]++;
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
					Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
					Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
					Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
					Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif

					//if !again, everything is OK, because there was one placed activity and it was eliminated

					if (again)
					{
						aip1 = -1, aip2 = -1;
						ainp1 = -1, ainp2 = -1;
#if conflActivities_ConditionalDefinition1
						if (c.times[ai2] == GlobalMembersTimetable_defs.UNALLOCATED_TIME || GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
						if (c.times[ai2] == GlobalMembersTimetable_defs.UNALLOCATED_TIME || conflActivities[newtime].contains(ai2))
#endif
							ainp1 = ai2;
						else
							aip1 = ai2;
#if conflActivities_ConditionalDefinition1
						if (c.times[ai3] == GlobalMembersTimetable_defs.UNALLOCATED_TIME || GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai3))
#else
						if (c.times[ai3] == GlobalMembersTimetable_defs.UNALLOCATED_TIME || conflActivities[newtime].contains(ai3))
#endif
						{
							if (ainp1 == -1)
								ainp1 = ai3;
							else
								ainp2 = ai3;
						}
						else
						{
							if (aip1 == -1)
								aip1 = ai3;
							else
								aip2 = ai3;
						}

						Debug.Assert(aip1 >= 0 && ainp1 >= 0 && aip2 == -1 && ainp2 == -1); //only one placed

						//again the procedure from above, with 1 placed
						int dp1 = c.times[aip1] % gt.rules.nDaysPerWeek;
						int hp1 = c.times[aip1] / gt.rules.nDaysPerWeek;
						int durp1 = gt.rules.internalActivitiesList[aip1].duration;

						int hoursBetweenThem = -1;

						if (dp1 != d)
							hoursBetweenThem = -1;
						else if (dp1 == d && h >= hp1 + durp1)
						{
							hoursBetweenThem = 0;
							for (int kk = hp1 + durp1; kk < h; kk++)
								if (!GlobalMembersGenerate_pre.breakDayHour(d,kk))
								{
									//check that the working hours are not separated by a break
									//assertion that durp1>0, so the kk-1 >= 0
									if (GlobalMembersGenerate_pre.breakDayHour(d,kk - 1) && hoursBetweenThem > 0)
									{
										hoursBetweenThem = -1;
										break;
									}

									hoursBetweenThem++;
								}
						}
						else if (dp1 == d && hp1 >= h + act.duration)
						{
							hoursBetweenThem = 0;
							for (int kk = h + act.duration; kk < hp1; kk++)
								if (!GlobalMembersGenerate_pre.breakDayHour(d,kk))
								{
									//check that the working hours are not separated by a break
									//assertion that act->duration>0, so the kk-1 >= 0
									if (GlobalMembersGenerate_pre.breakDayHour(d,kk - 1) && hoursBetweenThem > 0)
									{
										hoursBetweenThem = -1;
										break;
									}

									hoursBetweenThem++;
								}
						}
						else
							hoursBetweenThem = -1;

						Debug.Assert(ainp1 >= 0);
						if (hoursBetweenThem == 0 || hoursBetweenThem == gt.rules.internalActivitiesList[ainp1].duration)
							//OK
							ok = true;
						else
							//not OK
							ok = false;

						Debug.Assert(!sR);
						if (!ok)
						{
							aidisplaced = aip1;
							if (GlobalMembersGenerate_pre.fixedTimeActivity[aidisplaced] || GlobalMembersGenerate.swappedActivities[aidisplaced])
							{
								okthreeactivitiesgrouped = false;
								goto impossiblethreeactivitiesgrouped;
							}

#if conflActivities_ConditionalDefinition1
							Debug.Assert(!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(aidisplaced));
#else
							Debug.Assert(!conflActivities[newtime].contains(aidisplaced));
#endif
#if conflActivities_ConditionalDefinition1
							GlobalMembersGenerate.conflActivitiesL[level, newtime].append(aidisplaced);
#else
							conflActivities[newtime].append(aidisplaced);
#endif
#if nConflActivities_ConditionalDefinition1
							GlobalMembersGenerate.nConflActivitiesL[level, newtime]++;
#else
							nConflActivities[newtime]++;
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif

							//now it is OK, because there were two activities placed and both were eliminated
						}
					} //end if(again)
				}
			}

	impossiblethreeactivitiesgrouped:
			if (!okthreeactivitiesgrouped)
			{
				//if(updateSubgroups || updateTeachers)
				//	removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

			/*foreach(int ai2, conflActivities[newtime])
				assert(!swappedActivities[ai2]);*/

	/////////////////////////////////////////////////////////////////////////////////////////////

			//allowed from 2 activities ordered
			oktwoactivitiesordered = true;

			for (int i = 0; i < GlobalMembersGenerate_pre.constrTwoActivitiesOrderedActivities[ai].count(); i++)
			{
				//direct
				int ai2 = GlobalMembersGenerate_pre.constrTwoActivitiesOrderedActivities[ai].at(i);
				double perc = GlobalMembersGenerate_pre.constrTwoActivitiesOrderedPercentages[ai].at(i);
				if (c.times[ai2] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
					int d2 = c.times[ai2] % gt.rules.nDaysPerWeek;
					int h2 = c.times[ai2] / gt.rules.nDaysPerWeek;
					bool ok = true;

					if (!(d < d2 || (d == d2 && h + act.duration - 1 < h2)))
						ok = false;

					bool sR = GlobalMembersGenerate.skipRandom(perc);
					//if(fixedTimeActivity[ai] && perc<100.0)
					//	sR=true;

					if (!ok && !sR)
					{
						Debug.Assert(ai2 != ai);

						if (GlobalMembersGenerate_pre.fixedTimeActivity[ai2] || GlobalMembersGenerate.swappedActivities[ai2])
						{
							oktwoactivitiesordered = false;
							goto impossibletwoactivitiesordered;
						}

#if conflActivities_ConditionalDefinition1
						if (!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
						if (!conflActivities[newtime].contains(ai2))
#endif
						{
						//if(conflActivities[newtime].indexOf(ai2)==-1){

#if conflActivities_ConditionalDefinition1
							GlobalMembersGenerate.conflActivitiesL[level, newtime].append(ai2);
#else
							conflActivities[newtime].append(ai2);
#endif
							//conflActivities[newtime].append(ai2);
#if nConflActivities_ConditionalDefinition1
							GlobalMembersGenerate.nConflActivitiesL[level, newtime]++;
#else
							nConflActivities[newtime]++;
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif
							//addConflActivity(conflActivities[newtime], nConflActivities[newtime], ai2, &gt.rules.internalActivitiesList[ai2]);
						}
					}
				}
			}

			for (int i = 0; i < GlobalMembersGenerate_pre.inverseConstrTwoActivitiesOrderedActivities[ai].count(); i++)
			{
				//inverse
				int ai2 = GlobalMembersGenerate_pre.inverseConstrTwoActivitiesOrderedActivities[ai].at(i);
				double perc = GlobalMembersGenerate_pre.inverseConstrTwoActivitiesOrderedPercentages[ai].at(i);
				if (c.times[ai2] != GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
					int d2 = c.times[ai2] % gt.rules.nDaysPerWeek;
					int h2 = c.times[ai2] / gt.rules.nDaysPerWeek;
					int dur2 = gt.rules.internalActivitiesList[ai2].duration;
					bool ok = true;

					if (!(d2 < d || (d2 == d && h2 + dur2 - 1 < h)))
						ok = false;

					bool sR = GlobalMembersGenerate.skipRandom(perc);
					//if(fixedTimeActivity[ai] && perc<100.0)
					//	sR=true;

					if (!ok && !sR)
					{
						Debug.Assert(ai2 != ai);

						if (GlobalMembersGenerate_pre.fixedTimeActivity[ai2] || GlobalMembersGenerate.swappedActivities[ai2])
						{
							oktwoactivitiesordered = false;
							goto impossibletwoactivitiesordered;
						}

#if conflActivities_ConditionalDefinition1
						if (!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
						if (!conflActivities[newtime].contains(ai2))
#endif
						{
						//if(conflActivities[newtime].indexOf(ai2)==-1){
#if conflActivities_ConditionalDefinition1
							GlobalMembersGenerate.conflActivitiesL[level, newtime].append(ai2);
#else
							conflActivities[newtime].append(ai2);
#endif
							//conflActivities[newtime].append(ai2);
#if nConflActivities_ConditionalDefinition1
							GlobalMembersGenerate.nConflActivitiesL[level, newtime]++;
#else
							nConflActivities[newtime]++;
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif
							//addConflActivity(conflActivities[newtime], nConflActivities[newtime], ai2, &gt.rules.internalActivitiesList[ai2]);
						}
					}
				}
			}

	impossibletwoactivitiesordered:
			if (!oktwoactivitiesordered)
			{
				//if(updateSubgroups || updateTeachers)
				//	removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

			/*foreach(int ai2, conflActivities[newtime])
				assert(!swappedActivities[ai2]);*/

	/////////////////////////////////////////////////////////////////////////////////////////////

			//allowed from activity ends students day
			okactivityendsstudentsday = true;

			if (GlobalMembersGenerate_pre.haveActivityEndsStudentsDay)
			{
				//1. If current activity needs to be at the end
				if (GlobalMembersGenerate_pre.activityEndsStudentsDayPercentages[ai] >= 0)
				{
					bool skip = GlobalMembersGenerate.skipRandom(GlobalMembersGenerate_pre.activityEndsStudentsDayPercentages[ai]);
					if (!skip)
					{
						foreach (int sb, act.iSubgroupsList)
						{
						//for(int j=0; j<gt.rules.internalActivitiesList[ai].iSubgroupsList.count(); j++){
						//	int sb=gt.rules.internalActivitiesList[ai].iSubgroupsList.at(j);
							for (int hh = h + act.duration; hh < gt.rules.nHoursPerDay; hh++)
							{
								int ai2 = GlobalMembersGenerate.subgroupsTimetable(sb,d,hh);
								if (ai2 >= 0)
								{
									if (GlobalMembersGenerate_pre.fixedTimeActivity[ai2] || GlobalMembersGenerate.swappedActivities[ai2])
									{
										okactivityendsstudentsday = false;
										goto impossibleactivityendsstudentsday;
									}

#if conflActivities_ConditionalDefinition1
									if (!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
									if (!conflActivities[newtime].contains(ai2))
#endif
									{
									//if(conflActivities[newtime].indexOf(ai2)==-1){
										//conflActivities[newtime].append(ai2);
#if conflActivities_ConditionalDefinition1
										GlobalMembersGenerate.conflActivitiesL[level, newtime].append(ai2);
#else
										conflActivities[newtime].append(ai2);
#endif
#if nConflActivities_ConditionalDefinition1
										GlobalMembersGenerate.nConflActivitiesL[level, newtime]++;
#else
										nConflActivities[newtime]++;
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
										Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
										Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
										Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
										Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif
										//addConflActivity(conflActivities[newtime], nConflActivities[newtime], ai2, &gt.rules.internalActivitiesList[ai2]);
									}
								}
							}
						}
					}
				}

				//2. Check activities which have to be at the end, in the same day with current activity
				foreach (int sb, act.iSubgroupsList)
				{
				//for(int j=0; j<gt.rules.internalActivitiesList[ai].iSubgroupsList.count(); j++){
				//	int sb=gt.rules.internalActivitiesList[ai].iSubgroupsList.at(j);
					for (int hh = h - 1; hh >= 0; hh--)
					{
						int ai2 = GlobalMembersGenerate.subgroupsTimetable(sb,d,hh);
						if (ai2 >= 0)
							if (GlobalMembersGenerate_pre.activityEndsStudentsDayPercentages[ai2] >= 0)
							{
								bool skip = GlobalMembersGenerate.skipRandom(GlobalMembersGenerate_pre.activityEndsStudentsDayPercentages[ai2]);
								if (!skip)
								{
									if (GlobalMembersGenerate_pre.fixedTimeActivity[ai2] || GlobalMembersGenerate.swappedActivities[ai2])
									{
										okactivityendsstudentsday = false;
										goto impossibleactivityendsstudentsday;
									}

#if conflActivities_ConditionalDefinition1
									if (!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
									if (!conflActivities[newtime].contains(ai2))
#endif
									{
									//if(conflActivities[newtime].indexOf(ai2)==-1){
										//conflActivities[newtime].append(ai2);
#if conflActivities_ConditionalDefinition1
										GlobalMembersGenerate.conflActivitiesL[level, newtime].append(ai2);
#else
										conflActivities[newtime].append(ai2);
#endif
#if nConflActivities_ConditionalDefinition1
										GlobalMembersGenerate.nConflActivitiesL[level, newtime]++;
#else
										nConflActivities[newtime]++;
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
										Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
										Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
										Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
										Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif
										//addConflActivity(conflActivities[newtime], nConflActivities[newtime], ai2, &gt.rules.internalActivitiesList[ai2]);
									}
								}
							}
					}
				}
			}

	impossibleactivityendsstudentsday:
			if (!okactivityendsstudentsday)
			{
				//if(updateSubgroups || updateTeachers)
				//	removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

			//////////////////////////////////////////////////
			if (updateSubgroups || updateTeachers)
			{
				addAiToNewTimetable(ai, act, d, h);
				if (updateTeachers)
					updateTeachersNHoursGaps(act, ai, d);
				if (updateSubgroups)
					updateSubgroupsNHoursGaps(act, ai, d);
			}
			//////////////////////////////////////////////////


	/////////////////////////////////////////////////////////////////////////////////////////////

			////////////STUDENTS////////////////

	/////////////////////////////////////////////////////////////////////////////////////////////

			//BEGIN students interval max days per week
			okstudentsintervalmaxdaysperweek = true;
			foreach (int sbg, act.iSubgroupsList)
			{
				double perc = -1.0;
				for (int cnt = 0; cnt < 3; cnt++)
				{
					if (cnt == 0)
					{
						perc = GlobalMembersGenerate_pre.subgroupsIntervalMaxDaysPerWeekPercentages1[sbg];
					}
					else if (cnt == 1)
					{
						perc = GlobalMembersGenerate_pre.subgroupsIntervalMaxDaysPerWeekPercentages2[sbg];
					}
					else if (cnt == 2)
					{
						perc = GlobalMembersGenerate_pre.subgroupsIntervalMaxDaysPerWeekPercentages3[sbg];
					}
					else
						Debug.Assert(0);

					if (perc >= 0)
					{
						int maxDays = -1;
						int sth = -1;
						int endh = -1;

						if (cnt == 0)
						{
							maxDays = GlobalMembersGenerate_pre.subgroupsIntervalMaxDaysPerWeekMaxDays1[sbg];
							sth = GlobalMembersGenerate_pre.subgroupsIntervalMaxDaysPerWeekIntervalStart1[sbg];
							endh = GlobalMembersGenerate_pre.subgroupsIntervalMaxDaysPerWeekIntervalEnd1[sbg];
						}
						else if (cnt == 1)
						{
							maxDays = GlobalMembersGenerate_pre.subgroupsIntervalMaxDaysPerWeekMaxDays2[sbg];
							sth = GlobalMembersGenerate_pre.subgroupsIntervalMaxDaysPerWeekIntervalStart2[sbg];
							endh = GlobalMembersGenerate_pre.subgroupsIntervalMaxDaysPerWeekIntervalEnd2[sbg];
						}
						else if (cnt == 2)
						{
							maxDays = GlobalMembersGenerate_pre.subgroupsIntervalMaxDaysPerWeekMaxDays3[sbg];
							sth = GlobalMembersGenerate_pre.subgroupsIntervalMaxDaysPerWeekIntervalStart3[sbg];
							endh = GlobalMembersGenerate_pre.subgroupsIntervalMaxDaysPerWeekIntervalEnd3[sbg];
						}
						else
							Debug.Assert(0);

						Debug.Assert(sth >= 0 && sth < gt.rules.nHoursPerDay);
						Debug.Assert(endh > sth && endh <= gt.rules.nHoursPerDay);
						Debug.Assert(maxDays >= 0 && maxDays <= gt.rules.nDaysPerWeek);

						if (GlobalMembersGenerate.skipRandom(perc))
							continue;

						Debug.Assert(perc == 100.0);

						bool foundothers = false;
						bool foundai = false;
						for (int hh = sth; hh < endh; hh++)
						{
							if (GlobalMembersGenerate.newSubgroupsTimetable(sbg,d,hh) == ai)
							{
								foundai = true;
							}
							else
							{
								Debug.Assert(GlobalMembersGenerate.newSubgroupsTimetable(sbg,d,hh) == GlobalMembersGenerate.subgroupsTimetable(sbg,d,hh));
								if (GlobalMembersGenerate.newSubgroupsTimetable(sbg,d,hh) >= 0)
								{
#if conflActivities_ConditionalDefinition1
									if (!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(GlobalMembersGenerate.newSubgroupsTimetable(sbg,d,hh)))
#else
									if (!conflActivities[newtime].contains(GlobalMembersGenerate.newSubgroupsTimetable(sbg,d,hh)))
#endif
									{
										foundothers = true;
									}
								}
							}
						}
						int nrotherdays = 0;
						for (int dd = 0; dd < gt.rules.nDaysPerWeek; dd++)
						{
							if (dd != d)
							{
								for (int hh = sth; hh < endh; hh++)
								{
									Debug.Assert(GlobalMembersGenerate.newSubgroupsTimetable(sbg,dd,hh) == GlobalMembersGenerate.subgroupsTimetable(sbg,dd,hh));
#if conflActivities_ConditionalDefinition1
									if (GlobalMembersGenerate.newSubgroupsTimetable(sbg,dd,hh) >= 0 && !GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(GlobalMembersGenerate.newSubgroupsTimetable(sbg,dd,hh)))
#else
									if (GlobalMembersGenerate.newSubgroupsTimetable(sbg,dd,hh) >= 0 && !conflActivities[newtime].contains(GlobalMembersGenerate.newSubgroupsTimetable(sbg,dd,hh)))
#endif
									{
										nrotherdays++;
										break;
									}
								}
							}
						}
						Debug.Assert(nrotherdays <= maxDays); //if percentage==100%, then it is impossible to break this constraint
						if ((foundai && !foundothers) && nrotherdays == maxDays)
						{
							//increased above limit
							bool[] occupiedIntervalDay = new bool[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK];
							bool[] canEmptyIntervalDay = new bool[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK];

							int[] _minWrong = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK];
							int[] _nWrong = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK];
							int[] _nConflActivities = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK];
							int[] _minIndexAct = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK];

							QList<int>[] _activitiesForIntervalDay = new QList[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK];

							for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
							{
								if (d2 == d)
									continue;

								occupiedIntervalDay[d2] = false;
								canEmptyIntervalDay[d2] = true;

								_minWrong[d2] = GlobalMembersGenerate.INF;
								_nWrong[d2] = 0;
								_nConflActivities[d2] = 0;
								_minIndexAct[d2] = gt.rules.nInternalActivities;
								_activitiesForIntervalDay[d2].clear();

								for (int h2 = sth; h2 < endh; h2++)
								{
									int ai2 = GlobalMembersGenerate.subgroupsTimetable(sbg,d2,h2);
								//foreach(int ai2, teacherActivitiesOfTheDay(tch,d2)){
									if (ai2 >= 0)
									{
#if conflActivities_ConditionalDefinition1
										if (!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
										if (!conflActivities[newtime].contains(ai2))
#endif
										{
											occupiedIntervalDay[d2] = true;
											if (GlobalMembersGenerate_pre.fixedTimeActivity[ai2] || GlobalMembersGenerate.swappedActivities[ai2])
												canEmptyIntervalDay[d2] = false;
											else if (!_activitiesForIntervalDay[d2].contains(ai2))
											{
												_minWrong[d2] = min(_minWrong[d2], GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]));
												_minIndexAct[d2] = min(_minIndexAct[d2], GlobalMembersGenerate.invPermutation[ai2]);
												_nWrong[d2] += GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]);
												_nConflActivities[d2]++;
												_activitiesForIntervalDay[d2].append(ai2);
												Debug.Assert(_nConflActivities[d2] == _activitiesForIntervalDay[d2].count());
											}
										}
									}
								}

								if (!occupiedIntervalDay[d2])
									canEmptyIntervalDay[d2] = false;
							}
							occupiedIntervalDay[d] = true;
							canEmptyIntervalDay[d] = false;

							int nOc = 0;
							bool canChooseDay = false;

							for (int j = 0; j < gt.rules.nDaysPerWeek; j++)
								if (occupiedIntervalDay[j])
								{
									nOc++;
									if (canEmptyIntervalDay[j])
									{
										canChooseDay = true;
									}
								}

							//if(nOc>maxDays){
							Debug.Assert(nOc == maxDays + 1);

							if (!canChooseDay)
							{
								if (level == 0)
								{
									//Liviu: inactivated from version 5.12.4 (7 Feb. 2010), because it may take too long for some files
									//cout<<"WARNING - mb - file "<<__FILE__<<" line "<<__LINE__<<endl;
								}
								okstudentsintervalmaxdaysperweek = false;
								goto impossiblestudentsintervalmaxdaysperweek;
							}

							int d2 = -1;

							if (level != 0)
							{
								//choose random day from those with minimum number of conflicting activities
								QList<int> candidateDays = new QList<int>();

								int m = gt.rules.nInternalActivities;

								for (int kk = 0; kk < gt.rules.nDaysPerWeek; kk++)
									if (canEmptyIntervalDay[kk])
										if (m > _nConflActivities[kk])
											m = _nConflActivities[kk];

								candidateDays.clear();
								for (int kk = 0; kk < gt.rules.nDaysPerWeek; kk++)
									if (canEmptyIntervalDay[kk] && m == _nConflActivities[kk])
										candidateDays.append(kk);

								Debug.Assert(candidateDays.count() > 0);
								d2 = candidateDays.at(GlobalMembersTimetable_defs.randomKnuth(candidateDays.count()));
							}
							else //level==0
							{
								QList<int> candidateDays = new QList<int>();

								int _mW = GlobalMembersGenerate.INF;
								int _nW = GlobalMembersGenerate.INF;
								int _mCA = gt.rules.nInternalActivities;
								int _mIA = gt.rules.nInternalActivities;

								for (int kk = 0; kk < gt.rules.nDaysPerWeek; kk++)
									if (canEmptyIntervalDay[kk])
									{
										if (_mW > _minWrong[kk] || (_mW == _minWrong[kk] && _nW > _nWrong[kk]) || (_mW == _minWrong[kk] && _nW == _nWrong[kk] && _mCA > _nConflActivities[kk]) || (_mW == _minWrong[kk] && _nW == _nWrong[kk] && _mCA == _nConflActivities[kk] && _mIA > _minIndexAct[kk]))
										{
											_mW = _minWrong[kk];
											_nW = _nWrong[kk];
											_mCA = _nConflActivities[kk];
											_mIA = _minIndexAct[kk];
										}
									}

								Debug.Assert(_mW < GlobalMembersGenerate.INF);

								candidateDays.clear();
								for (int kk = 0; kk < gt.rules.nDaysPerWeek; kk++)
									if (canEmptyIntervalDay[kk] && _mW == _minWrong[kk] && _nW == _nWrong[kk] && _mCA == _nConflActivities[kk] && _mIA == _minIndexAct[kk])
										candidateDays.append(kk);

								Debug.Assert(candidateDays.count() > 0);
								d2 = candidateDays.at(GlobalMembersTimetable_defs.randomKnuth(candidateDays.count()));
							}

							Debug.Assert(d2 >= 0);

							Debug.Assert(_activitiesForIntervalDay[d2].count() > 0);

							foreach (int ai2, _activitiesForIntervalDay[d2])
							{
								Debug.Assert(ai2 != ai);
								Debug.Assert(!GlobalMembersGenerate.swappedActivities[ai2]);
								Debug.Assert(!GlobalMembersGenerate_pre.fixedTimeActivity[ai2]);
#if conflActivities_ConditionalDefinition1
								Debug.Assert(!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2));
#else
								Debug.Assert(!conflActivities[newtime].contains(ai2));
#endif
#if conflActivities_ConditionalDefinition1
								GlobalMembersGenerate.conflActivitiesL[level, newtime].append(ai2);
#else
								conflActivities[newtime].append(ai2);
#endif
#if nConflActivities_ConditionalDefinition1
								GlobalMembersGenerate.nConflActivitiesL[level, newtime]++;
#else
								nConflActivities[newtime]++;
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif
								//addConflActivity(conflActivities[newtime], nConflActivities[newtime], ai2, &gt.rules.internalActivitiesList[ai2]);
							}
						}
					}
				}
			}
			//respecting students interval max days per week
	impossiblestudentsintervalmaxdaysperweek:
			if (!okstudentsintervalmaxdaysperweek)
			{
				if (updateSubgroups || updateTeachers)
					removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

			////////////////////////////END students interval max days per week


	/////////////////////////////////////////////////////////////////////////////////////////////

			//not breaking students early max beginnings at second hour
			//TODO: this should take care of students max gaps per day also. Very critical changes, so be very careful if you do them. Safer -> leave them as they are now.
			//see file fet-v.v.v/doc/algorithm/improve-studentsmaxgapsperday.txt for advice and (unstable) code on how to make students max gaps per day constraint perfect
			okstudentsearlymaxbeginningsatsecondhour = true;

			foreach (int sbg, act.iSubgroupsList) if (!GlobalMembersGenerate.skipRandom(GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourPercentage[sbg]))
			{
					//preliminary check
					int _nHours = 0;
					int _nFirstGapsOne = 0;
					int _nFirstGapsTwo = 0;
					int _nGaps = 0;
					int _nIllegalGaps = 0;
					for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
					{
						_nHours += GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d2);

						if (GlobalMembersGenerate.newSubgroupsDayNFirstGaps(sbg, d2) == 1)
						{
							_nFirstGapsOne++;
						}
						else if (GlobalMembersGenerate.newSubgroupsDayNFirstGaps(sbg, d2) >= 2)
						{
							_nFirstGapsTwo++;
							_nIllegalGaps++;
							_nGaps += GlobalMembersGenerate.newSubgroupsDayNFirstGaps(sbg, d2) - 2;
						}
						_nGaps += GlobalMembersGenerate.newSubgroupsDayNGaps(sbg,d2);
					}

					int _tt = GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourMaxBeginnings[sbg];
					if (_tt >= _nFirstGapsOne)
					{
						_tt -= _nFirstGapsOne;
						_nFirstGapsOne = 0;
					}
					else
					{
						_nFirstGapsOne -= _tt;
						_tt = 0;
					}
					if (_tt >= _nFirstGapsTwo)
					{
						_tt -= _nFirstGapsTwo;
						_nFirstGapsTwo = 0;
					}
					else
					{
						_nFirstGapsTwo -= _tt;
						_tt = 0;
					}

					if (_nFirstGapsTwo > 0)
					{
						_nGaps += _nFirstGapsTwo;
						_nFirstGapsTwo = 0;
					}

					int _nHoursGaps = 0;
					if (GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekPercentage[sbg] >= 0)
					{
						Debug.Assert(GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekPercentage[sbg] == 100);
						if (_nGaps > GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekMaxGaps[sbg])
							_nHoursGaps = _nGaps - GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekMaxGaps[sbg];
					}

					if (_nHours + _nFirstGapsOne + _nHoursGaps + _nIllegalGaps > GlobalMembersGenerate_pre.nHoursPerSubgroup[sbg])
					{
						if (level >= GlobalMembersGenerate.LEVEL_STOP_CONFLICTS_CALCULATION)
						{
							okstudentsearlymaxbeginningsatsecondhour = false;
							goto impossiblestudentsearlymaxbeginningsatsecondhour;
						}

#if conflActivities_ConditionalDefinition1
						getSbgTimetable(sbg, GlobalMembersGenerate.conflActivitiesL[level, newtime]);
#else
						getSbgTimetable(sbg, conflActivities[newtime]);
#endif
						sbgGetNHoursGaps(sbg);

						for (;;)
						{
							int nHours = 0;
							int nFirstGapsOne = 0;
							int nFirstGapsTwo = 0;
							int nGaps = 0;
							int nIllegalGaps = 0;
							for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
							{
								nHours += GlobalMembersGenerate.sbgDayNHours[d2];

								if (GlobalMembersGenerate.sbgDayNFirstGaps[d2] == 1)
								{
									nFirstGapsOne++;
								}
								else if (GlobalMembersGenerate.sbgDayNFirstGaps[d2] >= 2)
								{
									nFirstGapsTwo++;
									nIllegalGaps++;
									nGaps += GlobalMembersGenerate.sbgDayNFirstGaps[d2] - 2;
								}
								nGaps += GlobalMembersGenerate.sbgDayNGaps[d2];
							}

							int tt = GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourMaxBeginnings[sbg];
							if (tt >= nFirstGapsOne)
							{
								tt -= nFirstGapsOne;
								nFirstGapsOne = 0;
							}
							else
							{
								nFirstGapsOne -= tt;
								tt = 0;
							}
							if (tt >= nFirstGapsTwo)
							{
								tt -= nFirstGapsTwo;
								nFirstGapsTwo = 0;
							}
							else
							{
								nFirstGapsTwo -= tt;
								tt = 0;
							}

							if (nFirstGapsTwo > 0)
							{
								nGaps += nFirstGapsTwo;
								nFirstGapsTwo = 0;
							}

							int nHoursGaps = 0;
							if (GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekPercentage[sbg] >= 0)
							{
								Debug.Assert(GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekPercentage[sbg] == 100);
								if (nGaps > GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekMaxGaps[sbg])
									nHoursGaps = nGaps - GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekMaxGaps[sbg];
							}

							int ai2 = -1;

							if (nHours + nFirstGapsOne + nHoursGaps + nIllegalGaps > GlobalMembersGenerate_pre.nHoursPerSubgroup[sbg])
							{
								//remove an activity
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								bool k = subgroupRemoveAnActivityFromEnd(sbg, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
								bool k = subgroupRemoveAnActivityFromEnd(sbg, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref nConflActivities[newtime], ref ai2);
#endif
#else
#if nConflActivities_ConditionalDefinition1
								bool k = subgroupRemoveAnActivityFromEnd(sbg, level, ai, ref conflActivities[newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
								bool k = subgroupRemoveAnActivityFromEnd(sbg, level, ai, ref conflActivities[newtime], ref nConflActivities[newtime], ref ai2);
#endif
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif
								if (!k)
								{
									if (level == 0)
									{
										//this should not be displayed
										//cout<<"WARNING - maybe bug - file "<<__FILE__<<" line "<<__LINE__<<endl;
									}
									okstudentsearlymaxbeginningsatsecondhour = false;
									goto impossiblestudentsearlymaxbeginningsatsecondhour;
								}
							}
							else //OK
							{
								break;
							}

							Debug.Assert(ai2 >= 0);

							removeAi2FromSbgTimetable(ai2);
							updateSbgNHoursGaps(sbg, c.times[ai2] % gt.rules.nDaysPerWeek);
						}
					}
			}

	impossiblestudentsearlymaxbeginningsatsecondhour:
			if (!okstudentsearlymaxbeginningsatsecondhour)
			{
				if (updateSubgroups || updateTeachers)
					removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

			////////////////////////////END students early max beginnings at second hour

	/////////////////////////////////////////////////////////////////////////////////////////////

			//not breaking students max gaps per week
			//TODO: this should take care of students max gaps per day also. Very critical changes, so be very careful if you do them. Safer -> leave them as they are now.
			//see file fet-v.v.v/doc/algorithm/improve-studentsmaxgapsperday.txt for advice and (unstable) code on how to make students max gaps per day constraint perfect
			okstudentsmaxgapsperweek = true;

			foreach (int sbg, act.iSubgroupsList) if (!GlobalMembersGenerate.skipRandom(GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekPercentage[sbg]))
			{
				//TODO
				//if(!skipRandom(subgroupsMaxGapsPerWeekPercentage[sbg])){
					//assert(subgroupsMaxGapsPerWeekPercentage[sbg]==100);

					//preliminary test
					int _nHours = 0;
					int _nGaps = 0;
					int _nFirstGaps = 0;
					for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
					{
						_nHours += GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d2);
						_nGaps += GlobalMembersGenerate.newSubgroupsDayNGaps(sbg,d2);
						_nFirstGaps += GlobalMembersGenerate.newSubgroupsDayNFirstGaps(sbg,d2);
					}

					int _nFirstHours = 0;

					if (GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourPercentage[sbg] >= 0)
					{
						Debug.Assert(GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourPercentage[sbg] == 100);
						if (_nFirstGaps > GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourMaxBeginnings[sbg])
							_nFirstHours = _nFirstGaps - GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourMaxBeginnings[sbg];
					}

					if (_nGaps + _nHours + _nFirstHours > GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekMaxGaps[sbg] + GlobalMembersGenerate_pre.nHoursPerSubgroup[sbg])
					{
						if (level >= GlobalMembersGenerate.LEVEL_STOP_CONFLICTS_CALCULATION)
						{
							okstudentsmaxgapsperweek = false;
							goto impossiblestudentsmaxgapsperweek;
						}

#if conflActivities_ConditionalDefinition1
						getSbgTimetable(sbg, GlobalMembersGenerate.conflActivitiesL[level, newtime]);
#else
						getSbgTimetable(sbg, conflActivities[newtime]);
#endif
						sbgGetNHoursGaps(sbg);

						for (;;)
						{
							int nHours = 0;
							int nGaps = 0;
							int nFirstGaps = 0;
							for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
							{
								nHours += GlobalMembersGenerate.sbgDayNHours[d2];
								nGaps += GlobalMembersGenerate.sbgDayNGaps[d2];
								nFirstGaps += GlobalMembersGenerate.sbgDayNFirstGaps[d2];
							}

							int ai2 = -1;

							int nFirstHours = 0;

							if (GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourPercentage[sbg] >= 0)
							{
								Debug.Assert(GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourPercentage[sbg] == 100);
								if (nFirstGaps > GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourMaxBeginnings[sbg])
									nFirstHours = nFirstGaps - GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourMaxBeginnings[sbg];
							}

							if (nGaps + nHours + nFirstHours > GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekMaxGaps[sbg] + GlobalMembersGenerate_pre.nHoursPerSubgroup[sbg])
							{
								//remove an activity
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								bool k = subgroupRemoveAnActivityFromBeginOrEnd(sbg, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
								bool k = subgroupRemoveAnActivityFromBeginOrEnd(sbg, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref nConflActivities[newtime], ref ai2);
#endif
#else
#if nConflActivities_ConditionalDefinition1
								bool k = subgroupRemoveAnActivityFromBeginOrEnd(sbg, level, ai, ref conflActivities[newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
								bool k = subgroupRemoveAnActivityFromBeginOrEnd(sbg, level, ai, ref conflActivities[newtime], ref nConflActivities[newtime], ref ai2);
#endif
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif
								if (!k)
								{
									if (level == 0)
									{
										//Liviu: inactivated from version 5.12.4 (7 Feb. 2010), because it may take too long for some files
										//cout<<"WARNING - mb - file "<<__FILE__<<" line "<<__LINE__<<endl;
									}
									okstudentsmaxgapsperweek = false;
									goto impossiblestudentsmaxgapsperweek;
								}
							}
							else //OK
							{
								break;
							}

							Debug.Assert(ai2 >= 0);

							removeAi2FromSbgTimetable(ai2);
							updateSbgNHoursGaps(sbg, c.times[ai2] % gt.rules.nDaysPerWeek);
						}
					}
			}

	impossiblestudentsmaxgapsperweek:
			if (!okstudentsmaxgapsperweek)
			{
				if (updateSubgroups || updateTeachers)
					removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

			////////////////////////////END students max gaps per week

	/////////////////////////////////////////////////////////////////////////////////////////////

			//!!!NOT PERFECT constraint, in other places may be improved, like in min/max hours daily.
			//see file fet-v.v.v/doc/algorithm/improve-studentsmaxgapsperday.txt for advice and (unstable) code on how to make students max gaps per day constraint perfect

			//not causing more than subgroupsMaxGapsPerDay students gaps

			//TODO: improve, check

		okstudentsmaxgapsperday = true;

		if (GlobalMembersGenerate_pre.haveStudentsMaxGapsPerDay)
		{

			//okstudentsmaxgapsperday=true;
			foreach (int sbg, act.iSubgroupsList) if (!GlobalMembersGenerate.skipRandom(GlobalMembersGenerate_pre.subgroupsMaxGapsPerDayPercentage[sbg]))
			{
					Debug.Assert(GlobalMembersGenerate_pre.subgroupsMaxGapsPerDayPercentage[sbg] == 100);

					//preliminary test
					int _total = 0;
					int _remnf = GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourMaxBeginnings[sbg];
					bool _haveMaxBegs = (GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourPercentage[sbg] >= 0);
					for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
					{
						_total += GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d2);
						int _g = GlobalMembersGenerate.newSubgroupsDayNGaps(sbg,d2);
						if (_haveMaxBegs)
						{
							int _fg = GlobalMembersGenerate.newSubgroupsDayNFirstGaps(sbg,d2);
							if (_fg == 0)
							{
								if (_g > GlobalMembersGenerate_pre.subgroupsMaxGapsPerDayMaxGaps[sbg])
									_total += _g - GlobalMembersGenerate_pre.subgroupsMaxGapsPerDayMaxGaps[sbg];
							}
							else if (_fg == 1)
							{
								if (_remnf > 0)
									_remnf--;
								else
									_total++;
								if (_g > GlobalMembersGenerate_pre.subgroupsMaxGapsPerDayMaxGaps[sbg])
									_total += _g - GlobalMembersGenerate_pre.subgroupsMaxGapsPerDayMaxGaps[sbg];
							}
							else if (_fg >= 2)
							{
								if (_g + _fg - 1 <= GlobalMembersGenerate_pre.subgroupsMaxGapsPerDayMaxGaps[sbg])
									_total++;
								else
								{
									if (_remnf > 0)
										_remnf--;
									else
										_total++;
									_total++;
									Debug.Assert(_g + _fg - 2 >= GlobalMembersGenerate_pre.subgroupsMaxGapsPerDayMaxGaps[sbg]);
									_total += (_g + _fg - 2 - GlobalMembersGenerate_pre.subgroupsMaxGapsPerDayMaxGaps[sbg]);
								}
							}
							else
								Debug.Assert(0);
						}
						else
						{
							if (_g > GlobalMembersGenerate_pre.subgroupsMaxGapsPerDayMaxGaps[sbg])
								_total += _g - GlobalMembersGenerate_pre.subgroupsMaxGapsPerDayMaxGaps[sbg];
						}
					}

					if (_total <= GlobalMembersGenerate_pre.nHoursPerSubgroup[sbg]) //OK
						continue;

					if (level >= GlobalMembersGenerate.LEVEL_STOP_CONFLICTS_CALCULATION)
					{
						okstudentsmaxgapsperday = false;
						goto impossiblestudentsmaxgapsperday;
					}

#if conflActivities_ConditionalDefinition1
					getSbgTimetable(sbg, GlobalMembersGenerate.conflActivitiesL[level, newtime]);
#else
					getSbgTimetable(sbg, conflActivities[newtime]);
#endif
					sbgGetNHoursGaps(sbg);

					for (;;)
					{
						int total = 0;
						int remnf = GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourMaxBeginnings[sbg];
						bool haveMaxBegs = (GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourPercentage[sbg] >= 0);
						for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
						{
							total += GlobalMembersGenerate.sbgDayNHours[d2];
							int g = GlobalMembersGenerate.sbgDayNGaps[d2];
							if (haveMaxBegs)
							{
								int fg = GlobalMembersGenerate.sbgDayNFirstGaps[d2];
								if (fg == 0)
								{
									if (g > GlobalMembersGenerate_pre.subgroupsMaxGapsPerDayMaxGaps[sbg])
										total += g - GlobalMembersGenerate_pre.subgroupsMaxGapsPerDayMaxGaps[sbg];
								}
								else if (fg == 1)
								{
									if (remnf > 0)
										remnf--;
									else
										total++;
									if (g > GlobalMembersGenerate_pre.subgroupsMaxGapsPerDayMaxGaps[sbg])
										total += g - GlobalMembersGenerate_pre.subgroupsMaxGapsPerDayMaxGaps[sbg];
								}
								else if (fg >= 2)
								{
									if (g + fg - 1 <= GlobalMembersGenerate_pre.subgroupsMaxGapsPerDayMaxGaps[sbg])
										total++;
									else
									{
										if (remnf > 0)
											remnf--;
										else
											total++;
										total++;
										Debug.Assert(g + fg - 2 >= GlobalMembersGenerate_pre.subgroupsMaxGapsPerDayMaxGaps[sbg]);
										total += (g + fg - 2 - GlobalMembersGenerate_pre.subgroupsMaxGapsPerDayMaxGaps[sbg]);
									}
								}
								else
									Debug.Assert(0);
							}
							else
							{
								if (g > GlobalMembersGenerate_pre.subgroupsMaxGapsPerDayMaxGaps[sbg])
									total += g - GlobalMembersGenerate_pre.subgroupsMaxGapsPerDayMaxGaps[sbg];
							}
						}

						if (total <= GlobalMembersGenerate_pre.nHoursPerSubgroup[sbg]) //OK
							break;

						//remove an activity from the beginning or from the end of a day
						//following code is identical to maxgapsperweek
						//remove an activity
						int ai2 = -1;

						//it should also be allowed to take from anywhere, but it is risky to change now
						if (GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourPercentage[sbg] >= 0)
						{
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
							bool k = subgroupRemoveAnActivityFromEnd(sbg, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
							bool k = subgroupRemoveAnActivityFromEnd(sbg, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref nConflActivities[newtime], ref ai2);
#endif
#else
#if nConflActivities_ConditionalDefinition1
							bool k = subgroupRemoveAnActivityFromEnd(sbg, level, ai, ref conflActivities[newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
							bool k = subgroupRemoveAnActivityFromEnd(sbg, level, ai, ref conflActivities[newtime], ref nConflActivities[newtime], ref ai2);
#endif
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif
							if (!k)
							{
								bool kk;
								if (GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourMaxBeginnings[sbg] == 0 && (GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekMaxGaps[sbg] == 0 || GlobalMembersGenerate_pre.subgroupsMaxGapsPerDayMaxGaps[sbg] == 0))
									kk = false;
								else
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
									kk = subgroupRemoveAnActivityFromBegin(sbg, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
									kk = subgroupRemoveAnActivityFromBegin(sbg, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref nConflActivities[newtime], ref ai2);
#endif
#else
#if nConflActivities_ConditionalDefinition1
									kk = subgroupRemoveAnActivityFromBegin(sbg, level, ai, ref conflActivities[newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
									kk = subgroupRemoveAnActivityFromBegin(sbg, level, ai, ref conflActivities[newtime], ref nConflActivities[newtime], ref ai2);
#endif
#endif

#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif
								if (!kk)
								{
									if (level == 0)
									{
										//Liviu: inactivated from version 5.12.4 (7 Feb. 2010), because it may take too long for some files
										//cout<<"WARNING - mb - file "<<__FILE__<<" line "<<__LINE__<<endl;
									}
									okstudentsmaxgapsperday = false;
									goto impossiblestudentsmaxgapsperday;
								}
							}
						}
						else
						{
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
							bool k = subgroupRemoveAnActivityFromBeginOrEnd(sbg, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
							bool k = subgroupRemoveAnActivityFromBeginOrEnd(sbg, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref nConflActivities[newtime], ref ai2);
#endif
#else
#if nConflActivities_ConditionalDefinition1
							bool k = subgroupRemoveAnActivityFromBeginOrEnd(sbg, level, ai, ref conflActivities[newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
							bool k = subgroupRemoveAnActivityFromBeginOrEnd(sbg, level, ai, ref conflActivities[newtime], ref nConflActivities[newtime], ref ai2);
#endif
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif
							if (!k)
							{
								if (level == 0)
								{
									//Liviu: inactivated from version 5.12.4 (7 Feb. 2010), because it may take too long for some files
									//cout<<"WARNING - mb - file "<<__FILE__<<" line "<<__LINE__<<endl;
								}
								okstudentsmaxgapsperday = false;
								goto impossiblestudentsmaxgapsperday;
							}
						}

						Debug.Assert(ai2 >= 0);

						removeAi2FromSbgTimetable(ai2);
						updateSbgNHoursGaps(sbg, c.times[ai2] % gt.rules.nDaysPerWeek);
					}
			}
		}

	impossiblestudentsmaxgapsperday:
			if (!okstudentsmaxgapsperday)
			{
				if (updateSubgroups || updateTeachers)
					removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

			////////////////////////////END max gaps per day

	/////////////////////////////////////////////////////////////////////////////////////////////

			//to be put after max gaps and early!!! because of an assert

			//allowed from students max hours daily
			//TODO: this should take care of students max gaps per day also. Very critical changes, so be very careful if you do them. Safer -> leave them as they are now.
			//see file fet-v.v.v/doc/algorithm/improve-studentsmaxgapsperday.txt for advice and (unstable) code on how to make students max gaps per day constraint perfect
			okstudentsmaxhoursdaily = true;

			foreach (int sbg, act.iSubgroupsList)
			{
				for (int count = 0; count < 2; count++)
				{
					int limitHoursDaily;
					double percentage;
					if (count == 0)
					{
						limitHoursDaily = GlobalMembersGenerate_pre.subgroupsMaxHoursDailyMaxHours1[sbg];
						percentage = GlobalMembersGenerate_pre.subgroupsMaxHoursDailyPercentages1[sbg];
					}
					else
					{
						limitHoursDaily = GlobalMembersGenerate_pre.subgroupsMaxHoursDailyMaxHours2[sbg];
						percentage = GlobalMembersGenerate_pre.subgroupsMaxHoursDailyPercentages2[sbg];
					}

					if (limitHoursDaily < 0)
						continue;

					//if(fixedTimeActivity[ai] && percentage<100.0) //added on 21 Feb. 2009 in FET 5.9.1, to solve a bug of impossible timetables for fixed timetables
					//	continue;

					bool increased;
					if (GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourPercentage[sbg] >= 0)
					{
						if (GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekPercentage[sbg] >= 0)
						{
							//both
							if (GlobalMembersGenerate.oldSubgroupsDayNHours(sbg,d) + GlobalMembersGenerate.oldSubgroupsDayNGaps(sbg,d) + GlobalMembersGenerate.oldSubgroupsDayNFirstGaps(sbg,d) < GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d) + GlobalMembersGenerate.newSubgroupsDayNGaps(sbg,d) + GlobalMembersGenerate.newSubgroupsDayNFirstGaps(sbg,d) || GlobalMembersGenerate.oldSubgroupsDayNHours(sbg,d) < GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d))
								  increased = true;
							else
								increased = false;
						}
						else
						{
							//only at beginning
							if (GlobalMembersGenerate.oldSubgroupsDayNHours(sbg,d) + GlobalMembersGenerate.oldSubgroupsDayNFirstGaps(sbg,d) < GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d) + GlobalMembersGenerate.newSubgroupsDayNFirstGaps(sbg,d) || GlobalMembersGenerate.oldSubgroupsDayNHours(sbg,d) < GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d))
								  increased = true;
							else
								increased = false;
						}
					}
					else
					{
						if (GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekPercentage[sbg] >= 0)
						{
							//only max gaps
							if (GlobalMembersGenerate.oldSubgroupsDayNHours(sbg,d) + GlobalMembersGenerate.oldSubgroupsDayNGaps(sbg,d) < GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d) + GlobalMembersGenerate.newSubgroupsDayNGaps(sbg,d) || GlobalMembersGenerate.oldSubgroupsDayNHours(sbg,d) < GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d))
								  increased = true;
							else
								increased = false;
						}
						else
						{
							//none
							if (GlobalMembersGenerate.oldSubgroupsDayNHours(sbg,d) < GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d))
								  increased = true;
							else
								increased = false;
						}
					}

					if (limitHoursDaily >= 0 && !GlobalMembersGenerate.skipRandom(percentage) && increased)
					{
						if (limitHoursDaily < act.duration)
						{
							okstudentsmaxhoursdaily = false;
							goto impossiblestudentsmaxhoursdaily;
						}

						if (GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourMaxBeginnings[sbg] == 0 && GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekMaxGaps[sbg] == 0)
						{
							  if (GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d) + GlobalMembersGenerate.newSubgroupsDayNGaps(sbg,d) + GlobalMembersGenerate.newSubgroupsDayNFirstGaps(sbg,d) > limitHoursDaily)
							  {
								  okstudentsmaxhoursdaily = false;
								goto impossiblestudentsmaxhoursdaily;
							  }
							else //OK
								continue;
						}

						//////////////////////////new
						bool _ok;
						if (GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d) > limitHoursDaily)
						{
							_ok = false; //trivially
						}
						//basically, see that the gaps are enough
						else
						{
							if (GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourPercentage[sbg] >= 0)
							{
								if (GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekPercentage[sbg] >= 0)
								{
									//both
									int rg = GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekMaxGaps[sbg] + GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourMaxBeginnings[sbg];
									for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
									{
										if (d2 != d)
										{
											int g = limitHoursDaily - GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d2);
											//TODO: if g lower than 0 make g 0
											//but with this change, speed decreases for test 25_2_2008_1.fet (private Greek sample from my80s)
											g = GlobalMembersGenerate.newSubgroupsDayNFirstGaps(sbg,d2) + GlobalMembersGenerate.newSubgroupsDayNGaps(sbg,d2) - g;
											if (g > 0)
												rg -= g;
										}
									}

									if (rg < 0)
										rg = 0;

									int hg = GlobalMembersGenerate.newSubgroupsDayNGaps(sbg,d) + GlobalMembersGenerate.newSubgroupsDayNFirstGaps(sbg,d) - rg;
									if (hg < 0)
										hg = 0;

									if (hg + GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d) > limitHoursDaily)
									{
										_ok = false;
									}
									else
										_ok = true;
								}
								else
								{
									//only max beginnings
									int lateBeginnings = 0;
									for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
									{
										if (d2 != d)
										{
											if (GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d2) >= limitHoursDaily && GlobalMembersGenerate.newSubgroupsDayNFirstGaps(sbg,d2) == 1)
												lateBeginnings++;
										}
									}

									int fg = 0; //first gaps, added hours
									int ah = 0;
									if (GlobalMembersGenerate.newSubgroupsDayNFirstGaps(sbg,d) == 0)
									{
										fg = 0;
										ah = 0;
									}
									else if (GlobalMembersGenerate.newSubgroupsDayNFirstGaps(sbg,d) == 1)
									{
										fg = 1;
										ah = 0;
										if (GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourMaxBeginnings[sbg] == 0 || (GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourMaxBeginnings[sbg] > 0 && lateBeginnings >= GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourMaxBeginnings[sbg]))
											ah += fg;

									}
									else if (GlobalMembersGenerate.newSubgroupsDayNFirstGaps(sbg,d) >= 2)
									{
										fg = 0;
										ah = 1;
									}

									if (ah + GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d) > limitHoursDaily)
									{
										_ok = false;
									}
									else
										_ok = true;
								}
							}
							else
							{
								if (GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekPercentage[sbg] >= 0)
								{
									//only max gaps
									int rg = GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekMaxGaps[sbg];
									for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
									{
										if (d2 != d)
										{
											int g = limitHoursDaily - GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d2);
											//TODO: if g lower than 0 make g 0
											//but with this change, speed decreases for test 25_2_2008_1.fet (private Greek sample from my80s)
											g = GlobalMembersGenerate.newSubgroupsDayNGaps(sbg,d2) - g;
											if (g > 0)
												rg -= g;
										}
									}

									if (rg < 0)
										rg = 0;

									int hg = GlobalMembersGenerate.newSubgroupsDayNGaps(sbg,d) - rg;
									if (hg < 0)
										hg = 0;

									if (hg + GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d) > limitHoursDaily)
									{
										_ok = false;
									}
									else
										_ok = true;
								}
								else
								{
									//none
									_ok = true;
								}
							}
						}

						/////////////////////////////

						//preliminary test
						if (_ok)
						{
							continue;
						}

						if (level >= GlobalMembersGenerate.LEVEL_STOP_CONFLICTS_CALCULATION)
						{
							okstudentsmaxhoursdaily = false;
							goto impossiblestudentsmaxhoursdaily;
						}

#if conflActivities_ConditionalDefinition1
						getSbgTimetable(sbg, GlobalMembersGenerate.conflActivitiesL[level, newtime]);
#else
						getSbgTimetable(sbg, conflActivities[newtime]);
#endif
						sbgGetNHoursGaps(sbg);

						//theoretically, it should be canTakeFromBegin = true all time and ctfAnywhere = true if max gaps per week is not 0.
						//but practically, I tried these changes and it was 30% slower for a modified german sample (with max gaps per day=1,
						//12 hours per day, removed subacts. pref. times, max hours daily 6 for students).
						bool canTakeFromBegin = (GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourMaxBeginnings[sbg] != 0); //-1 or >0
						bool canTakeFromEnd = true;
						bool canTakeFromAnywhere = (GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekMaxGaps[sbg] == -1);

						for (;;)
						{
							//////////////////////////new
							bool ok;
							if (GlobalMembersGenerate.sbgDayNHours[d] > limitHoursDaily)
							{
								ok = false;
							}
							else
							{
								if (GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourPercentage[sbg] >= 0)
								{
									if (GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekPercentage[sbg] >= 0)
									{
										//both
										int rg = GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekMaxGaps[sbg] + GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourMaxBeginnings[sbg];
										for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
										{
											if (d2 != d)
											{
												int g = limitHoursDaily - GlobalMembersGenerate.sbgDayNHours[d2];
												//TODO: if g lower than 0 make g 0
												//but with this change, speed decreases for test 25_2_2008_1.fet (private Greek sample from my80s)
												g = GlobalMembersGenerate.sbgDayNFirstGaps[d2] + GlobalMembersGenerate.sbgDayNGaps[d2] - g;
												if (g > 0)
													rg -= g;
											}
										}

										if (rg < 0)
											rg = 0;

										int hg = GlobalMembersGenerate.sbgDayNGaps[d] + GlobalMembersGenerate.sbgDayNFirstGaps[d] - rg;
										if (hg < 0)
											hg = 0;

										if (hg + GlobalMembersGenerate.sbgDayNHours[d] > limitHoursDaily)
										{
											ok = false;
										}
										else
											ok = true;
									}
									else
									{
										//only max beginnings
										int lateBeginnings = 0;
										for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
										{
											if (d2 != d)
											{
												if (GlobalMembersGenerate.sbgDayNHours[d2] >= limitHoursDaily && GlobalMembersGenerate.sbgDayNFirstGaps[d2] == 1)
													lateBeginnings++;
											}
										}

										int fg = 0; //first gaps, added hours
										int ah = 0;
										if (GlobalMembersGenerate.sbgDayNFirstGaps[d] == 0)
										{
											fg = 0;
											ah = 0;
										}
										else if (GlobalMembersGenerate.sbgDayNFirstGaps[d] == 1)
										{
											fg = 1;
											ah = 0;
											if (GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourMaxBeginnings[sbg] == 0 || (GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourMaxBeginnings[sbg] > 0 && lateBeginnings >= GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourMaxBeginnings[sbg]))
												ah += fg;

										}
										else if (GlobalMembersGenerate.sbgDayNFirstGaps[d] >= 2)
										{
											fg = 0;
											ah = 1;
										}

										if (ah + GlobalMembersGenerate.sbgDayNHours[d] > limitHoursDaily)
										{
											ok = false;
										}
										else
											ok = true;
									}
								}
								else
								{
									if (GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekPercentage[sbg] >= 0)
									{
										//only max gaps
										int rg = GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekMaxGaps[sbg];
										for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
										{
											if (d2 != d)
											{
												int g = limitHoursDaily - GlobalMembersGenerate.sbgDayNHours[d2];
												//TODO: if g lower than 0 make g 0
												//but with this change, speed decreases for test 25_2_2008_1.fet (private Greek sample from my80s)
												g = GlobalMembersGenerate.sbgDayNGaps[d2] - g;
												if (g > 0)
													rg -= g;
											}
										}

										if (rg < 0)
											rg = 0;

										int hg = GlobalMembersGenerate.sbgDayNGaps[d] - rg;
										if (hg < 0)
											hg = 0;

										if (hg + GlobalMembersGenerate.sbgDayNHours[d] > limitHoursDaily)
										{
											ok = false;
										}
										else
											ok = true;
									}
									else
									{
										//none
										ok = true;
									}
								}
							}
							/////////////////////////////

							if (ok)
							{
								break;
							}

							int ai2 = -1;

							bool kk = false;
							if (canTakeFromEnd)
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								kk = subgroupRemoveAnActivityFromEndCertainDay(sbg, d, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
								kk = subgroupRemoveAnActivityFromEndCertainDay(sbg, d, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref nConflActivities[newtime], ref ai2);
#endif
#else
#if nConflActivities_ConditionalDefinition1
								kk = subgroupRemoveAnActivityFromEndCertainDay(sbg, d, level, ai, ref conflActivities[newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
								kk = subgroupRemoveAnActivityFromEndCertainDay(sbg, d, level, ai, ref conflActivities[newtime], ref nConflActivities[newtime], ref ai2);
#endif
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif
							if (!kk)
							{
								canTakeFromEnd = false;
								bool k = false;
								if (canTakeFromBegin)
								{
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
									k = subgroupRemoveAnActivityFromBeginCertainDay(sbg, d, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
									k = subgroupRemoveAnActivityFromBeginCertainDay(sbg, d, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref nConflActivities[newtime], ref ai2);
#endif
#else
#if nConflActivities_ConditionalDefinition1
									k = subgroupRemoveAnActivityFromBeginCertainDay(sbg, d, level, ai, ref conflActivities[newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
									k = subgroupRemoveAnActivityFromBeginCertainDay(sbg, d, level, ai, ref conflActivities[newtime], ref nConflActivities[newtime], ref ai2);
#endif
#endif
									if (GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourMaxBeginnings[sbg] > 0)
										canTakeFromBegin = false;
								}
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif
								if (!k)
								{
									canTakeFromBegin = false;
									bool ka = false;
									if (canTakeFromAnywhere)
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
										ka = subgroupRemoveAnActivityFromAnywhereCertainDay(sbg, d, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
										ka = subgroupRemoveAnActivityFromAnywhereCertainDay(sbg, d, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref nConflActivities[newtime], ref ai2);
#endif
#else
#if nConflActivities_ConditionalDefinition1
										ka = subgroupRemoveAnActivityFromAnywhereCertainDay(sbg, d, level, ai, ref conflActivities[newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
										ka = subgroupRemoveAnActivityFromAnywhereCertainDay(sbg, d, level, ai, ref conflActivities[newtime], ref nConflActivities[newtime], ref ai2);
#endif
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
									Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
									Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
									Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
									Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif

									if (!ka)
									{
										if (level == 0)
										{
											/*cout<<"subgroup=="<<qPrintable(gt.rules.internalSubgroupsList[sbg]->name)<<endl;
											cout<<"d=="<<d<<endl;
											cout<<"H="<<H<<endl;
											cout<<"Timetable:"<<endl;
											for(int h2=0; h2<gt.rules.nHoursPerDay; h2++){
												for(int d2=0; d2<gt.rules.nDaysPerWeek; d2++)
													cout<<"\t"<<sbgTimetable(d2,h2)<<"\t";
												cout<<endl;
											}*/

											//this should not be displayed
											//cout<<"WARNING - file "<<__FILE__<<" line "<<__LINE__<<endl;
										}
										okstudentsmaxhoursdaily = false;
										goto impossiblestudentsmaxhoursdaily;
									}
								}
							}

							Debug.Assert(ai2 >= 0);

							removeAi2FromSbgTimetable(ai2);
							updateSbgNHoursGaps(sbg, c.times[ai2] % gt.rules.nDaysPerWeek);
						}
					}
				}
			}

	impossiblestudentsmaxhoursdaily:
			if (!okstudentsmaxhoursdaily)
			{
				if (updateSubgroups || updateTeachers)
					removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

	/////////////////////////////////////////////////////////////////////////////////////////////

			//allowed from students max hours continuously

			okstudentsmaxhourscontinuously = true;

			foreach (int sbg, act.iSubgroupsList)
			{
				for (int count = 0; count < 2; count++)
				{
					int limitHoursCont;
					double percentage;
					if (count == 0)
					{
						limitHoursCont = GlobalMembersGenerate_pre.subgroupsMaxHoursContinuouslyMaxHours1[sbg];
						percentage = GlobalMembersGenerate_pre.subgroupsMaxHoursContinuouslyPercentages1[sbg];
					}
					else
					{
						limitHoursCont = GlobalMembersGenerate_pre.subgroupsMaxHoursContinuouslyMaxHours2[sbg];
						percentage = GlobalMembersGenerate_pre.subgroupsMaxHoursContinuouslyPercentages2[sbg];
					}

					if (limitHoursCont < 0) //no constraint
						continue;

					//if(fixedTimeActivity[ai] && percentage<100.0) //added on 21 Feb. 2009 in FET 5.9.1, to solve a bug of impossible timetables for fixed timetables
					//	continue;

					bool increased;
					int h2;
					for (h2 = h; h2 < h + act.duration; h2++)
					{
						Debug.Assert(h2 < gt.rules.nHoursPerDay);
						if (GlobalMembersGenerate.subgroupsTimetable(sbg,d,h2) == -1)
							break;
					}
					if (h2 < h + act.duration)
						increased = true;
					else
						increased = false;

					QList<int> removableActs = new QList<int>();

					int nc = act.duration;
					for (h2 = h - 1; h2 >= 0; h2--)
					{
						int ai2 = GlobalMembersGenerate.subgroupsTimetable(sbg,d,h2);
						Debug.Assert(ai2 == GlobalMembersGenerate.newSubgroupsTimetable(sbg,d,h2));
						Debug.Assert(ai2 != ai);
#if conflActivities_ConditionalDefinition1
						if (ai2 >= 0 && !GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
						if (ai2 >= 0 && !conflActivities[newtime].contains(ai2))
#endif
						{
							nc++;

							if (!removableActs.contains(ai2) && !GlobalMembersGenerate_pre.fixedTimeActivity[ai2] && !GlobalMembersGenerate.swappedActivities[ai2])
								removableActs.append(ai2);
						}
						else
							break;
					}
					for (h2 = h + act.duration; h2 < gt.rules.nHoursPerDay; h2++)
					{
						int ai2 = GlobalMembersGenerate.subgroupsTimetable(sbg,d,h2);
						Debug.Assert(ai2 == GlobalMembersGenerate.newSubgroupsTimetable(sbg,d,h2));
						Debug.Assert(ai2 != ai);
#if conflActivities_ConditionalDefinition1
						if (ai2 >= 0 && !GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
						if (ai2 >= 0 && !conflActivities[newtime].contains(ai2))
#endif
						{
							nc++;

							if (!removableActs.contains(ai2) && !GlobalMembersGenerate_pre.fixedTimeActivity[ai2] && !GlobalMembersGenerate.swappedActivities[ai2])
								removableActs.append(ai2);
						}
						else
							break;
					}

					if (!increased && percentage == 100.0)
						Debug.Assert(nc <= limitHoursCont);

					if (!increased || nc <= limitHoursCont) //OK
						continue;

					Debug.Assert(limitHoursCont >= 0);

					if (!GlobalMembersGenerate.skipRandom(percentage) && increased)
					{
						if (act.duration > limitHoursCont)
						{
							okstudentsmaxhourscontinuously = false;
							goto impossiblestudentsmaxhourscontinuously;
						}

						if (level >= GlobalMembersGenerate.LEVEL_STOP_CONFLICTS_CALCULATION)
						{
							okstudentsmaxhourscontinuously = false;
							goto impossiblestudentsmaxhourscontinuously;
						}

						while (true)
						{
							if (removableActs.count() == 0)
							{
								okstudentsmaxhourscontinuously = false;
								goto impossiblestudentsmaxhourscontinuously;
							}

							int j = -1;

							if (level == 0)
							{
								int optMinWrong = GlobalMembersGenerate.INF;

								QList<int> tl = new QList<int>();

								for (int q = 0; q < removableActs.count(); q++)
								{
									int ai2 = removableActs.at(q);
									if (optMinWrong > GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]))
									{
										 optMinWrong = GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]);
									}
								}

								for (int q = 0; q < removableActs.count(); q++)
								{
									int ai2 = removableActs.at(q);
									if (optMinWrong == GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]))
										tl.append(q);
								}

								Debug.Assert(tl.size() >= 1);
								j = tl.at(GlobalMembersTimetable_defs.randomKnuth(tl.size()));

								Debug.Assert(j >= 0 && j < removableActs.count());
							}
							else
							{
								j = GlobalMembersTimetable_defs.randomKnuth(removableActs.count());
							}

							Debug.Assert(j >= 0);

							int ai2 = removableActs.at(j);

							int t = removableActs.removeAll(ai2);
							Debug.Assert(t == 1);

#if conflActivities_ConditionalDefinition1
							Debug.Assert(!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2));
#else
							Debug.Assert(!conflActivities[newtime].contains(ai2));
#endif
#if conflActivities_ConditionalDefinition1
							GlobalMembersGenerate.conflActivitiesL[level, newtime].append(ai2);
#else
							conflActivities[newtime].append(ai2);
#endif
#if nConflActivities_ConditionalDefinition1
							GlobalMembersGenerate.nConflActivitiesL[level, newtime]++;
#else
							nConflActivities[newtime]++;
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif

							////////////
							removableActs.clear();

							int nc = act.duration;
							int h2;
							for (h2 = h - 1; h2 >= 0; h2--)
							{
								int ai2 = GlobalMembersGenerate.subgroupsTimetable(sbg,d,h2);
								Debug.Assert(ai2 == GlobalMembersGenerate.newSubgroupsTimetable(sbg,d,h2));
								Debug.Assert(ai2 != ai);
#if conflActivities_ConditionalDefinition1
								if (ai2 >= 0 && !GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
								if (ai2 >= 0 && !conflActivities[newtime].contains(ai2))
#endif
								{
									nc++;

									if (!removableActs.contains(ai2) && !GlobalMembersGenerate_pre.fixedTimeActivity[ai2] && !GlobalMembersGenerate.swappedActivities[ai2])
										removableActs.append(ai2);
								}
								else
									break;
							}
							for (h2 = h + act.duration; h2 < gt.rules.nHoursPerDay; h2++)
							{
								int ai2 = GlobalMembersGenerate.subgroupsTimetable(sbg,d,h2);
								Debug.Assert(ai2 == GlobalMembersGenerate.newSubgroupsTimetable(sbg,d,h2));
								Debug.Assert(ai2 != ai);
#if conflActivities_ConditionalDefinition1
								if (ai2 >= 0 && !GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
								if (ai2 >= 0 && !conflActivities[newtime].contains(ai2))
#endif
								{
									nc++;

									if (!removableActs.contains(ai2) && !GlobalMembersGenerate_pre.fixedTimeActivity[ai2] && !GlobalMembersGenerate.swappedActivities[ai2])
										removableActs.append(ai2);
								}
								else
									break;
							}

							if (nc <= limitHoursCont) //OK
								break;
							////////////
						}
					}
				}
			}

	impossiblestudentsmaxhourscontinuously:
			if (!okstudentsmaxhourscontinuously)
			{
				if (updateSubgroups || updateTeachers)
					removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

	/////////////////////////////////////////////////////////////////////////////////////////////

			//allowed from students activity tag max hours daily

			//!!!NOT PERFECT, there is room for improvement

			okstudentsactivitytagmaxhoursdaily = true;

			if (GlobalMembersGenerate_pre.haveStudentsActivityTagMaxHoursDaily)
			{

				foreach (int sbg, act.iSubgroupsList)
				{
					for (int cnt = 0; cnt < GlobalMembersGenerate_pre.subgroupsActivityTagMaxHoursDailyMaxHours[sbg].count(); cnt++)
					{
						int activityTag = GlobalMembersGenerate_pre.subgroupsActivityTagMaxHoursDailyActivityTag[sbg].at(cnt);

						if (!gt.rules.internalActivitiesList[ai].iActivityTagsSet.contains(activityTag))
							continue;

						int limitHoursDaily = GlobalMembersGenerate_pre.subgroupsActivityTagMaxHoursDailyMaxHours[sbg].at(cnt);
						double percentage = GlobalMembersGenerate_pre.subgroupsActivityTagMaxHoursDailyPercentage[sbg].at(cnt);

						Debug.Assert(limitHoursDaily >= 0);
						Debug.Assert(percentage >= 0);
						Debug.Assert(activityTag >= 0); //&& activityTag<gt.rules.nInternalActivityTags

						//if(fixedTimeActivity[ai] && percentage<100.0) //added on 21 Feb. 2009 in FET 5.9.1, to solve a bug of impossible timetables for fixed timetables
						//	continue;

						bool increased;

						int nold = 0;
						int nnew = 0;
						///////////
						for (int h2 = 0; h2 < h; h2++)
						{
							if (GlobalMembersGenerate.newSubgroupsTimetable(sbg,d,h2) >= 0)
							{
								int ai2 = GlobalMembersGenerate.newSubgroupsTimetable(sbg,d,h2);
								Debug.Assert(ai2 >= 0 && ai2 < gt.rules.nInternalActivities);
								Activity act = gt.rules.internalActivitiesList[ai2];
								if (act.iActivityTagsSet.contains(activityTag))
								{
									nold++;
									nnew++;
								}
							}
						}
						for (int h2 = h; h2 < h + act.duration; h2++)
						{
							if (GlobalMembersGenerate.oldSubgroupsTimetable(sbg,d,h2) >= 0)
							{
								int ai2 = GlobalMembersGenerate.oldSubgroupsTimetable(sbg,d,h2);
								Debug.Assert(ai2 >= 0 && ai2 < gt.rules.nInternalActivities);
								Activity act = gt.rules.internalActivitiesList[ai2];
								if (act.iActivityTagsSet.contains(activityTag))
									nold++;
							}
						}
						for (int h2 = h; h2 < h + act.duration; h2++)
						{
							if (GlobalMembersGenerate.newSubgroupsTimetable(sbg,d,h2) >= 0)
							{
								int ai2 = GlobalMembersGenerate.newSubgroupsTimetable(sbg,d,h2);
								Debug.Assert(ai2 >= 0 && ai2 < gt.rules.nInternalActivities);
								Activity act = gt.rules.internalActivitiesList[ai2];
								if (act.iActivityTagsSet.contains(activityTag))
									nnew++;
							}
						}
						for (int h2 = h + act.duration; h2 < gt.rules.nHoursPerDay; h2++)
						{
							if (GlobalMembersGenerate.newSubgroupsTimetable(sbg,d,h2) >= 0)
							{
								int ai2 = GlobalMembersGenerate.newSubgroupsTimetable(sbg,d,h2);
								Debug.Assert(ai2 >= 0 && ai2 < gt.rules.nInternalActivities);
								Activity act = gt.rules.internalActivitiesList[ai2];
								if (act.iActivityTagsSet.contains(activityTag))
								{
									nold++;
									nnew++;
								}
							}
						}
						/////////
						if (nold < nnew)
							increased = true;
						else
							increased = false;

						if (percentage == 100.0)
							Debug.Assert(nold <= limitHoursDaily);
						if (!increased && percentage == 100.0)
							Debug.Assert(nnew <= limitHoursDaily);

						if (!increased || nnew <= limitHoursDaily) //OK
							continue;

						Debug.Assert(limitHoursDaily >= 0);

						Debug.Assert(increased);
						Debug.Assert(nnew > limitHoursDaily);
						if (!GlobalMembersGenerate.skipRandom(percentage))
						{
							if (act.duration > limitHoursDaily)
							{
								okstudentsactivitytagmaxhoursdaily = false;
								goto impossiblestudentsactivitytagmaxhoursdaily;
							}

							if (level >= GlobalMembersGenerate.LEVEL_STOP_CONFLICTS_CALCULATION)
							{
								okstudentsactivitytagmaxhoursdaily = false;
								goto impossiblestudentsactivitytagmaxhoursdaily;
							}

#if conflActivities_ConditionalDefinition1
							getSbgTimetable(sbg, GlobalMembersGenerate.conflActivitiesL[level, newtime]);
#else
							getSbgTimetable(sbg, conflActivities[newtime]);
#endif
							sbgGetNHoursGaps(sbg);

							while (true)
							{
								int ncrt = 0;
								for (int h2 = 0; h2 < gt.rules.nHoursPerDay; h2++)
								{
									if (GlobalMembersGenerate.sbgTimetable(d,h2) >= 0)
									{
										int ai2 = GlobalMembersGenerate.sbgTimetable(d,h2);
										Debug.Assert(ai2 >= 0 && ai2 < gt.rules.nInternalActivities);
										Activity act = gt.rules.internalActivitiesList[ai2];
										if (act.iActivityTagsSet.contains(activityTag))
											ncrt++;
									}
								}

								if (ncrt <= limitHoursDaily)
									break;

								int ai2 = -1;

#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								bool ke = subgroupRemoveAnActivityFromAnywhereCertainDayCertainActivityTag(sbg, d, activityTag, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
								bool ke = subgroupRemoveAnActivityFromAnywhereCertainDayCertainActivityTag(sbg, d, activityTag, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref nConflActivities[newtime], ref ai2);
#endif
#else
#if nConflActivities_ConditionalDefinition1
								bool ke = subgroupRemoveAnActivityFromAnywhereCertainDayCertainActivityTag(sbg, d, activityTag, level, ai, ref conflActivities[newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
								bool ke = subgroupRemoveAnActivityFromAnywhereCertainDayCertainActivityTag(sbg, d, activityTag, level, ai, ref conflActivities[newtime], ref nConflActivities[newtime], ref ai2);
#endif
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif

								if (!ke)
								{
									if (level == 0)
									{
										//...this is not too good, but hopefully there is no problem
									}
									okstudentsactivitytagmaxhoursdaily = false;
									goto impossiblestudentsactivitytagmaxhoursdaily;
								}

								Debug.Assert(ai2 >= 0);

								Debug.Assert(gt.rules.internalActivitiesList[ai2].iActivityTagsSet.contains(activityTag));

								removeAi2FromSbgTimetable(ai2);
								updateSbgNHoursGaps(sbg, c.times[ai2] % gt.rules.nDaysPerWeek);
							}
						}
					}
				}

			}

	impossiblestudentsactivitytagmaxhoursdaily:
			if (!okstudentsactivitytagmaxhoursdaily)
			{
				if (updateSubgroups || updateTeachers)
					removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

	/////////////////////////////////////////////////////////////////////////////////////////////

			//allowed from students activity tag max hours continuously

			okstudentsactivitytagmaxhourscontinuously = true;

			if (GlobalMembersGenerate_pre.haveStudentsActivityTagMaxHoursContinuously)
			{

				foreach (int sbg, act.iSubgroupsList)
				{
					for (int cnt = 0; cnt < GlobalMembersGenerate_pre.subgroupsActivityTagMaxHoursContinuouslyMaxHours[sbg].count(); cnt++)
					{
						int activityTag = GlobalMembersGenerate_pre.subgroupsActivityTagMaxHoursContinuouslyActivityTag[sbg].at(cnt);

						//if(gt.rules.internalActivitiesList[ai].activityTagIndex!=activityTag)
						//	continue;
						if (!gt.rules.internalActivitiesList[ai].iActivityTagsSet.contains(activityTag))
							continue;

						int limitHoursCont = GlobalMembersGenerate_pre.subgroupsActivityTagMaxHoursContinuouslyMaxHours[sbg].at(cnt);
						double percentage = GlobalMembersGenerate_pre.subgroupsActivityTagMaxHoursContinuouslyPercentage[sbg].at(cnt);

						Debug.Assert(limitHoursCont >= 0);
						Debug.Assert(percentage >= 0);
						Debug.Assert(activityTag >= 0); //&& activityTag<gt.rules.nInternalActivityTags

						//if(fixedTimeActivity[ai] && percentage<100.0) //added on 21 Feb. 2009 in FET 5.9.1, to solve a bug of impossible timetables for fixed timetables
						//	continue;

						bool increased;
						int h2;
						for (h2 = h; h2 < h + act.duration; h2++)
						{
							Debug.Assert(h2 < gt.rules.nHoursPerDay);
							if (GlobalMembersGenerate.subgroupsTimetable(sbg,d,h2) == -1)
								break;
							int ai2 = GlobalMembersGenerate.subgroupsTimetable(sbg,d,h2);
							Debug.Assert(ai2 >= 0);
							//if(gt.rules.internalActivitiesList[ai2].activityTagIndex!=activityTag)
							//	break;
							if (!gt.rules.internalActivitiesList[ai2].iActivityTagsSet.contains(activityTag))
								break;
						}
						if (h2 < h + act.duration)
							increased = true;
						else
							increased = false;

						QList<int> removableActs = new QList<int>();

						int nc = act.duration;
						for (h2 = h - 1; h2 >= 0; h2--)
						{
							int ai2 = GlobalMembersGenerate.subgroupsTimetable(sbg,d,h2);
							Debug.Assert(ai2 == GlobalMembersGenerate.newSubgroupsTimetable(sbg,d,h2));
							Debug.Assert(ai2 != ai);
							if (ai2 < 0)
								break;
#if conflActivities_ConditionalDefinition1
							 //gt.rules.internalActivitiesList[ai2].activityTagIndex==activityTag){
							if (ai2 >= 0 && !GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2) && gt.rules.internalActivitiesList[ai2].iActivityTagsSet.contains(activityTag))
#else
							if (ai2 >= 0 && !conflActivities[newtime].contains(ai2) && gt.rules.internalActivitiesList[ai2].iActivityTagsSet.contains(activityTag))
#endif
							{
								nc++;

								if (!removableActs.contains(ai2) && !GlobalMembersGenerate_pre.fixedTimeActivity[ai2] && !GlobalMembersGenerate.swappedActivities[ai2])
									removableActs.append(ai2);
							}
							else
								break;
						}
						for (h2 = h + act.duration; h2 < gt.rules.nHoursPerDay; h2++)
						{
							int ai2 = GlobalMembersGenerate.subgroupsTimetable(sbg,d,h2);
							Debug.Assert(ai2 == GlobalMembersGenerate.newSubgroupsTimetable(sbg,d,h2));
							Debug.Assert(ai2 != ai);
							if (ai2 < 0)
								break;
#if conflActivities_ConditionalDefinition1
							 //gt.rules.internalActivitiesList[ai2].activityTagIndex==activityTag){
							if (ai2 >= 0 && !GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2) && gt.rules.internalActivitiesList[ai2].iActivityTagsSet.contains(activityTag))
#else
							if (ai2 >= 0 && !conflActivities[newtime].contains(ai2) && gt.rules.internalActivitiesList[ai2].iActivityTagsSet.contains(activityTag))
#endif
							{
								nc++;

								if (!removableActs.contains(ai2) && !GlobalMembersGenerate_pre.fixedTimeActivity[ai2] && !GlobalMembersGenerate.swappedActivities[ai2])
									removableActs.append(ai2);
							}
							else
								break;
						}

						if (!increased && percentage == 100.0)
							Debug.Assert(nc <= limitHoursCont);

						if (!increased || nc <= limitHoursCont) //OK
							continue;

						Debug.Assert(limitHoursCont >= 0);

						if (!GlobalMembersGenerate.skipRandom(percentage) && increased)
						{
							if (act.duration > limitHoursCont)
							{
								okstudentsactivitytagmaxhourscontinuously = false;
								goto impossiblestudentsactivitytagmaxhourscontinuously;
							}

							if (level >= GlobalMembersGenerate.LEVEL_STOP_CONFLICTS_CALCULATION)
							{
								okstudentsactivitytagmaxhourscontinuously = false;
								goto impossiblestudentsactivitytagmaxhourscontinuously;
							}

							while (true)
							{
								if (removableActs.count() == 0)
								{
									okstudentsactivitytagmaxhourscontinuously = false;
									goto impossiblestudentsactivitytagmaxhourscontinuously;
								}

								int j = -1;

								if (level == 0)
								{
									int optMinWrong = GlobalMembersGenerate.INF;

									QList<int> tl = new QList<int>();

									for (int q = 0; q < removableActs.count(); q++)
									{
										int ai2 = removableActs.at(q);
										if (optMinWrong > GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]))
										{
											 optMinWrong = GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]);
										}
									}

									for (int q = 0; q < removableActs.count(); q++)
									{
										int ai2 = removableActs.at(q);
										if (optMinWrong == GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]))
											tl.append(q);
									}

									Debug.Assert(tl.size() >= 1);
									j = tl.at(GlobalMembersTimetable_defs.randomKnuth(tl.size()));

									Debug.Assert(j >= 0 && j < removableActs.count());
								}
								else
								{
									j = GlobalMembersTimetable_defs.randomKnuth(removableActs.count());
								}

								Debug.Assert(j >= 0);

								int ai2 = removableActs.at(j);

								int t = removableActs.removeAll(ai2);
								Debug.Assert(t == 1);

#if conflActivities_ConditionalDefinition1
								Debug.Assert(!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2));
#else
								Debug.Assert(!conflActivities[newtime].contains(ai2));
#endif
#if conflActivities_ConditionalDefinition1
								GlobalMembersGenerate.conflActivitiesL[level, newtime].append(ai2);
#else
								conflActivities[newtime].append(ai2);
#endif
#if nConflActivities_ConditionalDefinition1
								GlobalMembersGenerate.nConflActivitiesL[level, newtime]++;
#else
								nConflActivities[newtime]++;
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif

								////////////
								removableActs.clear();

								int nc = act.duration;
								int h2;
								for (h2 = h - 1; h2 >= 0; h2--)
								{
									int ai2 = GlobalMembersGenerate.subgroupsTimetable(sbg,d,h2);
									Debug.Assert(ai2 == GlobalMembersGenerate.newSubgroupsTimetable(sbg,d,h2));
									Debug.Assert(ai2 != ai);
									if (ai2 < 0)
										break;
#if conflActivities_ConditionalDefinition1
									 //gt.rules.internalActivitiesList[ai2].activityTagIndex==activityTag){
									if (ai2 >= 0 && !GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2) && gt.rules.internalActivitiesList[ai2].iActivityTagsSet.contains(activityTag))
#else
									if (ai2 >= 0 && !conflActivities[newtime].contains(ai2) && gt.rules.internalActivitiesList[ai2].iActivityTagsSet.contains(activityTag))
#endif
									{
										nc++;

										if (!removableActs.contains(ai2) && !GlobalMembersGenerate_pre.fixedTimeActivity[ai2] && !GlobalMembersGenerate.swappedActivities[ai2])
											removableActs.append(ai2);
									}
									else
										break;
								}
								for (h2 = h + act.duration; h2 < gt.rules.nHoursPerDay; h2++)
								{
									int ai2 = GlobalMembersGenerate.subgroupsTimetable(sbg,d,h2);
									Debug.Assert(ai2 == GlobalMembersGenerate.newSubgroupsTimetable(sbg,d,h2));
									Debug.Assert(ai2 != ai);
									if (ai2 < 0)
										break;
#if conflActivities_ConditionalDefinition1
									 //gt.rules.internalActivitiesList[ai2].activityTagIndex==activityTag){
									if (ai2 >= 0 && !GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2) && gt.rules.internalActivitiesList[ai2].iActivityTagsSet.contains(activityTag))
#else
									if (ai2 >= 0 && !conflActivities[newtime].contains(ai2) && gt.rules.internalActivitiesList[ai2].iActivityTagsSet.contains(activityTag))
#endif
									{
										nc++;

										if (!removableActs.contains(ai2) && !GlobalMembersGenerate_pre.fixedTimeActivity[ai2] && !GlobalMembersGenerate.swappedActivities[ai2])
											removableActs.append(ai2);
									}
									else
										break;
								}

								if (nc <= limitHoursCont) //OK
									break;
								////////////
							}
						}
					}
				}

			}

	impossiblestudentsactivitytagmaxhourscontinuously:
			if (!okstudentsactivitytagmaxhourscontinuously)
			{
				if (updateSubgroups || updateTeachers)
					removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

	/////////////////////////////////////////////////////////////////////////////////////////////

			/////////begin students min hours daily

			//TODO: this should take care of students max gaps per day also. Very critical changes, so be very careful if you do them. Safer -> leave them as they are now.
			//see file fet-v.v.v/doc/algorithm/improve-studentsmaxgapsperday.txt for advice and (unstable) code on how to make students max gaps per day constraint perfect
			okstudentsminhoursdaily = true;

			foreach (int sbg, act.iSubgroupsList)
			{
				if (GlobalMembersGenerate_pre.subgroupsMinHoursDailyMinHours[sbg] >= 0)
				{
					Debug.Assert(GlobalMembersGenerate_pre.subgroupsMinHoursDailyPercentages[sbg] == 100);

					bool allowEmptyDays = GlobalMembersGenerate_pre.subgroupsMinHoursDailyAllowEmptyDays[sbg];

					bool skip = GlobalMembersGenerate.skipRandom(GlobalMembersGenerate_pre.subgroupsMinHoursDailyPercentages[sbg]);
					if (!skip)
					{
						//preliminary test
						bool _ok;
						if (GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourPercentage[sbg] >= 0)
						{
							if (GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekPercentage[sbg] >= 0)
							{
								//both limitations
								int remG = 0;
								int totalH = 0;
								for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
								{
									int remGDay = GlobalMembersGenerate.newSubgroupsDayNFirstGaps(sbg,d2) + GlobalMembersGenerate.newSubgroupsDayNGaps(sbg,d2);
									if (!allowEmptyDays || GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d2) > 0) //1
									{
										if (GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d2) < GlobalMembersGenerate_pre.subgroupsMinHoursDailyMinHours[sbg])
										{
											remGDay -= GlobalMembersGenerate_pre.subgroupsMinHoursDailyMinHours[sbg] - GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d2);
											totalH += GlobalMembersGenerate_pre.subgroupsMinHoursDailyMinHours[sbg];
										}
										else
											totalH += GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d2);
									}
									if (remGDay > 0)
										remG += remGDay;
								}
								if ((remG + totalH <= GlobalMembersGenerate_pre.nHoursPerSubgroup[sbg] + GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourMaxBeginnings[sbg] + GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekMaxGaps[sbg]) && (totalH <= GlobalMembersGenerate_pre.nHoursPerSubgroup[sbg]))
									  _ok = true;
								else
									_ok = false;
							}
							else
							{
								//only first gaps limitation
								int remG = 0;
								int totalH = 0;
								for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
								{
									int remGDay = 0;
									if (!allowEmptyDays || GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d2) > 0) //1
									{
										if (GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d2) < GlobalMembersGenerate_pre.subgroupsMinHoursDailyMinHours[sbg])
										{
											remGDay = 0;
											totalH += GlobalMembersGenerate_pre.subgroupsMinHoursDailyMinHours[sbg];
										}
										else
										{
											totalH += GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d2);
											if (GlobalMembersGenerate.newSubgroupsDayNFirstGaps(sbg,d2) == 0)
												remGDay = 0;
											else if (GlobalMembersGenerate.newSubgroupsDayNFirstGaps(sbg,d2) == 1)
												remGDay = 1;
											else if (GlobalMembersGenerate.newSubgroupsDayNFirstGaps(sbg,d2) >= 2)
											{
												remGDay = 0;
												totalH++;
											}
										}
									}
									if (remGDay > 0)
										remG += remGDay;
								}
								if ((remG + totalH <= GlobalMembersGenerate_pre.nHoursPerSubgroup[sbg] + GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourMaxBeginnings[sbg]) && (totalH <= GlobalMembersGenerate_pre.nHoursPerSubgroup[sbg]))
									  _ok = true;
								else
									_ok = false;
							}
						}
						else
						{
							if (GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekPercentage[sbg] >= 0)
							{
								//only max gaps per week limitation
								int remG = 0;
								int totalH = 0;
								for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
								{
									int remGDay = GlobalMembersGenerate.newSubgroupsDayNGaps(sbg,d2);
									if (!allowEmptyDays || GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d2) > 0) //1
									{
										if (GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d2) < GlobalMembersGenerate_pre.subgroupsMinHoursDailyMinHours[sbg])
										{
											remGDay -= GlobalMembersGenerate_pre.subgroupsMinHoursDailyMinHours[sbg] - GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d2);
											totalH += GlobalMembersGenerate_pre.subgroupsMinHoursDailyMinHours[sbg];
										}
										else
											totalH += GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d2);
									}
									if (remGDay > 0)
										remG += remGDay;
								}
								if ((remG + totalH <= GlobalMembersGenerate_pre.nHoursPerSubgroup[sbg] + GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekMaxGaps[sbg]) && (totalH <= GlobalMembersGenerate_pre.nHoursPerSubgroup[sbg]))
									  _ok = true;
								else
									_ok = false;
							}
							else
							{
								//no limitation
								int totalH = 0;
								for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
								{
									if (!allowEmptyDays || GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d2) > 0) //1
									{
										if (GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d2) < GlobalMembersGenerate_pre.subgroupsMinHoursDailyMinHours[sbg])
											totalH += GlobalMembersGenerate_pre.subgroupsMinHoursDailyMinHours[sbg];
										else
											totalH += GlobalMembersGenerate.newSubgroupsDayNHours(sbg,d2);
									}
								}
								if (totalH <= GlobalMembersGenerate_pre.nHoursPerSubgroup[sbg])
									  _ok = true;
								else
									_ok = false;
							}
						}

						if (_ok)
							continue;

						if (level >= GlobalMembersGenerate.LEVEL_STOP_CONFLICTS_CALCULATION)
						{
							okstudentsminhoursdaily = false;
							goto impossiblestudentsminhoursdaily;
						}

#if conflActivities_ConditionalDefinition1
						getSbgTimetable(sbg, GlobalMembersGenerate.conflActivitiesL[level, newtime]);
#else
						getSbgTimetable(sbg, conflActivities[newtime]);
#endif
						sbgGetNHoursGaps(sbg);

						for (;;)
						{
							bool ok;
							////////////////////////////
							if (GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourPercentage[sbg] >= 0)
							{
								if (GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekPercentage[sbg] >= 0)
								{
									//both limitations
									int remG = 0;
									int totalH = 0;
									for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
									{
										int remGDay = GlobalMembersGenerate.sbgDayNFirstGaps[d2] + GlobalMembersGenerate.sbgDayNGaps[d2];
										if (!allowEmptyDays || GlobalMembersGenerate.sbgDayNHours[d2] > 0) //1
										{
											if (GlobalMembersGenerate.sbgDayNHours[d2] < GlobalMembersGenerate_pre.subgroupsMinHoursDailyMinHours[sbg])
											{
												remGDay -= GlobalMembersGenerate_pre.subgroupsMinHoursDailyMinHours[sbg] - GlobalMembersGenerate.sbgDayNHours[d2];
												totalH += GlobalMembersGenerate_pre.subgroupsMinHoursDailyMinHours[sbg];
											}
											else
												totalH += GlobalMembersGenerate.sbgDayNHours[d2];
										}
										if (remGDay > 0)
											remG += remGDay;
									}
									if ((remG + totalH <= GlobalMembersGenerate_pre.nHoursPerSubgroup[sbg] + GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourMaxBeginnings[sbg] + GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekMaxGaps[sbg]) && (totalH <= GlobalMembersGenerate_pre.nHoursPerSubgroup[sbg]))
										  ok = true;
									else
										ok = false;
								}
								else
								{
									//only first gaps limitation
									int remG = 0;
									int totalH = 0;
									for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
									{
										int remGDay = 0;
										if (!allowEmptyDays || GlobalMembersGenerate.sbgDayNHours[d2] > 0) //1
										{
											if (GlobalMembersGenerate.sbgDayNHours[d2] < GlobalMembersGenerate_pre.subgroupsMinHoursDailyMinHours[sbg])
											{
												remGDay = 0;
												totalH += GlobalMembersGenerate_pre.subgroupsMinHoursDailyMinHours[sbg];
											}
											else
											{
												totalH += GlobalMembersGenerate.sbgDayNHours[d2];
												if (GlobalMembersGenerate.sbgDayNFirstGaps[d2] == 0)
													remGDay = 0;
												else if (GlobalMembersGenerate.sbgDayNFirstGaps[d2] == 1)
													remGDay = 1;
												else if (GlobalMembersGenerate.sbgDayNFirstGaps[d2] >= 2)
												{
													remGDay = 0;
													totalH++;
												}
											}
										}
										if (remGDay > 0)
											remG += remGDay;
									}
									if ((remG + totalH <= GlobalMembersGenerate_pre.nHoursPerSubgroup[sbg] + GlobalMembersGenerate_pre.subgroupsEarlyMaxBeginningsAtSecondHourMaxBeginnings[sbg]) && (totalH <= GlobalMembersGenerate_pre.nHoursPerSubgroup[sbg]))
										  ok = true;
									else
										ok = false;
								}
							}
							else
							{
								if (GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekPercentage[sbg] >= 0)
								{
									//only max gaps per week limitation
									int remG = 0;
									int totalH = 0;
									for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
									{
										int remGDay = GlobalMembersGenerate.sbgDayNGaps[d2];
										if (!allowEmptyDays || GlobalMembersGenerate.sbgDayNHours[d2] > 0) //1
										{
											if (GlobalMembersGenerate.sbgDayNHours[d2] < GlobalMembersGenerate_pre.subgroupsMinHoursDailyMinHours[sbg])
											{
												remGDay -= GlobalMembersGenerate_pre.subgroupsMinHoursDailyMinHours[sbg] - GlobalMembersGenerate.sbgDayNHours[d2];
												totalH += GlobalMembersGenerate_pre.subgroupsMinHoursDailyMinHours[sbg];
											}
											else
												totalH += GlobalMembersGenerate.sbgDayNHours[d2];
										}
										if (remGDay > 0)
											remG += remGDay;
									}
									if ((remG + totalH <= GlobalMembersGenerate_pre.nHoursPerSubgroup[sbg] + GlobalMembersGenerate_pre.subgroupsMaxGapsPerWeekMaxGaps[sbg]) && (totalH <= GlobalMembersGenerate_pre.nHoursPerSubgroup[sbg]))
										  ok = true;
									else
										ok = false;
								}
								else
								{
									//no limitation
									int totalH = 0;
									for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
									{
										if (!allowEmptyDays || GlobalMembersGenerate.sbgDayNHours[d2] > 0) //1
										{
											if (GlobalMembersGenerate.sbgDayNHours[d2] < GlobalMembersGenerate_pre.subgroupsMinHoursDailyMinHours[sbg])
												totalH += GlobalMembersGenerate_pre.subgroupsMinHoursDailyMinHours[sbg];
											else
												totalH += GlobalMembersGenerate.sbgDayNHours[d2];
										}
									}
									if (totalH <= GlobalMembersGenerate_pre.nHoursPerSubgroup[sbg])
										  ok = true;
									else
										ok = false;
								}
							}
							////////////////////////////

							if (ok)
								break; //ok

							int ai2 = -1;

#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
							bool kk = subgroupRemoveAnActivityFromEnd(sbg, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
							bool kk = subgroupRemoveAnActivityFromEnd(sbg, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref nConflActivities[newtime], ref ai2);
#endif
#else
#if nConflActivities_ConditionalDefinition1
							bool kk = subgroupRemoveAnActivityFromEnd(sbg, level, ai, ref conflActivities[newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
							bool kk = subgroupRemoveAnActivityFromEnd(sbg, level, ai, ref conflActivities[newtime], ref nConflActivities[newtime], ref ai2);
#endif
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif
							if (!kk)
							{
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								bool k = subgroupRemoveAnActivityFromBegin(sbg, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
								bool k = subgroupRemoveAnActivityFromBegin(sbg, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref nConflActivities[newtime], ref ai2);
#endif
#else
#if nConflActivities_ConditionalDefinition1
								bool k = subgroupRemoveAnActivityFromBegin(sbg, level, ai, ref conflActivities[newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
								bool k = subgroupRemoveAnActivityFromBegin(sbg, level, ai, ref conflActivities[newtime], ref nConflActivities[newtime], ref ai2);
#endif
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif
								if (!k)
								{
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
									bool ka = subgroupRemoveAnActivityFromAnywhere(sbg, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
									bool ka = subgroupRemoveAnActivityFromAnywhere(sbg, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref nConflActivities[newtime], ref ai2);
#endif
#else
#if nConflActivities_ConditionalDefinition1
									bool ka = subgroupRemoveAnActivityFromAnywhere(sbg, level, ai, ref conflActivities[newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
									bool ka = subgroupRemoveAnActivityFromAnywhere(sbg, level, ai, ref conflActivities[newtime], ref nConflActivities[newtime], ref ai2);
#endif
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
									Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
									Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
									Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
									Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif

									if (!ka)
									{
										if (level == 0)
										{
											/*cout<<"d=="<<d<<", h=="<<h<<", ai=="<<ai<<endl;
											for(int h2=0; h2<gt.rules.nHoursPerDay; h2++){
												for(int d2=0; d2<gt.rules.nDaysPerWeek; d2++)
													cout<<"\t"<<sbgTimetable(d2,h2);
												cout<<endl;
											}*/

											//this should not be displayed
											//cout<<"WARNING - unlikely situation - file "<<__FILE__<<" line "<<__LINE__<<endl;
										}
										okstudentsminhoursdaily = false;
										goto impossiblestudentsminhoursdaily;
									}
								}
							}

							Debug.Assert(ai2 >= 0);

							removeAi2FromSbgTimetable(ai2);
							updateSbgNHoursGaps(sbg, c.times[ai2] % gt.rules.nDaysPerWeek);
						}
					}
				}
			}

	impossiblestudentsminhoursdaily:
			if (!okstudentsminhoursdaily)
			{
				if (updateSubgroups || updateTeachers)
					removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

			/////////end students(s) min hours daily



	/////////////////////////////////////////////////////////////////////////////////////////////


					////////////TEACHERS////////////////

	/////////////////////////////////////////////////////////////////////////////////////////////

			//not breaking the teacher max days per week constraints
			////////////////////////////BEGIN max days per week for teachers
			okteachermaxdaysperweek = true;
			//foreach(int tch, act->iTeachersList){
			foreach (int tch, GlobalMembersGenerate_pre.teachersWithMaxDaysPerWeekForActivities[ai])
			{
				if (GlobalMembersGenerate.skipRandom(GlobalMembersGenerate_pre.teachersMaxDaysPerWeekWeightPercentages[tch]))
					continue;

				int maxDays = GlobalMembersGenerate_pre.teachersMaxDaysPerWeekMaxDays[tch];
				Debug.Assert(maxDays >= 0); //the list contains real information

				//preliminary test
				int _nOc = 0;
				for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
					//if(newTeachersDayNHours(tch,d2)>0)

					//IT IS VITAL TO USE teacherActivitiesOfTheDay as a QList<int> (tch,d2)!!!!!!!
					//The order of evaluation of activities is changed,
					//with activities which were moved forward and back again
					//being put at the end.
					//If you do not follow this, you'll get impossible timetables
					//for italian sample or samples from South Africa, I am not sure which of these 2

					if (GlobalMembersGenerate.teacherActivitiesOfTheDay(tch,d2).count() > 0 || d2 == d)
						_nOc++;
				if (_nOc <= maxDays)
					continue; //OK, preliminary

				if (maxDays >= 0)
				{
					Debug.Assert(maxDays > 0);

					//getTchTimetable(tch, conflActivities[newtime]);
					//tchGetNHoursGaps(tch);

					bool[] occupiedDay = new bool[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK];
					bool[] canEmptyDay = new bool[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK];

					int[] _minWrong = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK];
					int[] _nWrong = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK];
					int[] _nConflActivities = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK];
					int[] _minIndexAct = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK];

					QList<int>[] _activitiesForDay = new QList[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK];

					for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
					{
						if (d2 == d)
							continue;

						occupiedDay[d2] = false;
						canEmptyDay[d2] = true;

						_minWrong[d2] = GlobalMembersGenerate.INF;
						_nWrong[d2] = 0;
						_nConflActivities[d2] = 0;
						_minIndexAct[d2] = gt.rules.nInternalActivities;
						_activitiesForDay[d2].clear();

						foreach (int ai2, GlobalMembersGenerate.teacherActivitiesOfTheDay(tch,d2))
						{
							if (ai2 >= 0)
							{
#if conflActivities_ConditionalDefinition1
								if (!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
								if (!conflActivities[newtime].contains(ai2))
#endif
								{
									occupiedDay[d2] = true;
									if (GlobalMembersGenerate_pre.fixedTimeActivity[ai2] || GlobalMembersGenerate.swappedActivities[ai2])
										canEmptyDay[d2] = false;
									else if (!_activitiesForDay[d2].contains(ai2))
									{
										_minWrong[d2] = min(_minWrong[d2], GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]));
										_minIndexAct[d2] = min(_minIndexAct[d2], GlobalMembersGenerate.invPermutation[ai2]);
										_nWrong[d2] += GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]);
										_nConflActivities[d2]++;
										_activitiesForDay[d2].append(ai2);
										Debug.Assert(_nConflActivities[d2] == _activitiesForDay[d2].count());
									}
								}
							}
						}

						if (!occupiedDay[d2])
							canEmptyDay[d2] = false;
					}
					occupiedDay[d] = true;
					canEmptyDay[d] = false;

					int nOc = 0;
					bool canChooseDay = false;

					for (int j = 0; j < gt.rules.nDaysPerWeek; j++)
						if (occupiedDay[j])
						{
							nOc++;
							if (canEmptyDay[j])
							{
								canChooseDay = true;
							}
						}

					if (nOc > maxDays)
					{
						Debug.Assert(nOc == maxDays + 1);

						if (!canChooseDay)
						{
							if (level == 0)
							{
								//Liviu: inactivated from version 5.12.4 (7 Feb. 2010), because it may take too long for some files
								//cout<<"WARNING - mb - file "<<__FILE__<<" line "<<__LINE__<<endl;
							}
							okteachermaxdaysperweek = false;
							goto impossibleteachermaxdaysperweek;
						}

						int d2 = -1;

						if (level != 0)
						{
							//choose random day from those with minimum number of conflicting activities
							QList<int> candidateDays = new QList<int>();

							int m = gt.rules.nInternalActivities;

							for (int kk = 0; kk < gt.rules.nDaysPerWeek; kk++)
								if (canEmptyDay[kk])
									if (m > _nConflActivities[kk])
										m = _nConflActivities[kk];

							candidateDays.clear();
							for (int kk = 0; kk < gt.rules.nDaysPerWeek; kk++)
								if (canEmptyDay[kk] && m == _nConflActivities[kk])
									candidateDays.append(kk);

							Debug.Assert(candidateDays.count() > 0);
							d2 = candidateDays.at(GlobalMembersTimetable_defs.randomKnuth(candidateDays.count()));
						}
						else //level==0
						{
							QList<int> candidateDays = new QList<int>();

							int _mW = GlobalMembersGenerate.INF;
							int _nW = GlobalMembersGenerate.INF;
							int _mCA = gt.rules.nInternalActivities;
							int _mIA = gt.rules.nInternalActivities;

							for (int kk = 0; kk < gt.rules.nDaysPerWeek; kk++)
								if (canEmptyDay[kk])
								{
									if (_mW > _minWrong[kk] || (_mW == _minWrong[kk] && _nW > _nWrong[kk]) || (_mW == _minWrong[kk] && _nW == _nWrong[kk] && _mCA > _nConflActivities[kk]) || (_mW == _minWrong[kk] && _nW == _nWrong[kk] && _mCA == _nConflActivities[kk] && _mIA > _minIndexAct[kk]))
									{
										_mW = _minWrong[kk];
										_nW = _nWrong[kk];
										_mCA = _nConflActivities[kk];
										_mIA = _minIndexAct[kk];
									}
								}

							Debug.Assert(_mW < GlobalMembersGenerate.INF);

							candidateDays.clear();
							for (int kk = 0; kk < gt.rules.nDaysPerWeek; kk++)
								if (canEmptyDay[kk] && _mW == _minWrong[kk] && _nW == _nWrong[kk] && _mCA == _nConflActivities[kk] && _mIA == _minIndexAct[kk])
									candidateDays.append(kk);

							Debug.Assert(candidateDays.count() > 0);
							d2 = candidateDays.at(GlobalMembersTimetable_defs.randomKnuth(candidateDays.count()));
						}

						Debug.Assert(d2 >= 0);

						Debug.Assert(_activitiesForDay[d2].count() > 0);

						foreach (int ai2, _activitiesForDay[d2])
						{
							Debug.Assert(ai2 != ai);
							Debug.Assert(!GlobalMembersGenerate.swappedActivities[ai2]);
							Debug.Assert(!GlobalMembersGenerate_pre.fixedTimeActivity[ai2]);
#if conflActivities_ConditionalDefinition1
							Debug.Assert(!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2));
#else
							Debug.Assert(!conflActivities[newtime].contains(ai2));
#endif
#if conflActivities_ConditionalDefinition1
							GlobalMembersGenerate.conflActivitiesL[level, newtime].append(ai2);
#else
							conflActivities[newtime].append(ai2);
#endif
#if nConflActivities_ConditionalDefinition1
							GlobalMembersGenerate.nConflActivitiesL[level, newtime]++;
#else
							nConflActivities[newtime]++;
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif
							//addConflActivity(conflActivities[newtime], nConflActivities[newtime], ai2, &gt.rules.internalActivitiesList[ai2]);
						}
					}
				}
			}
	impossibleteachermaxdaysperweek:
			if (!okteachermaxdaysperweek)
			{
				if (updateSubgroups || updateTeachers)
					removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

			////////////////////////////END max days per week

	/////////////////////////////////////////////////////////////////////////////////////////////
			//BEGIN teachers intervals max days per week

			okteachersintervalmaxdaysperweek = true;
			foreach (int tch, act.iTeachersList)
			{
				double perc = -1.0;
				for (int cnt = 0; cnt < 3; cnt++)
				{
					if (cnt == 0)
					{
						perc = GlobalMembersGenerate_pre.teachersIntervalMaxDaysPerWeekPercentages1[tch];
					}
					else if (cnt == 1)
					{
						perc = GlobalMembersGenerate_pre.teachersIntervalMaxDaysPerWeekPercentages2[tch];
					}
					else if (cnt == 2)
					{
						perc = GlobalMembersGenerate_pre.teachersIntervalMaxDaysPerWeekPercentages3[tch];
					}
					else
						Debug.Assert(0);

					if (perc >= 0)
					{
						int maxDays = -1;
						int sth = -1;
						int endh = -1;

						if (cnt == 0)
						{
							maxDays = GlobalMembersGenerate_pre.teachersIntervalMaxDaysPerWeekMaxDays1[tch];
							sth = GlobalMembersGenerate_pre.teachersIntervalMaxDaysPerWeekIntervalStart1[tch];
							endh = GlobalMembersGenerate_pre.teachersIntervalMaxDaysPerWeekIntervalEnd1[tch];
						}
						else if (cnt == 1)
						{
							maxDays = GlobalMembersGenerate_pre.teachersIntervalMaxDaysPerWeekMaxDays2[tch];
							sth = GlobalMembersGenerate_pre.teachersIntervalMaxDaysPerWeekIntervalStart2[tch];
							endh = GlobalMembersGenerate_pre.teachersIntervalMaxDaysPerWeekIntervalEnd2[tch];
						}
						else if (cnt == 2)
						{
							maxDays = GlobalMembersGenerate_pre.teachersIntervalMaxDaysPerWeekMaxDays3[tch];
							sth = GlobalMembersGenerate_pre.teachersIntervalMaxDaysPerWeekIntervalStart3[tch];
							endh = GlobalMembersGenerate_pre.teachersIntervalMaxDaysPerWeekIntervalEnd3[tch];
						}
						else
							Debug.Assert(0);

						Debug.Assert(sth >= 0 && sth < gt.rules.nHoursPerDay);
						Debug.Assert(endh > sth && endh <= gt.rules.nHoursPerDay);
						Debug.Assert(maxDays >= 0 && maxDays <= gt.rules.nDaysPerWeek);

						if (GlobalMembersGenerate.skipRandom(perc))
							continue;

						Debug.Assert(perc == 100.0);

						bool foundothers = false;
						bool foundai = false;
						for (int hh = sth; hh < endh; hh++)
						{
							if (GlobalMembersGenerate.newTeachersTimetable(tch,d,hh) == ai)
							{
								foundai = true;
							}
							else
							{
								Debug.Assert(GlobalMembersGenerate.newTeachersTimetable(tch,d,hh) == GlobalMembersGenerate.teachersTimetable(tch,d,hh));
								if (GlobalMembersGenerate.newTeachersTimetable(tch,d,hh) >= 0)
								{
#if conflActivities_ConditionalDefinition1
									if (!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(GlobalMembersGenerate.newTeachersTimetable(tch,d,hh)))
#else
									if (!conflActivities[newtime].contains(GlobalMembersGenerate.newTeachersTimetable(tch,d,hh)))
#endif
									{
										foundothers = true;
									}
								}
							}
						}
						int nrotherdays = 0;
						for (int dd = 0; dd < gt.rules.nDaysPerWeek; dd++)
						{
							if (dd != d)
							{
								for (int hh = sth; hh < endh; hh++)
								{
									Debug.Assert(GlobalMembersGenerate.newTeachersTimetable(tch,dd,hh) == GlobalMembersGenerate.teachersTimetable(tch,dd,hh));
#if conflActivities_ConditionalDefinition1
									if (GlobalMembersGenerate.newTeachersTimetable(tch,dd,hh) >= 0 && !GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(GlobalMembersGenerate.newTeachersTimetable(tch,dd,hh)))
#else
									if (GlobalMembersGenerate.newTeachersTimetable(tch,dd,hh) >= 0 && !conflActivities[newtime].contains(GlobalMembersGenerate.newTeachersTimetable(tch,dd,hh)))
#endif
									{
										nrotherdays++;
										break;
									}
								}
							}
						}
						Debug.Assert(nrotherdays <= maxDays); //if percentage==100%, then it is impossible to break this constraint
						if ((foundai && !foundothers) && nrotherdays == maxDays)
						{
							//increased above limit
							bool[] occupiedIntervalDay = new bool[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK];
							bool[] canEmptyIntervalDay = new bool[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK];

							int[] _minWrong = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK];
							int[] _nWrong = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK];
							int[] _nConflActivities = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK];
							int[] _minIndexAct = new int[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK];

							QList<int>[] _activitiesForIntervalDay = new QList[GlobalMembersTimetable_defs.MAX_DAYS_PER_WEEK];

							for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
							{
								if (d2 == d)
									continue;

								occupiedIntervalDay[d2] = false;
								canEmptyIntervalDay[d2] = true;

								_minWrong[d2] = GlobalMembersGenerate.INF;
								_nWrong[d2] = 0;
								_nConflActivities[d2] = 0;
								_minIndexAct[d2] = gt.rules.nInternalActivities;
								_activitiesForIntervalDay[d2].clear();

								for (int h2 = sth; h2 < endh; h2++)
								{
									int ai2 = GlobalMembersGenerate.teachersTimetable(tch,d2,h2);
								//foreach(int ai2, teacherActivitiesOfTheDay(tch,d2)){
									if (ai2 >= 0)
									{
#if conflActivities_ConditionalDefinition1
										if (!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
										if (!conflActivities[newtime].contains(ai2))
#endif
										{
											occupiedIntervalDay[d2] = true;
											if (GlobalMembersGenerate_pre.fixedTimeActivity[ai2] || GlobalMembersGenerate.swappedActivities[ai2])
												canEmptyIntervalDay[d2] = false;
											else if (!_activitiesForIntervalDay[d2].contains(ai2))
											{
												_minWrong[d2] = min(_minWrong[d2], GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]));
												_minIndexAct[d2] = min(_minIndexAct[d2], GlobalMembersGenerate.invPermutation[ai2]);
												_nWrong[d2] += GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]);
												_nConflActivities[d2]++;
												_activitiesForIntervalDay[d2].append(ai2);
												Debug.Assert(_nConflActivities[d2] == _activitiesForIntervalDay[d2].count());
											}
										}
									}
								}

								if (!occupiedIntervalDay[d2])
									canEmptyIntervalDay[d2] = false;
							}
							occupiedIntervalDay[d] = true;
							canEmptyIntervalDay[d] = false;

							int nOc = 0;
							bool canChooseDay = false;

							for (int j = 0; j < gt.rules.nDaysPerWeek; j++)
								if (occupiedIntervalDay[j])
								{
									nOc++;
									if (canEmptyIntervalDay[j])
									{
										canChooseDay = true;
									}
								}

							//if(nOc>maxDays){
							Debug.Assert(nOc == maxDays + 1);

							if (!canChooseDay)
							{
								if (level == 0)
								{
									//Liviu: inactivated from version 5.12.4 (7 Feb. 2010), because it may take too long for some files
									//cout<<"WARNING - mb - file "<<__FILE__<<" line "<<__LINE__<<endl;
								}
								okteachersintervalmaxdaysperweek = false;
								goto impossibleteachersintervalmaxdaysperweek;
							}

							int d2 = -1;

							if (level != 0)
							{
								//choose random day from those with minimum number of conflicting activities
								QList<int> candidateDays = new QList<int>();

								int m = gt.rules.nInternalActivities;

								for (int kk = 0; kk < gt.rules.nDaysPerWeek; kk++)
									if (canEmptyIntervalDay[kk])
										if (m > _nConflActivities[kk])
											m = _nConflActivities[kk];

								candidateDays.clear();
								for (int kk = 0; kk < gt.rules.nDaysPerWeek; kk++)
									if (canEmptyIntervalDay[kk] && m == _nConflActivities[kk])
										candidateDays.append(kk);

								Debug.Assert(candidateDays.count() > 0);
								d2 = candidateDays.at(GlobalMembersTimetable_defs.randomKnuth(candidateDays.count()));
							}
							else //level==0
							{
								QList<int> candidateDays = new QList<int>();

								int _mW = GlobalMembersGenerate.INF;
								int _nW = GlobalMembersGenerate.INF;
								int _mCA = gt.rules.nInternalActivities;
								int _mIA = gt.rules.nInternalActivities;

								for (int kk = 0; kk < gt.rules.nDaysPerWeek; kk++)
									if (canEmptyIntervalDay[kk])
									{
										if (_mW > _minWrong[kk] || (_mW == _minWrong[kk] && _nW > _nWrong[kk]) || (_mW == _minWrong[kk] && _nW == _nWrong[kk] && _mCA > _nConflActivities[kk]) || (_mW == _minWrong[kk] && _nW == _nWrong[kk] && _mCA == _nConflActivities[kk] && _mIA > _minIndexAct[kk]))
										{
											_mW = _minWrong[kk];
											_nW = _nWrong[kk];
											_mCA = _nConflActivities[kk];
											_mIA = _minIndexAct[kk];
										}
									}

								Debug.Assert(_mW < GlobalMembersGenerate.INF);

								candidateDays.clear();
								for (int kk = 0; kk < gt.rules.nDaysPerWeek; kk++)
									if (canEmptyIntervalDay[kk] && _mW == _minWrong[kk] && _nW == _nWrong[kk] && _mCA == _nConflActivities[kk] && _mIA == _minIndexAct[kk])
										candidateDays.append(kk);

								Debug.Assert(candidateDays.count() > 0);
								d2 = candidateDays.at(GlobalMembersTimetable_defs.randomKnuth(candidateDays.count()));
							}

							Debug.Assert(d2 >= 0);

							Debug.Assert(_activitiesForIntervalDay[d2].count() > 0);

							foreach (int ai2, _activitiesForIntervalDay[d2])
							{
								Debug.Assert(ai2 != ai);
								Debug.Assert(!GlobalMembersGenerate.swappedActivities[ai2]);
								Debug.Assert(!GlobalMembersGenerate_pre.fixedTimeActivity[ai2]);
#if conflActivities_ConditionalDefinition1
								Debug.Assert(!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2));
#else
								Debug.Assert(!conflActivities[newtime].contains(ai2));
#endif
#if conflActivities_ConditionalDefinition1
								GlobalMembersGenerate.conflActivitiesL[level, newtime].append(ai2);
#else
								conflActivities[newtime].append(ai2);
#endif
#if nConflActivities_ConditionalDefinition1
								GlobalMembersGenerate.nConflActivitiesL[level, newtime]++;
#else
								nConflActivities[newtime]++;
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif
								//addConflActivity(conflActivities[newtime], nConflActivities[newtime], ai2, &gt.rules.internalActivitiesList[ai2]);
							}
						}
					}
				}
			}
			//respecting teachers interval max days per week
	impossibleteachersintervalmaxdaysperweek:
			if (!okteachersintervalmaxdaysperweek)
			{
				if (updateSubgroups || updateTeachers)
					removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

			////////////////////////////END teachers interval max days per week

	/////////////////////////////////////////////////////////////////////////////////////////////

			//not causing more than teachersMaxGapsPerWeek teachers gaps
			okteachersmaxgapsperweek = true;
			foreach (int tch, act.iTeachersList) if (!GlobalMembersGenerate.skipRandom(GlobalMembersGenerate_pre.teachersMaxGapsPerWeekPercentage[tch]))
			{
					Debug.Assert(GlobalMembersGenerate_pre.teachersMaxGapsPerWeekPercentage[tch] == 100);

					//preliminary test
					int _nHours = 0;
					int _nGaps = 0;
					for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
					{
						_nHours += GlobalMembersGenerate.newTeachersDayNHours(tch,d2);
						_nGaps += GlobalMembersGenerate.newTeachersDayNGaps(tch,d2);
					}

					if (_nGaps + _nHours > GlobalMembersGenerate_pre.teachersMaxGapsPerWeekMaxGaps[tch] + GlobalMembersGenerate_pre.nHoursPerTeacher[tch])
					{

						if (level >= GlobalMembersGenerate.LEVEL_STOP_CONFLICTS_CALCULATION)
						{
							okteachersmaxgapsperweek = false;
							goto impossibleteachersmaxgapsperweek;
						}

#if conflActivities_ConditionalDefinition1
						getTchTimetable(tch, GlobalMembersGenerate.conflActivitiesL[level, newtime]);
#else
						getTchTimetable(tch, conflActivities[newtime]);
#endif
						tchGetNHoursGaps(tch);

						for (;;)
						{
							int nHours = 0;
							int nGaps = 0;
							for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
							{
								nHours += GlobalMembersGenerate.tchDayNHours[d2];
								nGaps += GlobalMembersGenerate.tchDayNGaps[d2];
							}

							int ai2 = -1;

							if (nGaps + nHours > GlobalMembersGenerate_pre.teachersMaxGapsPerWeekMaxGaps[tch] + GlobalMembersGenerate_pre.nHoursPerTeacher[tch])
							{
								//remove an activity
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								bool k = teacherRemoveAnActivityFromBeginOrEnd(tch, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
								bool k = teacherRemoveAnActivityFromBeginOrEnd(tch, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref nConflActivities[newtime], ref ai2);
#endif
#else
#if nConflActivities_ConditionalDefinition1
								bool k = teacherRemoveAnActivityFromBeginOrEnd(tch, level, ai, ref conflActivities[newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
								bool k = teacherRemoveAnActivityFromBeginOrEnd(tch, level, ai, ref conflActivities[newtime], ref nConflActivities[newtime], ref ai2);
#endif
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif
								if (!k)
								{
									if (level == 0)
									{
										//Liviu: inactivated from version 5.12.4 (7 Feb. 2010), because it may take too long for some files
										//cout<<"WARNING - mb - file "<<__FILE__<<" line "<<__LINE__<<endl;
									}
									okteachersmaxgapsperweek = false;
									goto impossibleteachersmaxgapsperweek;
								}
							}
							else //OK
							{
								break;
							}

							Debug.Assert(ai2 >= 0);

							removeAi2FromTchTimetable(ai2);
							updateTchNHoursGaps(tch, c.times[ai2] % gt.rules.nDaysPerWeek);
						}
					}
			}

	impossibleteachersmaxgapsperweek:
			if (!okteachersmaxgapsperweek)
			{
				if (updateSubgroups || updateTeachers)
					removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

			////////////////////////////END max gaps per week

	/////////////////////////////////////////////////////////////////////////////////////////////

			//not causing more than teachersMaxGapsPerDay teachers gaps
			okteachersmaxgapsperday = true;
			foreach (int tch, act.iTeachersList) if (!GlobalMembersGenerate.skipRandom(GlobalMembersGenerate_pre.teachersMaxGapsPerDayPercentage[tch]))
			{
					Debug.Assert(GlobalMembersGenerate_pre.teachersMaxGapsPerDayPercentage[tch] == 100);

					//preliminary test
					int _total = 0;
					for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
					{
						_total += GlobalMembersGenerate.newTeachersDayNHours(tch,d2);
						if (GlobalMembersGenerate_pre.teachersMaxGapsPerDayMaxGaps[tch] < GlobalMembersGenerate.newTeachersDayNGaps(tch,d2))
							_total += GlobalMembersGenerate.newTeachersDayNGaps(tch,d2) - GlobalMembersGenerate_pre.teachersMaxGapsPerDayMaxGaps[tch];
					}
					if (_total <= GlobalMembersGenerate_pre.nHoursPerTeacher[tch]) //OK
						continue;

					if (level >= GlobalMembersGenerate.LEVEL_STOP_CONFLICTS_CALCULATION)
					{
						okteachersmaxgapsperday = false;
						goto impossibleteachersmaxgapsperday;
					}

#if conflActivities_ConditionalDefinition1
					getTchTimetable(tch, GlobalMembersGenerate.conflActivitiesL[level, newtime]);
#else
					getTchTimetable(tch, conflActivities[newtime]);
#endif
					tchGetNHoursGaps(tch);

					for (;;)
					{
						int total = 0;
						for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
						{
							total += GlobalMembersGenerate.tchDayNHours[d2];
							if (GlobalMembersGenerate_pre.teachersMaxGapsPerDayMaxGaps[tch] < GlobalMembersGenerate.tchDayNGaps[d2])
								total += GlobalMembersGenerate.tchDayNGaps[d2] - GlobalMembersGenerate_pre.teachersMaxGapsPerDayMaxGaps[tch];
						}
						if (total <= GlobalMembersGenerate_pre.nHoursPerTeacher[tch]) //OK
							break;

						//remove an activity from the beginning or from the end of a day
						//following code is identical to maxgapsperweek
						//remove an activity
						int ai2 = -1;

						//it should also be allowed to take from anywhere, but it is risky to change now
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
						bool k = teacherRemoveAnActivityFromBeginOrEnd(tch, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
						bool k = teacherRemoveAnActivityFromBeginOrEnd(tch, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref nConflActivities[newtime], ref ai2);
#endif
#else
#if nConflActivities_ConditionalDefinition1
						bool k = teacherRemoveAnActivityFromBeginOrEnd(tch, level, ai, ref conflActivities[newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
						bool k = teacherRemoveAnActivityFromBeginOrEnd(tch, level, ai, ref conflActivities[newtime], ref nConflActivities[newtime], ref ai2);
#endif
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
						Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
						Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
						Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
						Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif
						if (!k)
						{
							if (level == 0)
							{
								//Liviu: inactivated from version 5.12.4 (7 Feb. 2010), because it may take too long for some files
								//cout<<"WARNING - mb - file "<<__FILE__<<" line "<<__LINE__<<endl;
							}
							okteachersmaxgapsperday = false;
							goto impossibleteachersmaxgapsperday;
						}

						Debug.Assert(ai2 >= 0);

						/*Activity* act2=&gt.rules.internalActivitiesList[ai2];
						int d2=c.times[ai2]%gt.rules.nDaysPerWeek;
						int h2=c.times[ai2]/gt.rules.nDaysPerWeek;
						
						for(int dur2=0; dur2<act2->duration; dur2++){
							assert(tchTimetable(d2,h2+dur2)==ai2);
							tchTimetable(d2,h2+dur2)=-1;
						}*/

						removeAi2FromTchTimetable(ai2);
						updateTchNHoursGaps(tch, c.times[ai2] % gt.rules.nDaysPerWeek);
					}
			}

	impossibleteachersmaxgapsperday:
			if (!okteachersmaxgapsperday)
			{
				if (updateSubgroups || updateTeachers)
					removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

			////////////////////////////END max gaps per day

	/////////////////////////////////////////////////////////////////////////////////////////////

			//allowed from teachers max hours daily

			//!!!after max gaps per week and max gaps per day

			okteachersmaxhoursdaily = true;

			foreach (int tch, act.iTeachersList)
			{
				for (int count = 0; count < 2; count++)
				{
					int limitHoursDaily;
					double percentage;
					if (count == 0)
					{
						limitHoursDaily = GlobalMembersGenerate_pre.teachersMaxHoursDailyMaxHours1[tch];
						percentage = GlobalMembersGenerate_pre.teachersMaxHoursDailyPercentages1[tch];
					}
					else
					{
						limitHoursDaily = GlobalMembersGenerate_pre.teachersMaxHoursDailyMaxHours2[tch];
						percentage = GlobalMembersGenerate_pre.teachersMaxHoursDailyPercentages2[tch];
					}

					if (limitHoursDaily < 0)
						continue;

					//if(fixedTimeActivity[ai] && percentage<100.0) //added on 21 Feb. 2009 in FET 5.9.1, to solve a bug of impossible timetables for fixed timetables
					//	continue;

					bool increased;
					if (GlobalMembersGenerate_pre.teachersMaxGapsPerWeekPercentage[tch] >= 0 || GlobalMembersGenerate_pre.teachersMaxGapsPerDayPercentage[tch] >= 0)
					{
						if (GlobalMembersGenerate.newTeachersDayNHours(tch,d) > GlobalMembersGenerate.oldTeachersDayNHours(tch,d) || GlobalMembersGenerate.newTeachersDayNHours(tch,d) + GlobalMembersGenerate.newTeachersDayNGaps(tch,d) > GlobalMembersGenerate.oldTeachersDayNHours(tch,d) + GlobalMembersGenerate.oldTeachersDayNGaps(tch,d))
							  increased = true;
						else
							increased = false;
					}
					else
					{
						if (GlobalMembersGenerate.newTeachersDayNHours(tch,d) > GlobalMembersGenerate.oldTeachersDayNHours(tch,d))
							  increased = true;
						else
							increased = false;
					}
					/*
					if(newTeachersDayNHours(tch,d) > oldTeachersDayNHours(tch,d))
					  	increased=true;
					else
						increased=false;*/

					if (limitHoursDaily >= 0 && !GlobalMembersGenerate.skipRandom(percentage) && increased)
					{
						if (limitHoursDaily < act.duration)
						{
							okteachersmaxhoursdaily = false;
							goto impossibleteachersmaxhoursdaily;
						}

						//preliminary test

						//basically, see that the gaps are enough
						bool _ok;
						if (GlobalMembersGenerate.newTeachersDayNHours(tch,d) > limitHoursDaily)
						{
							_ok = false;
						}
						else
						{
							if (GlobalMembersGenerate_pre.teachersMaxGapsPerWeekPercentage[tch] >= 0)
							{
								int rg = GlobalMembersGenerate_pre.teachersMaxGapsPerWeekMaxGaps[tch];
								for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
								{
									if (d2 != d)
									{
										int g = limitHoursDaily - GlobalMembersGenerate.newTeachersDayNHours(tch,d2);
										//TODO: if g lower than 0 make g 0
										//but with this change, speed decreases for test 25_2_2008_1.fet (private Greek sample from my80s)
										g = GlobalMembersGenerate.newTeachersDayNGaps(tch,d2) - g;
										if (g > 0)
											rg -= g;
									}
								}

								if (rg < 0)
									rg = 0;

								if (GlobalMembersGenerate_pre.teachersMaxGapsPerDayPercentage[tch] >= 0)
									if (rg > GlobalMembersGenerate_pre.teachersMaxGapsPerDayMaxGaps[tch])
										rg = GlobalMembersGenerate_pre.teachersMaxGapsPerDayMaxGaps[tch];

								int hg = GlobalMembersGenerate.newTeachersDayNGaps(tch,d) - rg;
								if (hg < 0)
									hg = 0;

								if (hg + GlobalMembersGenerate.newTeachersDayNHours(tch,d) > limitHoursDaily)
								{
									_ok = false;
								}
								else
									_ok = true;
							}
							else
							{
								int rg = GlobalMembersGenerate.newTeachersDayNGaps(tch,d);
								int hg = rg;
								if (GlobalMembersGenerate_pre.teachersMaxGapsPerDayPercentage[tch] >= 0)
									if (rg > GlobalMembersGenerate_pre.teachersMaxGapsPerDayMaxGaps[tch])
										rg = GlobalMembersGenerate_pre.teachersMaxGapsPerDayMaxGaps[tch];
								hg -= rg;
								if (hg + GlobalMembersGenerate.newTeachersDayNHours(tch,d) > limitHoursDaily)
									_ok = false;
								else
									_ok = true;
							}
						}

						if (_ok)
						{
							continue;
						}

						if (level >= GlobalMembersGenerate.LEVEL_STOP_CONFLICTS_CALCULATION)
						{
							okteachersmaxhoursdaily = false;
							goto impossibleteachersmaxhoursdaily;
						}

#if conflActivities_ConditionalDefinition1
						getTchTimetable(tch, GlobalMembersGenerate.conflActivitiesL[level, newtime]);
#else
						getTchTimetable(tch, conflActivities[newtime]);
#endif
						tchGetNHoursGaps(tch);

						for (;;)
						{
							//basically, see that the gaps are enough
							bool ok;
							if (GlobalMembersGenerate.tchDayNHours[d] > limitHoursDaily)
							{
								ok = false;
							}
							else
							{
								if (GlobalMembersGenerate_pre.teachersMaxGapsPerWeekPercentage[tch] >= 0)
								{
									int rg = GlobalMembersGenerate_pre.teachersMaxGapsPerWeekMaxGaps[tch];
									for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
									{
										if (d2 != d)
										{
											int g = limitHoursDaily - GlobalMembersGenerate.tchDayNHours[d2];
											//TODO: if g lower than 0 make g 0
											//but with this change, speed decreases for test 25_2_2008_1.fet (private Greek sample from my80s)
											g = GlobalMembersGenerate.tchDayNGaps[d2] - g;
											if (g > 0)
												rg -= g;
										}
									}

									if (rg < 0)
										rg = 0;

									if (GlobalMembersGenerate_pre.teachersMaxGapsPerDayPercentage[tch] >= 0)
										if (rg > GlobalMembersGenerate_pre.teachersMaxGapsPerDayMaxGaps[tch])
											rg = GlobalMembersGenerate_pre.teachersMaxGapsPerDayMaxGaps[tch];

									int hg = GlobalMembersGenerate.tchDayNGaps[d] - rg;
									if (hg < 0)
										hg = 0;

									if (hg + GlobalMembersGenerate.tchDayNHours[d] > limitHoursDaily)
									{
										ok = false;
									}
									else
										ok = true;
								}
								else
								{
									int rg = GlobalMembersGenerate.tchDayNGaps[d];
									int hg = rg;
									if (GlobalMembersGenerate_pre.teachersMaxGapsPerDayPercentage[tch] >= 0)
										if (rg > GlobalMembersGenerate_pre.teachersMaxGapsPerDayMaxGaps[tch])
											rg = GlobalMembersGenerate_pre.teachersMaxGapsPerDayMaxGaps[tch];
									hg -= rg;
									if (hg + GlobalMembersGenerate.tchDayNHours[d] > limitHoursDaily)
										ok = false;
									else
										ok = true;
								}
							}

							if (ok)
							{
								break;
							}

							int ai2 = -1;

#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
							bool k = teacherRemoveAnActivityFromBeginOrEndCertainDay(tch, d, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
							bool k = teacherRemoveAnActivityFromBeginOrEndCertainDay(tch, d, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref nConflActivities[newtime], ref ai2);
#endif
#else
#if nConflActivities_ConditionalDefinition1
							bool k = teacherRemoveAnActivityFromBeginOrEndCertainDay(tch, d, level, ai, ref conflActivities[newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
							bool k = teacherRemoveAnActivityFromBeginOrEndCertainDay(tch, d, level, ai, ref conflActivities[newtime], ref nConflActivities[newtime], ref ai2);
#endif
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif
							if (!k)
							{
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								bool ka = teacherRemoveAnActivityFromAnywhereCertainDay(tch, d, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
								bool ka = teacherRemoveAnActivityFromAnywhereCertainDay(tch, d, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref nConflActivities[newtime], ref ai2);
#endif
#else
#if nConflActivities_ConditionalDefinition1
								bool ka = teacherRemoveAnActivityFromAnywhereCertainDay(tch, d, level, ai, ref conflActivities[newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
								bool ka = teacherRemoveAnActivityFromAnywhereCertainDay(tch, d, level, ai, ref conflActivities[newtime], ref nConflActivities[newtime], ref ai2);
#endif
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif

								if (!ka)
								{
									if (level == 0)
									{
										/*cout<<"d=="<<d<<", h=="<<h<<", teacher=="<<qPrintable(gt.rules.internalTeachersList[tch]->name);
										cout<<", ai=="<<ai<<endl;
										for(int h2=0; h2<gt.rules.nHoursPerDay; h2++){
											for(int d2=0; d2<gt.rules.nDaysPerWeek; d2++)
												cout<<"\t"<<tchTimetable(d2,h2)<<"\t";
											cout<<endl;
										}
										
										cout<<endl;
										for(int h2=0; h2<gt.rules.nHoursPerDay; h2++){
											for(int d2=0; d2<gt.rules.nDaysPerWeek; d2++)
												cout<<"\t"<<newTeachersTimetable(tch,d2,h2)<<"\t";
											cout<<endl;
										}*/

										//Liviu: inactivated from version 5.12.4 (7 Feb. 2010), because it may take too long for some files
										//cout<<"WARNING - mb - file "<<__FILE__<<" line "<<__LINE__<<endl;
									}
									okteachersmaxhoursdaily = false;
									goto impossibleteachersmaxhoursdaily;
								}
							}

							Debug.Assert(ai2 >= 0);

							removeAi2FromTchTimetable(ai2);
							updateTchNHoursGaps(tch, c.times[ai2] % gt.rules.nDaysPerWeek);
						}
					}
				}
			}

	impossibleteachersmaxhoursdaily:
			if (!okteachersmaxhoursdaily)
			{
				if (updateSubgroups || updateTeachers)
					removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

	/////////////////////////////////////////////////////////////////////////////////////////////

			//allowed from teachers max hours continuously

			okteachersmaxhourscontinuously = true;

			foreach (int tch, act.iTeachersList)
			{
				for (int count = 0; count < 2; count++)
				{
					int limitHoursCont;
					double percentage;
					if (count == 0)
					{
						limitHoursCont = GlobalMembersGenerate_pre.teachersMaxHoursContinuouslyMaxHours1[tch];
						percentage = GlobalMembersGenerate_pre.teachersMaxHoursContinuouslyPercentages1[tch];
					}
					else
					{
						limitHoursCont = GlobalMembersGenerate_pre.teachersMaxHoursContinuouslyMaxHours2[tch];
						percentage = GlobalMembersGenerate_pre.teachersMaxHoursContinuouslyPercentages2[tch];
					}

					if (limitHoursCont < 0) //no constraint
						continue;

					//if(fixedTimeActivity[ai] && percentage<100.0) //added on 21 Feb. 2009 in FET 5.9.1, to solve a bug of impossible timetables for fixed timetables
					//	continue;

					bool increased;
					int h2;
					for (h2 = h; h2 < h + act.duration; h2++)
					{
						Debug.Assert(h2 < gt.rules.nHoursPerDay);
						if (GlobalMembersGenerate.teachersTimetable(tch,d,h2) == -1)
							break;
					}
					if (h2 < h + act.duration)
						increased = true;
					else
						increased = false;

					QList<int> removableActs = new QList<int>();

					int nc = act.duration;
					for (h2 = h - 1; h2 >= 0; h2--)
					{
						int ai2 = GlobalMembersGenerate.teachersTimetable(tch,d,h2);
						Debug.Assert(ai2 == GlobalMembersGenerate.newTeachersTimetable(tch,d,h2));
						Debug.Assert(ai2 != ai);
#if conflActivities_ConditionalDefinition1
						if (ai2 >= 0 && !GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
						if (ai2 >= 0 && !conflActivities[newtime].contains(ai2))
#endif
						{
							nc++;

							if (!removableActs.contains(ai2) && !GlobalMembersGenerate_pre.fixedTimeActivity[ai2] && !GlobalMembersGenerate.swappedActivities[ai2])
								removableActs.append(ai2);
						}
						else
							break;
					}
					for (h2 = h + act.duration; h2 < gt.rules.nHoursPerDay; h2++)
					{
						int ai2 = GlobalMembersGenerate.teachersTimetable(tch,d,h2);
						/*if(ai2!=newTeachersTimetable(tch,d,h2)){
							cout<<"ai=="<<ai<<", d=="<<d<<", h=="<<h<<endl;
							cout<<"teachersTimetable(tch,d,h2)=="<<teachersTimetable(tch,d,h2)<<endl;
							cout<<"newTeachersTimetable(tch,d,h2)=="<<newTeachersTimetable(tch,d,h2)<<endl;
						}*/
						Debug.Assert(ai2 == GlobalMembersGenerate.newTeachersTimetable(tch,d,h2));
						Debug.Assert(ai2 != ai);
#if conflActivities_ConditionalDefinition1
						if (ai2 >= 0 && !GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
						if (ai2 >= 0 && !conflActivities[newtime].contains(ai2))
#endif
						{
							nc++;

							if (!removableActs.contains(ai2) && !GlobalMembersGenerate_pre.fixedTimeActivity[ai2] && !GlobalMembersGenerate.swappedActivities[ai2])
								removableActs.append(ai2);
						}
						else
							break;
					}

					if (!increased && percentage == 100.0)
						Debug.Assert(nc <= limitHoursCont);

					if (!increased || nc <= limitHoursCont) //OK
						continue;

					Debug.Assert(limitHoursCont >= 0);

					if (!GlobalMembersGenerate.skipRandom(percentage) && increased)
					{
						if (act.duration > limitHoursCont)
						{
							okteachersmaxhourscontinuously = false;
							goto impossibleteachersmaxhourscontinuously;
						}

						if (level >= GlobalMembersGenerate.LEVEL_STOP_CONFLICTS_CALCULATION)
						{
							okteachersmaxhourscontinuously = false;
							goto impossibleteachersmaxhourscontinuously;
						}

						while (true)
						{
							if (removableActs.count() == 0)
							{
								okteachersmaxhourscontinuously = false;
								goto impossibleteachersmaxhourscontinuously;
							}

							int j = -1;

							if (level == 0)
							{
								int optMinWrong = GlobalMembersGenerate.INF;

								QList<int> tl = new QList<int>();

								for (int q = 0; q < removableActs.count(); q++)
								{
									int ai2 = removableActs.at(q);
									if (optMinWrong > GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]))
									{
										 optMinWrong = GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]);
									}
								}

								for (int q = 0; q < removableActs.count(); q++)
								{
									int ai2 = removableActs.at(q);
									if (optMinWrong == GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]))
										tl.append(q);
								}

								Debug.Assert(tl.size() >= 1);
								j = tl.at(GlobalMembersTimetable_defs.randomKnuth(tl.size()));

								Debug.Assert(j >= 0 && j < removableActs.count());
							}
							else
							{
								j = GlobalMembersTimetable_defs.randomKnuth(removableActs.count());
							}

							Debug.Assert(j >= 0);

							int ai2 = removableActs.at(j);

							int t = removableActs.removeAll(ai2);
							Debug.Assert(t == 1);

#if conflActivities_ConditionalDefinition1
							Debug.Assert(!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2));
#else
							Debug.Assert(!conflActivities[newtime].contains(ai2));
#endif
#if conflActivities_ConditionalDefinition1
							GlobalMembersGenerate.conflActivitiesL[level, newtime].append(ai2);
#else
							conflActivities[newtime].append(ai2);
#endif
#if nConflActivities_ConditionalDefinition1
							GlobalMembersGenerate.nConflActivitiesL[level, newtime]++;
#else
							nConflActivities[newtime]++;
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif

							////////////
							removableActs.clear();

							int nc = act.duration;
							int h2;
							for (h2 = h - 1; h2 >= 0; h2--)
							{
								int ai2 = GlobalMembersGenerate.teachersTimetable(tch,d,h2);
								Debug.Assert(ai2 == GlobalMembersGenerate.newTeachersTimetable(tch,d,h2));
								Debug.Assert(ai2 != ai);
#if conflActivities_ConditionalDefinition1
								if (ai2 >= 0 && !GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
								if (ai2 >= 0 && !conflActivities[newtime].contains(ai2))
#endif
								{
									nc++;

									if (!removableActs.contains(ai2) && !GlobalMembersGenerate_pre.fixedTimeActivity[ai2] && !GlobalMembersGenerate.swappedActivities[ai2])
										removableActs.append(ai2);
								}
								else
									break;
							}
							for (h2 = h + act.duration; h2 < gt.rules.nHoursPerDay; h2++)
							{
								int ai2 = GlobalMembersGenerate.teachersTimetable(tch,d,h2);
								Debug.Assert(ai2 == GlobalMembersGenerate.newTeachersTimetable(tch,d,h2));
								Debug.Assert(ai2 != ai);
#if conflActivities_ConditionalDefinition1
								if (ai2 >= 0 && !GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
								if (ai2 >= 0 && !conflActivities[newtime].contains(ai2))
#endif
								{
									nc++;

									if (!removableActs.contains(ai2) && !GlobalMembersGenerate_pre.fixedTimeActivity[ai2] && !GlobalMembersGenerate.swappedActivities[ai2])
										removableActs.append(ai2);
								}
								else
									break;
							}

							if (nc <= limitHoursCont) //OK
								break;
							////////////
						}
					}
				}
			}

	impossibleteachersmaxhourscontinuously:
			if (!okteachersmaxhourscontinuously)
			{
				if (updateSubgroups || updateTeachers)
					removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

	/////////////////////////////////////////////////////////////////////////////////////////////

			//allowed from teachers activity tag max hours daily

			//!!!NOT PERFECT, there is room for improvement

			okteachersactivitytagmaxhoursdaily = true;

			if (GlobalMembersGenerate_pre.haveTeachersActivityTagMaxHoursDaily)
			{

				foreach (int tch, act.iTeachersList)
				{
					for (int cnt = 0; cnt < GlobalMembersGenerate_pre.teachersActivityTagMaxHoursDailyMaxHours[tch].count(); cnt++)
					{
						int activityTag = GlobalMembersGenerate_pre.teachersActivityTagMaxHoursDailyActivityTag[tch].at(cnt);

						if (!gt.rules.internalActivitiesList[ai].iActivityTagsSet.contains(activityTag))
							continue;

						int limitHoursDaily = GlobalMembersGenerate_pre.teachersActivityTagMaxHoursDailyMaxHours[tch].at(cnt);
						double percentage = GlobalMembersGenerate_pre.teachersActivityTagMaxHoursDailyPercentage[tch].at(cnt);

						Debug.Assert(limitHoursDaily >= 0);
						Debug.Assert(percentage >= 0);
						Debug.Assert(activityTag >= 0); //&& activityTag<gt.rules.nInternalActivityTags

						//if(fixedTimeActivity[ai] && percentage<100.0) //added on 21 Feb. 2009 in FET 5.9.1, to solve a bug of impossible timetables for fixed timetables
						//	continue;

						bool increased;

						int nold = 0;
						int nnew = 0;
						///////////
						for (int h2 = 0; h2 < h; h2++)
						{
							if (GlobalMembersGenerate.newTeachersTimetable(tch,d,h2) >= 0)
							{
								int ai2 = GlobalMembersGenerate.newTeachersTimetable(tch,d,h2);
								Debug.Assert(ai2 >= 0 && ai2 < gt.rules.nInternalActivities);
								Activity act = gt.rules.internalActivitiesList[ai2];
								if (act.iActivityTagsSet.contains(activityTag))
								{
									nold++;
									nnew++;
								}
							}
						}
						for (int h2 = h; h2 < h + act.duration; h2++)
						{
							if (GlobalMembersGenerate.oldTeachersTimetable(tch,d,h2) >= 0)
							{
								int ai2 = GlobalMembersGenerate.oldTeachersTimetable(tch,d,h2);
								Debug.Assert(ai2 >= 0 && ai2 < gt.rules.nInternalActivities);
								Activity act = gt.rules.internalActivitiesList[ai2];
								if (act.iActivityTagsSet.contains(activityTag))
									nold++;
							}
						}
						for (int h2 = h; h2 < h + act.duration; h2++)
						{
							if (GlobalMembersGenerate.newTeachersTimetable(tch,d,h2) >= 0)
							{
								int ai2 = GlobalMembersGenerate.newTeachersTimetable(tch,d,h2);
								Debug.Assert(ai2 >= 0 && ai2 < gt.rules.nInternalActivities);
								Activity act = gt.rules.internalActivitiesList[ai2];
								if (act.iActivityTagsSet.contains(activityTag))
									nnew++;
							}
						}
						for (int h2 = h + act.duration; h2 < gt.rules.nHoursPerDay; h2++)
						{
							if (GlobalMembersGenerate.newTeachersTimetable(tch,d,h2) >= 0)
							{
								int ai2 = GlobalMembersGenerate.newTeachersTimetable(tch,d,h2);
								Debug.Assert(ai2 >= 0 && ai2 < gt.rules.nInternalActivities);
								Activity act = gt.rules.internalActivitiesList[ai2];
								if (act.iActivityTagsSet.contains(activityTag))
								{
									nold++;
									nnew++;
								}
							}
						}
						/////////
						if (nold < nnew)
							increased = true;
						else
							increased = false;

						if (percentage == 100.0)
							Debug.Assert(nold <= limitHoursDaily);
						if (!increased && percentage == 100.0)
							Debug.Assert(nnew <= limitHoursDaily);

						if (!increased || nnew <= limitHoursDaily) //OK
							continue;

						Debug.Assert(limitHoursDaily >= 0);

						Debug.Assert(increased);
						Debug.Assert(nnew > limitHoursDaily);
						if (!GlobalMembersGenerate.skipRandom(percentage))
						{
							if (act.duration > limitHoursDaily)
							{
								okteachersactivitytagmaxhoursdaily = false;
								goto impossibleteachersactivitytagmaxhoursdaily;
							}

							if (level >= GlobalMembersGenerate.LEVEL_STOP_CONFLICTS_CALCULATION)
							{
								okteachersactivitytagmaxhoursdaily = false;
								goto impossibleteachersactivitytagmaxhoursdaily;
							}

#if conflActivities_ConditionalDefinition1
							getTchTimetable(tch, GlobalMembersGenerate.conflActivitiesL[level, newtime]);
#else
							getTchTimetable(tch, conflActivities[newtime]);
#endif
							tchGetNHoursGaps(tch);

							while (true)
							{
								int ncrt = 0;
								for (int h2 = 0; h2 < gt.rules.nHoursPerDay; h2++)
								{
									if (GlobalMembersGenerate.tchTimetable(d,h2) >= 0)
									{
										int ai2 = GlobalMembersGenerate.tchTimetable(d,h2);
										Debug.Assert(ai2 >= 0 && ai2 < gt.rules.nInternalActivities);
										Activity act = gt.rules.internalActivitiesList[ai2];
										if (act.iActivityTagsSet.contains(activityTag))
											ncrt++;
									}
								}

								if (ncrt <= limitHoursDaily)
									break;

								int ai2 = -1;

#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								bool ke = teacherRemoveAnActivityFromAnywhereCertainDayCertainActivityTag(tch, d, activityTag, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
								bool ke = teacherRemoveAnActivityFromAnywhereCertainDayCertainActivityTag(tch, d, activityTag, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref nConflActivities[newtime], ref ai2);
#endif
#else
#if nConflActivities_ConditionalDefinition1
								bool ke = teacherRemoveAnActivityFromAnywhereCertainDayCertainActivityTag(tch, d, activityTag, level, ai, ref conflActivities[newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
								bool ke = teacherRemoveAnActivityFromAnywhereCertainDayCertainActivityTag(tch, d, activityTag, level, ai, ref conflActivities[newtime], ref nConflActivities[newtime], ref ai2);
#endif
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif

								if (!ke)
								{
									if (level == 0)
									{
										//...this is not too good, but hopefully there is no problem
									}
									okteachersactivitytagmaxhoursdaily = false;
									goto impossibleteachersactivitytagmaxhoursdaily;
								}

								Debug.Assert(ai2 >= 0);

								Debug.Assert(gt.rules.internalActivitiesList[ai2].iActivityTagsSet.contains(activityTag));

								removeAi2FromTchTimetable(ai2);
								updateTchNHoursGaps(tch, c.times[ai2] % gt.rules.nDaysPerWeek);
							}
						}
					}
				}

			}

	impossibleteachersactivitytagmaxhoursdaily:
			if (!okteachersactivitytagmaxhoursdaily)
			{
				if (updateSubgroups || updateTeachers)
					removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

	/////////////////////////////////////////////////////////////////////////////////////////////

			//allowed from teachers activity tag max hours continuously
			okteachersactivitytagmaxhourscontinuously = true;

			if (GlobalMembersGenerate_pre.haveTeachersActivityTagMaxHoursContinuously)
			{

				foreach (int tch, act.iTeachersList)
				{
					for (int cnt = 0; cnt < GlobalMembersGenerate_pre.teachersActivityTagMaxHoursContinuouslyMaxHours[tch].count(); cnt++)
					{
						int activityTag = GlobalMembersGenerate_pre.teachersActivityTagMaxHoursContinuouslyActivityTag[tch].at(cnt);

						//if(gt.rules.internalActivitiesList[ai].activityTagIndex!=activityTag)
						//	continue;
						if (!gt.rules.internalActivitiesList[ai].iActivityTagsSet.contains(activityTag))
							continue;

						int limitHoursCont = GlobalMembersGenerate_pre.teachersActivityTagMaxHoursContinuouslyMaxHours[tch].at(cnt);
						double percentage = GlobalMembersGenerate_pre.teachersActivityTagMaxHoursContinuouslyPercentage[tch].at(cnt);

						Debug.Assert(limitHoursCont >= 0);
						Debug.Assert(percentage >= 0);
						Debug.Assert(activityTag >= 0); // && activityTag<gt.rules.nInternalActivityTags

						//if(fixedTimeActivity[ai] && percentage<100.0) //added on 21 Feb. 2009 in FET 5.9.1, to solve a bug of impossible timetables for fixed timetables
						//	continue;

						bool increased;
						int h2;
						for (h2 = h; h2 < h + act.duration; h2++)
						{
							Debug.Assert(h2 < gt.rules.nHoursPerDay);
							if (GlobalMembersGenerate.teachersTimetable(tch,d,h2) == -1)
								break;
							int ai2 = GlobalMembersGenerate.teachersTimetable(tch,d,h2);
							//if(gt.rules.internalActivitiesList[ai2].activityTagIndex!=activityTag)
							//	break;
							if (!gt.rules.internalActivitiesList[ai2].iActivityTagsSet.contains(activityTag))
								break;
						}
						if (h2 < h + act.duration)
							increased = true;
						else
							increased = false;

						QList<int> removableActs = new QList<int>();

						int nc = act.duration;
						for (h2 = h - 1; h2 >= 0; h2--)
						{
							int ai2 = GlobalMembersGenerate.teachersTimetable(tch,d,h2);
							Debug.Assert(ai2 == GlobalMembersGenerate.newTeachersTimetable(tch,d,h2));
							Debug.Assert(ai2 != ai);
							if (ai2 < 0)
								break;
#if conflActivities_ConditionalDefinition1
							 //gt.rules.internalActivitiesList[ai2].activityTagIndex==activityTag){
							if (ai2 >= 0 && !GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2) && gt.rules.internalActivitiesList[ai2].iActivityTagsSet.contains(activityTag))
#else
							if (ai2 >= 0 && !conflActivities[newtime].contains(ai2) && gt.rules.internalActivitiesList[ai2].iActivityTagsSet.contains(activityTag))
#endif
							{
								nc++;

								if (!removableActs.contains(ai2) && !GlobalMembersGenerate_pre.fixedTimeActivity[ai2] && !GlobalMembersGenerate.swappedActivities[ai2])
									removableActs.append(ai2);
							}
							else
								break;
						}
						for (h2 = h + act.duration; h2 < gt.rules.nHoursPerDay; h2++)
						{
							int ai2 = GlobalMembersGenerate.teachersTimetable(tch,d,h2);
							Debug.Assert(ai2 == GlobalMembersGenerate.newTeachersTimetable(tch,d,h2));
							Debug.Assert(ai2 != ai);
							if (ai2 < 0)
								break;
#if conflActivities_ConditionalDefinition1
							 //gt.rules.internalActivitiesList[ai2].activityTagIndex==activityTag){
							if (ai2 >= 0 && !GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2) && gt.rules.internalActivitiesList[ai2].iActivityTagsSet.contains(activityTag))
#else
							if (ai2 >= 0 && !conflActivities[newtime].contains(ai2) && gt.rules.internalActivitiesList[ai2].iActivityTagsSet.contains(activityTag))
#endif
							{
								nc++;

								if (!removableActs.contains(ai2) && !GlobalMembersGenerate_pre.fixedTimeActivity[ai2] && !GlobalMembersGenerate.swappedActivities[ai2])
									removableActs.append(ai2);
							}
							else
								break;
						}

						if (!increased && percentage == 100.0)
							Debug.Assert(nc <= limitHoursCont);

						if (!increased || nc <= limitHoursCont) //OK
							continue;

						Debug.Assert(limitHoursCont >= 0);

						if (!GlobalMembersGenerate.skipRandom(percentage) && increased)
						{
							if (act.duration > limitHoursCont)
							{
								okteachersactivitytagmaxhourscontinuously = false;
								goto impossibleteachersactivitytagmaxhourscontinuously;
							}

							if (level >= GlobalMembersGenerate.LEVEL_STOP_CONFLICTS_CALCULATION)
							{
								okteachersactivitytagmaxhourscontinuously = false;
								goto impossibleteachersactivitytagmaxhourscontinuously;
							}

							while (true)
							{
								if (removableActs.count() == 0)
								{
									okteachersactivitytagmaxhourscontinuously = false;
									goto impossibleteachersactivitytagmaxhourscontinuously;
								}

								int j = -1;

								if (level == 0)
								{
									int optMinWrong = GlobalMembersGenerate.INF;

									QList<int> tl = new QList<int>();

									for (int q = 0; q < removableActs.count(); q++)
									{
										int ai2 = removableActs.at(q);
										if (optMinWrong > GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]))
										{
											 optMinWrong = GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]);
										}
									}

									for (int q = 0; q < removableActs.count(); q++)
									{
										int ai2 = removableActs.at(q);
										if (optMinWrong == GlobalMembersGenerate.triedRemovals(ai2,c.times[ai2]))
											tl.append(q);
									}

									Debug.Assert(tl.size() >= 1);
									j = tl.at(GlobalMembersTimetable_defs.randomKnuth(tl.size()));

									Debug.Assert(j >= 0 && j < removableActs.count());
								}
								else
								{
									j = GlobalMembersTimetable_defs.randomKnuth(removableActs.count());
								}

								Debug.Assert(j >= 0);

								int ai2 = removableActs.at(j);

								int t = removableActs.removeAll(ai2);
								Debug.Assert(t == 1);

#if conflActivities_ConditionalDefinition1
								Debug.Assert(!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2));
#else
								Debug.Assert(!conflActivities[newtime].contains(ai2));
#endif
#if conflActivities_ConditionalDefinition1
								GlobalMembersGenerate.conflActivitiesL[level, newtime].append(ai2);
#else
								conflActivities[newtime].append(ai2);
#endif
#if nConflActivities_ConditionalDefinition1
								GlobalMembersGenerate.nConflActivitiesL[level, newtime]++;
#else
								nConflActivities[newtime]++;
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif

								////////////
								removableActs.clear();

								int nc = act.duration;
								int h2;
								for (h2 = h - 1; h2 >= 0; h2--)
								{
									int ai2 = GlobalMembersGenerate.teachersTimetable(tch,d,h2);
									Debug.Assert(ai2 == GlobalMembersGenerate.newTeachersTimetable(tch,d,h2));
									Debug.Assert(ai2 != ai);
									if (ai2 < 0)
										break;
#if conflActivities_ConditionalDefinition1
									// gt.rules.internalActivitiesList[ai2].activityTagIndex==activityTag){
									if (ai2 >= 0 && !GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2) && gt.rules.internalActivitiesList[ai2].iActivityTagsSet.contains(activityTag))
#else
									if (ai2 >= 0 && !conflActivities[newtime].contains(ai2) && gt.rules.internalActivitiesList[ai2].iActivityTagsSet.contains(activityTag))
#endif
									{
										nc++;

										if (!removableActs.contains(ai2) && !GlobalMembersGenerate_pre.fixedTimeActivity[ai2] && !GlobalMembersGenerate.swappedActivities[ai2])
											removableActs.append(ai2);
									}
									else
										break;
								}
								for (h2 = h + act.duration; h2 < gt.rules.nHoursPerDay; h2++)
								{
									int ai2 = GlobalMembersGenerate.teachersTimetable(tch,d,h2);
									Debug.Assert(ai2 == GlobalMembersGenerate.newTeachersTimetable(tch,d,h2));
									Debug.Assert(ai2 != ai);
									if (ai2 < 0)
										break;
#if conflActivities_ConditionalDefinition1
									// gt.rules.internalActivitiesList[ai2].activityTagIndex==activityTag){
									if (ai2 >= 0 && !GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2) && gt.rules.internalActivitiesList[ai2].iActivityTagsSet.contains(activityTag))
#else
									if (ai2 >= 0 && !conflActivities[newtime].contains(ai2) && gt.rules.internalActivitiesList[ai2].iActivityTagsSet.contains(activityTag))
#endif
									{
										nc++;

										if (!removableActs.contains(ai2) && !GlobalMembersGenerate_pre.fixedTimeActivity[ai2] && !GlobalMembersGenerate.swappedActivities[ai2])
											removableActs.append(ai2);
									}
									else
										break;
								}

								if (nc <= limitHoursCont) //OK
									break;
								////////////
							}
						}
					}
				}

			}

	impossibleteachersactivitytagmaxhourscontinuously:
			if (!okteachersactivitytagmaxhourscontinuously)
			{
				if (updateSubgroups || updateTeachers)
					removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

	/////////////////////////////////////////////////////////////////////////////////////////////

			/////////begin teacher(s) min hours daily

			//I think it is best to put this routine after max days per week

			//Added on 11 September 2009: takes care of teachers min days per week

			okteachersminhoursdaily = true;
			foreach (int tch, act.iTeachersList)
			{
				if (GlobalMembersGenerate_pre.teachersMinHoursDailyMinHours[tch] >= 0)
				{
					Debug.Assert(GlobalMembersGenerate_pre.teachersMinHoursDailyPercentages[tch] == 100);

					bool skip = GlobalMembersGenerate.skipRandom(GlobalMembersGenerate_pre.teachersMinHoursDailyPercentages[tch]);
					if (!skip)
					{
						//preliminary test
						bool _ok;
						if (GlobalMembersGenerate_pre.teachersMaxGapsPerWeekPercentage[tch] == -1)
						{
							int _reqHours = 0;
							int _usedDays = 0;
							for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
								if (GlobalMembersGenerate.newTeachersDayNHours(tch,d2) > 0)
								{
									_usedDays++;
									if (GlobalMembersGenerate_pre.teachersMaxGapsPerDayPercentage[tch] == -1)
									{
										_reqHours += GlobalMembersGenerate.max(GlobalMembersGenerate.newTeachersDayNHours(tch,d2), GlobalMembersGenerate_pre.teachersMinHoursDailyMinHours[tch]);
									}
									else
									{
										int nh = GlobalMembersGenerate.max(0, GlobalMembersGenerate.newTeachersDayNGaps(tch,d2) - GlobalMembersGenerate_pre.teachersMaxGapsPerDayMaxGaps[tch]);
										_reqHours += GlobalMembersGenerate.max(GlobalMembersGenerate.newTeachersDayNHours(tch,d2) + nh, GlobalMembersGenerate_pre.teachersMinHoursDailyMinHours[tch]);
									}
								}

							if (GlobalMembersGenerate_pre.teachersMinDaysPerWeekPercentages[tch] >= 0)
							{
								Debug.Assert(_usedDays >= 0 && _usedDays <= gt.rules.nDaysPerWeek);
								Debug.Assert(GlobalMembersGenerate_pre.teachersMinDaysPerWeekPercentages[tch] == 100.0);
								int _md = GlobalMembersGenerate_pre.teachersMinDaysPerWeekMinDays[tch];
								Debug.Assert(_md >= 0);
								if (_md > _usedDays)
									_reqHours += (_md - _usedDays) * GlobalMembersGenerate_pre.teachersMinHoursDailyMinHours[tch];
							}

							if (_reqHours <= GlobalMembersGenerate_pre.nHoursPerTeacher[tch])
								_ok = true; //ok
							else
								_ok = false;
						}
						else
						{
							int remG = 0;
							int totalH = 0;
							int _usedDays = 0;
							for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
							{
								int remGDay = GlobalMembersGenerate.newTeachersDayNGaps(tch,d2);
								int h = GlobalMembersGenerate.newTeachersDayNHours(tch,d2);
								if (h > 0)
								{
									_usedDays++;
								}
								int addh;
								if (GlobalMembersGenerate_pre.teachersMaxGapsPerDayPercentage[tch] >= 0)
									addh = GlobalMembersGenerate.max(0, remGDay - GlobalMembersGenerate_pre.teachersMaxGapsPerDayMaxGaps[tch]);
								else
									addh = 0;
								remGDay -= addh;
								Debug.Assert(remGDay >= 0);
								h += addh;
								if (h > 0)
								{
									if (h < GlobalMembersGenerate_pre.teachersMinHoursDailyMinHours[tch])
									{
										remGDay -= GlobalMembersGenerate_pre.teachersMinHoursDailyMinHours[tch] - h;
										totalH += GlobalMembersGenerate_pre.teachersMinHoursDailyMinHours[tch];
									}
									else
										totalH += h;
								}
								if (remGDay > 0)
									remG += remGDay;
							}

							if (GlobalMembersGenerate_pre.teachersMinDaysPerWeekPercentages[tch] >= 0)
							{
								Debug.Assert(_usedDays >= 0 && _usedDays <= gt.rules.nDaysPerWeek);
								Debug.Assert(GlobalMembersGenerate_pre.teachersMinDaysPerWeekPercentages[tch] == 100.0);
								int _md = GlobalMembersGenerate_pre.teachersMinDaysPerWeekMinDays[tch];
								Debug.Assert(_md >= 0);
								if (_md > _usedDays)
									totalH += (_md - _usedDays) * GlobalMembersGenerate_pre.teachersMinHoursDailyMinHours[tch];
							}

							if (remG + totalH <= GlobalMembersGenerate_pre.nHoursPerTeacher[tch] + GlobalMembersGenerate_pre.teachersMaxGapsPerWeekMaxGaps[tch] && totalH <= GlobalMembersGenerate_pre.nHoursPerTeacher[tch])
								  _ok = true;
							else
								_ok = false;
						}

						if (_ok)
							continue;

						if (level >= GlobalMembersGenerate.LEVEL_STOP_CONFLICTS_CALCULATION)
						{
							okteachersminhoursdaily = false;
							goto impossibleteachersminhoursdaily;
						}

#if conflActivities_ConditionalDefinition1
						getTchTimetable(tch, GlobalMembersGenerate.conflActivitiesL[level, newtime]);
#else
						getTchTimetable(tch, conflActivities[newtime]);
#endif
						tchGetNHoursGaps(tch);

						for (;;)
						{
							bool ok;
							if (GlobalMembersGenerate_pre.teachersMaxGapsPerWeekPercentage[tch] == -1)
							{
								int _reqHours = 0;
								int _usedDays = 0;
								for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
									if (GlobalMembersGenerate.tchDayNHours[d2] > 0)
									{
										_usedDays++;
										if (GlobalMembersGenerate_pre.teachersMaxGapsPerDayPercentage[tch] == -1)
										{
											_reqHours += GlobalMembersGenerate.max(GlobalMembersGenerate.tchDayNHours[d2], GlobalMembersGenerate_pre.teachersMinHoursDailyMinHours[tch]);
										}
										else
										{
											int nh = GlobalMembersGenerate.max(0, GlobalMembersGenerate.tchDayNGaps[d2] - GlobalMembersGenerate_pre.teachersMaxGapsPerDayMaxGaps[tch]);
											_reqHours += GlobalMembersGenerate.max(GlobalMembersGenerate.tchDayNHours[d2] + nh, GlobalMembersGenerate_pre.teachersMinHoursDailyMinHours[tch]);
										}
									}

								if (GlobalMembersGenerate_pre.teachersMinDaysPerWeekPercentages[tch] >= 0)
								{
									Debug.Assert(_usedDays >= 0 && _usedDays <= gt.rules.nDaysPerWeek);
									Debug.Assert(GlobalMembersGenerate_pre.teachersMinDaysPerWeekPercentages[tch] == 100.0);
									int _md = GlobalMembersGenerate_pre.teachersMinDaysPerWeekMinDays[tch];
									Debug.Assert(_md >= 0);
									if (_md > _usedDays)
										_reqHours += (_md - _usedDays) * GlobalMembersGenerate_pre.teachersMinHoursDailyMinHours[tch];
								}

								if (_reqHours <= GlobalMembersGenerate_pre.nHoursPerTeacher[tch])
									ok = true; //ok
								else
									ok = false;
							}
							else
							{
								int remG = 0;
								int totalH = 0;
								int _usedDays = 0;
								for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
								{
									int remGDay = GlobalMembersGenerate.tchDayNGaps[d2];
									int h = GlobalMembersGenerate.tchDayNHours[d2];
									if (h > 0)
										_usedDays++;
									int addh;
									if (GlobalMembersGenerate_pre.teachersMaxGapsPerDayPercentage[tch] >= 0)
										addh = GlobalMembersGenerate.max(0, remGDay - GlobalMembersGenerate_pre.teachersMaxGapsPerDayMaxGaps[tch]);
									else
										addh = 0;
									remGDay -= addh;
									Debug.Assert(remGDay >= 0);
									h += addh;
									if (h > 0)
									{
										if (h < GlobalMembersGenerate_pre.teachersMinHoursDailyMinHours[tch])
										{
											remGDay -= GlobalMembersGenerate_pre.teachersMinHoursDailyMinHours[tch] - h;
											totalH += GlobalMembersGenerate_pre.teachersMinHoursDailyMinHours[tch];
										}
										else
											totalH += h;
									}
									if (remGDay > 0)
										remG += remGDay;
								}
								if (GlobalMembersGenerate_pre.teachersMinDaysPerWeekPercentages[tch] >= 0)
								{
									Debug.Assert(_usedDays >= 0 && _usedDays <= gt.rules.nDaysPerWeek);
									Debug.Assert(GlobalMembersGenerate_pre.teachersMinDaysPerWeekPercentages[tch] == 100.0);
									int _md = GlobalMembersGenerate_pre.teachersMinDaysPerWeekMinDays[tch];
									Debug.Assert(_md >= 0);
									if (_md > _usedDays)
										totalH += (_md - _usedDays) * GlobalMembersGenerate_pre.teachersMinHoursDailyMinHours[tch];
								}

								if (remG + totalH <= GlobalMembersGenerate_pre.nHoursPerTeacher[tch] + GlobalMembersGenerate_pre.teachersMaxGapsPerWeekMaxGaps[tch] && totalH <= GlobalMembersGenerate_pre.nHoursPerTeacher[tch])
									  ok = true;
								else
									ok = false;
							}

							if (ok)
								break;

							int ai2 = -1;

#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
							bool k = teacherRemoveAnActivityFromBeginOrEnd(tch, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
							bool k = teacherRemoveAnActivityFromBeginOrEnd(tch, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref nConflActivities[newtime], ref ai2);
#endif
#else
#if nConflActivities_ConditionalDefinition1
							bool k = teacherRemoveAnActivityFromBeginOrEnd(tch, level, ai, ref conflActivities[newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
							bool k = teacherRemoveAnActivityFromBeginOrEnd(tch, level, ai, ref conflActivities[newtime], ref nConflActivities[newtime], ref ai2);
#endif
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif
							if (!k)
							{
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								bool ka = teacherRemoveAnActivityFromAnywhere(tch, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
								bool ka = teacherRemoveAnActivityFromAnywhere(tch, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref nConflActivities[newtime], ref ai2);
#endif
#else
#if nConflActivities_ConditionalDefinition1
								bool ka = teacherRemoveAnActivityFromAnywhere(tch, level, ai, ref conflActivities[newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
								bool ka = teacherRemoveAnActivityFromAnywhere(tch, level, ai, ref conflActivities[newtime], ref nConflActivities[newtime], ref ai2);
#endif
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif

								if (!ka)
								{
									if (level == 0)
									{
										//Liviu: inactivated from version 5.12.4 (7 Feb. 2010), because it may take too long for some files
										//cout<<"WARNING - mb - file "<<__FILE__<<" line "<<__LINE__<<endl;
									}
									okteachersminhoursdaily = false;
									goto impossibleteachersminhoursdaily;
								}
							}

							Debug.Assert(ai2 >= 0);

							/*Activity* act2=&gt.rules.internalActivitiesList[ai2];
							int d2=c.times[ai2]%gt.rules.nDaysPerWeek;
							int h2=c.times[ai2]/gt.rules.nDaysPerWeek;
							
							for(int dur2=0; dur2<act2->duration; dur2++){
								assert(tchTimetable(d2,h2+dur2)==ai2);
								tchTimetable(d2,h2+dur2)=-1;
							}*/

							removeAi2FromTchTimetable(ai2);
							updateTchNHoursGaps(tch, c.times[ai2] % gt.rules.nDaysPerWeek);
						}
					}
				}
			}

	impossibleteachersminhoursdaily:
			if (!okteachersminhoursdaily)
			{
				if (updateSubgroups || updateTeachers)
					removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

			/////////end teacher(s) min hours daily

	/////////////////////////////////////////////////////////////////////////////////////////////

			/////////begin teacher(s) min days per week

			//Put this routine after min hours daily

			//Added on 11 September 2009

			okteachersmindaysperweek = true;
			foreach (int tch, act.iTeachersList)
			{
				if (GlobalMembersGenerate_pre.teachersMinDaysPerWeekMinDays[tch] >= 0 && GlobalMembersGenerate_pre.teachersMinHoursDailyMinHours[tch] == -1) //no need to recheck, if min hours daily is set, because I tested above.
				{
					Debug.Assert(GlobalMembersGenerate_pre.teachersMinDaysPerWeekPercentages[tch] == 100);

					bool skip = GlobalMembersGenerate.skipRandom(GlobalMembersGenerate_pre.teachersMinDaysPerWeekPercentages[tch]);
					if (!skip)
					{
						//preliminary test
						bool _ok;
						if (GlobalMembersGenerate_pre.teachersMaxGapsPerWeekPercentage[tch] == -1)
						{
							int _reqHours = 0;
							int _usedDays = 0;
							for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
								if (GlobalMembersGenerate.newTeachersDayNHours(tch,d2) > 0)
								{
									_usedDays++;
									if (GlobalMembersGenerate_pre.teachersMaxGapsPerDayPercentage[tch] == -1)
									{
										_reqHours += GlobalMembersGenerate.newTeachersDayNHours(tch,d2);
									}
									else
									{
										int nh = GlobalMembersGenerate.max(0, GlobalMembersGenerate.newTeachersDayNGaps(tch,d2) - GlobalMembersGenerate_pre.teachersMaxGapsPerDayMaxGaps[tch]);
										_reqHours += GlobalMembersGenerate.newTeachersDayNHours(tch,d2) + nh;
									}
								}

							Debug.Assert(_usedDays >= 0 && _usedDays <= gt.rules.nDaysPerWeek);
							Debug.Assert(GlobalMembersGenerate_pre.teachersMinDaysPerWeekPercentages[tch] == 100.0);
							int _md = GlobalMembersGenerate_pre.teachersMinDaysPerWeekMinDays[tch];
							Debug.Assert(_md >= 0);
							if (_md > _usedDays)
								_reqHours += (_md - _usedDays) * 1; //one hour per day minimum

							if (_reqHours <= GlobalMembersGenerate_pre.nHoursPerTeacher[tch])
								_ok = true; //ok
							else
								_ok = false;
						}
						else
						{
							int remG = 0;
							int totalH = 0;
							int _usedDays = 0;
							for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
							{
								int remGDay = GlobalMembersGenerate.newTeachersDayNGaps(tch,d2);
								int h = GlobalMembersGenerate.newTeachersDayNHours(tch,d2);
								if (h > 0)
								{
									_usedDays++;
								}
								int addh;
								if (GlobalMembersGenerate_pre.teachersMaxGapsPerDayPercentage[tch] >= 0)
									addh = GlobalMembersGenerate.max(0, remGDay - GlobalMembersGenerate_pre.teachersMaxGapsPerDayMaxGaps[tch]);
								else
									addh = 0;
								remGDay -= addh;
								Debug.Assert(remGDay >= 0);
								h += addh;
								if (h > 0)
									totalH += h;
								if (remGDay > 0)
									remG += remGDay;
							}

							Debug.Assert(_usedDays >= 0 && _usedDays <= gt.rules.nDaysPerWeek);
							Debug.Assert(GlobalMembersGenerate_pre.teachersMinDaysPerWeekPercentages[tch] == 100.0);
							int _md = GlobalMembersGenerate_pre.teachersMinDaysPerWeekMinDays[tch];
							Debug.Assert(_md >= 0);
							if (_md > _usedDays)
								totalH += (_md - _usedDays) * 1; //min 1 hour per day

							if (remG + totalH <= GlobalMembersGenerate_pre.nHoursPerTeacher[tch] + GlobalMembersGenerate_pre.teachersMaxGapsPerWeekMaxGaps[tch] && totalH <= GlobalMembersGenerate_pre.nHoursPerTeacher[tch])
								  _ok = true;
							else
								_ok = false;
						}

						if (_ok)
							continue;

						if (level >= GlobalMembersGenerate.LEVEL_STOP_CONFLICTS_CALCULATION)
						{
							okteachersmindaysperweek = false;
							goto impossibleteachersmindaysperweek;
						}

#if conflActivities_ConditionalDefinition1
						getTchTimetable(tch, GlobalMembersGenerate.conflActivitiesL[level, newtime]);
#else
						getTchTimetable(tch, conflActivities[newtime]);
#endif
						tchGetNHoursGaps(tch);

						for (;;)
						{
							bool ok;
							if (GlobalMembersGenerate_pre.teachersMaxGapsPerWeekPercentage[tch] == -1)
							{
								int _reqHours = 0;
								int _usedDays = 0;
								for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
									if (GlobalMembersGenerate.tchDayNHours[d2] > 0)
									{
										_usedDays++;
										if (GlobalMembersGenerate_pre.teachersMaxGapsPerDayPercentage[tch] == -1)
										{
											_reqHours += GlobalMembersGenerate.tchDayNHours[d2];
										}
										else
										{
											int nh = GlobalMembersGenerate.max(0, GlobalMembersGenerate.tchDayNGaps[d2] - GlobalMembersGenerate_pre.teachersMaxGapsPerDayMaxGaps[tch]);
											_reqHours += GlobalMembersGenerate.tchDayNHours[d2] + nh;
										}
									}

								Debug.Assert(_usedDays >= 0 && _usedDays <= gt.rules.nDaysPerWeek);
								Debug.Assert(GlobalMembersGenerate_pre.teachersMinDaysPerWeekPercentages[tch] == 100.0);
								int _md = GlobalMembersGenerate_pre.teachersMinDaysPerWeekMinDays[tch];
								Debug.Assert(_md >= 0);
								if (_md > _usedDays)
									_reqHours += (_md - _usedDays) * 1; //min 1 hour for each day

								if (_reqHours <= GlobalMembersGenerate_pre.nHoursPerTeacher[tch])
									ok = true; //ok
								else
									ok = false;
							}
							else
							{
								int remG = 0;
								int totalH = 0;
								int _usedDays = 0;
								for (int d2 = 0; d2 < gt.rules.nDaysPerWeek; d2++)
								{
									int remGDay = GlobalMembersGenerate.tchDayNGaps[d2];
									int h = GlobalMembersGenerate.tchDayNHours[d2];
									if (h > 0)
										_usedDays++;
									int addh;
									if (GlobalMembersGenerate_pre.teachersMaxGapsPerDayPercentage[tch] >= 0)
										addh = GlobalMembersGenerate.max(0, remGDay - GlobalMembersGenerate_pre.teachersMaxGapsPerDayMaxGaps[tch]);
									else
										addh = 0;
									remGDay -= addh;
									Debug.Assert(remGDay >= 0);
									h += addh;
									if (h > 0)
										totalH += h;
									if (remGDay > 0)
										remG += remGDay;
								}
								Debug.Assert(_usedDays >= 0 && _usedDays <= gt.rules.nDaysPerWeek);
								Debug.Assert(GlobalMembersGenerate_pre.teachersMinDaysPerWeekPercentages[tch] == 100.0);
								int _md = GlobalMembersGenerate_pre.teachersMinDaysPerWeekMinDays[tch];
								Debug.Assert(_md >= 0);
								if (_md > _usedDays)
									totalH += (_md - _usedDays) * 1; //min 1 hour each day

								if (remG + totalH <= GlobalMembersGenerate_pre.nHoursPerTeacher[tch] + GlobalMembersGenerate_pre.teachersMaxGapsPerWeekMaxGaps[tch] && totalH <= GlobalMembersGenerate_pre.nHoursPerTeacher[tch])
									  ok = true;
								else
									ok = false;
							}

							if (ok)
								break;

							int ai2 = -1;

#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
							bool k = teacherRemoveAnActivityFromBeginOrEnd(tch, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
							bool k = teacherRemoveAnActivityFromBeginOrEnd(tch, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref nConflActivities[newtime], ref ai2);
#endif
#else
#if nConflActivities_ConditionalDefinition1
							bool k = teacherRemoveAnActivityFromBeginOrEnd(tch, level, ai, ref conflActivities[newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
							bool k = teacherRemoveAnActivityFromBeginOrEnd(tch, level, ai, ref conflActivities[newtime], ref nConflActivities[newtime], ref ai2);
#endif
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
							Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif
							if (!k)
							{
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								bool ka = teacherRemoveAnActivityFromAnywhere(tch, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
								bool ka = teacherRemoveAnActivityFromAnywhere(tch, level, ai, ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref nConflActivities[newtime], ref ai2);
#endif
#else
#if nConflActivities_ConditionalDefinition1
								bool ka = teacherRemoveAnActivityFromAnywhere(tch, level, ai, ref conflActivities[newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime], ref ai2);
#else
								bool ka = teacherRemoveAnActivityFromAnywhere(tch, level, ai, ref conflActivities[newtime], ref nConflActivities[newtime], ref ai2);
#endif
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == nConflActivities[newtime]);
#endif
#else
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(conflActivities[newtime].count() == GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
								Debug.Assert(conflActivities[newtime].count() == nConflActivities[newtime]);
#endif
#endif

								if (!ka)
								{
									if (level == 0)
									{
										//Liviu: inactivated from version 5.12.4 (7 Feb. 2010), because it may take too long for some files
										//cout<<"WARNING - mb - file "<<__FILE__<<" line "<<__LINE__<<endl;
									}
									okteachersmindaysperweek = false;
									goto impossibleteachersmindaysperweek;
								}
							}

							Debug.Assert(ai2 >= 0);

							/*Activity* act2=&gt.rules.internalActivitiesList[ai2];
							int d2=c.times[ai2]%gt.rules.nDaysPerWeek;
							int h2=c.times[ai2]/gt.rules.nDaysPerWeek;
							
							for(int dur2=0; dur2<act2->duration; dur2++){
								assert(tchTimetable(d2,h2+dur2)==ai2);
								tchTimetable(d2,h2+dur2)=-1;
							}*/

							removeAi2FromTchTimetable(ai2);
							updateTchNHoursGaps(tch, c.times[ai2] % gt.rules.nDaysPerWeek);
						}
					}
				}
			}

	impossibleteachersmindaysperweek:
			if (!okteachersmindaysperweek)
			{
				if (updateSubgroups || updateTeachers)
					removeAiFromNewTimetable(ai, act, d, h);
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}

			/////////end teacher(s) min days per week

	/////////////////////////////////////////////////////////////////////////////////////////////

			//2011-09-30
			//care about activities max simultaneous in selected time slots
			//I think it is best to put this after all other major constraints
			//I think it is better to put this before activities occupy max time slots from selection
			if (GlobalMembersGenerate_pre.haveActivitiesOccupyOrSimultaneousConstraints)
			{
				okactivitiesmaxsimultaneousinselectedtimeslots = true;

				foreach (ActivitiesMaxSimultaneousInSelectedTimeSlots_item * item, GlobalMembersGenerate_pre.amsistsListForActivity[ai])
				{
					bool inSpecifiedTimeSlots = false;
					for (int t = newtime; t < newtime + act.duration * gt.rules.nDaysPerWeek; t += gt.rules.nDaysPerWeek)
						if (item.selectedTimeSlotsSet.contains(t))
						{
							inSpecifiedTimeSlots = true;
							break;
						}

					if (!inSpecifiedTimeSlots)
						continue;

					bool correct = true;

					for (int t = newtime; t < newtime + act.duration * gt.rules.nDaysPerWeek; t += gt.rules.nDaysPerWeek)
					{
						if (item.selectedTimeSlotsSet.contains(t))
						{
							GlobalMembersGenerate.slotSetOfActivities[t] = GlobalMembersGenerate.activitiesAtTime[t];

							if (GlobalMembersGenerate.slotSetOfActivities[t].count() + 1 <= item.maxSimultaneous)
								continue;

							GlobalMembersGenerate.slotSetOfActivities[t].intersect(item.activitiesSet);

							if (GlobalMembersGenerate.slotSetOfActivities[t].count() + 1 <= item.maxSimultaneous)
								continue;

#if conflActivities_ConditionalDefinition1
							GlobalMembersGenerate.slotSetOfActivities[t].subtract(GlobalMembersGenerate.conflActivitiesL[level, newtime].toSet());
#else
							GlobalMembersGenerate.slotSetOfActivities[t].subtract(conflActivities[newtime].toSet());
#endif

							if (GlobalMembersGenerate.slotSetOfActivities[t].count() + 1 <= item.maxSimultaneous)
								continue;

							Debug.Assert(!GlobalMembersGenerate.slotSetOfActivities[t].contains(ai));
							GlobalMembersGenerate.slotSetOfActivities[t].insert(ai);

							correct = false;
						}
					}

					if (!correct)
					{
						QList<QSet<int>> candidates = new QList<QSet<int>>();
						QSet<int> allCandidates = new QSet<int>();
						for (int t = newtime; t < newtime + act.duration * gt.rules.nDaysPerWeek; t += gt.rules.nDaysPerWeek)
						{
							if (item.selectedTimeSlotsSet.contains(t))
							{
								if (GlobalMembersGenerate.slotSetOfActivities[t].count() > item.maxSimultaneous)
								{
									QSet<int> tmpSet = new QSet<int>();

									Debug.Assert(GlobalMembersGenerate.slotSetOfActivities[t].count() == item.maxSimultaneous + 1);
									foreach (int ai2, GlobalMembersGenerate.slotSetOfActivities[t]) if (ai2 != ai && !GlobalMembersGenerate_pre.fixedTimeActivity[ai2] && !GlobalMembersGenerate.swappedActivities[ai2])
									{
											tmpSet.insert(ai2);
											if (!allCandidates.contains(ai2))
												allCandidates.insert(ai2);
									}

									candidates.append(tmpSet);
								}
							}
						}

						foreach (QSet<int> tmpSet, candidates) if (tmpSet.count() == 0)
						{
								okactivitiesmaxsimultaneousinselectedtimeslots = false;
								goto impossibleactivitiesmaxsimultaneousinselectedtimeslots;
						}

						//possible to fix
						while (candidates.count() > 0)
						{
							int tc = candidates.count();

							int q = GlobalMembersTimetable_defs.randomKnuth(allCandidates.count());

							//To keep generation identical on all computers - 2013-01-03
							QList<int> tmpSortedList = allCandidates.toList();
							qSort(tmpSortedList);
							int ai2 = tmpSortedList.at(q);
							//int ai2=allCandidates.toList().at(q);

							////
							Debug.Assert(ai2 != ai);
							Debug.Assert(c.times[ai2] != GlobalMembersTimetable_defs.UNALLOCATED_TIME);
							Debug.Assert(!GlobalMembersGenerate_pre.fixedTimeActivity[ai2] && !GlobalMembersGenerate.swappedActivities[ai2]);

#if conflActivities_ConditionalDefinition1
							Debug.Assert(!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2));
#else
							Debug.Assert(!conflActivities[newtime].contains(ai2));
#endif
#if conflActivities_ConditionalDefinition1
							GlobalMembersGenerate.conflActivitiesL[level, newtime].append(ai2);
#else
							conflActivities[newtime].append(ai2);
#endif

#if nConflActivities_ConditionalDefinition1
							GlobalMembersGenerate.nConflActivitiesL[level, newtime]++;
#else
							nConflActivities[newtime]++;
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(GlobalMembersGenerate.nConflActivitiesL[level, newtime] == GlobalMembersGenerate.conflActivitiesL[level, newtime].count());
#else
							Debug.Assert(nConflActivities[newtime] == GlobalMembersGenerate.conflActivitiesL[level, newtime].count());
#endif
#else
#if nConflActivities_ConditionalDefinition1
							Debug.Assert(GlobalMembersGenerate.nConflActivitiesL[level, newtime] == conflActivities[newtime].count());
#else
							Debug.Assert(nConflActivities[newtime] == conflActivities[newtime].count());
#endif
#endif
							////

							QList<QSet<int>> newCandidates = new QList<QSet<int>>();
							QSet<int> newAllCandidates = new QSet<int>();

							foreach (QSet<int> tmpSet, candidates) if (!tmpSet.contains(ai2))
							{
									newCandidates.append(tmpSet);
									newAllCandidates.unite(tmpSet);
							}

							allCandidates = newAllCandidates;
							candidates = newCandidates;

							Debug.Assert(candidates.count() < tc); //need to have a progress, not an endless loop
						}
					}
				}

	impossibleactivitiesmaxsimultaneousinselectedtimeslots:
				if (!okactivitiesmaxsimultaneousinselectedtimeslots)
				{
					if (updateSubgroups || updateTeachers)
						removeAiFromNewTimetable(ai, act, d, h);
					//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
					GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
					nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
					continue;
				}

				/*foreach(int ai2, conflActivities[newtime])
					assert(!swappedActivities[ai2]);*/
			}

	/////////////////////////////////////////////////////////////////////////////////////////////

			//2011-09-25
			//care about activities max number of occupied time slots from selection
			//I think it is best to put this after all other major constraints
			//I think it is best to put this after activities max simultaneous in selected time slots

			if (GlobalMembersGenerate_pre.haveActivitiesOccupyOrSimultaneousConstraints)
			{
				okactivitiesoccupymaxtimeslotsfromselection = true;

				foreach (ActivitiesOccupyMaxTimeSlotsFromSelection_item * item, GlobalMembersGenerate_pre.aomtsListForActivity[ai])
				{
					//preliminary, for speed
					bool contained = false;
					for (int t = newtime; t < newtime + act.duration * gt.rules.nDaysPerWeek; t += gt.rules.nDaysPerWeek)
						if (item.selectedTimeSlotsSet.contains(t))
						{
							contained = true;
							break;
						}
					if (!contained)
						continue;

					int _nOcc = 0;
					foreach (int t, item.selectedTimeSlotsList) if (GlobalMembersGenerate.activitiesAtTime[t].count() > 0) _nOcc++;
					for (int t = newtime; t < newtime + act.duration * gt.rules.nDaysPerWeek; t += gt.rules.nDaysPerWeek)
						if (item.selectedTimeSlotsSet.contains(t))
							if (GlobalMembersGenerate.activitiesAtTime[t].count() == 0)
								_nOcc++;
					if (_nOcc <= item.maxOccupiedTimeSlots)
						continue;
					///////

					foreach (int t, item.selectedTimeSlotsList)
					{
						GlobalMembersGenerate.slotSetOfActivities[t].clear();
						GlobalMembersGenerate.slotCanEmpty[t] = true;
					}

					foreach (int ai2, item.activitiesList)
					{
#if conflActivities_ConditionalDefinition1
						if (ai2 != ai && c.times[ai2] != GlobalMembersTimetable_defs.UNALLOCATED_TIME && !GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2))
#else
						if (ai2 != ai && c.times[ai2] != GlobalMembersTimetable_defs.UNALLOCATED_TIME && !conflActivities[newtime].contains(ai2))
#endif
						{
							for (int t = c.times[ai2]; t < c.times[ai2] + gt.rules.internalActivitiesList[ai2].duration * gt.rules.nDaysPerWeek; t += gt.rules.nDaysPerWeek)
							{
								if (item.selectedTimeSlotsSet.contains(t))
								{
									GlobalMembersGenerate.slotSetOfActivities[t].insert(ai2);

									if (GlobalMembersGenerate_pre.fixedTimeActivity[ai2] || GlobalMembersGenerate.swappedActivities[ai2])
										GlobalMembersGenerate.slotCanEmpty[t] = false;
								}
							}
						}
						else if (ai2 == ai)
						{
							for (int t = newtime; t < newtime + act.duration * gt.rules.nDaysPerWeek; t += gt.rules.nDaysPerWeek)
							{
								if (item.selectedTimeSlotsSet.contains(t))
								{
									GlobalMembersGenerate.slotSetOfActivities[t].insert(ai);
									GlobalMembersGenerate.slotCanEmpty[t] = false;
								}
							}
						}
					}

					int nOccupied = 0;
					QSet<int> candidates = new QSet<int>();
					foreach (int t, item.selectedTimeSlotsList)
					{
						if (GlobalMembersGenerate.slotSetOfActivities[t].count() > 0)
						{
							nOccupied++;

							if (GlobalMembersGenerate.slotCanEmpty[t])
								candidates.insert(t);
						}
					}

					if (nOccupied > item.maxOccupiedTimeSlots)
					{
						int target = nOccupied - item.maxOccupiedTimeSlots;
						while (target > 0)
						{
							bool decreased = false;

							if (candidates.count() == 0)
							{
								okactivitiesoccupymaxtimeslotsfromselection = false;
								goto impossibleactivitiesoccupymaxtimeslotsfromselection;
							}
							int q = GlobalMembersTimetable_defs.randomKnuth(candidates.count());

							//To keep generation identical on all computers - 2013-01-03
							QList<int> tmpSortedList = candidates.toList();
							qSort(tmpSortedList);
							int t = tmpSortedList.at(q);
							//int t=candidates.toList().at(q);

							QSet<int> tmpSet = GlobalMembersGenerate.slotSetOfActivities[t];
							//To keep generation identical on all computers - 2013-01-03
							QList<int> tmpListFromSet = tmpSet.toList();
							qSort(tmpListFromSet);
							//Randomize list
							for (int i = 0; i < tmpListFromSet.count(); i++)
							{
								int t = tmpListFromSet.at(i);
								int r = GlobalMembersTimetable_defs.randomKnuth(tmpListFromSet.count() - i);
								tmpListFromSet[i] = tmpListFromSet[i + r];
								tmpListFromSet[i + r] = t;
							}

							foreach (int ai2, tmpListFromSet)
							{
								Debug.Assert(ai2 != ai);
								Debug.Assert(c.times[ai2] != GlobalMembersTimetable_defs.UNALLOCATED_TIME);
								Debug.Assert(!GlobalMembersGenerate_pre.fixedTimeActivity[ai2] && !GlobalMembersGenerate.swappedActivities[ai2]);

								for (int tt = c.times[ai2]; tt < c.times[ai2] + gt.rules.internalActivitiesList[ai2].duration * gt.rules.nDaysPerWeek; tt += gt.rules.nDaysPerWeek)
									if (item.selectedTimeSlotsSet.contains(tt))
									{
										Debug.Assert(GlobalMembersGenerate.slotSetOfActivities[tt].contains(ai2));
										GlobalMembersGenerate.slotSetOfActivities[tt].remove(ai2);
										if (GlobalMembersGenerate.slotSetOfActivities[tt].count() == 0)
										{
											Debug.Assert(candidates.contains(tt));
											candidates.remove(tt);
											target--;

											decreased = true;
										}
									}

#if conflActivities_ConditionalDefinition1
								Debug.Assert(!GlobalMembersGenerate.conflActivitiesL[level, newtime].contains(ai2));
#else
								Debug.Assert(!conflActivities[newtime].contains(ai2));
#endif
#if conflActivities_ConditionalDefinition1
								GlobalMembersGenerate.conflActivitiesL[level, newtime].append(ai2);
#else
								conflActivities[newtime].append(ai2);
#endif

#if nConflActivities_ConditionalDefinition1
								GlobalMembersGenerate.nConflActivitiesL[level, newtime]++;
#else
								nConflActivities[newtime]++;
#endif
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(GlobalMembersGenerate.nConflActivitiesL[level, newtime] == GlobalMembersGenerate.conflActivitiesL[level, newtime].count());
#else
								Debug.Assert(nConflActivities[newtime] == GlobalMembersGenerate.conflActivitiesL[level, newtime].count());
#endif
#else
#if nConflActivities_ConditionalDefinition1
								Debug.Assert(GlobalMembersGenerate.nConflActivitiesL[level, newtime] == conflActivities[newtime].count());
#else
								Debug.Assert(nConflActivities[newtime] == conflActivities[newtime].count());
#endif
#endif
							}

							Debug.Assert(decreased);
						}
					}
				}

	impossibleactivitiesoccupymaxtimeslotsfromselection:
				if (!okactivitiesoccupymaxtimeslotsfromselection)
				{
					if (updateSubgroups || updateTeachers)
						removeAiFromNewTimetable(ai, act, d, h);
					//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
					GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
					nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
					continue;
				}

				/*foreach(int ai2, conflActivities[newtime])
					assert(!swappedActivities[ai2]);*/

			}

	/////////////////////////////////////////////////////////////////////////////////////////////

	skip_here_if_already_allocated_in_time:

			//////////////////rooms
#if selectedRoom_ConditionalDefinition1
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
#if roomSlots_ConditionalDefinition1
			bool okroomnotavailable = getRoom(level, act, ai, d, h, ref GlobalMembersGenerate.roomSlotsL[level, newtime], ref GlobalMembersGenerate.selectedRoomL[level, newtime], ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
			bool okroomnotavailable = getRoom(level, act, ai, d, h, ref roomSlots[newtime], ref GlobalMembersGenerate.selectedRoomL[level, newtime], ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#endif
#else
#if roomSlots_ConditionalDefinition1
			bool okroomnotavailable = getRoom(level, act, ai, d, h, ref GlobalMembersGenerate.roomSlotsL[level, newtime], ref GlobalMembersGenerate.selectedRoomL[level, newtime], ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref nConflActivities[newtime]);
#else
			bool okroomnotavailable = getRoom(level, act, ai, d, h, ref roomSlots[newtime], ref GlobalMembersGenerate.selectedRoomL[level, newtime], ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref nConflActivities[newtime]);
#endif
#endif
#else
#if nConflActivities_ConditionalDefinition1
#if roomSlots_ConditionalDefinition1
			bool okroomnotavailable = getRoom(level, act, ai, d, h, ref GlobalMembersGenerate.roomSlotsL[level, newtime], ref GlobalMembersGenerate.selectedRoomL[level, newtime], ref conflActivities[newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
			bool okroomnotavailable = getRoom(level, act, ai, d, h, ref roomSlots[newtime], ref GlobalMembersGenerate.selectedRoomL[level, newtime], ref conflActivities[newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#endif
#else
#if roomSlots_ConditionalDefinition1
			bool okroomnotavailable = getRoom(level, act, ai, d, h, ref GlobalMembersGenerate.roomSlotsL[level, newtime], ref GlobalMembersGenerate.selectedRoomL[level, newtime], ref conflActivities[newtime], ref nConflActivities[newtime]);
#else
			bool okroomnotavailable = getRoom(level, act, ai, d, h, ref roomSlots[newtime], ref GlobalMembersGenerate.selectedRoomL[level, newtime], ref conflActivities[newtime], ref nConflActivities[newtime]);
#endif
#endif
#endif
#else
#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
#if roomSlots_ConditionalDefinition1
			bool okroomnotavailable = getRoom(level, act, ai, d, h, ref GlobalMembersGenerate.roomSlotsL[level, newtime], ref selectedRoom[newtime], ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
			bool okroomnotavailable = getRoom(level, act, ai, d, h, ref roomSlots[newtime], ref selectedRoom[newtime], ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#endif
#else
#if roomSlots_ConditionalDefinition1
			bool okroomnotavailable = getRoom(level, act, ai, d, h, ref GlobalMembersGenerate.roomSlotsL[level, newtime], ref selectedRoom[newtime], ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref nConflActivities[newtime]);
#else
			bool okroomnotavailable = getRoom(level, act, ai, d, h, ref roomSlots[newtime], ref selectedRoom[newtime], ref GlobalMembersGenerate.conflActivitiesL[level, newtime], ref nConflActivities[newtime]);
#endif
#endif
#else
#if nConflActivities_ConditionalDefinition1
#if roomSlots_ConditionalDefinition1
			bool okroomnotavailable = getRoom(level, act, ai, d, h, ref GlobalMembersGenerate.roomSlotsL[level, newtime], ref selectedRoom[newtime], ref conflActivities[newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#else
			bool okroomnotavailable = getRoom(level, act, ai, d, h, ref roomSlots[newtime], ref selectedRoom[newtime], ref conflActivities[newtime], ref GlobalMembersGenerate.nConflActivitiesL[level, newtime]);
#endif
#else
#if roomSlots_ConditionalDefinition1
			bool okroomnotavailable = getRoom(level, act, ai, d, h, ref GlobalMembersGenerate.roomSlotsL[level, newtime], ref selectedRoom[newtime], ref conflActivities[newtime], ref nConflActivities[newtime]);
#else
			bool okroomnotavailable = getRoom(level, act, ai, d, h, ref roomSlots[newtime], ref selectedRoom[newtime], ref conflActivities[newtime], ref nConflActivities[newtime]);
#endif
#endif
#endif
#endif

	//impossibleroomnotavailable:
			if (!okroomnotavailable)
			{
				if (c.times[ai] == GlobalMembersTimetable_defs.UNALLOCATED_TIME)
				{
					if (updateSubgroups || updateTeachers)
						removeAiFromNewTimetable(ai, act, d, h);
				}
				//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if nConflActivities_ConditionalDefinition1
				GlobalMembersGenerate.nConflActivitiesL[level, newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#else
				nConflActivities[newtime] = GlobalMembersTimetable_defs.MAX_ACTIVITIES;
#endif
				continue;
			}
			///////////////////////

			if (c.times[ai] == GlobalMembersTimetable_defs.UNALLOCATED_TIME)
			{
				if (updateSubgroups || updateTeachers)
					removeAiFromNewTimetable(ai, act, d, h);
			}
			//removeConflActivities(conflActivities[newtime], nConflActivities[newtime], act, newtime);

#if false
	//		//sort activities in decreasing order of difficulty.
	//		//if the index of the activity in "permutation" is smaller, the act. is more difficult
	//		QList<int> sorted;
	//		QList<int> conflActs=conflActivities[newtime];
	//		while(conflActs.count()>0){
	//			int m=gt.rules.nInternalActivities;
	//			int j=-1;
	//			for(int k=0; k<conflActs.count(); k++){
	//				int a=conflActs.at(k);
	//				if(invPermutation[a]<m){
	//					m=invPermutation[a];
	//					j=k;
	//				}
	//			}
	//			assert(j>=0);
	//
	//			sorted.append(conflActs.at(j));
	//			int a=conflActs.at(j);
	//			int t=conflActs.removeAll(a);
	//			assert(t==1);
	//		}
	//		assert(sorted.count()==conflActivities[newtime].count());
	//		conflActivities[newtime]=sorted;
	//
	// /*
	// for(int k=0; k<conflActivities[newtime].count()-1; k++){
	// 	int a1=conflActivities[newtime].at(k);
	// 	int a2=conflActivities[newtime].at(k+1);
	//
	// 	int i1, i2;
	// 	for(i1=0; i1<gt.rules.nInternalActivities; i1++)
	// 		if(permutation[i1]==a1)
	// 			break;
	// 	assert(i1<gt.rules.nInternalActivities);
	//
	// 	for(i2=0; i2<gt.rules.nInternalActivities; i2++)
	// 		if(permutation[i2]==a2)
	// 			break;
	// 	assert(i2<gt.rules.nInternalActivities);
	//
	// 	assert(i1<i2);
	// }*/
#endif

			///////////////////////////////
			//5.0.0-preview28
			//no conflicting activities for this timeslot - place the activity and return

#if nMinDaysBroken_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
			if (GlobalMembersGenerate.nConflActivitiesL[level, newtime] == 0 && GlobalMembersGenerate.nMinDaysBrokenL[level, newtime] == 0.0)
#else
			if (nConflActivities[newtime] == 0 && GlobalMembersGenerate.nMinDaysBrokenL[level, newtime] == 0.0)
#endif
#else
#if nConflActivities_ConditionalDefinition1
			if (GlobalMembersGenerate.nConflActivitiesL[level, newtime] == 0 && nMinDaysBroken[newtime] == 0.0)
#else
			if (nConflActivities[newtime] == 0 && nMinDaysBroken[newtime] == 0.0)
#endif
#endif
			{
				Debug.Assert(c.times[ai] == GlobalMembersTimetable_defs.UNALLOCATED_TIME || (GlobalMembersGenerate_pre.fixedTimeActivity[ai] && !GlobalMembersGenerate_pre.fixedSpaceActivity[ai]));

				if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME && GlobalMembersGenerate_pre.fixedTimeActivity[ai] && !GlobalMembersGenerate_pre.fixedSpaceActivity[ai])
					Debug.Assert(c.times[ai] == newtime);

#if conflActivities_ConditionalDefinition1
				Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == 0);
#else
				Debug.Assert(conflActivities[newtime].count() == 0);
#endif

				GlobalMembersGenerate.restoreActIndex[GlobalMembersGenerate.nRestore] = ai;
				GlobalMembersGenerate.restoreTime[GlobalMembersGenerate.nRestore] = c.times[ai];
				GlobalMembersGenerate.restoreRoom[GlobalMembersGenerate.nRestore] = c.rooms[ai];
				GlobalMembersGenerate.nRestore++;

				//5.0.0-preview25
				Debug.Assert(GlobalMembersGenerate.swappedActivities[ai]);

#if selectedRoom_ConditionalDefinition1
				moveActivity(ai, c.times[ai], newtime, c.rooms[ai], GlobalMembersGenerate.selectedRoomL[level, newtime]);
#else
				moveActivity(ai, c.times[ai], newtime, c.rooms[ai], selectedRoom[newtime]);
#endif

				GlobalMembersGenerate.foundGoodSwap = true;
				return;
			}
			///////////////////////////////



#if conflActivities_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
			Debug.Assert(GlobalMembersGenerate.nConflActivitiesL[level, newtime] == GlobalMembersGenerate.conflActivitiesL[level, newtime].count());
#else
			Debug.Assert(nConflActivities[newtime] == GlobalMembersGenerate.conflActivitiesL[level, newtime].count());
#endif
#else
#if nConflActivities_ConditionalDefinition1
			Debug.Assert(GlobalMembersGenerate.nConflActivitiesL[level, newtime] == conflActivities[newtime].count());
#else
			Debug.Assert(nConflActivities[newtime] == conflActivities[newtime].count());
#endif
#endif
		}


		//for(int i=0; i<gt.rules.nHoursPerWeek; i++)
		//	conflPerm[perm[i]]=perm[i];

		//DEPRECATED
		//Sorting - O(n^2) - should be improved?
		//The sorting below is not stable (I hope I am not mistaking) - but this should not be a problem.
	/*	for(int i=0; i<gt.rules.nHoursPerWeek; i++)
			for(int j=i+1; j<gt.rules.nHoursPerWeek; j++)
				if(nConflActivities[conflPerm[perm[i]]]>nConflActivities[conflPerm[perm[j]]]
				 || (nConflActivities[conflPerm[perm[i]]]==nConflActivities[conflPerm[perm[j]]]
				 && nMinDaysBroken[conflPerm[perm[i]]]>nMinDaysBroken[conflPerm[perm[j]]] )){
					int t=conflPerm[perm[i]];
					conflPerm[perm[i]]=conflPerm[perm[j]];
					conflPerm[perm[j]]=t;
				}*/

		//O(n*log(n)) stable sorting
		GlobalMembersGenerate.currentLevel = level;
#if perm_ConditionalDefinition1
		qStableSort(GlobalMembersGenerate.permL[level] + 0, GlobalMembersGenerate.permL[level] + gt.rules.nHoursPerWeek, GlobalMembersGenerate.compareFunctionGenerate);
#else
		qStableSort(perm + 0, perm + gt.rules.nHoursPerWeek, GlobalMembersGenerate.compareFunctionGenerate);
#endif

		/*cout<<"perm[i]: ";
		for(int i=0; i<gt.rules.nHoursPerWeek; i++)
			cout<<perm[i]<<" ";
		cout<<endl;
		cout<<"conflPerm[perm[i]]: ";
		for(int i=0; i<gt.rules.nHoursPerWeek; i++)
			cout<<conflPerm[perm[i]]<<" ";
		cout<<endl;
		cout<<"nConflActivities[i]: ";
		for(int i=0; i<gt.rules.nHoursPerWeek; i++)
			cout<<nConflActivities[i]<<" ";
		cout<<endl;
		assert(0);*/

		for (int i = 1; i < gt.rules.nHoursPerWeek; i++)
		{
#if nMinDaysBroken_ConditionalDefinition1
#if perm_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
			Debug.Assert((GlobalMembersGenerate.nConflActivitiesL[level, GlobalMembersGenerate.permL[level, i - 1]] < GlobalMembersGenerate.nConflActivitiesL[level, GlobalMembersGenerate.permL[level, i]]) || ((GlobalMembersGenerate.nConflActivitiesL[level, GlobalMembersGenerate.permL[level, i - 1]] == GlobalMembersGenerate.nConflActivitiesL[level, GlobalMembersGenerate.permL[level, i]]) && (GlobalMembersGenerate.nMinDaysBrokenL[level, GlobalMembersGenerate.permL[level, i - 1]] <= GlobalMembersGenerate.nMinDaysBrokenL[level, GlobalMembersGenerate.permL[level, i]])));
#else
			Debug.Assert((nConflActivities[GlobalMembersGenerate.permL[level, i - 1]] < nConflActivities[GlobalMembersGenerate.permL[level, i]]) || ((nConflActivities[GlobalMembersGenerate.permL[level, i - 1]] == nConflActivities[GlobalMembersGenerate.permL[level, i]]) && (GlobalMembersGenerate.nMinDaysBrokenL[level, GlobalMembersGenerate.permL[level, i - 1]] <= GlobalMembersGenerate.nMinDaysBrokenL[level, GlobalMembersGenerate.permL[level, i]])));
#endif
#else
#if nConflActivities_ConditionalDefinition1
			Debug.Assert((GlobalMembersGenerate.nConflActivitiesL[level, perm[i - 1]] < GlobalMembersGenerate.nConflActivitiesL[level, perm[i]]) || ((GlobalMembersGenerate.nConflActivitiesL[level, perm[i - 1]] == GlobalMembersGenerate.nConflActivitiesL[level, perm[i]]) && (GlobalMembersGenerate.nMinDaysBrokenL[level, perm[i - 1]] <= GlobalMembersGenerate.nMinDaysBrokenL[level, perm[i]])));
#else
			Debug.Assert((nConflActivities[perm[i - 1]] < nConflActivities[perm[i]]) || ((nConflActivities[perm[i - 1]] == nConflActivities[perm[i]]) && (GlobalMembersGenerate.nMinDaysBrokenL[level, perm[i - 1]] <= GlobalMembersGenerate.nMinDaysBrokenL[level, perm[i]])));
#endif
#endif
#else
#if perm_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
			Debug.Assert((GlobalMembersGenerate.nConflActivitiesL[level, GlobalMembersGenerate.permL[level, i - 1]] < GlobalMembersGenerate.nConflActivitiesL[level, GlobalMembersGenerate.permL[level, i]]) || ((GlobalMembersGenerate.nConflActivitiesL[level, GlobalMembersGenerate.permL[level, i - 1]] == GlobalMembersGenerate.nConflActivitiesL[level, GlobalMembersGenerate.permL[level, i]]) && (nMinDaysBroken[GlobalMembersGenerate.permL[level, i - 1]] <= nMinDaysBroken[GlobalMembersGenerate.permL[level, i]])));
#else
			Debug.Assert((nConflActivities[GlobalMembersGenerate.permL[level, i - 1]] < nConflActivities[GlobalMembersGenerate.permL[level, i]]) || ((nConflActivities[GlobalMembersGenerate.permL[level, i - 1]] == nConflActivities[GlobalMembersGenerate.permL[level, i]]) && (nMinDaysBroken[GlobalMembersGenerate.permL[level, i - 1]] <= nMinDaysBroken[GlobalMembersGenerate.permL[level, i]])));
#endif
#else
#if nConflActivities_ConditionalDefinition1
			Debug.Assert((GlobalMembersGenerate.nConflActivitiesL[level, perm[i - 1]] < GlobalMembersGenerate.nConflActivitiesL[level, perm[i]]) || ((GlobalMembersGenerate.nConflActivitiesL[level, perm[i - 1]] == GlobalMembersGenerate.nConflActivitiesL[level, perm[i]]) && (nMinDaysBroken[perm[i - 1]] <= nMinDaysBroken[perm[i]])));
#else
			Debug.Assert((nConflActivities[perm[i - 1]] < nConflActivities[perm[i]]) || ((nConflActivities[perm[i - 1]] == nConflActivities[perm[i]]) && (nMinDaysBroken[perm[i - 1]] <= nMinDaysBroken[perm[i]])));
#endif
#endif
#endif
		}

		/*for(int i=0; i<gt.rules.nHoursPerWeek; i++){
			int newtime=conflPerm[perm[i]];
			if(nConflActivities[newtime]!=MAX_ACTIVITIES)
				foreach(int ai2, conflActivities[newtime])
					assert(!swappedActivities[ai2]);
		}*/

#if perm_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
		if (level == 0 && (GlobalMembersGenerate.nConflActivitiesL[level, GlobalMembersGenerate.permL[level, 0]] == GlobalMembersTimetable_defs.MAX_ACTIVITIES))
#else
		if (level == 0 && (nConflActivities[GlobalMembersGenerate.permL[level, 0]] == GlobalMembersTimetable_defs.MAX_ACTIVITIES))
#endif
#else
#if nConflActivities_ConditionalDefinition1
		if (level == 0 && (GlobalMembersGenerate.nConflActivitiesL[level, perm[0]] == GlobalMembersTimetable_defs.MAX_ACTIVITIES))
#else
		if (level == 0 && (nConflActivities[perm[0]] == GlobalMembersTimetable_defs.MAX_ACTIVITIES))
#endif
#endif
		{
			//to check if generation was stopped
	if (this.isThreaded)
	{
				mutex.unlock();
				mutex.lock();
	}
			if (!abortOptimization && activity_count_impossible_tries < GlobalMembersGenerate.MAX_RETRIES_FOR_AN_ACTIVITY_AT_LEVEL_0)
			{
				activity_count_impossible_tries++;
				goto again_if_impossible_activity;
			}
			else
			{
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __LINE__ macro:
	//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent in C# to the C++ __FILE__ macro:
				Console.Write(__FILE__);
				Console.Write(" line ");
				Console.Write(__LINE__);
				Console.Write(" - WARNING - after retrying for ");
				Console.Write(activity_count_impossible_tries);
				Console.Write(" times - no possible time slot for activity with id==");
				Console.Write(gt.rules.internalActivitiesList[ai].id);
				Console.Write("\n");
			}
		}

		if (level == 0)
		{
			/*Matrix1D<int> l0nWrong;
			Matrix1D<int> l0minWrong;
			Matrix1D<int> l0minIndexAct;
			l0nWrong.resize(gt.rules.nHoursPerWeek);
			l0minWrong.resize(gt.rules.nHoursPerWeek);
			l0minIndexAct.resize(gt.rules.nHoursPerWeek);*/

			/*int nWrong[MAX_HOURS_PER_WEEK];
			int minWrong[MAX_HOURS_PER_WEEK];
			int minIndexAct[MAX_HOURS_PER_WEEK];*/

			for (int i = 0; i < gt.rules.nHoursPerWeek; i++)
			{
				GlobalMembersGenerate.l0nWrong[i] = GlobalMembersGenerate.INF;
				GlobalMembersGenerate.l0minWrong[i] = GlobalMembersGenerate.INF;
				GlobalMembersGenerate.l0minIndexAct[i] = gt.rules.nInternalActivities;
			}

			QList<int> tim = new QList<int>();
			for (int i = 0; i < gt.rules.nHoursPerWeek; i++)
#if perm_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
#if roomSlots_ConditionalDefinition1
				if (GlobalMembersGenerate.nConflActivitiesL[level, GlobalMembersGenerate.permL[level, i]] > 0 && GlobalMembersGenerate.nConflActivitiesL[level, GlobalMembersGenerate.permL[level, i]] < GlobalMembersTimetable_defs.MAX_ACTIVITIES && GlobalMembersGenerate.roomSlotsL[level, GlobalMembersGenerate.permL[level, i]] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
#else
				if (GlobalMembersGenerate.nConflActivitiesL[level, GlobalMembersGenerate.permL[level, i]] > 0 && GlobalMembersGenerate.nConflActivitiesL[level, GlobalMembersGenerate.permL[level, i]] < GlobalMembersTimetable_defs.MAX_ACTIVITIES && roomSlots[GlobalMembersGenerate.permL[level, i]] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
#endif
#else
#if roomSlots_ConditionalDefinition1
				if (nConflActivities[GlobalMembersGenerate.permL[level, i]] > 0 && nConflActivities[GlobalMembersGenerate.permL[level, i]] < GlobalMembersTimetable_defs.MAX_ACTIVITIES && GlobalMembersGenerate.roomSlotsL[level, GlobalMembersGenerate.permL[level, i]] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
#else
				if (nConflActivities[GlobalMembersGenerate.permL[level, i]] > 0 && nConflActivities[GlobalMembersGenerate.permL[level, i]] < GlobalMembersTimetable_defs.MAX_ACTIVITIES && roomSlots[GlobalMembersGenerate.permL[level, i]] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
#endif
#endif
#else
#if nConflActivities_ConditionalDefinition1
#if roomSlots_ConditionalDefinition1
				if (GlobalMembersGenerate.nConflActivitiesL[level, perm[i]] > 0 && GlobalMembersGenerate.nConflActivitiesL[level, perm[i]] < GlobalMembersTimetable_defs.MAX_ACTIVITIES && GlobalMembersGenerate.roomSlotsL[level, perm[i]] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
#else
				if (GlobalMembersGenerate.nConflActivitiesL[level, perm[i]] > 0 && GlobalMembersGenerate.nConflActivitiesL[level, perm[i]] < GlobalMembersTimetable_defs.MAX_ACTIVITIES && roomSlots[perm[i]] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
#endif
#else
#if roomSlots_ConditionalDefinition1
				if (nConflActivities[perm[i]] > 0 && nConflActivities[perm[i]] < GlobalMembersTimetable_defs.MAX_ACTIVITIES && GlobalMembersGenerate.roomSlotsL[level, perm[i]] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
#else
				if (nConflActivities[perm[i]] > 0 && nConflActivities[perm[i]] < GlobalMembersTimetable_defs.MAX_ACTIVITIES && roomSlots[perm[i]] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE)
#endif
#endif
#endif
#if perm_ConditionalDefinition1
					tim.append(GlobalMembersGenerate.permL[level, i]);
#else
					tim.append(perm[i]);
#endif
#if perm_ConditionalDefinition1
#if nConflActivities_ConditionalDefinition1
			if (tim.count() == 0 && GlobalMembersGenerate.nConflActivitiesL[level, GlobalMembersGenerate.permL[level, 0]] == GlobalMembersTimetable_defs.MAX_ACTIVITIES)
#else
			if (tim.count() == 0 && nConflActivities[GlobalMembersGenerate.permL[level, 0]] == GlobalMembersTimetable_defs.MAX_ACTIVITIES)
#endif
#else
#if nConflActivities_ConditionalDefinition1
			if (tim.count() == 0 && GlobalMembersGenerate.nConflActivitiesL[level, perm[0]] == GlobalMembersTimetable_defs.MAX_ACTIVITIES)
#else
			if (tim.count() == 0 && nConflActivities[perm[0]] == GlobalMembersTimetable_defs.MAX_ACTIVITIES)
#endif
#endif
			{
				//cout<<__FILE__<<" line "<<__LINE__<<" - WARNING - no possible time slot for activity with id=="<<
				// gt.rules.internalActivitiesList[ai].id<<endl;

				GlobalMembersGenerate.impossibleActivity = true;
			}
			if (tim.count() > 0)
			{
				foreach (int i, tim)
				{
					int cnt = 0;
					int m = gt.rules.nInternalActivities;
#if conflActivities_ConditionalDefinition1
					foreach (int aii, GlobalMembersGenerate.conflActivitiesL[level, i])
#else
					foreach (int aii, conflActivities[i])
#endif
					{
						if (GlobalMembersGenerate.triedRemovals(aii,c.times[aii]) > 0)
							cnt += GlobalMembersGenerate.triedRemovals(aii,c.times[aii]);

						if (GlobalMembersGenerate.l0minWrong[i] > GlobalMembersGenerate.triedRemovals(aii,c.times[aii]))
							GlobalMembersGenerate.l0minWrong[i] = GlobalMembersGenerate.triedRemovals(aii,c.times[aii]);

						int j = GlobalMembersGenerate.invPermutation[aii];
						if (m > j)
							m = j;
					}
					GlobalMembersGenerate.l0nWrong[i] = cnt;
					GlobalMembersGenerate.l0minIndexAct[i] = m;
				}

				int optMinIndex = gt.rules.nInternalActivities;
				int optNWrong = GlobalMembersGenerate.INF;
				int optMinWrong = GlobalMembersGenerate.INF;
				int optNConflActs = gt.rules.nInternalActivities;
				int j = -1;

				//bool chooseRandom = (randomKnuth()%20 == 0);

				foreach (int i, tim)
				{
					//choose a random time out of these with minimum number of wrongly replaced activities
#if nConflActivities_ConditionalDefinition1
					if (optMinWrong > GlobalMembersGenerate.l0minWrong[i] || (optMinWrong == GlobalMembersGenerate.l0minWrong[i] && optNWrong > GlobalMembersGenerate.l0nWrong[i]) || (optMinWrong == GlobalMembersGenerate.l0minWrong[i] && optNWrong == GlobalMembersGenerate.l0nWrong[i] && optNConflActs > GlobalMembersGenerate.nConflActivitiesL[level, i]) || (optMinWrong == GlobalMembersGenerate.l0minWrong[i] && optNWrong == GlobalMembersGenerate.l0nWrong[i] && optNConflActs == GlobalMembersGenerate.nConflActivitiesL[level, i] && optMinIndex > GlobalMembersGenerate.l0minIndexAct[i]))
#else
					if (optMinWrong > GlobalMembersGenerate.l0minWrong[i] || (optMinWrong == GlobalMembersGenerate.l0minWrong[i] && optNWrong > GlobalMembersGenerate.l0nWrong[i]) || (optMinWrong == GlobalMembersGenerate.l0minWrong[i] && optNWrong == GlobalMembersGenerate.l0nWrong[i] && optNConflActs > nConflActivities[i]) || (optMinWrong == GlobalMembersGenerate.l0minWrong[i] && optNWrong == GlobalMembersGenerate.l0nWrong[i] && optNConflActs == nConflActivities[i] && optMinIndex > GlobalMembersGenerate.l0minIndexAct[i]))
#endif
					{
						optNWrong = GlobalMembersGenerate.l0nWrong[i];
						optMinWrong = GlobalMembersGenerate.l0minWrong[i];
#if nConflActivities_ConditionalDefinition1
						optNConflActs = GlobalMembersGenerate.nConflActivitiesL[level, i];
#else
						optNConflActs = nConflActivities[i];
#endif
						optMinIndex = GlobalMembersGenerate.l0minIndexAct[i];
						j = i;
					}
				}

				Debug.Assert(j >= 0);
				QList<int> tim2 = new QList<int>();
#if nConflActivities_ConditionalDefinition1
				foreach (int i, tim) if (optNWrong == GlobalMembersGenerate.l0nWrong[i] && GlobalMembersGenerate.l0minWrong[i] == optMinWrong && optNConflActs == GlobalMembersGenerate.nConflActivitiesL[level, i] && optMinIndex == GlobalMembersGenerate.l0minIndexAct[i]) tim2.append(i);
#else
				foreach (int i, tim) if (optNWrong == GlobalMembersGenerate.l0nWrong[i] && GlobalMembersGenerate.l0minWrong[i] == optMinWrong && optNConflActs == nConflActivities[i] && optMinIndex == GlobalMembersGenerate.l0minIndexAct[i]) tim2.append(i);
#endif
				Debug.Assert(tim2.count() > 0);
				int rnd = GlobalMembersTimetable_defs.randomKnuth(tim2.count());
				j = tim2.at(rnd);

				Debug.Assert(j >= 0);
				GlobalMembersGenerate.timeSlot = j;
#if roomSlots_ConditionalDefinition1
				Debug.Assert(GlobalMembersGenerate.roomSlotsL[level, j] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE);
#else
				Debug.Assert(roomSlots[j] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE);
#endif
#if roomSlots_ConditionalDefinition1
				GlobalMembersGenerate.roomSlot = GlobalMembersGenerate.roomSlotsL[level, j];
#else
				GlobalMembersGenerate.roomSlot = roomSlots[j];
#endif

				//conflActivitiesTimeSlot=conflActivities[timeSlot];
				GlobalMembersGenerate.conflActivitiesTimeSlot.clear();
#if conflActivities_ConditionalDefinition1
				foreach (int a, GlobalMembersGenerate.conflActivitiesL[level, GlobalMembersGenerate.timeSlot]) GlobalMembersGenerate.conflActivitiesTimeSlot.append(a);
#else
				foreach (int a, conflActivities[GlobalMembersGenerate.timeSlot]) GlobalMembersGenerate.conflActivitiesTimeSlot.append(a);
#endif
			}
		}

		//int nExplored=0;

		for (int i = 0; i < gt.rules.nHoursPerWeek; i++)
		{
#if perm_ConditionalDefinition1
			int newtime = GlobalMembersGenerate.permL[level, i];
#else
			int newtime = perm[i];
#endif
#if nConflActivities_ConditionalDefinition1
			if (GlobalMembersGenerate.nConflActivitiesL[level, newtime] >= GlobalMembersTimetable_defs.MAX_ACTIVITIES)
#else
			if (nConflActivities[newtime] >= GlobalMembersTimetable_defs.MAX_ACTIVITIES)
#endif
				break;

			Debug.Assert(c.times[ai] == GlobalMembersTimetable_defs.UNALLOCATED_TIME || (GlobalMembersGenerate_pre.fixedTimeActivity[ai] && !GlobalMembersGenerate_pre.fixedSpaceActivity[ai]));

			//no conflicting activities for this timeslot - place the activity and return
#if nConflActivities_ConditionalDefinition1
			if (GlobalMembersGenerate.nConflActivitiesL[level, newtime] == 0)
#else
			if (nConflActivities[newtime] == 0)
#endif
			{
				Debug.Assert(c.times[ai] == GlobalMembersTimetable_defs.UNALLOCATED_TIME || (GlobalMembersGenerate_pre.fixedTimeActivity[ai] && !GlobalMembersGenerate_pre.fixedSpaceActivity[ai]));

				if (c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME && GlobalMembersGenerate_pre.fixedTimeActivity[ai] && !GlobalMembersGenerate_pre.fixedSpaceActivity[ai])
					Debug.Assert(c.times[ai] == newtime);

#if conflActivities_ConditionalDefinition1
				Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].count() == 0);
#else
				Debug.Assert(conflActivities[newtime].count() == 0);
#endif

				GlobalMembersGenerate.restoreActIndex[GlobalMembersGenerate.nRestore] = ai;
				GlobalMembersGenerate.restoreTime[GlobalMembersGenerate.nRestore] = c.times[ai];
				GlobalMembersGenerate.restoreRoom[GlobalMembersGenerate.nRestore] = c.rooms[ai];
				GlobalMembersGenerate.nRestore++;

				//5.0.0-preview25
				Debug.Assert(GlobalMembersGenerate.swappedActivities[ai]);

#if selectedRoom_ConditionalDefinition1
				moveActivity(ai, c.times[ai], newtime, c.rooms[ai], GlobalMembersGenerate.selectedRoomL[level, newtime]);
#else
				moveActivity(ai, c.times[ai], newtime, c.rooms[ai], selectedRoom[newtime]);
#endif

				GlobalMembersGenerate.foundGoodSwap = true;
				return;
			}
			else
			{
				/*foreach(int ai2, conflActivities[newtime])
					assert(!swappedActivities[ai2]);*/

				if (level == GlobalMembersGenerate.level_limit - 1)
				{
					//cout<<"level_limit-1==level=="<<level<<", for activity with id "<<gt.rules.internalActivitiesList[ai].id<<" returning"<<endl;
					GlobalMembersGenerate.foundGoodSwap = false;
					break;
				}

				if (GlobalMembersGenerate.ncallsrandomswap >= GlobalMembersGenerate.limitcallsrandomswap)
				{
					GlobalMembersGenerate.foundGoodSwap = false;
					break;
				}

				/*
				//sort activities in decreasing order of difficulty.
				//if the index of the activity in "permutation" is smaller, the act. is more difficult
				QList<int> sorted;
				QList<int> conflActs=conflActivities[newtime];
				while(conflActs.count()>0){
					int m=gt.rules.nInternalActivities;
					int j=-1;
					for(int k=0; k<conflActs.count(); k++){
						int a=conflActs.at(k);
						if(invPermutation[a]<m){
							m=invPermutation[a];
							j=k;
						}
					}
					assert(j>=0);
				
					sorted.append(conflActs.at(j));
					int a=conflActs.at(j);
					int t=conflActs.removeAll(a);
					assert(t==1);
				}
				assert(sorted.count()==conflActivities[newtime].count());
				conflActivities[newtime]=sorted;*/

				int ok = true;
				//cout<<"LEVEL=="<<level<<", for activity ai with id=="<<gt.rules.internalActivitiesList[ai].id<<", list of conflActivities ids: ";
#if conflActivities_ConditionalDefinition1
				foreach (int a, GlobalMembersGenerate.conflActivitiesL[level, newtime])
#else
				foreach (int a, conflActivities[newtime])
#endif
				{
					//cout<<gt.rules.internalActivitiesList[a].id<<" ";
					if (GlobalMembersGenerate.swappedActivities[a])
					{
						Debug.Assert(0);
						//cout<<"here ";
						ok = false;
						break;
					}
					Debug.Assert(!(GlobalMembersGenerate_pre.fixedTimeActivity[a] && GlobalMembersGenerate_pre.fixedSpaceActivity[a]));
				}
				//cout<<endl;

				if (ok == 0)
				{
					Debug.Assert(0);
					continue;
				}

				//////////////place it at a new time

				int oldNRestore = GlobalMembersGenerate.nRestore;

				////////////////
				QList<int> oldacts = new QList<int>();
				QList<int> oldtimes = new QList<int>();
				QList<int> oldrooms = new QList<int>();

				if (true) //ok
				{
#if conflActivities_ConditionalDefinition1
					Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].size() > 0);
#else
					Debug.Assert(conflActivities[newtime].size() > 0);
#endif

#if conflActivities_ConditionalDefinition1
					foreach (int a, GlobalMembersGenerate.conflActivitiesL[level, newtime])
#else
					foreach (int a, conflActivities[newtime])
#endif
					{
						//cout<<"Level=="<<level<<", conflicting act. id=="<<gt.rules.internalActivitiesList[a].id<<", old time=="<<c.times[a]<<endl;

						GlobalMembersGenerate.restoreActIndex[GlobalMembersGenerate.nRestore] = a;
						GlobalMembersGenerate.restoreTime[GlobalMembersGenerate.nRestore] = c.times[a];
						GlobalMembersGenerate.restoreRoom[GlobalMembersGenerate.nRestore] = c.rooms[a];
						GlobalMembersGenerate.nRestore++;

						oldacts.append(a);
						oldtimes.append(c.times[a]);
						oldrooms.append(c.rooms[a]);
						Debug.Assert(c.times[a] != GlobalMembersTimetable_defs.UNALLOCATED_TIME);
						Debug.Assert(c.rooms[a] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE);
						int nt = GlobalMembersTimetable_defs.UNALLOCATED_TIME;
						if (GlobalMembersGenerate_pre.fixedTimeActivity[a] && !GlobalMembersGenerate_pre.fixedSpaceActivity[a])
							nt = c.times[a];
						//cout<<"level=="<<level<<", unallocating activity with id=="<<gt.rules.internalActivitiesList[a].id<<endl;
						moveActivity(a, c.times[a], nt, c.rooms[a], GlobalMembersTimetable_defs.UNALLOCATED_SPACE);

						//swappedActivities[a]=true;
					}
				}
#if conflActivities_ConditionalDefinition1
				Debug.Assert(oldacts.count() == GlobalMembersGenerate.conflActivitiesL[level, newtime].count());
#else
				Debug.Assert(oldacts.count() == conflActivities[newtime].count());
#endif
#if conflActivities_ConditionalDefinition1
				Debug.Assert(oldtimes.count() == GlobalMembersGenerate.conflActivitiesL[level, newtime].count());
#else
				Debug.Assert(oldtimes.count() == conflActivities[newtime].count());
#endif
#if conflActivities_ConditionalDefinition1
				Debug.Assert(oldrooms.count() == GlobalMembersGenerate.conflActivitiesL[level, newtime].count());
#else
				Debug.Assert(oldrooms.count() == conflActivities[newtime].count());
#endif
				////////////////

				int oldtime = c.times[ai];
				int oldroom = c.rooms[ai];
				//if(c.times[ai]!=UNALLOCATED_TIME){
					GlobalMembersGenerate.restoreActIndex[GlobalMembersGenerate.nRestore] = ai;
					GlobalMembersGenerate.restoreTime[GlobalMembersGenerate.nRestore] = oldtime;
					GlobalMembersGenerate.restoreRoom[GlobalMembersGenerate.nRestore] = oldroom;
					GlobalMembersGenerate.nRestore++;
				//}

				//cout<<"Level=="<<level<<", act. id=="<<gt.rules.internalActivitiesList[ai].id<<", old time=="<<c.times[ai]<<endl;

#if selectedRoom_ConditionalDefinition1
				moveActivity(ai, oldtime, newtime, oldroom, GlobalMembersGenerate.selectedRoomL[level, newtime]);
#else
				moveActivity(ai, oldtime, newtime, oldroom, selectedRoom[newtime]);
#endif
				//cout<<"level=="<<level<<", activity with id=="<<gt.rules.internalActivitiesList[ai].id<<
				// " goes from time: "<<oldtime<<" to time: "<<newtime<<endl;
				//////////////////

				if (true)
#if conflActivities_ConditionalDefinition1
					foreach (int a, GlobalMembersGenerate.conflActivitiesL[level, newtime]) GlobalMembersGenerate.swappedActivities[a] = true;
#else
					foreach (int a, conflActivities[newtime]) GlobalMembersGenerate.swappedActivities[a] = true;
#endif

				GlobalMembersGenerate.foundGoodSwap = false;

				ok = false;
				if (true)
				{
#if conflActivities_ConditionalDefinition1
					Debug.Assert(GlobalMembersGenerate.conflActivitiesL[level, newtime].size() > 0);
#else
					Debug.Assert(conflActivities[newtime].size() > 0);
#endif
					ok = true;

#if conflActivities_ConditionalDefinition1
					foreach (int a, GlobalMembersGenerate.conflActivitiesL[level, newtime])
#else
					foreach (int a, conflActivities[newtime])
#endif
					{
						randomSwap(a, level + 1);
						if (!GlobalMembersGenerate.foundGoodSwap)
						{
							ok = false;
							break;
						}
						Debug.Assert(c.times[a] != GlobalMembersTimetable_defs.UNALLOCATED_TIME);
						Debug.Assert(GlobalMembersGenerate.foundGoodSwap);
						GlobalMembersGenerate.foundGoodSwap = false;
					}
				}

				if (ok != 0)
				{
#if conflActivities_ConditionalDefinition1
					foreach (int a, GlobalMembersGenerate.conflActivitiesL[level, newtime]) assert(c.times[a] != GlobalMembersTimetable_defs.UNALLOCATED_TIME);
#else
					foreach (int a, conflActivities[newtime]) assert(c.times[a] != GlobalMembersTimetable_defs.UNALLOCATED_TIME);
#endif
					Debug.Assert(c.times[ai] != GlobalMembersTimetable_defs.UNALLOCATED_TIME);

					GlobalMembersGenerate.foundGoodSwap = true;
					return;
				}

				/*if(1)
					foreach(int a, conflActivities[newtime])
						swappedActivities[a]=false;*/

				//////////////restore times from the restore list
				for (int j = GlobalMembersGenerate.nRestore-1; j >= oldNRestore; j--)
				{
					//assert(c.times[ai]!=UNALLOCATED_TIME);

					int aii = GlobalMembersGenerate.restoreActIndex[j];
					oldtime = GlobalMembersGenerate.restoreTime[j];
					oldroom = GlobalMembersGenerate.restoreRoom[j];

					/*if(aii!=ai)
						cout<<"Level=="<<level<<", activity with id=="<<gt.rules.internalActivitiesList[aii].id<<" should change swapped state from true to false"<<endl;
					else
						cout<<"Level=="<<level<<", activity with id=="<<gt.rules.internalActivitiesList[aii].id<<" should remain swapped==true"<<endl;
					*/

					if (aii != ai)
					{
						//assert(swappedActivities[aii]);
						GlobalMembersGenerate.swappedActivities[aii] = false;
					}
					else
					{
						Debug.Assert(GlobalMembersGenerate.swappedActivities[aii]);
						//swappedActivities[aii]=false;
					}

					//assert(oldtime!=UNALLOCATED_TIME);

					//cout<<"level=="<<level<<", activity with id=="<<gt.rules.internalActivitiesList[aii].id<<
					// " restored from time: "<<c.times[aii]<<" to time: "<<oldtime<<endl;
					moveActivity(aii, c.times[aii], oldtime, c.rooms[aii], oldroom);

					//cout<<"Level=="<<level<<", act. id=="<<gt.rules.internalActivitiesList[ai].id<<", restoring old time=="<<c.times[ai]<<endl;

					//assert(oldtime!=UNALLOCATED_TIME);
				}
				GlobalMembersGenerate.nRestore = oldNRestore;

				//////////////////////////////
#if conflActivities_ConditionalDefinition1
				foreach (int a, GlobalMembersGenerate.conflActivitiesL[level, newtime])
#else
				foreach (int a, conflActivities[newtime])
#endif
				{
					Debug.Assert(c.times[a] != GlobalMembersTimetable_defs.UNALLOCATED_TIME);
					Debug.Assert(c.rooms[a] != GlobalMembersTimetable_defs.UNALLOCATED_SPACE);
					Debug.Assert(!GlobalMembersGenerate.swappedActivities[a]);
					Debug.Assert(!(GlobalMembersGenerate_pre.fixedTimeActivity[a] && GlobalMembersGenerate_pre.fixedSpaceActivity[a]));
				}
				//////////////////////////////

				Debug.Assert(!GlobalMembersGenerate.foundGoodSwap);

				if (level >= 5) //7 also might be used? This is a value found practically, has no theoretical meaning probably
					return;
			}
		}
	}

//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
signals:
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//	void activityPlaced(int NamelessParameter);

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//	void simulationFinished();

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//	void impossibleToSolve();

	private bool isThreaded;
}


//C++ TO C# CONVERTER WARNING: The declaration of the following method implementation was not found:
//ORIGINAL LINE: Generate::Generate()


//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define nMinDaysBroken (nMinDaysBrokenL[level])
#define nMinDaysBroken
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define selectedRoom (selectedRoomL[level])
#define selectedRoom
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define perm (permL[level])
#define perm
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define conflActivities (conflActivitiesL[level])
#define conflActivities
//#define conflPerm				(conflPermL[level])
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define nConflActivities (nConflActivitiesL[level])
#define nConflActivities
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define roomSlots (roomSlotsL[level])
#define roomSlots



public partial class Generate
{
	public Generate()
	{
	}
}