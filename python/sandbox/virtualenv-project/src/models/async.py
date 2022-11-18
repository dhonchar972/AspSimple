import asyncio
import socket
from httpx import AsyncClient


def probe(domain: str) -> tuple[str, bool]:  # no async
    loop = asyncio.get_running_loop()
    try:
        loop.getaddrinfo(domain, None)  # no await
    except socket.gaierror:
        return (domain, False)
    return (domain, True)


async def probe_async(domain: str) -> tuple[str, bool]:
    loop = asyncio.get_running_loop()
    try:
        await loop.getaddrinfo(domain, None)
    except socket.gaierror:
        return (domain, False)
    return (domain, True)


def download_many(cc_list: list[str]) -> int:
    return asyncio.run(supervisor(cc_list))


async def supervisor(cc_list: list[str]) -> int:
    async with AsyncClient() as client:
        to_do = [download_one(client, cc)
                 for cc in sorted(cc_list)]
        res = await asyncio.gather(*to_do)

    return len(res)


if __name__ == '__main__':
