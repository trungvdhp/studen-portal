using System.Diagnostics;

public static class GlobalMembersActivity
{

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//void centerWidgetOnScreen(QWidget widget);
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//void forceCenterWidgetOnScreen(QWidget widget);
	//void centerWidgetOnParent(QWidget* widget, QWidget* parent);

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//int maxScreenWidth(QWidget widget);

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//int maxRecommendedWidth(QWidget widget);

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//void saveFETDialogGeometry(QWidget widget, QString alternativeName);
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//void restoreFETDialogGeometry(QWidget widget, QString alternativeName);

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//void setParentAndOtherThings(QWidget widget, QWidget parent);

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//void setStretchAvailabilityTableNicely(QTableWidget notAllowedTimesTable);

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//void setRulesModifiedAndOtherThings(Rules rules);
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//void setRulesUnmodifiedAndOtherThings(Rules rules);


	/*
	File activity.h
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
	//class Activity;
}

/*
File activity.cpp 
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
File centerwidgetonscreen.h
*/

/***************************************************************************
                          centerwidgetonscreen.h  -  description
                             -------------------
    begin                : 13 July 2008
    copyright            : (C) 2008 by Lalescu Liviu
    email                : Please see http://lalescu.ro/liviu/ for details about contacting Liviu Lalescu (in particular, you can find here the e-mail address)
 ***************************************************************************/

/***************************************************************************
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 ***************************************************************************/



//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class QWidget;
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class QTableWidget;

//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class Rules;



/**
This class represents an activity.
<p>
An activity is a certain course (lecture), taught by a certain teacher (or more),
to a certain year (or group, or subgroup) of students (or more).
*/

public class Activity
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(Activity) public: QString comments;

	/**
	The teachers' names.
	*/
	private QStringList teachersNames = new QStringList();

	/**
	The name of the subject.
	*/
	private QString subjectName = new QString();

	/**
	The name of the activity tag.
	*/
	//QString activityTagName;
	private QStringList activityTagsNames = new QStringList();

	/**
	The names of the sets of students involved in this activity (years, groups or subgroups).
	*/
	private QStringList studentsNames = new QStringList();

	/**
	The duration, in hours.
	*/
	private int duration;

	/**
	The parity: weekly (PARITY_WEEKLY) or once at two weeks (PARITY_FORTNIGHTLY).
	*/
	//int parity;

	/**
	This value is used only for split activities (for high-schools).
	If totalDuration==duration, then this activity is not split.
	If totalDuration>duration, then this activity is split.
	*/
	private int totalDuration;

	/**
	A unique ID for any activity. This is NOT the index (activities might be erased,
	but this ID remains the same).
	*/
	private int id;

	/**
	The activities generated from a split activity have the same activityGroupId.
	For non-split activities, activityGroupId==0
	*/
	private int activityGroupId;

	/**
	The number of students who are attending this activity.
	If computeNTotalStudentsFromSets is false, this number
	is given. If it is true, this number should be calculated
	from the sets involved.
	*/
	private int nTotalStudents;

	/**
	If true, we will have to compute the number of total students from the 
	involved students sets. If false, it means that nTotalStudents is given
	and must not be recalculated.
	*/
	private bool computeNTotalStudents;

	/**
	True if this activity is active, that is it will be taken into consideration
	when generating the timetable.
	*/
	private bool active;

	/**
	If the teachers, subject, activity tag, students, duration are identical
	and the activity group id of both of them is 0 or of both of them is != 0, returns true.
	TODO: add a more intelligent comparison
	*/
	private static bool operator == (Activity ImpliedObject, ref Activity a)
	{
		if (ImpliedObject.teachersNames != a.teachersNames)
			return false;
		if (ImpliedObject.subjectName != a.subjectName)
			return false;
		if (ImpliedObject.activityTagsNames != a.activityTagsNames)
			return false;
		if (ImpliedObject.studentsNames != a.studentsNames)
			return false;
		//if(this->duration != a.duration)
		  //  return false;
		if ((ImpliedObject.activityGroupId == 0 && a.activityGroupId != 0) || (ImpliedObject.activityGroupId != 0 && a.activityGroupId == 0))
			return false;
		return true;
	}

