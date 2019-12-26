

namespace JX_StandardLibrary_WMS
{
    /// <summary>
    /// 项目相关内容
    /// </summary>
    public class JXPROJECTABOUT
    {
        /// <summary>
        /// 项目名称(中文全称)，全项目唯一。
        /// </summary>
        public static string NAME_Chinese = "佳轩仓储管理系统";

        /// <summary>
        /// 项目名称(中文简称)，全项目唯一。
        /// </summary>
        public static string NAME_Chinese_Simple = "仓储系统";

        /// <summary>
        /// 项目名称（英文全称），全项目唯一。
        /// </summary>
        public static string NAME_English = "JiaXuanWarehouseManagementSystem";

        /// <summary>
        /// 项目名称（英文简称），全项目唯一。
        /// </summary>
        public static string NAME_English_Simple = "JiaXuanWMS";

        /// <summary>
        /// 初始化项目名称信息
        /// </summary>
        /// <param name="中文全称"></param>
        /// <param name="中文简称"></param>
        /// <param name="英文全称"></param>
        /// <param name="英文简称"></param>
        public static void InitPro(string 中文全称,string 中文简称,string 英文全称,string 英文简称)
        {
            NAME_Chinese = 中文全称;
            NAME_Chinese_Simple = 中文简称;
            NAME_English = 英文全称;
            NAME_English_Simple = 英文简称;
        }

    }
}
