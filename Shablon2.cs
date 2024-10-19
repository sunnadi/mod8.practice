using System;
public abstract class ReportGenerator
{
    public void GenerateReport()
    {
        GatherData();
        ProcessData();
        FormatData();
        SaveReport();
        SendReport();
    }

    protected abstract void GatherData();
    protected abstract void ProcessData();
    protected abstract void FormatData();
    protected abstract void SaveReport();

    protected virtual void SendReport()
    {
        Console.WriteLine("Отчет отправлен по электронной почте.");
    }
}

public class PdfReport : ReportGenerator
{
    protected override void GatherData()
    {
        Console.WriteLine("Сбор данных для PDF отчета.");
    }

    protected override void ProcessData()
    {
        Console.WriteLine("Обработка данных для PDF отчета.");
    }

    protected override void FormatData()
    {
        Console.WriteLine("Форматирование данных в PDF формате.");
    }

    protected override void SaveReport()
    {
        Console.WriteLine("Сохранение PDF отчета.");
    }
}

public class ExcelReport : ReportGenerator
{
    protected override void GatherData()
    {
        Console.WriteLine("Сбор данных для Excel отчета.");
    }

    protected override void ProcessData()
    {
        Console.WriteLine("Обработка данных для Excel отчета.");
    }

    protected override void FormatData()
    {
        Console.WriteLine("Форматирование данных в Excel формате.");
    }

    protected override void SaveReport()
    {
        Console.WriteLine("Сохранение Excel отчета.");
    }

    protected override void SendReport()
    {
        Console.WriteLine("Excel отчет отправлен по электронной почте.");
    }
}

public class HtmlReport : ReportGenerator
{
    protected override void GatherData()
    {
        Console.WriteLine("Сбор данных для HTML отчета.");
    }

    protected override void ProcessData()
    {
        Console.WriteLine("Обработка данных для HTML отчета.");
    }

    protected override void FormatData()
    {
        Console.WriteLine("Форматирование данных в HTML формате.");
    }

    protected override void SaveReport()
    {
        Console.WriteLine("Сохранение HTML отчета.");
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Генерация PDF отчета:");
        ReportGenerator pdfReport = new PdfReport();
        pdfReport.GenerateReport();

        Console.WriteLine("\nГенерация Excel отчета:");
        ReportGenerator excelReport = new ExcelReport();
        excelReport.GenerateReport();

        Console.WriteLine("\nГенерация HTML отчета:");
        ReportGenerator htmlReport = new HtmlReport();
        htmlReport.GenerateReport();
    }
}

