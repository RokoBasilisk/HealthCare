export default function HeaderItem({ params }: {
    params: {
        displayText: string,
        displayIcon: string,
        href: string
    }
}) {
    return (
        <li><a className="dropdown-item" href={params.href}>{params.displayText}</a></li>
    )
}