	//internal structure

	/**
	The number of teachers who are teaching this activity
	*/
	//int nTeachers;

	/**
	The indices of the teachers who are teaching this activity.
	*/
	//int teachers[MAX_TEACHERS_PER_ACTIVITY];
	private QList<int> iTeachersList = new QList<int>();

	/**
	The index of the subject.
	*/
	private int subjectIndex;

	/**
	The index of the activity tag.
	*/
	private QSet<int> iActivityTagsSet = new QSet<int>();
	//int activityTagIndex;

	/**
	The number of subgroups implied in this activity.
	*/
	//int nSubgroups;

	/**
	The indices of the subgroups implied in this activity.
	*/
	//int subgroups[MAX_SUBGROUPS_PER_ACTIVITY];
	private QList<int> iSubgroupsList = new QList<int>();

	/**
	Simple constructor, used only indirectly by the static variable
	"Activity internalActivitiesList[MAX_ACTIVITIES]".
	Any other use of this function should be avoided.
	*/
	private Activity()
	{
		comments = new QString("");
	}

	/**
	Complete constructor.
	If _totalDuration!=duration, then this activity is a part of a bigger (split)
	activity.
	<p>
	As a must, for non-split activities, _activityGroupId==0.
	For the split ones, it is >0
	*/
	private Activity(ref Rules r, int _id, int _activityGroupId, QStringList _teachersNames, QString _subjectName, QStringList _activityTagsNames, QStringList _studentsNames, int _duration, int _totalDuration, bool _active, bool _computeNTotalStudents, int _nTotalStudents)
	{
		comments = new QString("");

		this.id = _id;
		this.activityGroupId = _activityGroupId;
		this.teachersNames = _teachersNames;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->subjectName = _subjectName;
		this.subjectName.CopyFrom(_subjectName);
		this.activityTagsNames = _activityTagsNames;
		this.studentsNames = _studentsNames;
		this.duration = _duration;
		this.totalDuration = _totalDuration;
		this.active = _active;
		this.computeNTotalStudents = _computeNTotalStudents;

		if (_computeNTotalStudents == true)
		{
			this.nTotalStudents = 0;
			for (QStringList.Iterator it = this.studentsNames.begin(); it != this.studentsNames.end(); it++)
			{
				StudentsSet ss = r.searchStudentsSet(*it);
				this.nTotalStudents += ss.numberOfStudents;
			}
		}
		else
		{
			Debug.Assert(_nTotalStudents >= 0);
			this.nTotalStudents = _nTotalStudents;
		}
	}
		//int _parity,

	//this is used only when reading a file (Rules), so that the computed number of students is known faster
	private Activity(ref Rules r, int _id, int _activityGroupId, QStringList _teachersNames, QString _subjectName, QStringList _activityTagsNames, QStringList _studentsNames, int _duration, int _totalDuration, bool _active, bool _computeNTotalStudents, int _nTotalStudents, int _computedNumberOfStudents)
	{
		Q_UNUSED(r);
		Q_UNUSED(_nTotalStudents);

		comments = new QString("");

		this.id = _id;
		this.activityGroupId = _activityGroupId;
		this.teachersNames = _teachersNames;
//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created if it does not yet exist:
//ORIGINAL LINE: this->subjectName = _subjectName;
		this.subjectName.CopyFrom(_subjectName);
		this.activityTagsNames = _activityTagsNames;
		this.studentsNames = _studentsNames;
		this.duration = _duration;
		this.totalDuration = _totalDuration;
		this.active = _active;
		this.computeNTotalStudents = _computeNTotalStudents;

		Debug.Assert(_computeNTotalStudents);
		this.nTotalStudents = _computedNumberOfStudents;
	}
		//int _parity,

	private bool searchTeacher(QString teacherName)
	{
		return this.teachersNames.indexOf(teacherName) != -1;
	}

	/**
	Removes this teacher from the list of teachers
	*/
	private bool removeTeacher(QString teacherName)
	{
		int t = this.teachersNames.removeAll(teacherName);

		return t > 0;
	}

