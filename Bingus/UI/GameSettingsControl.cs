using BingusCommon;

namespace Bingus.UI
{
    public partial class GameSettingsControl : UserControl
    {
        public GameSettingsControl()
        {
            InitializeComponent();
            fillBoardSizeList();
            _randomSeedUpDown.ValueChanged += (o, e) => SeedChanged?.Invoke();
        }

        public int CurrentSeed => Convert.ToInt32(_randomSeedUpDown.Value);

        private int BoardSize
        {
            get { return _boardSizeComboBox.SelectedIndex + 3; }
            set { _boardSizeComboBox.SelectedIndex = value - 3; }
        }

        public Action? SeedChanged;

        public BingoGameSettings Settings
        {
            get
            {
                return new BingoGameSettings(
                    BoardSize,
                    _lockoutCheckBox.Checked,
                    false,
                    new HashSet<EldenRingClasses>(),
                    0,//Number of classes to pick
                    Convert.ToInt32(_maxCategoryUpDown.Value),//Max number of squares in the same category
                    Convert.ToInt32(_randomSeedUpDown.Value), //Random seed
                    Convert.ToInt32(_preparationTimeUpDown.Value), //Preparation time in seconds
                    Convert.ToInt32(_bonusPointsUpDown.Value) //Bonus points for a bingo line
                );
            }
            set
            {
                BoardSize = value.BoardSize;
                _lockoutCheckBox.Checked = value.Lockout;
                _maxCategoryUpDown.Value = value.CategoryLimit;
                _randomSeedUpDown.Value = value.RandomSeed;
                _preparationTimeUpDown.Value = value.PreparationTime;
                _bonusPointsUpDown.Value = value.PointsPerBingoLine;
            }
        }

        private void fillBoardSizeList()
        {
            for(int i = BingoConstants.BoardSizeMin; i <= BingoConstants.BoardSizeMax; ++i)
            {
                _boardSizeComboBox.Items.Add($"{i}x{i}");
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _randomSeedUpDown.Value = 0;
        }
    }
}