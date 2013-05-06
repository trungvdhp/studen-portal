using System;

public static class GlobalMembersMessageboxes
{

	#if FET_COMMAND_LINE
	public static void commandLineMessage(QWidget parent, QString title, QString message)
	{
		Q_UNUSED(parent);

		Console.Write(qPrintable(FetCommandLine.tr("Title: %1").arg(title)));
		Console.Write("\n");
		Console.Write(qPrintable(FetCommandLine.tr("Message: %1").arg(message)));
		Console.Write("\n");
		Console.Write("\n");
	}
	public static int commandLineMessage(QWidget parent, QString title, QString message, QString button0Text, QString button1Text, QString button2Text, int defaultButton, int escapeButton)
	{
		Q_UNUSED(parent);

		Console.Write(qPrintable(FetCommandLine.tr("Title: %1").arg(title)));
		Console.Write("\n");
		Console.Write(qPrintable(FetCommandLine.tr("Message: %1").arg(message)));
		Console.Write("\n");

		if (button0Text != new QString())
		{
			Console.Write(qPrintable(FetCommandLine.tr("Button 0 text: %1").arg(button0Text)));
			Console.Write("\n");
		}
		if (button1Text != new QString())
		{
			Console.Write(qPrintable(FetCommandLine.tr("Button 1 text: %1").arg(button1Text)));
			Console.Write("\n");
		}
		if (button2Text != new QString())
		{
			Console.Write(qPrintable(FetCommandLine.tr("Button 2 text: %1").arg(button2Text)));
			Console.Write("\n");
		}

		Console.Write(qPrintable(FetCommandLine.tr("Default button: %1").arg(defaultButton)));
		Console.Write("\n");
		Console.Write(qPrintable(FetCommandLine.tr("Escape button: %1").arg(escapeButton)));
		Console.Write("\n");

		Console.Write(qPrintable(FetCommandLine.tr("Pressing default button %1").arg(defaultButton)));
		Console.Write("\n");

		Console.Write("\n");

		return defaultButton;
	}
	#endif
}

//
//
// Description: This file is part of FET
//
//
// Author: Liviu Lalescu <http://lalescu.ro/liviu/>
// Copyright (C) 2013 Liviu Lalescu <http://lalescu.ro/liviu/>
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
// Author: Liviu Lalescu <http://lalescu.ro/liviu/>
// Copyright (C) 2013 Liviu Lalescu <http://lalescu.ro/liviu/>
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



#if ! FET_COMMAND_LINE
#else
public class QWidget
{
}
#endif

#if FET_COMMAND_LINE
public class FetCommandLine: QObject
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_OBJECT
}
#else
//Just to disable a Qt moc warning
public class DummyFetGuiClass: QObject
{
//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	Q_OBJECT
}

//Rules

public class RulesConstraintIgnored
{

	//Rules

	public static int mediumConfirmation(QWidget parent, QString title, QString message, QString button0Text, QString button1Text, QString button2Text, int defaultButton, int escapeButton)
	{
		return LongTextMessageBox.mediumConfirmation(parent, title, message, button0Text, button1Text, button2Text, defaultButton, escapeButton);
	}
}

public class RulesImpossible
{
	public static void warning(QWidget parent, QString title, QString message)
	{
		LongTextMessageBox.mediumInformation(parent, title, message);
	}
}

public class RulesReconcilableMessage
{
	public static void warning(QWidget parent, QString title, QString message)
	{
		LongTextMessageBox.mediumInformation(parent, title, message);
	}

	public static int warning(QWidget parent, QString title, QString message, QString button0Text, QString button1Text, QString button2Text, int defaultButton, int escapeButton)
	{
		return LongTextMessageBox.mediumConfirmation(parent, title, message, button0Text, button1Text, button2Text, defaultButton, escapeButton);
	}

	public static int mediumConfirmation(QWidget parent, QString title, QString message, QString button0Text, QString button1Text, QString button2Text, int defaultButton, int escapeButton)
	{
		return LongTextMessageBox.mediumConfirmation(parent, title, message, button0Text, button1Text, button2Text, defaultButton, escapeButton);
	}

	public static void information(QWidget parent, QString title, QString message)
	{
		LongTextMessageBox.mediumInformation(parent, title, message);
	}

	public static int information(QWidget parent, QString title, QString message, QString button0Text, QString button1Text, QString button2Text, int defaultButton, int escapeButton)
	{
		return LongTextMessageBox.mediumConfirmation(parent, title, message, button0Text, button1Text, button2Text, defaultButton, escapeButton);
	}
}

public class RulesIrreconcilableMessage
{
	public static void warning(QWidget parent, QString title, QString message)
	{
		LongTextMessageBox.mediumInformation(parent, title, message);
	}
}

public class RulesUsualInformation
{
	public static void information(QWidget parent, QString title, QString message)
	{
		LongTextMessageBox.mediumInformation(parent, title, message);
	}
}

public class RulesReadingWrongConstraint
{
	public static void warning(QWidget parent, QString title, QString message)
	{
		LongTextMessageBox.mediumInformation(parent, title, message);
	}
}

public class IrreconcilableCriticalMessage
{
	public static void critical(QWidget parent, QString title, QString message)
	{
#if ! FET_COMMAND_LINE
		QMessageBox.critical(parent, title, message);
#else
		GlobalMembersMessageboxes.commandLineMessage(parent, title, message);
#endif
	}
}

//GeneratePre

public class GeneratePreReconcilableMessage
{

	//GeneratePre

	public static int mediumConfirmation(QWidget parent, QString title, QString message, QString button0Text, QString button1Text, QString button2Text, int defaultButton, int escapeButton)
	{
		return LongTextMessageBox.mediumConfirmation(parent, title, message, button0Text, button1Text, button2Text, defaultButton, escapeButton);
	}
}

