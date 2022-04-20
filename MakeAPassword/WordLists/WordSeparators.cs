namespace MakeAPassword;

public static class WordSeparators
{
    // Brackets MUST be two characters long or things will crash
    // Put sets in multiple times for higher chance to pick them
    public static readonly List<string> Brackets = new List<string>()
    {
        "()",
        "()",
        "()",
        "()",
        "{}",
        "[]",
        "<>",
        "--",
        "\\\\",
        "//",
        "||"
    };

    public static readonly List<string> None = new List<string>();

    public static readonly List<string> Spaces = new List<string>() { " " };

    public static readonly List<string> JustSpecialChars = new List<string>()
    {
        "#",
        "&",
        ";",
        "!",
        ":",
        "_",
        "-",
        "--",
        "!!",
        "?",
        "?!",
        "*",
        "#",
        "+",
        ".",
        ","
     };

    public static readonly List<string> Complex = new List<string>()
    {
        "#",
        "&",
        ";",
        "!",
        ":",
        "_",
        "-",
        "--",
        "!!",
        "?",
        "?!",
        "*",
        "#",
        "+",
        ".",
        ",",
        ",SoI",
        ",And",
        ",The",
        ",WithThe",
        ",With",
        ",Without",
        ",But",
        ",ButWith",
        ",ButAlso",
        ",InsteadOf",
        ",Then",
        ",ThenA",
        ",AlongA",
        ",Because",
        ",AlongWith",
        ",AlongThe",
        ",OverThe",
        ",OverA",
        ",BecauseOf",
        ",BecauseOfThe",
        "More-Than",
        "Less-Than",
        ",Also",
        ",UntilThe",
        ",Plus",
        ",At",
        ",AtThe",
        ",AlongSideA",
        ",BesideThe",
        ",SaidThe",
        ",AsLongAs",
        ",AsSoonAs",
        ",OnlyIf",
        ",IfOnly",
        ",NowThat",
        ",SoThat",
        ",AsIf",
        ",AsThough",
        ",RatherThan",
        ",Whenever",
        ",Until",
        ",While",
        "YouSay?",
        "(and)",
        "(or)",
        "(with)",
        "(but)",
        "(not)",
        "(without)"
     };

}