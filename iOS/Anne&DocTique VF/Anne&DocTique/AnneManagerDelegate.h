//
//  AnneManagerDelegate.h
//  Anne&DocTique
//
//  Created by Kapi on 01/03/2014.
//  Copyright (c) 2014 Lionel. All rights reserved.
//

#import <Foundation/Foundation.h>

@protocol AnneManagerDelegate
- (void)didReceiveGroup:(NSArray *)groups;
- (void)fetchingCountryFailedWithError:(NSError *)error;
@end