public class GeneratePreIrreconcilableMessage
{
	public static void information(QWidget parent, QString title, QString message)
	{
		LongTextMessageBox.mediumInformation(parent, title, message);
	}

	public static int information(QWidget parent, QString title, QString message, QString button0Text, QString button1Text, QString button2Text, int defaultButton, int escapeButton)
	{
		return LongTextMessageBox.mediumConfirmation(parent, title, message, button0Text, button1Text, button2Text, defaultButton, escapeButton);
	}

	public static void mediumInformation(QWidget parent, QString title, QString message)
	{
		LongTextMessageBox.mediumInformation(parent, title, message);
	}

	public static int mediumConfirmation(QWidget parent, QString title, QString message, QString button0Text, QString button1Text, QString button2Text, int defaultButton, int escapeButton)
	{
		return LongTextMessageBox.mediumConfirmation(parent, title, message, button0Text, button1Text, button2Text, defaultButton, escapeButton);
	}
}

//TimetableExport

public class TimetableExportMessage
{

	//TimetableExport

	public static int information(QWidget parent, QString title, QString message, QString button0Text, QString button1Text, QString button2Text, int defaultButton, int escapeButton)
	{
		return LongTextMessageBox.mediumConfirmation(parent, title, message, button0Text, button1Text, button2Text, defaultButton, escapeButton);
	}

	public static int warning(QWidget parent, QString title, QString message, QString button0Text, QString button1Text, QString button2Text, int defaultButton, int escapeButton)
	{
		return LongTextMessageBox.mediumConfirmation(parent, title, message, button0Text, button1Text, button2Text, defaultButton, escapeButton);
	}
}

//TimeConstraint

public class TimeConstraintIrreconcilableMessage
{

	//TimeConstraint

	public static void information(QWidget parent, QString title, QString message)
	{
		LongTextMessageBox.mediumInformation(parent, title, message);
	}
	public static void warning(QWidget parent, QString title, QString message)
	{
		LongTextMessageBox.mediumInformation(parent, title, message);
	}
}

//SpaceConstraint

public class SpaceConstraintIrreconcilableMessage
{

	//SpaceConstraint

	public static void information(QWidget parent, QString title, QString message)
	{
		LongTextMessageBox.mediumInformation(parent, title, message);
	}
	public static void warning(QWidget parent, QString title, QString message)
	{
		LongTextMessageBox.mediumInformation(parent, title, message);
	}
}

//Fet

public class FetMessage
{

	//Fet

	public static void information(QWidget parent, QString title, QString message)
	{
		LongTextMessageBox.mediumInformation(parent, title, message);
	}
	public static void warning(QWidget parent, QString title, QString message)
	{
		LongTextMessageBox.mediumInformation(parent, title, message);
	}
}

//QProgressDialog

#if FET_COMMAND_LINE

public class QProgressDialog
{
#if FET_COMMAND_LINE
	public QProgressDialog(QWidget parent)
	{
		Q_UNUSED(parent);
	}
	public void setWindowTitle(QString title)
	{
		Console.Write(qPrintable(FetCommandLine.tr("Progress title: %1").arg(title)));
		Console.Write("\n");
	}
	public void setLabelText(QString label)
	{
		Console.Write(qPrintable(FetCommandLine.tr("Progress label: %1").arg(label)));
		Console.Write("\n");
	}
	public void setRange(int a, int b)
	{
		Console.Write(qPrintable(FetCommandLine.tr("Progress range: %1..%2").arg(a).arg(b)));
		Console.Write("\n");
	}
	public void setModal(bool m)
	{
		if (m)
		{
			Console.Write(qPrintable(FetCommandLine.tr("Progress setModal(true)")));
			Console.Write("\n");
		}
		else
		{
			Console.Write(qPrintable(FetCommandLine.tr("Progress setModal(false)")));
			Console.Write("\n");
		}
	}
	public void setValue(int v)
	{
		Q_UNUSED(v);
		//cout<<qPrintable(FetCommandLine::tr("Progress value: %1").arg(v))<<endl;
	}
	public bool wasCanceled()
	{
		return false;
	}
}

#endif



#if ! FET_COMMAND_LINE
#else
#endif

/*
File longtextmessagebox.h
*/

/***************************************************************************
                          longtextmessagebox.cpp  -  description
                             -------------------
    begin                : 27 June 2009
    copyright            : (C) 2009 by Lalescu Liviu
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
//class QString;
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class QWidget;


public class LongTextMessageBox: QObject
{
	Q_OBJECT public: static int confirmation(QWidget * parent, const QString & title, const QString & text, const QString & button0Text, const QString & button1Text, const QString & button2Text, int defaultButton, int escapeButton);

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//	static int largeConfirmation(QWidget parent, QString title, QString text, QString button0Text, QString button1Text, QString button2Text, int defaultButton, int escapeButton);

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//	static int mediumConfirmation(QWidget parent, QString title, QString text, QString button0Text, QString button1Text, QString button2Text, int defaultButton, int escapeButton);

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//	static void information(QWidget parent, QString title, QString text);

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//	static void largeInformation(QWidget parent, QString title, QString text);

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//	static void mediumInformation(QWidget parent, QString title, QString text);

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//	static int confirmationWithDimensions(QWidget parent, QString title, QString text, QString button0Text, QString button1Text, QString button2Text, int defaultButton, int escapeButton, int MINW, int MAXW, int MINH, int MAXH);

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//	static void informationWithDimensions(QWidget parent, QString title, QString text, int MINW, int MAXW, int MINH, int MAXH);
}



#endif

//QProgressDialog


#endif
