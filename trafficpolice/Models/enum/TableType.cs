﻿namespace trafficpolice.Models
{
    public enum TableType
    {
        unknown,
        day = 1,//日报表
        week = 7,//周报表
    }
    public enum datastatus
    {
        submit,//0-提交到网站
        draft,//1-草稿，
        localword,//，2-保存word文档到本地，
        undeterminied//3-待定
    }
}
