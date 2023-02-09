using App.UI;
using FluentAssertions;

namespace App.Ui.Test
{
    public class SnackMachineTextualRendererSpecs
    {
        [Fact]
        public void Render_prints_all_possible_coins_and_notes_to_insert()
        {
            var render = new SnackMachineTextualRenderer(new SnackMachineViewModel());

            var result = render.Render().ToString();

            result.Should()
                .Contain("Insert ¢1")
                .And.Contain("Insert ¢10")
                .And.Contain("Insert ¢25")
                .And.Contain("Insert $1")
                .And.Contain("Insert $5")
                .And.Contain("Insert $20");
        }

        [Fact]
        public void Render_prints_buy_snack_and_money_inserted()
        {
            var render = new SnackMachineTextualRenderer(new SnackMachineViewModel());

            var result = render.Render().ToString();

            result.Should()
                .Contain("Buy Snack")
                .And.Contain("Money Inserted");
        }

        [Fact]
        public void Render_prints_all_coins_and_notes_inside()
        {
            var render = new SnackMachineTextualRenderer(new SnackMachineViewModel());

            var result = render.Render().ToString();

            result.Should()
                .MatchRegex(@"\dx ¢1")
                .And.MatchRegex(@"\dx ¢10")
                .And.MatchRegex(@"\dx ¢25")
                .And.MatchRegex(@"\dx \$1")
                .And.MatchRegex(@"\dx \$5")
                .And.MatchRegex(@"\dx \$20");
        }







    }
}