-- include subprojects
includes("lib/commonlibsse-ng")

-- set project
set_project("SkyrimSharp")
set_version("1.0.0")
set_license("GPL-3.0")
set_languages("c++23")
set_warnings("allextra")

-- add common rules
add_rules("mode.debug", "mode.releasedbg")
add_rules("plugin.vsxmake.autoupdate")

-- targets
target("SkyrimSharp")
    -- add dependencies to target
    add_deps("commonlibsse-ng")

    -- add commonlibsse-ng plugin
    add_rules("commonlibsse-ng.plugin", {
        name = "SkyrimSharp",
        author = "mantodea",
        description = ""
    })

    -- add src files
    add_files("src/**.cpp")
    add_headerfiles("src/**.h")
    add_headerfiles("src/runtime/**.h")
    add_headerfiles("include/**.hpp")
    add_includedirs("src")
    set_pcxxheader("src/pch.h")

    add_linkdirs("lib/net-runtime")
    add_links("nethost")
