using System.Diagnostics;

public static class GlobalMembersLockunlock
{


	#if NDEBUG
	#endif

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool students_schedule_ready;
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool teachers_schedule_ready;
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern bool rooms_schedule_ready;

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Solution best_solution;

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern Timetable gt;

	public static QSet<int> idsOfLockedTime = new QSet<int>();
	public static QSet<int> idsOfLockedSpace = new QSet<int>();
	public static QSet<int> idsOfPermanentlyLockedTime = new QSet<int>();
	public static QSet<int> idsOfPermanentlyLockedSpace = new QSet<int>();

	public static CommunicationSpinBox communicationSpinBox = new CommunicationSpinBox();
}

/*
File lockunlock.cpp
*/

/***************************************************************************
                                FET
                          -------------------
   copyright            : (C) by Lalescu Liviu
    email                : Please see http://lalescu.ro/liviu/ for details about contacting Liviu Lalescu (in particular, you can find here the e-mail address)
 ***************************************************************************
                          lockunlock.cpp  -  description
                             -------------------
    begin                : Dec 2008
    copyright            : (C) by Liviu Lalescu (http://lalescu.ro/liviu/) and Volker Dirr (http://www.timetabling.de/)
 ***************************************************************************
 *                                                                         *
 *   FET program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 ***************************************************************************/

//#include <QSpinBox>

//extern QSpinBox* pcommunicationSpinBox;


/*
File lockunlock.h
*/

/***************************************************************************
                                FET
                          -------------------
   copyright            : (C) by Lalescu Liviu
    email                : Please see http://lalescu.ro/liviu/ for details about contacting Liviu Lalescu (in particular, you can find here the e-mail address)
 ***************************************************************************
                          lockunlock.h  -  description
                             -------------------
    begin                : Dec 2008
    copyright            : (C) by Liviu Lalescu (http://lalescu.ro/liviu/) and Volker Dirr (http://www.timetabling.de/)
 ***************************************************************************
 *                                                                         *
 *   FET program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 ***************************************************************************/



public partial class CommunicationSpinBox: QObject
{
//C++ TO C# CONVERTER TODO TASK: C# does not allow bit fields:
	private Q_OBJECT private: int value;
	private int maxValue;
	private int minValue;

	public CommunicationSpinBox()
	{
		minValue = 0;
		maxValue = 9;
		value = 0;
	}
	public void Dispose()
	{
	}

//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
signals:
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//	int valueChanged(int newValue);

public slots: void increaseValue();
}


public class LockUnlock
{
	public static void computeLockedUnlockedActivitiesTimeSpace()
	{
		//by Volker Dirr
		GlobalMembersLockunlock.idsOfLockedTime.clear();
		GlobalMembersLockunlock.idsOfLockedSpace.clear();
		GlobalMembersLockunlock.idsOfPermanentlyLockedTime.clear();
		GlobalMembersLockunlock.idsOfPermanentlyLockedSpace.clear();

		foreach (TimeConstraint * tc, gt.rules.timeConstraintsList)
		{
			if (tc.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITY_PREFERRED_STARTING_TIME && tc.weightPercentage == 100.0 && tc.active)
			{
				ConstraintActivityPreferredStartingTime c = (ConstraintActivityPreferredStartingTime) tc;
				if (c.day >= 0 && c.hour >= 0)
				{
					if (c.permanentlyLocked)
						GlobalMembersLockunlock.idsOfPermanentlyLockedTime.insert(c.activityId);
					else
						GlobalMembersLockunlock.idsOfLockedTime.insert(c.activityId);
				}
			}
		}

		foreach (SpaceConstraint * sc, gt.rules.spaceConstraintsList)
		{
			if (sc.type == GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITY_PREFERRED_ROOM && sc.weightPercentage == 100.0 && sc.active)
			{
				ConstraintActivityPreferredRoom c = (ConstraintActivityPreferredRoom) sc;

				if (c.permanentlyLocked)
					GlobalMembersLockunlock.idsOfPermanentlyLockedSpace.insert(c.activityId);
				else
					GlobalMembersLockunlock.idsOfLockedSpace.insert(c.activityId);
			}
		}
	}
	public static void computeLockedUnlockedActivitiesOnlyTime()
	{
		//by Volker Dirr
		GlobalMembersLockunlock.idsOfLockedTime.clear();
		GlobalMembersLockunlock.idsOfPermanentlyLockedTime.clear();

		foreach (TimeConstraint * tc, gt.rules.timeConstraintsList)
		{
			if (tc.type == GlobalMembersTimeconstraint.CONSTRAINT_ACTIVITY_PREFERRED_STARTING_TIME && tc.weightPercentage == 100.0 && tc.active)
			{
				ConstraintActivityPreferredStartingTime c = (ConstraintActivityPreferredStartingTime) tc;
				if (c.day >= 0 && c.hour >= 0)
				{
					if (c.permanentlyLocked)
						GlobalMembersLockunlock.idsOfPermanentlyLockedTime.insert(c.activityId);
					else
						GlobalMembersLockunlock.idsOfLockedTime.insert(c.activityId);
				}
			}
		}
	}
	public static void computeLockedUnlockedActivitiesOnlySpace()
	{
		//by Volker Dirr
		GlobalMembersLockunlock.idsOfLockedSpace.clear();
		GlobalMembersLockunlock.idsOfPermanentlyLockedSpace.clear();

		foreach (SpaceConstraint * sc, gt.rules.spaceConstraintsList)
		{
			if (sc.type == GlobalMembersSpaceconstraint.CONSTRAINT_ACTIVITY_PREFERRED_ROOM && sc.weightPercentage == 100.0 && sc.active)
			{
				ConstraintActivityPreferredRoom c = (ConstraintActivityPreferredRoom) sc;

				if (c.permanentlyLocked)
					GlobalMembersLockunlock.idsOfPermanentlyLockedSpace.insert(c.activityId);
				else
					GlobalMembersLockunlock.idsOfLockedSpace.insert(c.activityId);
			}
		}
	}

	public static void increaseCommunicationSpinBox()
	{
	/*	assert(pcommunicationSpinBox!=NULL);
	
		int q=pcommunicationSpinBox->value();	//needed to display locked and unlocked times and rooms
		//cout<<"communication spin box old value: "<<pcommunicationSpinBox->value()<<", ";
		q++;
		assert(pcommunicationSpinBox->maximum()>pcommunicationSpinBox->minimum());
		if(q > pcommunicationSpinBox->maximum())
			q=pcommunicationSpinBox->minimum();
		pcommunicationSpinBox->setValue(q);*/
		//cout<<"changed to new value: "<<pcommunicationSpinBox->value()<<endl;

		GlobalMembersLockunlock.communicationSpinBox.increaseValue();
	}
}

//C++ TO C# CONVERTER WARNING: The declaration of the following method implementation was not found:
//ORIGINAL LINE: void CommunicationSpinBox::increaseValue()



public partial class CommunicationSpinBox
{
	public void increaseValue()
	{
		Debug.Assert(maxValue > minValue);
		Debug.Assert(value >= minValue && value <= maxValue);
		value++;
		if (value > maxValue)
			value = minValue;
    
		//cout<<"comm. spin box: increased value, crt value=="<<value<<endl;
    
		emit(valueChanged(value));
	}
}