	/**
	Renames this teacher in the list of teachers
	*/
	private void renameTeacher(QString initialTeacherName, QString finalTeacherName)
	{
		int t = 0;
		for (QStringList.iterator it = this.teachersNames.begin(); it != this.teachersNames.end(); it++)
			if ((*it) == initialTeacherName)
			{
				*it = finalTeacherName;
				t++;
			}
		Debug.Assert(t <= 1);
	}

	private bool searchStudents(QString studentsName)
	{
		return this.studentsNames.indexOf(studentsName) != -1;
	}

	/**
	Removes this students set from the list of students
	*/
	private bool removeStudents(ref Rules r, QString studentsName, int nStudents)
	{
		Q_UNUSED(r);

		int t = this.studentsNames.removeAll(studentsName);

		if (t > 0 && this.computeNTotalStudents == true)
		{
			/*StudentsSet* s=r.searchStudentsSet(studentsName);
			assert(s!=NULL);
			this->nTotalStudents-=s->numberOfStudents;*/
			this.nTotalStudents -= nStudents;
			Debug.Assert(this.nTotalStudents >= 0);
		}

		return t > 0;
	}

	/**
	Renames this students set in the list of students and possibly modifies the number of students for the activity, if initialNumberOfStudents!=finalNumberOfStudents
	*/
	private void renameStudents(ref Rules r, QString initialStudentsName, QString finalStudentsName, int initialNumberOfStudents, int finalNumberOfStudents)
	{
		Q_UNUSED(r);

		int t = 0;
		for (QStringList.iterator it = this.studentsNames.begin(); it != this.studentsNames.end(); it++)
			if ((*it) == initialStudentsName)
			{
				/*if(this->computeNTotalStudents==true){
					StudentsSet* s=r.searchStudentsSet(initialStudentsName);
					assert(s!=NULL);
					this->nTotalStudents-=s->numberOfStudents;
				
					StudentsSet* s2=r.searchStudentsSet(finalStudentsName);
					assert(s2!=NULL);
					this->nTotalStudents+=s2->numberOfStudents;
				
					assert(this->nTotalStudents>=0);
				}*/

				*it = finalStudentsName;
				t++;

				if (this.computeNTotalStudents)
				{
					Debug.Assert(initialNumberOfStudents >= 0);
					Debug.Assert(finalNumberOfStudents >= 0);

					nTotalStudents -= initialNumberOfStudents;
					Debug.Assert(nTotalStudents >= 0);
					nTotalStudents += finalNumberOfStudents;
				}
			}
		Debug.Assert(t <= 1);
	}

