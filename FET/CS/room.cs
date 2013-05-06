using System.Diagnostics;

public static class GlobalMembersRoom
{

	public static int roomsAscending(Room r1, Room r2)
	{
		return r1.name < r2.name;
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
//class Room;
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class Rules;


/**
This class represents a room

@author Liviu Lalescu
*/
public class Room //classroom :-)
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(Room) public: QString name;
	private int capacity;

	/**
	If empty string, it is ignored
	*/
	private QString building = new QString();

	/**
	Internal. If -1, it is ignored
	*/
	private int buildingIndex;

	private Room()
	{
		this.capacity = GlobalMembersTimetable_defs.MAX_ROOM_CAPACITY;
		this.building = "";
	}
	public void Dispose()
	{
	}

	private void computeInternalStructure(ref Rules r)
	{
		if (building == "")
			buildingIndex = -1;
		else
		{
			buildingIndex = r.searchBuilding(building);
			Debug.Assert(buildingIndex >= 0 && buildingIndex < r.nInternalBuildings);
		}
	}

	private QString getXmlDescription()
	{
		QString s = "<Room>\n";
		s += "	<Name>" + GlobalMembersTimetable_defs.protect(this.name) + "</Name>\n";
		s += "	<Building>" + GlobalMembersTimetable_defs.protect(this.building) + "</Building>\n";
		//s+="	<Type>"+protect(this->type)+"</Type>\n";
		s += "	<Capacity>" + CustomFETString.number(this.capacity) + "</Capacity>\n";

		/*for(QStringList::Iterator it=this->equipments.begin(); it!=this->equipments.end(); it++)
			s+="	<Equipment>"+protect(*it)+"</Equipment>\n";*/

		s += "</Room>\n";

		return s;
	}
	private QString getDescription()
	{
		QString s = tr("N:%1", "Name of room").arg(this.name);
		s += ", ";

		if (this.building != "")
		{
			s += tr("B:%1", "Building").arg(this.building);
			s += ", ";
		}
		/*s+=tr("T:");
		s+=this->type;
		s+=",";*/
		s += tr("C:%1", "Capacity").arg(CustomFETString.number(this.capacity));
		//s+=",";

		/*for(QStringList::Iterator it=this->equipments.begin(); it!=this->equipments.end(); it++)
			s+="E:"+(*it)+", ";*/

		return s;
	}
	private QString getDetailedDescription()
	{
		QString s = tr("Room");
		s += "\n";
		s += tr("Name=%1", "The name of the room").arg(this.name);
		s += "\n";

		if (this.building != "")
		{
			s += tr("Building=%1").arg(this.building);
			s += "\n";
		}
		/*s+=tr("Type=");
		s+=this->type;
		s+="\n";*/
		s += tr("Capacity=%1").arg(CustomFETString.number(this.capacity));
		s += "\n";

		/*for(QStringList::Iterator it=this->equipments.begin(); it!=this->equipments.end(); it++)
			s+="Equipment="+(*it)+"\n";*/

		return s;
	}
	private QString getDetailedDescriptionWithConstraints(ref Rules r)
	{
		QString s = this.getDetailedDescription();

		s += "--------------------------------------------------\n";
		s += tr("Space constraints directly related to this room:");
		s += "\n";
		for (int i = 0; i < r.spaceConstraintsList.size(); i++)
		{
			SpaceConstraint c = r.spaceConstraintsList[i];
			if (c.isRelatedToRoom(this))
			{
				s += "\n";
				s += c.getDetailedDescription(r);
			}
		}
		s += "--------------------------------------------------\n";

		return s;
	}
}
