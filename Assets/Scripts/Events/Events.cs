public static class Events
{
    public static SimpleEvent<bool> isAutoSave = new SimpleEvent<bool>();
    public static SimpleEvent Save = new SimpleEvent();

    public static SimpleEvent<string> SetPath = new SimpleEvent<string>();
}