	/**
	Computes the internal structure
	*/
	private void computeInternalStructure(ref Rules r)
	{
		//the internal subgroups list must be computed before entering here.

		//teachers
		//this->nTeachers=0;
		this.iTeachersList.clear();
		for (QStringList.Iterator it = this.teachersNames.begin(); it != this.teachersNames.end(); it++)
		{
			int tmp;
			for (tmp = 0; tmp < r.nInternalTeachers; tmp++)
			{
				if (r.internalTeachersList[tmp].name == (*it))
					break;
			}
			Debug.Assert(tmp < r.nInternalTeachers);
			//assert(this->nTeachers<MAX_TEACHERS_PER_ACTIVITY);
			//this->teachers[this->nTeachers++]=tmp;
			this.iTeachersList.append(tmp);
		}

		//subjects
		this.subjectIndex = r.searchSubject(this.subjectName);
		Debug.Assert(this.subjectIndex >= 0);

		//activity tags
		this.iActivityTagsSet.clear();
		foreach (QString tag, this.activityTagsNames)
		{
			Debug.Assert(tag != "");
			int index = r.searchActivityTag(tag);
			Debug.Assert(index >= 0);
			this.iActivityTagsSet.insert(index);
		}
		//this->activityTagIndex = r.searchActivityTag(this->activityTagName);

		//students
		//this->nSubgroups=0;
		this.iSubgroupsList.clear();
		for (QStringList.Iterator it = this.studentsNames.begin(); it != this.studentsNames.end(); it++)
		{
			StudentsSet ss = r.searchAugmentedStudentsSet(*it);
			Debug.Assert(ss);
			if (ss.type == GlobalMembersStudentsset.STUDENTS_SUBGROUP)
			{
				int tmp;
				/*for(tmp=0; tmp<r.nInternalSubgroups; tmp++)
					if(r.internalSubgroupsList[tmp]->name == ss->name)
						break;*/
				tmp = ((StudentsSubgroup)ss).indexInInternalSubgroupsList;
				Debug.Assert(tmp >= 0);
				Debug.Assert(tmp < r.nInternalSubgroups);
				//assert(this->nSubgroups<MAX_SUBGROUPS_PER_ACTIVITY);

				bool duplicate = false;
				if (this.iSubgroupsList.contains(tmp))
				//for(int j=0; j<this->nSubgroups; j++)
				//	if(this->subgroups[j]==tmp)
						duplicate = true;
				if (duplicate)
				{
					/*QString s;
					s=QString("Warning: activity with id=%1 contains duplicated subgroups. Automatically correcting...")
						.arg(this->id);
					cout<<qPrintable(s)<<endl;*/
				}
				else
					this.iSubgroupsList.append(tmp);
					//this->subgroups[this->nSubgroups++]=tmp;
			}
			else if (ss.type == GlobalMembersStudentsset.STUDENTS_GROUP)
			{
				StudentsGroup stg = (StudentsGroup)ss;
				for (int k = 0; k < stg.subgroupsList.size(); k++)
				{
					StudentsSubgroup sts = stg.subgroupsList[k];
					int tmp;
					/*for(tmp=0; tmp<r.nInternalSubgroups; tmp++)
						if(r.internalSubgroupsList[tmp]->name == sts->name)
							break;*/
					tmp = sts.indexInInternalSubgroupsList;
					Debug.Assert(tmp >= 0);
					Debug.Assert(tmp < r.nInternalSubgroups);
					//assert(this->nSubgroups<MAX_SUBGROUPS_PER_ACTIVITY);

					bool duplicate = false;
					if (this.iSubgroupsList.contains(tmp))
					//for(int j=0; j<this->nSubgroups; j++)
					//	if(this->subgroups[j]==tmp)
							duplicate = true;
					if (duplicate)
					{
						/*QString s;
						s=QString("Warning: activity with id=%1 contains duplicated subgroups. Automatically correcting...")
							.arg(this->id);
						cout<<qPrintable(s)<<endl;*/
					}
					else
						//this->subgroups[this->nSubgroups++]=tmp;
						this.iSubgroupsList.append(tmp);
				}
			}
			else if (ss.type == GlobalMembersStudentsset.STUDENTS_YEAR)
			{
				StudentsYear sty = (StudentsYear)ss;
				for (int k = 0; k < sty.groupsList.size(); k++)
				{
					StudentsGroup stg = sty.groupsList[k];
					for (int l = 0; l < stg.subgroupsList.size(); l++)
					{
						StudentsSubgroup sts = stg.subgroupsList[l];
						int tmp;
						/*for(tmp=0; tmp<r.nInternalSubgroups; tmp++)
							if(r.internalSubgroupsList[tmp]->name == sts->name)
								break;*/
						tmp = sts.indexInInternalSubgroupsList;
						Debug.Assert(tmp >= 0);
						Debug.Assert(tmp < r.nInternalSubgroups);
						//assert(this->nSubgroups<MAX_SUBGROUPS_PER_ACTIVITY);

						bool duplicate = false;
						if (this.iSubgroupsList.contains(tmp))
						//for(int j=0; j<this->nSubgroups; j++)
						//	if(this->subgroups[j]==tmp)
								duplicate = true;
						if (duplicate)
						{
							/*QString s;
							s=QString("Warning: activity with id=%1 contains duplicated subgroups. Automatically correcting...")
								.arg(this->id);
							cout<<qPrintable(s)<<endl;*/
						}
						else
						{
							//this->subgroups[this->nSubgroups++]=tmp;
							this.iSubgroupsList.append(tmp);
						}
					}
				}
			}
			else
				Debug.Assert(0);
		}
	}

