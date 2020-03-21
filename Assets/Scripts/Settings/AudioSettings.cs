public static class AudioSettings
{
    private static bool music;
    private static bool sound;

    public static bool Music
    {
        get { return music; }
        set { music = value; }
    }

    public static bool Sound
    {
        get { return sound; }
        set { sound = value; }
    }
}
