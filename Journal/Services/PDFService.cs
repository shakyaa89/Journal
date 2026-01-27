// Journal/Services/PDFService.cs
using HTMLQuestPDF.Extensions;
using Journal.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF;
using QuestPDF.Infrastructure;
using System;

namespace Journal.Services
{
    public class PDFService : IPDFService
    {
        public byte[] GeneratePdf(JournalEntry entry)
        {
            ArgumentNullException.ThrowIfNull(entry);

            var title = string.IsNullOrWhiteSpace(entry.Title)
                ? "Journal Entry"
                : entry.Title;

            var dateText = entry.CreatedAt.ToLocalTime().ToString("dddd, MMM dd yyyy");
            var timeText = entry.CreatedAt.ToLocalTime().ToString("hh:mm tt");

            var primaryMood = string.IsNullOrWhiteSpace(entry.Mood) ? "N/A" : entry.Mood;

            var secondaryMoods = string.Join(
                ", ",
                new[]
                {
                    entry.SecondaryMood1,
                    entry.SecondaryMood2
                }.Where(m => !string.IsNullOrWhiteSpace(m))
            );

            if (string.IsNullOrWhiteSpace(secondaryMoods))
                secondaryMoods = "None";

            var tagsText = (entry.Tags != null && entry.Tags.Count > 0)
                ? string.Join(", ", entry.Tags)
                : "None";

            var htmlContent = entry.Content ?? string.Empty;

            var pdfBytes = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(60);

                    page.Content().Column(col =>
                    {
                        // Title
                        col.Item().Text(title)
                            .FontSize(20)
                            .Bold();

                        col.Item().Text($"{dateText}  •  {timeText}")
                            .FontSize(10)
                            .Italic()
                            .FontColor("#666666");

                        col.Item().Text(text =>
                        {
                            text.DefaultTextStyle(style => style.FontSize(11));

                            text.Span("Primary mood: ").Bold();
                            text.Span(primaryMood);
                        });

                        col.Item().Text(text =>
                        {
                            text.DefaultTextStyle(style => style.FontSize(11));

                            text.Span("Also feeling: ").Bold();
                            text.Span(secondaryMoods);
                        });

                        col.Item().Text(text =>
                        {
                            text.DefaultTextStyle(style => style.FontSize(11));

                            text.Span("Tags: ").Bold();
                            text.Span(tagsText);
                        });

                        col.Item().PaddingTop(10).LineHorizontal(1);

                        // HTML content
                        col.Item().PaddingTop(10).HTML(handler =>
                        {
                            handler.SetHtml(htmlContent);
                        });
                    });
                });
            }).GeneratePdf();

            return pdfBytes;
        }

        public byte[] GeneratePdf(IEnumerable<JournalEntry> entries)
        {
            ArgumentNullException.ThrowIfNull(entries);

            var list = entries
                .OrderByDescending(e => e.CreatedAt)
                .ToList();

            if (!list.Any())
                throw new InvalidOperationException("No journal entries to export.");

            return Document.Create(container =>
            {
                foreach (var entry in list)
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(60);

                        page.Content().Column(col =>
                        {
                            var title = string.IsNullOrWhiteSpace(entry.Title)
                                ? "Journal Entry"
                                : entry.Title;

                            var dateText = entry.CreatedAt.ToLocalTime().ToString("dddd, MMM dd yyyy");
                            var timeText = entry.CreatedAt.ToLocalTime().ToString("hh:mm tt");

                            var primaryMood = string.IsNullOrWhiteSpace(entry.Mood) ? "N/A" : entry.Mood;

                            var secondaryMoods = string.Join(
                                ", ",
                                new[]
                                {
                            entry.SecondaryMood1,
                            entry.SecondaryMood2
                                }.Where(m => !string.IsNullOrWhiteSpace(m))
                            );

                            if (string.IsNullOrWhiteSpace(secondaryMoods))
                                secondaryMoods = "None";

                            var tagsText = (entry.Tags != null && entry.Tags.Count > 0)
                                ? string.Join(", ", entry.Tags)
                                : "None";

                            var htmlContent = entry.Content ?? string.Empty;

                            col.Item().Text(title)
                                .FontSize(20)
                                .Bold();

                            col.Item().Text($"{dateText}  •  {timeText}")
                                .FontSize(10)
                                .Italic()
                                .FontColor("#666666");

                            col.Item().Text(text =>
                            {
                                text.DefaultTextStyle(style => style.FontSize(11));
                                text.Span("Primary mood: ").Bold();
                                text.Span(primaryMood);
                            });

                            col.Item().Text(text =>
                            {
                                text.DefaultTextStyle(style => style.FontSize(11));
                                text.Span("Also feeling: ").Bold();
                                text.Span(secondaryMoods);
                            });

                            col.Item().Text(text =>
                            {
                                text.DefaultTextStyle(style => style.FontSize(11));
                                text.Span("Tags: ").Bold();
                                text.Span(tagsText);
                            });

                            col.Item().PaddingTop(10).LineHorizontal(1);

                            col.Item().PaddingTop(10).HTML(handler =>
                            {
                                handler.SetHtml(htmlContent);
                            });
                        });
                    });
                }
            }).GeneratePdf();
        }
    }
}