	/**
	Returns a representation of this activity (xml format).
	*/
	private QString getXmlDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = "<Activity>\n";

		for (QStringList.Iterator it = this.teachersNames.begin(); it != this.teachersNames.end(); it++)
			s += "	<Teacher>" + GlobalMembersTimetable_defs.protect(*it) + "</Teacher>\n";

		s += "	<Subject>" + GlobalMembersTimetable_defs.protect(this.subjectName) + "</Subject>\n";

		foreach (QString tag, this.activityTagsNames) s += "	<Activity_Tag>" + GlobalMembersTimetable_defs.protect(tag) + "</Activity_Tag>\n";

		for (QStringList.Iterator it = this.studentsNames.begin(); it != this.studentsNames.end(); it++)
			s += "	<Students>" + GlobalMembersTimetable_defs.protect(*it) + "</Students>\n";

		s += "	<Duration>" + CustomFETString.number(this.duration) + "</Duration>\n";
		s += "	<Total_Duration>" + CustomFETString.number(this.totalDuration) + "</Total_Duration>\n";
		s += "	<Id>" + CustomFETString.number(this.id) + "</Id>\n";
		s += "	<Activity_Group_Id>" + CustomFETString.number(this.activityGroupId) + "</Activity_Group_Id>\n";

		if (this.computeNTotalStudents == false)
			s += "	<Number_Of_Students>" + CustomFETString.number(this.nTotalStudents) + "</Number_Of_Students>\n";

		s += "	<Active>";
		if (this.active == true)
			s += "true";
		else
			s += "false";
		s += "</Active>\n";

		s += "	<Comments>" + GlobalMembersTimetable_defs.protect(comments) + "</Comments>\n";

		s += "</Activity>";

