public static class GlobalMembersBuilding
{

	public static int buildingsAscending(Building b1, Building b2)
	{
		return b1.name < b2.name;
	}
}

//
//
// Description: This file is part of FET
//
//
// Author: Liviu Lalescu <Please see http://lalescu.ro/liviu/ for details about contacting Liviu Lalescu (in particular, you can find here the e-mail address)>
// Copyright (C) 2005 Liviu Lalescu <http://lalescu.ro/liviu/>
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
// Copyright (C) 2005 Liviu Lalescu <http://lalescu.ro/liviu/>
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
//class Building;
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class Rules;


/**
This class represents a building

@author Liviu Lalescu
*/
public class Building
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_DECLARE_TR_FUNCTIONS(Building) public: QString name;

	private Building()
	{
	}
	public void Dispose()
	{
	}

	private void computeInternalStructure(ref Rules r)
	{
		Q_UNUSED(r);
	}

	private QString getXmlDescription()
	{
		QString s = "<Building>\n";
		s += "	<Name>" + GlobalMembersTimetable_defs.protect(this.name) + "</Name>\n";
		s += "</Building>\n";

		return s;
	}
	//QString getDescription();

	/*
	QString Building::getDescription()
	{
		QString s=tr("N:%1", "Name of the building").arg(this->name);
	
		return s;
	}*/

	private QString getDetailedDescription()
	{
		QString s = tr("Building");
		s += "\n";
		s += tr("Name=%1", "The name of the building").arg(this.name);
		s += "\n";

		return s;
	}
	private QString getDetailedDescriptionWithConstraints(ref Rules r)
	{
		Q_UNUSED(r);

		QString s = this.getDetailedDescription();

		/*s+="--------------------------------------------------\n";
		s+=tr("Space constraints directly related to this building:");
		s+="\n";
		for(int i=0; i<r.spaceConstraintsList.size(); i++){
			SpaceConstraint* c=r.spaceConstraintsList[i];
			if(c->isRelatedToBuilding(this)){
				s+="\n";
				s+=c->getDetailedDescription(r);
			}
		}
		s+="--------------------------------------------------\n";*/

		return s;
	}
}