		return s;
	}

	/**
	Returns a representation of this activity.
	*/
	private QString getDescription(ref Rules r)
	{
		const int INDENT = 4;

		Q_UNUSED(r);

		bool _indent;
		if (this.isSplit() && this.id != this.activityGroupId)
			_indent = true;
		else
			_indent = false;

		bool indentRepr;
		if (this.isSplit() && this.id == this.activityGroupId)
			indentRepr = true;
		else
			indentRepr = false;

		QString _teachers = "";
		if (teachersNames.count() == 0)
			_teachers = tr("no teachers");
		else
			_teachers = this.teachersNames.join(",");

//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: QString _subject=this->subjectName;
		QString _subject = new QString(this.subjectName);

		QString _activityTags = this.activityTagsNames.join(",");

		QString _students = "";
		if (studentsNames.count() == 0)
			_students = tr("no students");
		else
			_students = this.studentsNames.join(",");

		QString _id = new QString();
		_id = CustomFETString.number(id);

		QString _agid = "";
		if (this.isSplit())
			_agid = CustomFETString.number(this.activityGroupId);

		QString _duration = CustomFETString.number(this.duration);

		QString _totalDuration = "";
		if (this.isSplit())
			_totalDuration = CustomFETString.number(this.totalDuration);

		QString _active = new QString();
		if (this.active == true)
			_active = "";
		else
			_active = "X";

		QString _nstudents = "";
		if (this.computeNTotalStudents == false)
			_nstudents = CustomFETString.number(this.nTotalStudents);

		/////////
		QString s = "";
		if (_indent)
			s += new QString(INDENT, ' ');

		s += _id;
		s += " - ";

		if (indentRepr)
			s += new QString(INDENT, ' ');

		if (_active != "")
		{
			s += _active;
			s += " - ";
		}

		s += _duration;
		if (this.isSplit())
		{
			s += "/";
			s += _totalDuration;
		}
		s += " - ";

		s += _teachers;
		s += " - ";
		s += _subject;
		s += " - ";
		if (_activityTags != "")
		{
			s += _activityTags;
			s += " - ";
		}
		s += _students;

		if (_nstudents != "")
		{
			s += " - ";
			s += _nstudents;
		}

		if (!comments.isEmpty())
		{
			s += " - ";
			s += comments;
		}

		return s;
	}

	/**
	Returns a representation of this activity (more detailed).
	*/
	private QString getDetailedDescription(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = new QString();

		s = tr("Activity:");
		s += "\n";

		//Id, AGId
		s += tr("Id=%1").arg(CustomFETString.number(id));
		s += "\n";
		if (this.isSplit())
		{
			s += tr("Activity group id=%1").arg(CustomFETString.number(this.activityGroupId));
			s += "\n";
		}

		//Dur, TD
		s += tr("Duration=%1").arg(CustomFETString.number(this.duration));
		s += "\n";
		if (this.isSplit())
		{
			s += tr("Total duration=%1").arg(CustomFETString.number(this.totalDuration));
			s += "\n";
		}

		if (teachersNames.count() == 0)
		{
			s += tr("No teachers for this activity");
			s += "\n";
		}
		else
			for (QStringList.Iterator it = this.teachersNames.begin(); it != this.teachersNames.end(); it++)
			{
				s += tr("Teacher=%1").arg(*it);
				s += "\n";
			}

		s += tr("Subject=%1").arg(this.subjectName);
		s += "\n";
		foreach (QString tag, this.activityTagsNames)
		{
			Debug.Assert(tag != "");
			s += tr("Activity tag=%1").arg(tag);
			s += "\n";
		}

		if (studentsNames.count() == 0)
		{
			s += tr("No students sets for this activity");
			s += "\n";
		}
		else
			for (QStringList.Iterator it = this.studentsNames.begin(); it != this.studentsNames.end(); it++)
			{
				s += tr("Students=%1").arg(*it);
				s += "\n";
			}

		if (this.computeNTotalStudents == true)
		{
			/*int nStud=0;
			for(QStringList::Iterator it=this->studentsNames.begin(); it!=this->studentsNames.end(); it++){
				StudentsSet* ss=r.searchStudentsSet(*it);
				nStud += ss->numberOfStudents;
			}*/
			int nStud = this.nTotalStudents;
			s += tr("Total number of students=%1").arg(nStud);
			s += "\n";
		}
		else
		{
			s += tr("Total number of students=%1").arg(this.nTotalStudents);
			s += " (" + tr("specified", "Specified means that the total number of students was specified separately for the activity") + ")";
			s += "\n";
		}

		//Not active?
		QString activeYesNo = new QString();
		if (this.active == true)
			activeYesNo = tr("yes");
		else
			activeYesNo = tr("no");
		if (!active)
		{
			s += tr("Active=%1", "Represents a boolean value, if activity is active or not, %1 is yes or no").arg(activeYesNo);
			s += "\n";
		}

		//Has comments?
		if (!comments.isEmpty())
		{
			s += tr("Comments=%1").arg(comments);
			s += "\n";
		}

		return s;
	}

	/**
	Returns a representation of this activity (detailed),
	together with the constraints related to this activity.
	*/
	private QString getDetailedDescriptionWithConstraints(ref Rules r)
	{
		QString s = this.getDetailedDescription(ref r);

		s += "--------------------------------------------------\n";
		s += tr("Time constraints directly related to this activity:");
		s += "\n";
		for (int i = 0; i < r.timeConstraintsList.size(); i++)
		{
			TimeConstraint c = r.timeConstraintsList[i];
			if (c.isRelatedToActivity(r, this))
			{
				s += "\n";
				s += c.getDetailedDescription(r);
			}
		}

		s += "--------------------------------------------------\n";
		s += tr("Space constraints directly related to this activity:");
		s += "\n";
		for (int i = 0; i < r.spaceConstraintsList.size(); i++)
		{
			SpaceConstraint c = r.spaceConstraintsList[i];
			if (c.isRelatedToActivity(this))
			{
				s += "\n";
				s += c.getDetailedDescription(r);
			}
		}
		s += "--------------------------------------------------\n";

		return s;
	}

	/**
	Returns true if this activity is split into more lessons per week.
	*/
	private bool isSplit()
	{
		return this.totalDuration != this.duration;
	}

	private bool representsComponentNumber(int index)
	{
		if (this.activityGroupId == 0)
			return index == 1;
			//return false;

		//assert(this->activityGroupId>0);

		return index == (this.id - this.activityGroupId + 1);
	}
}
